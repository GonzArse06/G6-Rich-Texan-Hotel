using NLayer.Entidades;
using NLayer.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NLayer.Formularios
{
    public partial class FrmBuscarCliente : Form
    {
        List<Cliente> _lista;
        HotelServicios _clienteServicios;
        public FrmBuscarCliente()
        {
            InitializeComponent();
            _clienteServicios = new HotelServicios();
            _lista = new List<Cliente>();
        }
        private void listBox1_doubleClick(object sender, EventArgs e)
        {
            Seleccionar();
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }
        private void Seleccionar() 
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una opcion.");
            }
            else
            {
                int idCliente = ((Cliente)listBox1.SelectedItem).Id;
                ((FrmAbmReservas)Owner).txtIdCliente.Text = idCliente.ToString();
                this.Close();
            }
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _clienteServicios.TraerClientes();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
