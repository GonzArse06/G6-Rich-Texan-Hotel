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
/// El formulario de transaccion cuenta con un ListView para mostrar todos los clientes registrados. este se actualiza en cada ABM.
/// En la derecha se encuentran los botones de Alta, Modificacion, baja y la exportacion a excel de los datos del ListView.
/// 
/// </summary>

namespace NLayer.Formularios
{
    public partial class FrmClientes : Form
    {
        private Form formularios;
        private HotelServicios _clienteServicios;
        private List<Cliente> _Lstclientes;
        private ListViewItem _listViewItem;
        private ListViewItem _items;

        public FrmClientes(HotelServicios serv)
        {
            InitializeComponent();
            _clienteServicios = serv;
            _listViewItem = new ListViewItem();
        }

        private void CargarListView()
        {
            lstClientes.Items.Clear();
            _Lstclientes = _clienteServicios.TraerClientes();

            foreach (Cliente a in _Lstclientes)
            {
                _listViewItem = lstClientes.Items.Add(a.Id.ToString());
                _listViewItem.SubItems.Add(a.Dni.ToString());
                _listViewItem.SubItems.Add(a.Nombre);
                _listViewItem.SubItems.Add(a.Apellido);
                _listViewItem.SubItems.Add(a.Direccion);
                _listViewItem.SubItems.Add(a.Email);
                _listViewItem.SubItems.Add(a.Telefono.ToString());
                _listViewItem.SubItems.Add(a.FechaAlta.ToString("d"));
            }
        }
        private void LlenarTextboxChild(FrmAbmClientes formularios)
        {
            _items = (ListViewItem)lstClientes.SelectedItems[0];
            formularios.txtIdCliente.Text = _items.Text;
            formularios.txtDni.Text = _items.SubItems[1].Text;
            formularios.txtNombre.Text = _items.SubItems[2].Text;
            formularios.txtApellido.Text = _items.SubItems[3].Text;
            formularios.txtDireccion.Text = _items.SubItems[4].Text;
            formularios.txtMail.Text = _items.SubItems[5].Text;
            formularios.txtTelefono.Text = _items.SubItems[6].Text;
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
                formularios = new FrmAbmClientes(AbmTipo.Alta, _clienteServicios);
                formularios.Owner = this;
                var ret = formularios.ShowDialog();
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
        private void FrmClientes_Load(object sender, EventArgs e)
        {            
            CargarListView();

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            LogHelper.LimpiarLog(lblResultado);
            try
            {
                FrmAbmClientes formularios = new FrmAbmClientes(AbmTipo.Modificacion, _clienteServicios);
                formularios.Owner = this;
                if (lstClientes.SelectedItems.Count == 1)
                {
                    LlenarTextboxChild(formularios);
                    formularios.Owner = this;
                    var ret = formularios.ShowDialog();
                    if (ret != DialogResult.Cancel)
                    {
                        CargarListView();
                    }
                }
                else
                    lblResultado.Text = "ERROR ->Debe seleccionar una fila para realizar la modificacion.";
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
                if (lstClientes.SelectedItems.Count == 1)
                {
                    if (MessageBox.Show("Esta seguro de eliminar el cliente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        _items = (ListViewItem)lstClientes.SelectedItems[0];
                        var resultado = _clienteServicios.EliminarCliente(int.Parse(_items.Text));
                        LogHelper.LogResultado(lblResultado, resultado, "Eliminar Cliente");
                        if (resultado)
                        {
                            CargarListView();
                        }
                    }
                }
                else
                  lblResultado.Text = "ERROR -> Debe seleccionar una fila poder eliminar.";
                
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                lblResultado.Text = "Exportando...";
                _clienteServicios.DescargarAExcel(lstClientes.ToList(), lstClientes.ToHeaders());
                lblResultado.Text = "OK -> Exportacion exitosa.";
            }
            catch (Exception ex)
            {
                lblResultado.Text = "ERROR -> " + ex.Message;
            }
        }
    }
}
