using AGVSystemCommonNet6.Configuration;
using AGVSystemCommonNet6.MAP;
namespace AGVSHotrun
{
    public partial class Form1 : Form
    {
        clsSysConfigs configs = new clsSysConfigs();
        AGVSDBHelper aGVSDBHelper = new AGVSDBHelper();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tasks_queuing = aGVSDBHelper.GetExecutingTasks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var agv = aGVSDBHelper.DBConn.AGVInfos.FirstOrDefault(agv => agv.AGVID == 2);

            var ret = aGVSDBHelper.ADD_TASK(new Models.ExecutingTask
            {
                Name = $"*TEST_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}",
                AGVID = 1,
                ActionType = "Move",
                Status = 1,
                ToStationId = 60,
                FromStationId = 60,
                ToStationName = "3",
                FromStationName = "3",
                Receive_Time = DateTime.Now,
                RepeatTime = 1,

            });

            MessageBox.Show("TASK ADD_NUM:" + ret.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Map map = MapManager.LoadMapFromFile(configs.MapFile);
        }
    }
}