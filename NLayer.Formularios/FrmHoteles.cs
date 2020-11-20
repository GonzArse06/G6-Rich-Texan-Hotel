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
/// El formulario de transaccion cuenta con un ListView para mostrar todos los hoteles registrados. 
/// Este ListView actualiza la informacion en cada nuevo registro de ABM.
/// En la derecha se encuentran los botones de Alta, Modificacion, baja y la exportacion a excel de los datos del ListView.
/// En el caso de modificacion, llevamos los datos del objeto seleccionado al form de ABM
/// </summary>

namespace NLayer.Formularios
{
    public partial class FrmHoteles : Form
    {
        Form _formularios;
        HotelServicios _hotelServicios;
        List<Hotel> _LstHoteles;
        ListViewItem _listViewItem;
        ListViewItem _items;
        public FrmHoteles(HotelServicios serv)
        {
            InitializeComponent();
            _hotelServicios = serv;
            _LstHoteles = new List<Hotel>();
            _listViewItem = new ListViewItem();
        }
        private void CargarListView()
        {
            lstHoteles.Items.Clear();

            _LstHoteles = _hotelServicios.TraerHoteles();
            foreach (Hotel a in _LstHoteles)
            {
                _listViewItem = lstHoteles.Items.Add(a.Id.ToString());
                _listViewItem.SubItems.Add(a.Nombre);
                _listViewItem.SubItems.Add(a.Direccion);
                _listViewItem.SubItems.Add(a.AmenitiesTexto);
                _listViewItem.SubItems.Add(a.Estrellas.ToString());
            }
        }
        private void LlenarTextboxChild(FrmAbmHoteles formularios)
        {
            _items = (ListViewItem)lstHoteles.SelectedItems[0];
            bool amenities;
            if (_items.SubItems[3].Text == "SI") amenities = true; else amenities = false;
            formularios.txtIdHotel.Text = _items.Text;
            formularios.txtNombre.Text = _items.SubItems[1].Text;
            formularios.txtDireccion.Text = _items.SubItems[2].Text;
            formularios.cbAmenities.Checked = amenities;
            formularios.nuEstrellas.Text = _items.SubItems[4].Text;
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
                _formularios = new FrmAbmHoteles(AbmTipo.Alta, _hotelServicios);
                _formularios.Owner = this;
                var ret = _formularios.ShowDialog();
                //si se cancelo, no necesito refrescar la vista
                if (ret != DialogResult.Cancel)
                {
                    CargarListView();
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogResultado(lblResultado, false, ex.Message);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            LogHelper.LimpiarLog(lblResultado);
            try
            { 
               
                if (lstHoteles.SelectedItems.Count == 1)
                {
                    FrmAbmHoteles formulario = new FrmAbmHoteles(AbmTipo.Modificacion, _hotelServicios);
                    LlenarTextboxChild(formulario);
                    formulario.Owner = this;
                    var ret = formulario.ShowDialog();
                    if (ret != DialogResult.Cancel)
                    {
                        CargarListView();
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
                if (lstHoteles.SelectedItems.Count == 1)
                {
                    if (MessageBox.Show("Esta seguro de eliminar el hotel?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        _items = (ListViewItem)lstHoteles.SelectedItems[0];
                        int resultado = _hotelServicios.EliminarHotel(int.Parse(_items.Text));
                        CargarListView();
                        LogHelper.LogResultado(lblResultado, resultado, "Eliminar Hotel");
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

        private void FrmHoteles_Load(object sender, EventArgs e)
        {
            CargarListView();
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
                    _hotelServicios.DescargarAExcel(lstHoteles.ToList(), lstHoteles.ToHeaders(), fichero.FileName);
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
