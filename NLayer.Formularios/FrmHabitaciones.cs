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
    public partial class FrmHabitaciones : Form
    {
        Form formularios;
        HabitacionServicios _habitacionServicios;
        List<Habitacion> _lstHabitaciones;
        ListViewItem _listViewItem;
        ListViewItem _items;
        List<Hotel> _hoteles;
        HotelServicios _hotelServicios;

        public ListViewItem Item { get => _items; }
        public FrmHabitaciones(HabitacionServicios serv)
        {
            InitializeComponent();
            _habitacionServicios = serv;
            _lstHabitaciones = new List<Habitacion>();
            _listViewItem = new ListViewItem();
            _hoteles = new List<Hotel>();
            _hotelServicios = new HotelServicios();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                int idSeleccionado = ((Hotel)cbxHoteles.SelectedItem).Id;
                formularios = new FrmAbmHabitaciones(AbmTipo.Alta, idSeleccionado);
                formularios.Owner = this;
                formularios.ShowDialog();
                CargarListView((Hotel)cbxHoteles.SelectedItem);
        
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
}

        private void FrmHabitacion_Load(object sender, EventArgs e)
        {            
            
            cbxHoteles.DataSource = _hotelServicios.TraerTodo();
            cbxHoteles.DisplayMember = "Nombre";
            cbxHoteles.ValueMember = "Id";
        }
        private void CargarListView(Hotel _hotel)
        {
            lstHabitaciones.Items.Clear();
            if (_hotel.Habitaciones != null && _hotel.Habitaciones.Count() > 0)
            {
                
            }
            else
            {
                _hotel.Habitaciones = _habitacionServicios.TraerTodoPorId(_hotel.Id);
               
            }
            _lstHabitaciones = _hotel.Habitaciones;

            foreach (Habitacion a in _lstHabitaciones)
            {
                _listViewItem = lstHabitaciones.Items.Add(a.Id.ToString());
                _listViewItem.SubItems.Add(a.Categoria);
                _listViewItem.SubItems.Add(a.CantidadPlazas.ToString());
                _listViewItem.SubItems.Add(a.Cancelable.ToString());
                _listViewItem.SubItems.Add(a.Precio.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int idSeleccionado = ((Hotel)cbxHoteles.SelectedItem).Id;
                FrmAbmHabitaciones formulario = new FrmAbmHabitaciones(AbmTipo.Modificacion, idSeleccionado);
                if (lstHabitaciones.SelectedItems.Count == 1)
                {
                    LlenarTextboxChild(formulario);
                    formulario.Owner = this;
                    formulario.ShowDialog();
                    CargarListView((Hotel)cbxHoteles.SelectedItem);
                }
                else
                    lblResultado.Text = "Debe seleccionar una fila para realizar la modificacion.";
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }    
        }

        private void LlenarTextboxChild(FrmAbmHabitaciones formulario)
        {
            _items = (ListViewItem)lstHabitaciones.SelectedItems[0];
            formulario.txtIdHabitacion.Text = _items.Text;
            formulario.txtCategoria.Text = _items.SubItems[1].Text;
            formulario.txtCantidadPlazas.Text = _items.SubItems[2].Text;
            formulario.cbCancelable.Checked = bool.Parse(_items.SubItems[3].Text);
            formulario.txtPrecio.Text = _items.SubItems[4].Text;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstHabitaciones.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Esta seguro de Eliminar?", "Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _items = (ListViewItem)lstHabitaciones.SelectedItems[0];
                    int resultado = _habitacionServicios.EliminarHabitacion(int.Parse(_items.Text));
                    LogResultado(resultado, "Eliminar habitacion");
                }
                else
                    lblResultado.Text = "ERROR -> Debe seleccionar una fila poder eliminar.";
            }
        }

        private void LogResultado(int resultado, string mensaje)
        {
            if (resultado == -1)
                lblResultado.Text = "ERROR -> " + mensaje;
            else
            {
                lblResultado.Text = "OK -> " + mensaje + ". ID: " + resultado;
                CargarListView(((Hotel)cbxHoteles.SelectedItem));
            }
        }

        private void cbxHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListView(((Hotel)cbxHoteles.SelectedItem));
        }

        private void lstHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
