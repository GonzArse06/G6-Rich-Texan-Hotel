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
    public partial class FrmAbmReservas : Form
    {
        AbmTipo _tipo;
        public FrmAbmReservas(AbmTipo tipo)
        {
            InitializeComponent();
            _tipo = tipo;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        private void Guardar()
        {
            lblResultado.Text = "";
            Reserva reserva = new Reserva();
            string mensaje = Estaticas.Validaciones(Controls);
            if (mensaje != "")
                MessageBox.Show(mensaje);
            else
            {
                try
                {
                    if (_tipo != AbmTipo.Alta)
                        reserva.Id = int.Parse(txtIdReserva.Text);
                    reserva.IdHabitacion = int.Parse(txtIdHabitacion.Text);
                    reserva.IdCliente = int.Parse(txtIdCliente.Text);
                    reserva.CantidadHuespedes = int.Parse(txtNroHuespedes.Text);
                    reserva.FechaIngreso = dtFechaIngreso.Value;
                    reserva.FechaEgreso = dtFechaEgreso.Value;
                    ReservaServicios reservaServicios = new ReservaServicios();
                    int resultado = -1;
                    switch (_tipo)
                    {
                        case AbmTipo.Alta:
                            resultado = reservaServicios.IngresarReserva(reserva);
                            LogResultado(resultado, "Ingresar Reserva");
                            break;
                        case AbmTipo.Modificacion:
                            resultado = reservaServicios.ModificarReserva(reserva);
                            LogResultado(resultado, "Modificar Reserva");
                            break;
                    }
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
                Estaticas.LimpiarTextBox(Controls); 
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarHabitacion_Click(object sender, EventArgs e)
        {

        }
    }
}
