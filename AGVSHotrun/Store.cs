﻿using AGVSHotrun.HotRun;
using AGVSHotrun.Models;
using AGVSHotrun.VirtualAGVSystem;
using AGVSystemCommonNet6.MAP;
using AGVSystemCommonNet6.Vehicle_Control.VCSDatabase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSHotrun
{
    public enum FIELD_NAME
    {
        UMTC_3F_AOI,
        UMTC_3F_YELLOW,
        UMTC_3F_MEC,
    }
    public static class Store
    {
        const string CONFIG_FILE_NAME = "SystemConfigs.json";
        internal static event EventHandler OnScriptCreated;
        internal static event EventHandler OnAGVLocUpdate;

        internal static event EventHandler<List<ExecutingTask>> OnExecutingTaskUpdate;
        internal static event EventHandler<List<AGVInfo>> OnAGVInfosUpdate;

        internal static Dictionary<AGVInfo, MapPoint> AGVlocStore = new Dictionary<AGVInfo, MapPoint>();
        internal static List<ExecutingTask> executingTasks = new List<ExecutingTask>();
        internal static List<AGVInfo> agv_infos = new List<AGVInfo>();

        public static clsSysConfigs SysConfigs = new clsSysConfigs();
        public static Map MapData { get; set; }

        public static List<clsHotRunScript> RunScriptsList { get; set; } = new List<clsHotRunScript>();

        internal static void AddNewHotRunScript(clsHotRunScript script)
        {
            script.ID = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            if (RunScriptsList.Any(_script => _script.ID == script.ID))
            {
                MessageBox.Show($"新增Hot Run腳本失敗，已經存在ID為 {script.ID} 之腳本");
                return;
            }
            RunScriptsList.Add(script);
            File.WriteAllText(SysConfigs.HotRunScriptStoredFile, JsonConvert.SerializeObject(RunScriptsList, Formatting.Indented));
            OnScriptCreated?.Invoke("Store", EventArgs.Empty);
        }
        internal static void SaveHotRunScript(clsHotRunScript script)
        {
            var existScript = RunScriptsList.FirstOrDefault(_script => _script.ID != null && _script.ID == script.ID);
            if (existScript != null)
            {
                var index = RunScriptsList.IndexOf(existScript);
                RunScriptsList[index].RepeatNum = script.RepeatNum;
                RunScriptsList[index].RunTasksDesigning = script.RunTasksDesigning;
                RunScriptsList[index].IsRandomTransferTaskCreateMode = script.IsRandomTransferTaskCreateMode;
                RunScriptsList[index].UseCIMSimulation = script.UseCIMSimulation;
                RunScriptsList[index].MaxTaskQueueSize = script.MaxTaskQueueSize;
                RunScriptsList[index].Description = script.Description;
                RunScriptsList[index].ExceptStationIndexList = script.ExceptStationIndexList;
                RunScriptsList[index].IsWipToWipTransferAllow = script.IsWipToWipTransferAllow;
            }
            File.WriteAllText(SysConfigs.HotRunScriptStoredFile, JsonConvert.SerializeObject(RunScriptsList, Formatting.Indented));
            OnScriptCreated?.Invoke("Store", EventArgs.Empty);
        }
        internal static void RemoveHotRunScript(clsHotRunScript script)
        {
            var existScript = RunScriptsList.FirstOrDefault(_script => _script.ID != null && _script.ID == script.ID);
            if (existScript != null)
                RunScriptsList.Remove(existScript);
            File.WriteAllText(SysConfigs.HotRunScriptStoredFile, JsonConvert.SerializeObject(RunScriptsList, Formatting.Indented));
            OnScriptCreated?.Invoke("Store", EventArgs.Empty);
        }

        internal static void LoadSystemConfig()
        {
            if (File.Exists(CONFIG_FILE_NAME))
            {
                SysConfigs = JsonConvert.DeserializeObject<clsSysConfigs>(File.ReadAllText(CONFIG_FILE_NAME));
            }
            SaveSystemConfig();
        }
        internal static void SaveSystemConfig()
        {
            File.WriteAllText(CONFIG_FILE_NAME, JsonConvert.SerializeObject(SysConfigs, Formatting.Indented));
        }
        internal static void SaveHostSetting(string AGVSHost, int AGVSPort)
        {
            SysConfigs.AGVSHost = $"http://{AGVSHost}:{AGVSPort}";
            SaveSystemConfig();
        }
        internal static void LoadHotRunScriptsStored()
        {
            if (File.Exists(SysConfigs.HotRunScriptStoredFile))
            {
                RunScriptsList = JsonConvert.DeserializeObject<List<clsHotRunScript>>(File.ReadAllText(SysConfigs.HotRunScriptStoredFile));
            }
            else
            {
                File.WriteAllText(SysConfigs.HotRunScriptStoredFile, JsonConvert.SerializeObject(RunScriptsList, Formatting.Indented));
            }
        }

        internal static void StartReadDataFromDataBase(AGVSDBHelper dbhelper)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);

                    executingTasks = dbhelper.DBConn.ExecutingTasks.ToList();
                    agv_infos = dbhelper.DBConn.AGVInfos.ToList();
                    try
                    {
                        AGVlocStore = agv_infos.ToDictionary(agv => agv, agv => agv.CurrentPos == 0 ? new MapPoint
                        {

                        } : MapData.Points[(int)agv.CurrentPos]);

                        OnAGVLocUpdate?.Invoke("", EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                    }        
                    OnAGVInfosUpdate?.Invoke("", agv_infos);
                    OnExecutingTaskUpdate?.Invoke("", executingTasks);

                }

            });
        }
        internal static void StartAGVLocSyncProcess(AGVSDBHelper dbhelper)
        {

            Task.Run(async () =>
            {

                while (true)
                {
                    await Task.Delay(1000);
                    try
                    {
                        AGVlocStore = dbhelper.DBConn.AGVInfos.ToDictionary(agv => agv, agv => agv.CurrentPos == 0 ? new MapPoint
                        {

                        } : MapData.Points[(int)agv.CurrentPos]);
                        OnAGVLocUpdate?.Invoke("", EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                    }
                }

            });
        }
    }
}
