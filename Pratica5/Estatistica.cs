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
    public partial class Estatistica : Form
    {
        public Func<int, int, bool> action;
        public Estatistica(Func<int, int, bool> a)
        {
            InitializeComponent();
            action = a;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            action(cbxModo.SelectedIndex, cbxQuantidade.SelectedIndex);
            Close();
        }
    }
}
