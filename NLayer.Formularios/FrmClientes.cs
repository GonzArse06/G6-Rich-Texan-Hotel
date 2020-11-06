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
    public partial class FrmClientes : Form
    {
        Form formularios;
        ClienteServicios _clienteServicios;
        List<Cliente> _cliente;
        ListViewItem _listViewItem;
        ListViewItem _items;
        public ListViewItem Item { get => _items; }
        public FrmClientes()
        {
            InitializeComponent();
            _clienteServicios = new ClienteServicios();
            _cliente = new List<Cliente>();
            _listViewItem = new ListViewItem();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            formularios = new FrmAbmClientes(AbmTipo.Alta);
            formularios.Owner = this;
            formularios.ShowDialog();
            CargarListView();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {            
            CargarListView();

        }
        private void CargarListView()
        {
            lstClientes.Items.Clear();

            _cliente = _clienteServicios.TraerTodo();            
            foreach (Cliente a in _cliente)
            {
                _listViewItem = lstClientes.Items.Add(a.Id.ToString());
                _listViewItem.SubItems.Add(a.Nombre);
                _listViewItem.SubItems.Add(a.Apellido);
                _listViewItem.SubItems.Add(a.Direccion);
                _listViewItem.SubItems.Add(a.Email);
                _listViewItem.SubItems.Add(a.Telefono.ToString());
                _listViewItem.SubItems.Add(a.FechaAlta.ToString("d"));
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmAbmClientes formularios = new FrmAbmClientes(AbmTipo.Modificacion);
            formularios.Owner = this;
            if (lstClientes.SelectedItems.Count==1)
            {
                LlenarTextboxChild(formularios);
                formularios.Owner = this;
                formularios.ShowDialog();
                CargarListView();
            }
            else
                lblResutadoTx.Text = "Debe seleccionar una fila para realizar la modificacion.";
        }

        private void LlenarTextboxChild(FrmAbmClientes formularios)
        {
            _items = (ListViewItem)lstClientes.SelectedItems[0];
            formularios.txtIdCliente.Text = _items.Text;
            formularios.txtNombre.Text = _items.SubItems[1].Text;
            formularios.txtApellido.Text = _items.SubItems[2].Text;
            formularios.txtDireccion.Text = _items.SubItems[3].Text;
            formularios.txtMail.Text = _items.SubItems[4].Text;
            formularios.txtTelefono.Text = _items.SubItems[5].Text;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
