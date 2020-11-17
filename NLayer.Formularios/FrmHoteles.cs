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
            formularios.cbAmenities.Checked = amenities;// _items.SubItems[3].Text;
            formularios.nuEstrellas.Text = _items.SubItems[4].Text;
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
                if (ret != DialogResult.Cancel)
                {
                    CargarListView();
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            LogHelper.LimpiarLog(lblResultado);
            try
            { 
                FrmAbmHoteles formulario = new FrmAbmHoteles(AbmTipo.Modificacion, _hotelServicios);
                if (lstHoteles.SelectedItems.Count == 1)
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
                    lblResultado.Text = "ERROR -> Debe seleccionar una fila para realizar la modificacion.";
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
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
                        LogResultado(resultado, "Eliminar Hotel");
                    }
                }
                else
                        lblResultado.Text = "ERROR -> Debe seleccionar una fila para poder eliminar.";
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> "+ex.Message;
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
                _hotelServicios.DescargarAExcel(lstHoteles);
                lblResultado.Text = "OK -> Exportacion exitosa.";
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
        }
    }
}
