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
    public partial class FrmReservas : Form
    {
        Form _formularios;      
        List<Reserva> _lstReservas;
        List<Habitacion> _lstHabitaciones;
        ListViewItem _listViewItem;
        ListViewItem _items;
        List<Cliente> _lstClientes;
        HotelServicios _hotelServicios;
  
        public FrmReservas(HotelServicios srv)
        {
            InitializeComponent();           
            _lstReservas = new List<Reserva>();
            _lstHabitaciones = new List<Habitacion>();
            _listViewItem = new ListViewItem();
            _lstClientes = new List<Cliente>();
            _hotelServicios = srv;                    
        }
        private void CargarListView(Hotel hotel)
        {
            lstReservas.Items.Clear();
            _lstReservas = _hotelServicios.TraerReservas();
            /*if (_hotel.Habitaciones != null && _hotel.Habitaciones.Count() > 0)
            {             }
            else
            {                _hotel.Habitaciones = _hotelServicios.TraerTodoPorId(_hotel.Id);
            }
            _lstHabitaciones = _hotel.Habitaciones;
            foreach (var h in _hotel.Habitaciones)
            {                h.Reservas = _lstReservas.Where(o => o.IdHabitacion == h.Id).ToList();
            }            var misreservas = _lstReservas.Where(o => _lstHabitaciones.Select(p => p.Id).Contains(o.IdHabitacion));
             */

            _lstHabitaciones = _hotelServicios.TraerTodoPorId(hotel.Id);
            var misreservas = _lstReservas.Where(o => _lstHabitaciones.Select(p => p.Id).Contains(o.IdHabitacion));

            foreach (Reserva a in misreservas)
            {
                Cliente cliente = _lstClientes.SingleOrDefault(x => x.Id == a.IdCliente);
                if (cliente != null)
                {
                    _listViewItem = lstReservas.Items.Add(a.Id.ToString());
                    _listViewItem.SubItems.Add(a.IdHabitacion.ToString());
                    _listViewItem.SubItems.Add(a.IdCliente.ToString());
                    _listViewItem.SubItems.Add(cliente.ToString());
                    _listViewItem.SubItems.Add(a.CantidadHuespedes.ToString());
                    _listViewItem.SubItems.Add(a.FechaIngreso.ToString("d"));
                    _listViewItem.SubItems.Add(a.FechaEgreso.ToString("d"));
                }
            }
        }
        
        private void LlenarTextboxChild(FrmAbmReservas formulario)
        {
            _items = (ListViewItem)lstReservas.SelectedItems[0];
            formulario.txtIdReserva.Text = _items.Text;
            formulario.txtIdHabitacion.Text = _items.SubItems[1].Text;
            formulario.txtIdCliente.Text = _items.SubItems[2].Text;
            formulario.txtNroHuespedes.Text = _items.SubItems[4].Text;
            formulario.dtFechaIngreso.Text = _items.SubItems[5].Text;
            formulario.dtFechaEgreso.Text = _items.SubItems[6].Text;
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
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                int idSeleccionado = ((Hotel)cbxHoteles.SelectedItem).Id;
                _formularios = new FrmAbmReservas(AbmTipo.Alta, idSeleccionado, _hotelServicios);
                _formularios.Owner = this;
                var ret = _formularios.ShowDialog();
                if (ret != DialogResult.Cancel)
                {
                    CargarListView((Hotel)cbxHoteles.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int idSeleccionado = ((Hotel)cbxHoteles.SelectedItem).Id;
                FrmAbmReservas formulario = new FrmAbmReservas(AbmTipo.Modificacion, idSeleccionado, _hotelServicios);
                if (lstReservas.SelectedItems.Count == 1)
                {
                    LlenarTextboxChild(formulario);
                    formulario.Owner = this;
                    var ret = formulario.ShowDialog();
                    if (ret != DialogResult.Cancel)
                    {
                        CargarListView((Hotel)cbxHoteles.SelectedItem);
                    }
                }
                else
                    lblResultado.Text = "ERROR -> Debe seleccionar una fila para realizar la modificacion.";
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try 
            { 
                if (lstReservas.SelectedItems.Count == 1)
                {
                    if (MessageBox.Show("Esta seguro de Eliminar?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        _items = (ListViewItem)lstReservas.SelectedItems[0];
                        int resultado = _hotelServicios.EliminarReserva(int.Parse(_items.Text));
                        LogResultado(resultado, "Eliminar reserva");
                    }
                }
                else
                    lblResultado.Text = "ERROR -> Debe seleccionar una fila para poder eliminar.";
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
        }

        private void cbxHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListView(((Hotel)cbxHoteles.SelectedItem));
        }

        private void FrmReservas_Load(object sender, EventArgs e)
        {
            _lstClientes = _hotelServicios.TraerClientes();
            cbxHoteles.DataSource = _hotelServicios.TraerHoteles();
            cbxHoteles.DisplayMember = "Nombre";
            cbxHoteles.ValueMember = "Id";
        }
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                lblResultado.Text = "Exportando...";
                _hotelServicios.DescargarAExcel(lstReservas);
                lblResultado.Text = "OK -> Exportacion exitosa.";
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
        }
    }
}
