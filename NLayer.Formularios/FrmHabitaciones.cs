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
/// El formulario de transaccion cuenta con un ListView para mostrar las habitaciones del hotel seleccionado en el combobox. 
/// Este ListView actualiza la informacion en cada nuevo registro de ABM.
/// En la derecha se encuentran los botones de Alta, Modificacion, baja y la exportacion a excel de los datos del ListView.
/// En el caso de modificacion, llevamos los datos del objeto seleccionado al form de ABM
/// </summary>

namespace NLayer.Formularios
{
    public partial class FrmHabitaciones : Form
    {
        HotelServicios _hotelServicios;
        List<Habitacion> _lstHabitaciones;
        ListViewItem _listViewItem;
        ListViewItem _items;

        public FrmHabitaciones(HotelServicios serv)
        {
            InitializeComponent();
            _hotelServicios = serv;
            _lstHabitaciones = new List<Habitacion>();
            _listViewItem = new ListViewItem();
        }
        private void CargarListView(Hotel _hotel)
        {
            lstHabitaciones.Items.Clear();
            _lstHabitaciones = _hotelServicios.TraerTodoPorId(_hotel.Id);
            foreach (Habitacion a in _lstHabitaciones)
            {
                _listViewItem = lstHabitaciones.Items.Add(a.Id.ToString());
                _listViewItem.SubItems.Add(a.Categoria);
                _listViewItem.SubItems.Add(a.CantidadPlazas.ToString());
                _listViewItem.SubItems.Add(a.CancelableTexto);
                _listViewItem.SubItems.Add(a.Precio.ToString());
            }
        }
        private void LlenarTextboxChild(FrmAbmHabitaciones formulario)
        {
            _items = (ListViewItem)lstHabitaciones.SelectedItems[0];
            bool cancelable;
            if (_items.SubItems[3].Text == "SI") cancelable = true; else cancelable = false;
            formulario.txtIdHabitacion.Text = _items.Text;
            formulario.txtCategoria.Text = _items.SubItems[1].Text;
            formulario.txtCantidadPlazas.Text = _items.SubItems[2].Text;
            formulario.cbCancelable.Checked = cancelable;
            formulario.txtPrecio.Text = _items.SubItems[4].Text;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LogHelper.LimpiarLog(lblResultado);
            try
            {
                int idSeleccionado = ((Hotel)cbxHoteles.SelectedItem).Id;
                FrmAbmHabitaciones formularios = new FrmAbmHabitaciones(AbmTipo.Alta, idSeleccionado,_hotelServicios);
                formularios.Owner = this;
               
                var ret = formularios.ShowDialog();
                if (ret != DialogResult.Cancel)
                {
                    CargarListView((Hotel)cbxHoteles.SelectedItem);
                }        
            }
            catch (Exception ex)
            {
                LogHelper.LogResultado(lblResultado, false, ex.Message);
            }
        }
        private void FrmHabitacion_Load(object sender, EventArgs e)
        {            
            cbxHoteles.DataSource = _hotelServicios.TraerHoteles();
            cbxHoteles.DisplayMember = "Nombre";
            cbxHoteles.ValueMember = "Id";
        }       
        private void btnEditar_Click(object sender, EventArgs e)
        {
            LogHelper.LimpiarLog(lblResultado);
            try
            {                
                if (lstHabitaciones.SelectedItems.Count == 1)
                {
                    int idSeleccionado = ((Hotel)cbxHoteles.SelectedItem).Id;
                    FrmAbmHabitaciones formulario = new FrmAbmHabitaciones(AbmTipo.Modificacion, idSeleccionado,_hotelServicios);
                    LlenarTextboxChild(formulario);
                    formulario.Owner = this;
                    var ret = formulario.ShowDialog();
                    if (ret != DialogResult.Cancel)
                    {
                        CargarListView((Hotel)cbxHoteles.SelectedItem);
                    }                   
                }
                else
                {
                    LogHelper.LogResultado(lblResultado, false, "Debe seleccionar una fila para realizar la modificacion");
             
                }
               
            }
            catch (Exception ex)
            {
                LogHelper.LogResultado(lblResultado, false, ex.Message);
            }    
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            LogHelper.LimpiarLog(lblResultado);
            try
            {
                if (lstHabitaciones.SelectedItems.Count == 1)
                {
                    if (MessageBox.Show("Esta seguro de eliminar la habitacion?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        _items = (ListViewItem)lstHabitaciones.SelectedItems[0];
                        int resultado = _hotelServicios.EliminarHabitacion(int.Parse(_items.Text));
                        LogHelper.LogResultado(lblResultado, resultado, "Eliminar habitacion");
                        CargarListView(((Hotel)cbxHoteles.SelectedItem));
                    }
                }
                else
                {
                    LogHelper.LogResultado(lblResultado, false, "Debe seleccionar una fila poder eliminar");
                  
                }
           
            }
            catch (Exception ex)
            {
                LogHelper.LogResultado(lblResultado, false, ex.Message);
            }
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
