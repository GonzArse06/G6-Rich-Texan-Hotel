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
    public partial class FrmHabitaciones : Form
    {
        Form formularios;
        HabitacionServicios _habitacionServicios;
        List<Habitacion> _lstHabitaciones;
        ListViewItem _listViewItem;
        ListViewItem _items;
        public ListViewItem Item { get => _items; }
        public FrmHabitaciones()
        {
            InitializeComponent();
            _habitacionServicios = new HabitacionServicios();
            _lstHabitaciones = new List<Habitacion>();
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
            string mensaje = ControlIDHotel();
            if (string.IsNullOrEmpty(mensaje))
            {
                formularios = new FrmAbmHabitaciones(AbmTipo.Alta,int.Parse(txtIdHotel.Text));
                formularios.Owner = this;
                formularios.ShowDialog();
                CargarListView(int.Parse(txtIdHotel.Text));
            }
            else
                MessageBox.Show(mensaje,"Error");
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {            

        }
        private void CargarListView(int idHotel)
        {
            lstHabitaciones.Items.Clear();

            _lstHabitaciones = _habitacionServicios.TraerTodoPorId(idHotel);            
            foreach (Habitacion a in _lstHabitaciones)
            {
                _listViewItem = lstHabitaciones.Items.Add(a.Id.ToString());
                _listViewItem.SubItems.Add(a.Categoria);
                _listViewItem.SubItems.Add(a.CantidadPlazas.ToString());
                _listViewItem.SubItems.Add(a.Cancelable.ToString());
                _listViewItem.SubItems.Add(a.Precio.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string mensaje = ControlIDHotel();
            if (string.IsNullOrEmpty(mensaje))
            {
                FrmAbmHabitaciones formulario = new FrmAbmHabitaciones(AbmTipo.Modificacion, int.Parse(txtIdHotel.Text));
                //formulario.Owner = this;
                if (lstHabitaciones.SelectedItems.Count == 1)
                {
                    LlenarTextboxChild(formulario);
                    formularios.Owner = this;
                    formularios.ShowDialog();
                    CargarListView(int.Parse(txtIdHotel.Text));
                }
                else
                    lblResultado.Text = "Debe seleccionar una fila para realizar la modificacion.";
            }
            else
                MessageBox.Show(mensaje);
        }

        private void LlenarTextboxChild(FrmAbmHabitaciones formulario)
        {
            _items = (ListViewItem)lstHabitaciones.SelectedItems[0];
            formulario.txtIdHabitacion.Text = _items.Text;
            formulario.txtCategoria.Text = _items.SubItems[1].Text;
            formulario.txtCantidadPlazas.Text = _items.SubItems[2].Text;
            formulario.cbCancelable.CheckOnClick = bool.Parse(_items.SubItems[3].Text);
            formulario.txtPrecio.Text = _items.SubItems[4].Text;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstHabitaciones.SelectedItems.Count == 1)
            {
                _items = (ListViewItem)lstHabitaciones.SelectedItems[0];
                int resultado = _habitacionServicios.EliminarHabitacion(int.Parse(_items.Text));
                LogResultado(resultado, "Eliminar habitacion");
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
                CargarListView(int.Parse(txtIdHotel.Text));
            }
        }

        private void txtIdHotel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                CargarListView(int.Parse(txtIdHotel.Text));
            }
        }
        private string ControlIDHotel()
        {
            string mensaje = "";
            if (string.IsNullOrEmpty(txtIdHotel.Text))
                mensaje = "Debe haber un id de hotel para continuar";
            return mensaje;
        }

        private void btnBuscarHotel_Click(object sender, EventArgs e)
        {
            string mensaje = ControlIDHotel();
            if (string.IsNullOrEmpty(mensaje))
                CargarListView(int.Parse(txtIdHotel.Text));
            else
                MessageBox.Show(mensaje, "Error");
        }
    }
}
