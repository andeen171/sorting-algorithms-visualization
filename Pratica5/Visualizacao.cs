using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pratica5
{
    public partial class Visualizacao : Form
    {
        public Func<int, bool> action;
        public Visualizacao(Func<int, bool> a)
        {
            InitializeComponent();
            action = a;
        }

        public int SelectedIndex
        {
            get { return cbxModo.SelectedIndex; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            action(cbxModo.SelectedIndex);
            Close();
        }
    }
}
