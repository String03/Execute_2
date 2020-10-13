using Execute_2.BLL;
using Execute_2.EE;
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

        private Genero ListarGenero()
        {
            return new Genero
            {
                Nombre = txt_genero_nombre.Text.Trim(),
                Fecha_reg = DateTime.Now
            };
        }

        private void btn_alta_genero_Click(object sender, EventArgs e)
        {
            var genero = ListarGenero();
            generoBLL.Alta(genero);
            RefrescarGrilla();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txt_genero_nombre.Text = string.Empty;
        }

        private Genero SeleccionarGenero()
        {
            return (Genero)grillaGenero.SelectedRows[0].DataBoundItem;
        }

        private void btn_baja_genero_Click(object sender, EventArgs e)
        {
            var genero = SeleccionarGenero();
            generoBLL.Baja(genero);
            RefrescarGrilla();
            LimpiarCampos();
        }

        private void btn_modificacion_genero_Click(object sender, EventArgs e)
        {
            var genero = SeleccionarGenero();
            genero.Nombre = txt_genero_nombre.Text.Trim();
            generoBLL.Modificar(genero);
            RefrescarGrilla();
            LimpiarCampos();
        }
    }
}
