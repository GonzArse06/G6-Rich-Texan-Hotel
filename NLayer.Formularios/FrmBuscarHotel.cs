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
/// El formulario de Busqueda. Tiene un listBox con los hoteles. Esto se agrega por si el usuario no conoce el id.
/// Para seleccionar se puede usar el boton o un dobleclick.
/// El dato elegido lo lleva al formulario de ABM.
/// Se pasa el objeto de HotelServicio para no instanciarlo nuevamente.
/// </summary>

namespace NLayer.Formularios
{
    public partial class FrmBuscarHotel : Form
    {
        HotelServicios _servicios;
        public FrmBuscarHotel( HotelServicios serv)
        {
            InitializeComponent();
            _servicios = serv;
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
                MessageBox.Show("Seleccione una opcion.","Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var _hotel = ((Hotel)listBox1.SelectedItem);
                this.Tag = _hotel;
                this.Close();
            }
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {          
            listBox1.DataSource = null;
            listBox1.DataSource = _servicios.TraerHoteles();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
