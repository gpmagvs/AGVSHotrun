namespace AGVSHotrun.VirtualAGVSystem
{
    public partial class AGVS_Dispath_Emulator
    {
        public class TaskObj
        {
            public string CarName { get; set; }
            public int AGVID { get; set; } = 1;
            public string Action { get; set; }

            public string FromStation { get; set; }
            public string FromSlot { get; set; }
            public string ToStation { get; set; }
            public string ToSlot { get; set; }

            public int Priority { get; set; } = 5;
            public int RepeatTime { get; set; } = 1;
            public string CSTID { get; set; } = "";

            public string ToQueryString()
            {
                return $"CarName={CarName}&AGVID={AGVID}&Action={Action}&FromStation={FromStation}&FromSlot={FromSlot}&ToStation={ToStation}&ToSlot={ToSlot}&Priority={Priority}&RepeatTime={RepeatTime}&CSTID={CSTID}";
            }

        }

    }
}
