using System.Diagnostics;

namespace AGVSHotrun.VirtualAGVSystem
{
    public partial class AGVS_Dispath_Emulator
    {
        public class POWERSHELL_HELPER
        {

            public static string Run(string powershellFile)
            {
                try
                {

                    var filePath = powershellFile;
                    var process = new Process();
                    process.StartInfo.FileName = "powershell.exe";
                    process.StartInfo.Arguments = $"-File {powershellFile}";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    return output;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
        }

    }
}
