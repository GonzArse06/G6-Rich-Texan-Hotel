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
/// El formulario de Reoporte cuenta con un ListView para mostrar todo el detalle de las reservas de un cliente seleccionado.
/// Para ejecutar el reporte es necesario tener el ID del cliente. Este se puede escribir directamente en el TextBox o buscarlo desde el boton de busqueda (form buscar cliente).
/// el reporte muestra el importe total a pagar por cada reserva y un TextBox con el importe total, suma de todos los totales de reserva.
/// </summary>

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

        private void CargarListView(int idCliente)
        {
            double PrecioFinal = 0;
       
            foreach (Reserva a in _LstReservas.Where(o => o.IdCliente == idCliente))
            {
                double precio = 0;
               

                Habitacion habitacion = _LstHabitacion.SingleOrDefault(x => x.Id == a.IdHabitacion);
                string categoria = habitacion == null? string.Empty: habitacion.Categoria;
                if (habitacion != null && habitacion.Precio > 0) 
                {
                    int days = (a.FechaEgreso - a.FechaIngreso).Days;
                    precio = habitacion.Precio * days;
                    PrecioFinal += precio;
                }

                _listViewItem = lstReporte.Items.Add(a.Id.ToString());
                _listViewItem.SubItems.Add(a.FechaIngreso.ToString("d"));
                _listViewItem.SubItems.Add(a.FechaEgreso.ToString("d"));
                _listViewItem.SubItems.Add(a.IdHabitacion.ToString());
                _listViewItem.SubItems.Add(categoria);
                _listViewItem.SubItems.Add(a.CantidadHuespedes.ToString());
                _listViewItem.SubItems.Add(string.Format("{0:c}", precio));

            }
            txtImporteTotal.Text = string.Format("{0:c}", PrecioFinal);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                LogHelper.LogResultado(lblResultado, false, ex.Message);
            }
}
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            try 
            {
                if (string.IsNullOrEmpty(txtIdCliente.Text))
                {
                    LogHelper.LogResultado(lblResultado, false, "Debe seleccionar un cliente");
                   
                }
         
                else
                {
                    int idCliente = int.Parse(txtIdCliente.Text);
                    Cliente cliente = _hotelServicios.TraerClientes().SingleOrDefault(x => x.Id == idCliente);
                    if (cliente == null)
                    {
                        LogHelper.LogResultado(lblResultado, false, "El cliente no existe");
                        
                    }
           
                    else
                    {
                        txtNombreCliente.Text = cliente.ToString();
                        lstReporte.Items.Clear();
                        CargarListView(idCliente);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogResultado(lblResultado, false, ex.Message);
            }
        }
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                lblResultado.Text = "Exportando...";

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    _hotelServicios.DescargarAExcel(lstReporte.ToList(), lstReporte.ToHeaders(), fichero.FileName);
                    LogHelper.LogResultado(lblResultado, true, "Exportacion exitosa");

                }
                lblResultado.Text = string.Empty;

            }
            catch (Exception ex)
            {
                LogHelper.LogResultado(lblResultado, false, ex.Message);
            }
           
        }

        private void lstReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
