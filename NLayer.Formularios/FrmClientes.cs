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
            formularios.Show();

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
            _items = (ListViewItem)lstClientes.SelectedItems[0];
            Cliente cliente = new Cliente();
            cliente.Id = int.Parse(_items.Text);
            cliente.Nombre = _items.SubItems[1].Text;
            //esto pasar a ABMCliente para cargar el form con los datos del ListView.

        }
    }
}
