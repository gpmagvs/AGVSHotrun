using AGVSHotrun.VirtualAGVSystem;
using AGVSystemCommonNet6.MAP;
using Azure.Identity;
using ACTION_TYPE = AGVSHotrun.Models.ACTION_TYPE;

namespace AGVSHotrun.HotRun
{
    public class clsRunTask
    {
        public string TaskName { get; set; }
        public ACTION_TYPE Action { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 圖資上的Name屬性
        /// </summary>
        public string FromStation { get; set; } = "";
        public string FromSlot { get; set; } = "";
        /// <summary>
        /// 圖資上的Name屬性
        /// </summary>
        public string ToStation { get; set; } = "";
        public string ToSlot { get; set; } = "";
        public string CSTID { get; set; } = "";
        public bool MoveOnly { get; set; } = false;
        public string AGVName { get; set; } = "AGV_1";

        public string GetSecondaryPt(string Station)
        {
            var map_points = Store.MapData.Points.ToList();
            MapPoint toStationPt = map_points.First(pt => pt.Value.Name == Station).Value;
            MapPoint hotRunToStationPt = Store.MapData.Points[toStationPt.Target.First().Key];
            return hotRunToStationPt.Name;
        }

        public string GetActualFromStationName()
        {
            var map_points = Store.MapData.Points.ToList();
            string _toStation = FromStation;
            if (MoveOnly && Action != ACTION_TYPE.MOVE && Action != ACTION_TYPE.PARK) //從圖資抓到二次定位點前的Point名稱
            {
                MapPoint toStationPt = map_points.First(pt => pt.Value.Name == FromStation).Value;
                MapPoint hotRunToStationPt = Store.MapData.Points[toStationPt.Target.First().Key];
                _toStation = hotRunToStationPt.Name;
            }
            return _toStation;
        }
        public string GetActualToStationName()
        {
            var map_points = Store.MapData.Points.ToList();
            string _toStation = ToStation;

            if (MoveOnly && Action != ACTION_TYPE.MOVE && Action != ACTION_TYPE.PARK) //從圖資抓到二次定位點前的Point名稱
            {
                MapPoint toStationPt = map_points.First(pt => pt.Value.Name == ToStation).Value;
                MapPoint hotRunToStationPt = Store.MapData.Points[toStationPt.Target.First().Key];
                _toStation = hotRunToStationPt.Name;
            }
            return _toStation;
        }

        internal int FromTag
        {
            get
            {
                var pt = Store.MapData.Points.Values.FirstOrDefault(p => p.Name == FromStation);
                return pt == null ? -1 : pt.TagNumber;
            }
        }
        internal int ToTag
        {
            get
            {
                var pt = Store.MapData.Points.Values.FirstOrDefault(p => p.Name == ToStation);
                return pt == null ? -1 : pt.TagNumber;
            }
        }


        internal int FromStationID
        {
            get
            {
                var pt = Store.MapData.Points.FirstOrDefault(p => p.Value.Name == FromStation);
                return pt.Value == null ? -1 : pt.Key;
            }
        }
        internal int ToStationID
        {
            get
            {
                var pt = Store.MapData.Points.FirstOrDefault(p => p.Value.Name == ToStation);
                return pt.Value == null ? -1 : pt.Key;
            }
        }

        internal async Task<bool> PostActionReq(string AgvName, int AgvID)
        {
            try
            {
                return await PostTaskHttpRequest(AgvName, AgvID, FromStation, FromSlot, ToStation, ToSlot, CSTID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<bool> PostFromStationReq(string AgvName, int AgvID)
        {
            try
            {
                return await PostTaskHttpRequest(AgvName, AgvID, GetActualFromStationName(), ToSlot, CSTID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<bool> PostToStationReq(string AgvName, int AgvID)
        {
            try
            {
                return await PostTaskHttpRequest(AgvName, AgvID, GetActualToStationName(), ToSlot, CSTID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> PostTaskHttpRequest(string AgvName, int AgvID, string from_station, string from_slot, string to_station = "", string to_slot = "", string cstid = "")
        {
            AGVS_Dispath_Emulator dispatcher_helper = new AGVS_Dispath_Emulator();
            AGVS_Dispath_Emulator.ExcuteResult? result = null;
            if (MoveOnly)
                result = await dispatcher_helper.Move(AgvName, AgvID, from_station);
            else
            {
                switch (Action)
                {
                    case ACTION_TYPE.MOVE:
                        result = await dispatcher_helper.Move(AgvName, AgvID, from_station);
                        break;
                    case ACTION_TYPE.LOAD:
                        result = await dispatcher_helper.Load(AgvName, AgvID, from_station, from_slot, cstid);
                        break;
                    case ACTION_TYPE.UNLOAD:
                        result = await dispatcher_helper.Unload(AgvName, AgvID, from_station, from_slot, cstid);
                        break;
                    case ACTION_TYPE.TRANSFER:
                        result = await dispatcher_helper.Carry(AgvName, AgvID, from_station, from_slot, to_station, to_slot, cstid);
                        break;
                    case ACTION_TYPE.CHARGE:
                        result = await dispatcher_helper.Charge(AgvName, AgvID, from_station, from_slot, cstid);
                        break;
                    case ACTION_TYPE.PARK:
                        result = await dispatcher_helper.Park(AgvName, AgvID, from_station, from_slot);
                        break;
                    default:
                        break;
                }
            }
            if (result.ResponseMsg.Contains("系統已閒置過久,請重新登入再進行手動派工"))
            {
                throw new AuthenticationFailedException(result.ResponseMsg);
            }
            if (result.ResponseMsg.Contains("無法連接至遠端伺服器"))
            {
                throw new HttpRequestException(result.ResponseMsg);
            }
            return result.Success;
        }

    }
}
