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
    public partial class FrmReporteReservas : Form
    {
        Form formularios;
        HotelServicios _hotelServicios;
        List<Hotel> _LstHoteles;
        List<Habitacion> _LstHabitacion;
        List<Reserva> _LstReservas;
        ListViewItem _listViewItem;
        ListViewItem _items;
        public ListViewItem Item { get => _items; }
        public FrmReporteReservas(HotelServicios serv)
        {
            InitializeComponent();
            _hotelServicios = serv;
            _LstHoteles = new List<Hotel>();
            _LstHabitacion = new List<Habitacion>();
            _listViewItem = new ListViewItem();
            _LstReservas = new List<Reserva>();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            formularios = new FrmAbmHoteles(AbmTipo.Alta, _hotelServicios);
            formularios.Owner = this;
            var ret = formularios.ShowDialog();
            if (ret != DialogResult.Cancel)
            {
                CargarListView();
            }
           
        }
        private void CargarListView()
        {
            lstReporte.Items.Clear();

            _LstReservas = _hotelServicios.TraerReservas();
            //_LstHabitacion = _hotelServicios.TraerTodoPorId();
            foreach (Reserva a in _LstReservas)
            {
                TimeSpan dias = a.FechaEgreso - a.FechaIngreso;
                int days = dias.Days;
                _listViewItem = lstReporte.Items.Add(a.Id.ToString());
                _listViewItem.SubItems.Add(a.FechaIngreso.ToString("d"));
                _listViewItem.SubItems.Add(a.FechaEgreso.ToString("d"));
                _listViewItem.SubItems.Add(a.IdHabitacion.ToString());
                _listViewItem.SubItems.Add(a.CantidadHuespedes.ToString());
                _listViewItem.SubItems.Add(a.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmAbmHoteles formulario = new FrmAbmHoteles(AbmTipo.Modificacion, _hotelServicios);
            if (lstReporte.SelectedItems.Count==1)
            {
                LlenarTextboxChild(formulario);
                formulario.Owner = this;
                var ret = formulario.ShowDialog();
                if (ret != DialogResult.Cancel)
                {
                    CargarListView();
                }
            }
            else
                lblResultado.Text = "Debe seleccionar una fila para realizar la modificacion.";
        }

        private void LlenarTextboxChild(FrmAbmHoteles formularios)
        {
            _items = (ListViewItem)lstReporte.SelectedItems[0];
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
            
                if (lstReporte.SelectedItems.Count == 1)
                {
                if (MessageBox.Show("Esta seguro de Eliminar?", "Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _items = (ListViewItem)lstReporte.SelectedItems[0];
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

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarCliente formulario = new FrmBuscarCliente(_hotelServicios);
            formulario.Owner = this;
            formulario.ShowDialog();
            var obj = formulario.Tag;
            if (obj != null && obj is Cliente)
            {
                txtIdCliente.Text = ((Cliente)obj).Id.ToString();
                txtNombreCliente.Text = ((Cliente)obj).ToString();
            }
        }
    }
}
