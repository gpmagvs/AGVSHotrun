using AGVSHotrun.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGVSHotrun.UI
{
    public partial class ActionComboBox : UserControl
    {
        public event EventHandler<ACTION_TYPE> OnActionTypeSelected;
        public ACTION_TYPE action_selected
        {
            set
            {
                comboBox1.SelectedItem = value;
            }
        }
        public ActionComboBox()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Enum.GetValues(typeof(ACTION_TYPE)).Cast<object>().ToArray());
        }

        private void ActionComboBox_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ACTION_TYPE action_selected = (ACTION_TYPE)comboBox1.SelectedItem;
            OnActionTypeSelected?.Invoke(this, action_selected);
        }
    }
}
