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
    public partial class AGVCombox : UserControl
    {
        public string _AGVSelected;
        public string AGVSelected
        {
            get => _AGVSelected;
            set
            {
                _AGVSelected = value;
                comboBox1.Text = _AGVSelected;
            }
        }

        public event EventHandler<string> OnAGVSelected;
        public AGVCombox()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnAGVSelected?.Invoke(this, comboBox1.SelectedItem?.ToString());
        }
    }
}
