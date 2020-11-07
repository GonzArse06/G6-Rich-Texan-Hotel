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
        Form formularios;
        ClienteServicios _clienteServicios;
        List<Cliente> _Lstclientes;
        ListViewItem _listViewItem;
        ListViewItem _items;
        public ListViewItem Item { get => _items; }
        public FrmHoteles()
        {
            InitializeComponent();
            _clienteServicios = new ClienteServicios();
            _Lstclientes = new List<Cliente>();
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

            _Lstclientes = _clienteServicios.TraerTodo();            
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
                lblResultado.Text = "Debe seleccionar una fila para realizar la modificacion.";
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstClientes.SelectedItems.Count == 1)
            {
                _items = (ListViewItem)lstClientes.SelectedItems[0];
                int resultado = _clienteServicios.EliminarCliente(int.Parse(_items.Text));
                LogResultado(resultado, "Eliminar Cliente");
            }
            else
                lblResultado.Text = "Debe seleccionar una fila para realizar la modificacion.";
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
    }
}
