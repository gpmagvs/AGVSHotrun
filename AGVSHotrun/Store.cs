using AGVSHotrun.HotRun;
using AGVSHotrun.Models;
using AGVSystemCommonNet6.MAP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSHotrun
{
    public static class Store
    {
        internal static event EventHandler OnScriptCreated;
        public static clsSysConfigs SysConfigs = new clsSysConfigs();
        public static Map MapData { get; set; }

        public static List<clsHotRunScript> RunScriptsList { get; set; } = new List<clsHotRunScript>();

        internal static void AddNewHotRunScript(clsHotRunScript script)
        {
            script.ID = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
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
                RunScriptsList[index] = script;
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
            string config_file = "SystemConfigs.json";
            if (File.Exists(config_file))
            {
                SysConfigs = JsonConvert.DeserializeObject<clsSysConfigs>(File.ReadAllText(config_file));
            }
            else
            {
                File.WriteAllText(config_file, JsonConvert.SerializeObject(SysConfigs, Formatting.Indented));
            }
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
    }
}
