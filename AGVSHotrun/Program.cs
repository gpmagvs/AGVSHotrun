using AGVSHotrun.DbContexts;
using AGVSystemCommonNet6.MAP;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AGVSHotrun
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Store.LoadSystemConfig();

            Store.LoadHotRunScriptsStored();
            PowershellInit();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            AGVSDBHelper.DBConnection = Store.SysConfigs.DBConnection;
            EnvironmentVariables.AddUserVariable("GPM_HOT_RUN", Environment.CurrentDirectory);
            Application.Run(new frmMain());
        }
        static void PowershellInit()
        {
            Process process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = "Set-ExecutionPolicy Unrestricted";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            // 启动进程
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
        }
    }
}