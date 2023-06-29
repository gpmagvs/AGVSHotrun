using AGVSHotrun.DbContexts;
using AGVSHotrun.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSHotrun
{
    public class AGVSDBHelper
    {
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
                    throw ex;
                }
            }
        }



        public Models.UserInfo test()
        {
            using (var conn = DBConn)
            {
                return conn.UserInfos.First();
            }
        }

        public List<Models.ExecutingTask> GetExecutingTasks()
        {
            using(var conn = DBConn)
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
