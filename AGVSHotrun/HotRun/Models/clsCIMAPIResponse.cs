namespace AGVSHotrun.HotRun.Models
{
    public class clsCIMAPIResponse
    {
        public int code { get; set; } = 0;
        public string message { get; set; } = "";
        public clsCIMAPIResponse(int return_code, string message = "")
        {
            code = return_code;
            this.message = message;
        }
    }
}
