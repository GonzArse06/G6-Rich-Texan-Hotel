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
    public partial class FrmReporteHabitaciones : Form
    {
        HotelServicios _hotelServicios;
        List<Habitacion> _lstHabitaciones;
        ListViewItem _listViewItem;

        public FrmReporteHabitaciones(HotelServicios serv)
        {
            InitializeComponent();
            _hotelServicios = serv;
            _lstHabitaciones = new List<Habitacion>();
            _listViewItem = new ListViewItem();
        }
        private void CargarListView(Hotel _hotel)
        {
            try 
            { 
                lstHabitaciones.Items.Clear();

                _hotel.Habitaciones = _hotelServicios.TraerTodoPorId(_hotel.Id);

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
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
        private void FrmHabitacion_Load(object sender, EventArgs e)
        {            
            cbxHoteles.DataSource = _hotelServicios.TraerHoteles();
            cbxHoteles.DisplayMember = "Nombre";
            cbxHoteles.ValueMember = "Id";
        }        
        private void cbxHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListView(((Hotel)cbxHoteles.SelectedItem));
        }
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                lblResultado.Text = "Exportando...";
                _hotelServicios.DescargarAExcel(lstHabitaciones);
                lblResultado.Text = "OK -> Exportacion exitosa.";
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
        }
    }
}
