using Execute_2.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Execute_2
{
    public partial class Form1 : Form
    {
        private readonly GeneroBLL generoBLL = new GeneroBLL();
        public Form1()
        {
            InitializeComponent();
            RefrescarGrilla();
        }

        private void RefrescarGrilla()
        {
            grillaGenero.DataSource = null;
            grillaGenero.DataSource = generoBLL.Listar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
