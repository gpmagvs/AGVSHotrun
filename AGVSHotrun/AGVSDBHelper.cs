﻿using AGVSHotrun.DbContexts;
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
        public WebAGVSystemDbcontext DBConn;

        public bool Connect(bool auto_create_database = false)
        {
            try
            {
                var optionbuilder = new DbContextOptionsBuilder<WebAGVSystemDbcontext>();
                optionbuilder.UseSqlServer(DBConnection);
                DBConn = new WebAGVSystemDbcontext(optionbuilder.Options);
                if (auto_create_database)
                {

                    DBConn.Database.EnsureCreated();
                    try
                    {
                        var agv_id = new int[] { 1, 2, 3, 4 };
                        DBConn.AGVInfos.AddRange(agv_id.Select(id => new AGVInfo { AGVID = id, AGVName = $"AGV_{id}" }));
                        DBConn.SaveChanges();
                    }
                    catch (Exception)
                    {

                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void Disconnect()
        {
            DBConn?.Database.CloseConnection();
        }
        public int GetAGVID(string AGVName)
        {
            using (var dbConn = DBConn)
            {
                var agv = dbConn.AGVInfos.FirstOrDefault(agv => agv.AGVName == AGVName);
                if (agv == null)
                    return 1;
                return agv.AGVID;
            }
        }

        public clsAGVStates GetAGVMainStatus(string AGVName)
        {

            var agv = DBConn.AGVInfos.FirstOrDefault(agv => agv.AGVName == AGVName);
            if (agv == null)
            {
                return new clsAGVStates()
                {
                    AutoStatus = AUTO_STATE.MANUAL,
                    RunStatus = RUN_STATE.DOWN,
                    OnlineStatus = ONLINE_STATE.OFFLINE
                };
            }
            else
            {
                var main_status = Enum.GetValues(typeof(RUN_STATE)).Cast<RUN_STATE>().FirstOrDefault(st => (int)st == agv.AGVMainStatus);
                var online_status = Enum.GetValues(typeof(ONLINE_STATE)).Cast<ONLINE_STATE>().FirstOrDefault(st => (int)st == agv.AGVMode);
                return new clsAGVStates
                {
                    RunStatus = main_status,
                    OnlineStatus = online_status
                };
            }
        }

        public List<Models.ExecutingTask> GetExecutingTasks()
        {

            return DBConn.ExecutingTasks.ToList();
        }

        internal int ADD_TASK(ExecutingTask executingTask)
        {

            DBConn.ExecutingTasks.Add(executingTask);
            return DBConn.SaveChanges();
        }



    }
}
