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
    public partial class FrmAbmHoteles : Form
    {
        AbmTipo _tipo;
        public FrmAbmHoteles(AbmTipo tipo)
        {
            InitializeComponent();
            _tipo = tipo;
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
            Hotel hotel = new Hotel();
            string mensaje = Estaticas.Validaciones(Controls);
            if (mensaje != "")
                MessageBox.Show(mensaje);
            else
            {
                try
                {
                    if (_tipo != AbmTipo.Alta)
                        hotel.Id = int.Parse(txtIdHotel.Text);
                    hotel.Nombre = txtNombre.Text;
                    hotel.Direccion = txtDireccion.Text;
                    hotel.Amenities = cbAmenities.Checked;
                    hotel.Estrellas = int.Parse(nuEstrellas.Value.ToString());

                    HotelServicios hotelServicios = new HotelServicios();
                    int resultado = -1;
                    switch (_tipo)
                    {
                        case AbmTipo.Alta:
                            resultado = hotelServicios.IngresarHotel(hotel);
                            LogResultado(resultado, "Ingresar Hotel");
                            break;
                        case AbmTipo.Modificacion:
                            resultado = hotelServicios.ModificarHotel(hotel);
                            LogResultado(resultado, "Modificar Hotel");
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
                Estaticas.LimpiarTextBox(Controls); //LimpiarTextBox();
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
    }
}
