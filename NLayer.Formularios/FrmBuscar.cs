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
    public partial class FrmBuscar : Form
    {
        List<Hotel> _lista;
        HotelServicios _Servicios;
        public FrmBuscar( HotelServicios serv)
        {
            InitializeComponent();
            _Servicios = serv;
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
                var _hotel = ((Hotel)listBox1.SelectedItem);
                this.Tag = _hotel;
                this.Close();
            }
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
          
            listBox1.DataSource = null;
            listBox1.DataSource = _Servicios.TraerHoteles();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
