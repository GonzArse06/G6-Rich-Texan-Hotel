using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLayer.Negocios;

namespace NLayer.Formularios
{
    public partial class FrmAbmHabitaciones : Form
    {
        AbmTipo _tipo;
        int _idHotel;
        public FrmAbmHabitaciones(AbmTipo tipo, int idHotel)
        {
            InitializeComponent();
            _tipo = tipo;
            _idHotel = idHotel;
        }
        private void cbCancelable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        private void Guardar()
        {
            lblResultado.Text = "";
            Habitacion habitacion = new Habitacion();
            string mensaje = Estaticas.Validaciones(Controls);
            if (mensaje != "")
                MessageBox.Show(mensaje);
            else
            {
                try
                {
                    if (_tipo != AbmTipo.Alta)
                        habitacion.Id = int.Parse(txtIdHabitacion.Text);
                    habitacion.IdHotel = _idHotel;
                    habitacion.Categoria = txtCategoria.Text;
                    habitacion.CantidadPlazas = int.Parse(txtCantidadPlazas.Text);
                    habitacion.Cancelable = cbCancelable.Checked;
                    habitacion.Precio = double.Parse(txtPrecio.Text);

                    HotelServicios habitacionServicios = new HotelServicios();
                    int resultado = -1;
                    switch (_tipo)
                    {
                        case AbmTipo.Alta:
                            resultado = habitacionServicios.IngresarHabitacion(habitacion);
                            LogResultado(resultado, "Ingresar Habitacion");
                            break;
                        case AbmTipo.Modificacion:
                            resultado = habitacionServicios.ModificarHabitacion(habitacion);
                            LogResultado(resultado, "Modificar Habitacion");
                            break;
                    }
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception e)
                {
                    lblResultado.Text = "ERROR -> " + e.Message;
                }
            }
        }
        private void LogResultado(int resultado, string mensaje)
        {
            if (resultado == -1)
                lblResultado.Text = "ERROR -> " + mensaje;
            else
            {
                lblResultado.Text = "OK -> " + mensaje + ". ID: " + resultado;
                Estaticas.LimpiarTextBox(Controls); //LimpiarTextBox();
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (MessageBox.Show("Esta seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void btnBuscarHotel_Click(object sender, EventArgs e)
        {

        }

        private void lblIidHabitacion_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
