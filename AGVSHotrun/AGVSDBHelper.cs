using AGVSHotrun.DbContexts;
using AGVSHotrun.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSHotrun
{
    public class AGVSDBHelper
    {
        internal static string DBConnection = "Server=127.0.0.1;Database=WebAGVSystem;User Id=sa;Password=12345678;Encrypt=False";

        public WebAGVSystemDbcontext DBConn
        {
            get
            {
                try
                {
                    var optionbuilder = new DbContextOptionsBuilder<WebAGVSystemDbcontext>();
                    optionbuilder.UseSqlServer("Server=127.0.0.1;Database=WebAGVSystem;User Id=sa;Password=12345678;Encrypt=False");
                    return new WebAGVSystemDbcontext(optionbuilder.Options);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public int GetAGVID(string AGVName)
        {
            if (Debugger.IsAttached)
            {
                return int.Parse(AGVName.Split('_')[1]);
            }
            using (var dbConn = DBConn)
            {
                var agv = dbConn.AGVInfos.FirstOrDefault(agv => agv.AGVName == AGVName);
                if (agv == null)
                    return 1;
                return agv.AGVID;
            }
        }

        public List<Models.ExecutingTask> GetExecutingTasks()
        {
            using (var conn = DBConn)
            {
                return conn.ExecutingTasks.ToList();
            }
        }

        internal int ADD_TASK(ExecutingTask executingTask)
        {
            using (var conn = DBConn)
            {
                conn.ExecutingTasks.Add(executingTask);
                return conn.SaveChanges();
            }
        }



    }
}
