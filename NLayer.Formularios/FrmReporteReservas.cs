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
        HotelServicios _hotelServicios;
        List<Hotel> _LstHoteles;
        List<Habitacion> _LstHabitacion;
        List<Reserva> _LstReservas;
        ListViewItem _listViewItem;
        public FrmReporteReservas(HotelServicios serv)
        {
            InitializeComponent();
            _hotelServicios = serv;
            _LstHoteles = new List<Hotel>();
            _LstHabitacion = new List<Habitacion>();
            _listViewItem = new ListViewItem();
            _LstReservas = new List<Reserva>();
            _LstReservas = _hotelServicios.TraerReservas();
            _LstHoteles = _hotelServicios.TraerHoteles();
            CargarHabitaciones(_LstHoteles);

        }
        private void CargarHabitaciones(List<Hotel> lsthoteles)
        {
            foreach (Hotel a in lsthoteles)
            {
                _LstHabitacion.AddRange(_hotelServicios.TraerTodoPorId(a.Id));
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarListView(int idCliente)
        {
            lstReporte.Items.Clear();
            double PrecioFinal = 0;
            foreach (Reserva a in _LstReservas)
            {
                if(a.IdCliente == idCliente)
                { 
                    TimeSpan dias = a.FechaEgreso - a.FechaIngreso;
                    int days = dias.Days;
                    Habitacion habitacion = _LstHabitacion.SingleOrDefault(x => x.Id == a.IdHabitacion);
                    if (habitacion != null) 
                    {
                        double precio = habitacion.Precio * days;
                        PrecioFinal += precio;
                        _listViewItem = lstReporte.Items.Add(a.Id.ToString());
                        _listViewItem.SubItems.Add(a.FechaIngreso.ToString("d"));
                        _listViewItem.SubItems.Add(a.FechaEgreso.ToString("d"));
                        _listViewItem.SubItems.Add(a.IdHabitacion.ToString());
                        _listViewItem.SubItems.Add(a.CantidadHuespedes.ToString());
                        _listViewItem.SubItems.Add(precio.ToString());
                    }
                    txtImporteTotal.Text = PrecioFinal.ToString();
                }                
            }
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

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCliente.Text))
                lblResultado.Text = "ERROR -> Debe seleccionar un cliente";
            else
            {
                CargarListView(int.Parse(txtIdCliente.Text));
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                _hotelServicios.DescargarAExcel(lstReporte);
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
            finally
            {
                lblResultado.Text = "OK -> Exportacion exitosa.";
            }
        }
    }
}
