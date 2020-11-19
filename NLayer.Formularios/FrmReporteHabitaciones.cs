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
/// El formulario de Reoporte cuenta con un ListView para mostrar todo el detalle de las habitaciones por el hotel seleccionado del combobox.
/// Tiene un boton para exportar la informacion del ListView a Excel.
/// </summary>

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
                    _listViewItem.SubItems.Add(a.CancelableTexto);
                    _listViewItem.SubItems.Add(a.Precio.ToString());
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogResultado(lblResultado, false, ex.Message);
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

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    _hotelServicios.DescargarAExcel(lstHabitaciones.ToList(), lstHabitaciones.ToHeaders(), fichero.FileName);
                    LogHelper.LogResultado(lblResultado, true, "Exportacion exitosa");

                }
                lblResultado.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LogHelper.LogResultado(lblResultado, false, ex.Message);
            }
           
        }
    }
}
