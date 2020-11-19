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

/// <summary>
/// El formulario de Busqueda. Tiene un listBox con los todos los clientes. Esto se agrega por si el usuario no conoce el id.
/// Para seleccionar se puede usar el boton o un dobleclick.
/// El dato elegido lo lleva al formulario de ABM.
/// Se pasa el objeto de HotelServicio para no instanciarlo nuevamente.
/// </summary>

namespace NLayer.Formularios
{
    public partial class FrmBuscarCliente : Form
    {
        HotelServicios _clienteServicios;
        public FrmBuscarCliente(HotelServicios serv)
        {
            InitializeComponent();
            _clienteServicios = serv;
        }
        
        private void Seleccionar() 
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una opcion.");
            }
            else
            {
                this.Tag = (Cliente)listBox1.SelectedItem;
                this.Close();
            }
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _clienteServicios.TraerClientes();
        }
        private void listBox1_doubleClick(object sender, EventArgs e)
        {
            Seleccionar();
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }
    }
}
