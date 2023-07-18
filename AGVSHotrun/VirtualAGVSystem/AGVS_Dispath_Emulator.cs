using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace AGVSHotrun.VirtualAGVSystem
{
    public partial class AGVS_Dispath_Emulator
    {
        public static string AGVSHost = "127.0.0.1";
        public static int AGVSPort = 6600;

        public enum ACTION
        {
            Move,
            Parking,
            Unload,
            Load,
            Charge,
            Transfer
        }
        public clsCookie Cookies = new clsCookie();

        public AGVS_Dispath_Emulator()
        {
            LoadCookies();
        }
        private string cookies_json_file = "cookie.json";
        private static string agvs_host_json_file = "agvs.json";
        private void LoadCookies()
        {
            if (File.Exists(cookies_json_file))
            {
                Cookies = JsonConvert.DeserializeObject<clsCookie>(File.ReadAllText(cookies_json_file));
            }
            else
            {
                SaveCookies();
            }
        }
        public static void LoadAGVSHost()
        {
            if (File.Exists(agvs_host_json_file))
            {
                var json = File.ReadAllText(agvs_host_json_file);
                var obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                AGVSHost = obj["IP"].ToString();
                AGVSPort = Convert.ToInt16(obj["Port"].ToString());
            }
            else
            {
                File.WriteAllText(agvs_host_json_file, JsonConvert.SerializeObject(new { IP = AGVSHost, Port = AGVSPort }, Formatting.Indented));
            }
        }

        internal static void SaveHostSetting()
        {
            File.WriteAllText(agvs_host_json_file, JsonConvert.SerializeObject(new { IP = AGVSHost, Port = AGVSPort }, Formatting.Indented));
        }
        private void SaveCookies()
        {
            File.WriteAllText(cookies_json_file, JsonConvert.SerializeObject(Cookies, Formatting.Indented));
        }

        public AGVS_Dispath_Emulator(string cookie_connect_sid, string cookie_io)
        {
            this.Cookies.Cookies_Connect_SID = cookie_connect_sid;
            this.Cookies.Cookies_io = cookie_io;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <returns></returns>
        public async static Task<ExcuteResult> Login()
        {
            var psFile = CreateLoginCmsPsFile();
            var output = POWERSHELL_HELPER.Run(psFile);
            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }
        /// <summary>
        /// 取消任務
        /// </summary>
        /// <returns></returns>
        public async static Task<ExcuteResult> CancelTask(string taskName)
        {
            await Login();
            var psFile = CreateCancelTaskCmdPsFile(taskName);
            var output = POWERSHELL_HELPER.Run(psFile);
            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }

        public async Task<ExcuteResult> Move(string CarName, int AGV_ID, string Station)
        {
            var psFile = CreateTaskCmdPSFile(ACTION.Move, CarName, AGV_ID + "", Station);
            var output = POWERSHELL_HELPER.Run(psFile);
            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }

        public async Task<ExcuteResult> Park(string CarName, int AGV_ID, string Station, string slot)
        {
            var psFile = CreateTaskCmdPSFile(ACTION.Parking, CarName, AGV_ID + "", Station, slot);
            var output = POWERSHELL_HELPER.Run(psFile);

            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }

        public async Task<ExcuteResult> Load(string CarName, int AGV_ID, string Station, string slot, string CST_ID = "")
        {
            var psFile = CreateTaskCmdPSFile(ACTION.Load, CarName, AGV_ID + "", Station, slot, CST_ID);
            var output = POWERSHELL_HELPER.Run(psFile);

            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }

        public async Task<ExcuteResult> Unload(string CarName, int AGV_ID, string Station, string slot, string CST_ID = "")
        {
            var psFile = CreateTaskCmdPSFile(ACTION.Unload, CarName, AGV_ID + "", Station, slot, CST_ID);
            var output = POWERSHELL_HELPER.Run(psFile);

            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }
        public async Task<ExcuteResult> Charge(string CarName, int AGV_ID, string Station, string slot, string CST_ID = "")
        {
            var psFile = CreateTaskCmdPSFile(ACTION.Charge, CarName, AGV_ID + "", Station, slot, CST_ID);
            var output = POWERSHELL_HELPER.Run(psFile);
            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }

        internal async Task<ExcuteResult?> Carry(string CarName, int AGV_ID, string FromStation, string FromSlot, string ToStation, string ToSlot, string CST_ID = "")
        {
            var psFile = CreateTaskCmdPSFile(ACTION.Transfer, CarName, AGV_ID + "", FromStation, FromSlot, ToStation, ToSlot, CST_ID);
            var output = POWERSHELL_HELPER.Run(psFile);

            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }


        public class ExcuteResult
        {
            public bool Success
            {
                get
                {
                    return ResponseMsg.Contains("403") | ResponseMsg.Contains("200");
                }
            }
            public string ResponseMsg { get; set; }
            public string ErrorMsg { get; set; }
            public string url { get; internal set; }
            public string fileName { get; internal set; }
            public string Json()
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
        }


        private string CreateTaskCmdPSFile(ACTION action, string CarName, string AGV_ID, string From_Station, string From_Slot, string To_Station, string To_Slot, string CST_ID)
        {
            if (From_Station.Contains("|"))
            {
                From_Station = From_Station.Replace("|", "%7C");
            }
            if (To_Station.Contains("|"))
            {
                To_Station = To_Station.Replace("|", "%7C");
            }
            string content = GetDispatchCmdTemplatePSContent();
            content = content.Replace("http://127.0.0.1:6600", $"http://{AGVSHost}:{AGVSPort}");
            content = content.Replace("127.0.0.1", AGVSHost);
            //content = content.Replace("s%3AdxkjsEgCfNN2aq40Pbvs1rTryFKM53Eu.pCWvdU%2FtbbAAFEWxhxYnlRpuVvN5MgbgDAY7QZC18uI", $"{Cookies.Cookies_Connect_SID}");
            //content = content.Replace("TPrw6Q8Aol3EBu1YAAAP", $"{Cookies.Cookies_io}");
            content = content.Replace("Action=Move", $"Action={action.ToString()}");
            content = content.Replace("CarName=AGV_1", $"CarName={CarName}");
            content = content.Replace("AGVID=1", $"AGVID={AGV_ID}");
            content = content.Replace("FromStation=35", $"FromStation={From_Station}");
            content = content.Replace("FromSlot=1", $"FromSlot={From_Slot}");
            content = content.Replace("ToStation=", $"ToStation={To_Station}");
            content = content.Replace("ToSlot=1", $"ToSlot={To_Slot}");
            content = content.Replace("CSTID=", $"CSTID={CST_ID}");
            Directory.CreateDirectory("temp");
            string psFileName = $"temp/{CarName}_{action}_From_{From_Station}-{From_Slot}_TO_{To_Station}-{To_Slot}_{DateTime.Now.Ticks}.ps1";
            File.WriteAllText(psFileName, content);
            return psFileName;
        }
        private static string CreateLoginCmsPsFile()
        {
            var template = File.ReadAllText("login_request.ps1");
            template = template.Replace("127.0.0.1:6600", $"{AGVSHost}:{AGVSPort}");
            template = template.Replace("127.0.0.1", AGVSHost);
            Directory.CreateDirectory("temp");
            string psFileName = $"temp/lgoin_{DateTime.Now.Ticks}.ps1";
            File.WriteAllText(psFileName, template);
            return psFileName;
        }
        private static string CreateCancelTaskCmdPsFile(string taskName)
        {
            var template = File.ReadAllText("cancel_task_template.ps1");
            template = template.Replace("127.0.0.1:6600", $"{AGVSHost}:{AGVSPort}");
            template = template.Replace("127.0.0.1", AGVSHost);
            template = template.Replace("TaskName=*Local_20230718103059880", $"TaskName={taskName}");
            Directory.CreateDirectory("temp");
            string psFileName = $"temp/lgoin_{DateTime.Now.Ticks}.ps1";
            File.WriteAllText(psFileName, template);
            return psFileName;
        }
        private string CreateTaskCmdPSFile(ACTION action, string CarName, string AGV_ID, string station_no, string slot_id = "1", string CST_ID = "")
        {
            if (station_no.Contains("|"))
            {
                station_no = station_no.Replace("|", "%7C");
            }

            string content = GetDispatchCmdTemplatePSContent();

            content = content.Replace("http://127.0.0.1:6600", $"http://{AGVSHost}:{AGVSPort}");
            content = content.Replace("127.0.0.1", AGVSHost);
            //content = content.Replace("s%3AdxkjsEgCfNN2aq40Pbvs1rTryFKM53Eu.pCWvdU%2FtbbAAFEWxhxYnlRpuVvN5MgbgDAY7QZC18uI", $"{Cookies.Cookies_Connect_SID}");
            //content = content.Replace("TPrw6Q8Aol3EBu1YAAAP", $"{Cookies.Cookies_io}");
            content = content.Replace("Action=Move", $"Action={action.ToString()}");
            content = content.Replace("CarName=AGV_1", $"CarName={CarName}");
            content = content.Replace("AGVID=1", $"AGVID={AGV_ID}");
            content = content.Replace("FromStation=35", $"FromStation={station_no}");
            content = content.Replace("FromSlot=1", $"FromSlot={slot_id}");
            content = content.Replace("CSTID=", $"CSTID={CST_ID}");
            Directory.CreateDirectory("temp");
            string psFileName = $"temp/{CarName}_Move_{station_no}_{slot_id}_{DateTime.Now.Ticks}.ps1";
            File.WriteAllText(psFileName, content);
            return psFileName;
        }
        private string GetDispatchCmdTemplatePSContent()
        {
            return File.ReadAllText("agv_task_cmd_template.ps1");
        }

        internal void SetCookie(string connect_sid, string io)
        {
            Cookies.Cookies_Connect_SID = connect_sid;
            Cookies.Cookies_io = io;
            SaveCookies();

        }

    }
}
