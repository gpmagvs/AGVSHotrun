using AGVSHotrun.Models;
using AGVSystemCommonNet6.MAP;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AGVSHotrun.UI
{
    public partial class uscMapDisplay : UserControl
    {
        public class clsPointAddToRunActionDto
        {
            public MapPoint map_point { get; set; }
            public ACTION_TYPE action { get; set; }
        }

        internal static Map MapData => Store.MapData;

        public MapPoint SelectedMapPoint { get; private set; }
        public bool AllowRunTaskDispatch { get; set; } = false;

        public string _HighlightAGVName = "";
        public string HighlightAGVName
        {
            get => _HighlightAGVName;
            set
            {
                _HighlightAGVName = value;
                picMap.Invalidate();
            }
        }

        public Action<clsPointAddToRunActionDto> OnMapPointAddToRunActionClick { get; set; }
        public Action<MapPoint> OnMapPoinAddtoExceptListClick { get; set; }

        bool isdrag = false;
        int offset_x = 0;
        int offset_y = 0;
        internal MapPoint hoverinigMapPoint;
        internal Dictionary<MapPoint, RectangleF> StationRectagles = new Dictionary<MapPoint, RectangleF>();
        internal float scale = 1;
        public uscMapDisplay()
        {
            InitializeComponent();
            picMap.MouseWheel += PicMap_MouseWheel;
            Store.OnAGVLocUpdate += (sedner, e) =>
            {
                Invoke(new Action(() =>
                {
                    picMap.Invalidate();
                }));
            };
        }

        private void PicMap_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                Console.WriteLine($"{e.Delta} 向上滚动");
            }

            else if (e.Delta < 0)
            {
                Console.WriteLine($"{e.Delta} 向下滚动");
            }
            scale += (float)(e.Delta / 1000.0);
            picMap.Invalidate();
        }

        private void picMap_Paint(object sender, PaintEventArgs e)
        {

            if (MapData == null)
                return;

            try
            {
                var graph = e.Graphics;
                graph.ScaleTransform(scale, scale);
                StationRectagles = MapData.Points.Values.ToDictionary(pt => pt, pt => new RectangleF(DrawPoint(pt.Graph), new SizeF(8, 8)));

                foreach (var station_point in MapData.Points.Values)
                {
                    var rectang = StationRectagles[station_point];
                    if (station_point.Target.Count != 0)
                    {
                        foreach (var item in station_point.Target)
                        {
                            var targetPt = MapData.Points[item.Key];
                            var endRectangle = StationRectagles[targetPt];
                            var line_pen = new Pen(Brushes.Gray, 2);
                            var line_start_pt = new Point((int)(rectang.Location.X + rectang.Width / 2), (int)(rectang.Location.Y + rectang.Height / 2));
                            var line_end_pt = new Point((int)(endRectangle.Location.X + rectang.Width / 2), (int)(endRectangle.Location.Y + endRectangle.Height / 2));
                            graph.DrawLine(line_pen, line_start_pt, line_end_pt);
                        }
                    }
                }
                foreach (var station_point in MapData.Points.Values)
                {
                    var rectang = StationRectagles[station_point];
                    var textLoca = rectang.Location;
                    textLoca.X = textLoca.X + 5;
                    textLoca.Y = textLoca.Y - 22;

                    string station_name_dispaly = NameShowSwitch(station_point);
                    bool agv_located = false;
                    KeyValuePair<AGVInfo, MapPoint> has_agv = Store.AGVlocStore.FirstOrDefault(a => a.Value.Name == station_point.Name);

                    if (has_agv.Value != null)
                    {
                        agv_located = true;
                        station_name_dispaly += $",{has_agv.Key.AGVName}";
                        bool highlight = HighlightAGVName == has_agv.Key.AGVName;
                    }

                    graph.DrawString(station_name_dispaly, new Font("微軟正黑體", 9, FontStyle.Bold), agv_located ? Brushes.Red : Brushes.Green, textLoca);
                    bool isSelected = SelectedMapPoint?.Name == station_point.Name;
                    var borderPen = new Pen(isSelected ? Brushes.Red : Brushes.Black, isSelected ? 8 : 2);
                    graph.DrawEllipse(borderPen, rectang);
                    graph.FillEllipse(agv_located ? Brushes.Red : GetPointBrush(station_point), rectang);


                }

            }
            catch (Exception ex)
            {
            }


        }

        private string NameShowSwitch(MapPoint station_point)
        {
            if (radbtn_Show_GraphDislay.Checked)
                return station_point.Graph.Display;
            else if (radbtn_Show_IDName.Checked)
                return station_point.Name;
            else if (radbtn_Show_Index.Checked)
                return MapData.Points.FirstOrDefault(pt => pt.Value.Name == station_point.Name).Key + "";
            else if (radbtn_Show_Tag.Checked)
                return station_point.TagNumber + "";
            else
                return station_point.Graph.Display;
        }

        private Brush GetPointBrush(MapPoint point)
        {
            if (point.IsEquipment)
                return Brushes.Blue;
            if (point.IsCharge)
                return Brushes.Orange;

            return Brushes.Green;
        }
        private Point DrawPoint(Graph graph_data)
        {
            return new Point((int)(graph_data.X / 2.5f) + offset_x, (int)(graph_data.Y / 2.5f) + offset_y);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            scale = (float)(1 + hScrollBar1.Value / 10.0);
            picMap.Invalidate();
        }

        private void picMap_MouseHover(object sender, EventArgs e)
        {
        }
        private void picMap_MouseDown(object sender, MouseEventArgs e)
        {
            drag_previous_mouse_loc = e.Location;
            Cursor = Cursors.Hand;
            isdrag = true;
        }

        private void picMap_MouseUp(object sender, MouseEventArgs e)
        {
            isdrag = false;
            Cursor = Cursors.Default;
        }
        Point drag_previous_mouse_loc = new Point(0, 0);
        private void picMap_MouseMove(object sender, MouseEventArgs e)
        {

            if (isdrag)
            {
                Cursor = Cursors.Hand;
                var x_move = e.X - drag_previous_mouse_loc.X;
                var y_move = e.Y - drag_previous_mouse_loc.Y;
                offset_x += (int)(x_move / scale);
                offset_y += (int)(y_move / scale);
                drag_previous_mouse_loc = e.Location;
                picMap.Invalidate();
            }

            var cusorLoc = new Point((int)(e.Location.X / scale), (int)(e.Location.Y / scale));
            cusorLoc.Offset(-7, -7);
            RectangleF cursor = new RectangleF(cusorLoc, new SizeF(40 / scale, 40 / scale));
            hoverinigMapPoint = StationRectagles.FirstOrDefault(pt => pt.Value.IntersectsWith(cursor)).Key;
            if (hoverinigMapPoint != null)
            {
                labCursorInfo.Text = $"{hoverinigMapPoint.Name} (Tag= {hoverinigMapPoint.TagNumber} , {hoverinigMapPoint.X}), {hoverinigMapPoint.Y}";
                this.Cursor = Cursors.Hand;
            }
            else
            {
                labCursorInfo.Text = "";
                Cursor = Cursors.Default;
            }
        }

        private void picMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (hoverinigMapPoint != null)
            {

                SelectedMapPoint = hoverinigMapPoint;
                btnParkStripitem.Enabled = SelectedMapPoint.IsParking;
                ContextMenuStrip menu = hoverinigMapPoint.IsEquipment ? LDULDStationMenuStrip : NormalPointContextMenuStrip;
                picMap.ContextMenuStrip = menu;
                picMap.Invalidate();
            }
            else
            {
                picMap.ContextMenuStrip = null;
            }
        }

        private void picMap_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNormalMoveAction_Click(object sender, EventArgs e)
        {
            if (OnMapPointAddToRunActionClick == null)
                return;
            OnMapPointAddToRunActionClick(new clsPointAddToRunActionDto
            {
                action = ACTION_TYPE.MOVE,
                map_point = SelectedMapPoint,
            });
        }

        private void btnAddULDRunTaskAction_Click(object sender, EventArgs e)
        {
            if (OnMapPointAddToRunActionClick == null)
                return;
            OnMapPointAddToRunActionClick(new clsPointAddToRunActionDto
            {
                action = ACTION_TYPE.UNLOAD,
                map_point = SelectedMapPoint,
            });
        }

        private void btnAddLDRunTaskAction_Click(object sender, EventArgs e)
        {
            if (OnMapPointAddToRunActionClick == null)
                return;
            OnMapPointAddToRunActionClick(new clsPointAddToRunActionDto
            {
                action = ACTION_TYPE.LOAD,
                map_point = SelectedMapPoint,
            });
        }

        private void btnParkStripitem_Click(object sender, EventArgs e)
        {
            if (OnMapPointAddToRunActionClick == null)
                return;
            OnMapPointAddToRunActionClick(new clsPointAddToRunActionDto
            {
                action = ACTION_TYPE.PARK,
                map_point = SelectedMapPoint,
            });
        }

        private void radbtn_Show_IDName_CheckedChanged(object sender, EventArgs e)
        {
            picMap.Invalidate();
        }

        private void BtnAddToExceptList_Click(object sender, EventArgs e)
        {
            if (SelectedMapPoint != null && OnMapPoinAddtoExceptListClick != null)
            {
                OnMapPoinAddtoExceptListClick(SelectedMapPoint);
            }
        }
    }
}
