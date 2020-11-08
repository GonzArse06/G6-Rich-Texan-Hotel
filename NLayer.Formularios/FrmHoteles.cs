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
    public partial class FrmHoteles : Form
    {
        Form formularios;
        HotelServicios _hotelServicios;
        List<Hotel> _LstHoteles;
        ListViewItem _listViewItem;
        ListViewItem _items;
        public ListViewItem Item { get => _items; }
        public FrmHoteles()
        {
            InitializeComponent();
            _hotelServicios = new HotelServicios();
            _LstHoteles = new List<Hotel>();
            _listViewItem = new ListViewItem();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            formularios = new FrmAbmHoteles(AbmTipo.Alta);
            formularios.Owner = this;
            formularios.ShowDialog();
            CargarListView();
        }
        private void CargarListView()
        {
            lstHoteles.Items.Clear();

            _LstHoteles = _hotelServicios.TraerTodo();            
            foreach (Hotel a in _LstHoteles)
            {
                _listViewItem = lstHoteles.Items.Add(a.Id.ToString());
                _listViewItem.SubItems.Add(a.Nombre);
                _listViewItem.SubItems.Add(a.Direccion);
                _listViewItem.SubItems.Add(a.Amenities.ToString());
                _listViewItem.SubItems.Add(a.Estrellas.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmAbmHoteles formulario = new FrmAbmHoteles(AbmTipo.Modificacion);
            if (lstHoteles.SelectedItems.Count==1)
            {
                LlenarTextboxChild(formulario);
                formulario.Owner = this;
                formulario.ShowDialog();
                CargarListView();
            }
            else
                lblResultado.Text = "Debe seleccionar una fila para realizar la modificacion.";
        }

        private void LlenarTextboxChild(FrmAbmHoteles formularios)
        {
            _items = (ListViewItem)lstHoteles.SelectedItems[0];
            formularios.txtIdHotel.Text = _items.Text;
            formularios.txtNombre.Text = _items.SubItems[1].Text;
            formularios.txtDireccion.Text = _items.SubItems[2].Text;
            formularios.cbAmenities.Text = _items.SubItems[3].Text;
            formularios.nuEstrellas.Text = _items.SubItems[4].Text;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
                if (lstHoteles.SelectedItems.Count == 1)
                {
                if (MessageBox.Show("Esta seguro de Eliminar el cliente?", "Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _items = (ListViewItem)lstHoteles.SelectedItems[0];
                    int resultado = _hotelServicios.EliminarHotel(int.Parse(_items.Text));
                    LogResultado(resultado, "Eliminar Hotel");
                }
                else
                    lblResultado.Text = "ERROR -> Debe seleccionar una fila para poder eliminar.";
            }
        }

        private void LogResultado(int resultado, string mensaje)
        {
            if (resultado == -1)
                lblResultado.Text = "ERROR -> " + mensaje;
            else
            {
                lblResultado.Text = "OK -> " + mensaje + ". ID: " + resultado;
                CargarListView();
            }
        }

        private void FrmHoteles_Load(object sender, EventArgs e)
        {
            CargarListView();
        }
    }
}
