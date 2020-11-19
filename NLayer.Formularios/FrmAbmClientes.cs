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
using System.Runtime.InteropServices;

/// <summary>
/// El formulario de ABM realiza las operaciones de Alta y Modificacion. (La baja se gestiona en el form de transaccion.)
/// En el contructor pasamos un enum para identificar el tipo de operacion y el objeto de hotelservicio para no instanciar uno nuevo.
/// Usamos un metodo estatico para validar los input y un controlador de usuarios personalizado de tipo TextBox para los campos numericos.
/// 
/// </summary>

namespace NLayer.Formularios
{
    public partial class FrmAbmClientes : Form
    {
        AbmTipo _tipo;
        HotelServicios _clienteServicios ;
        public FrmAbmClientes(AbmTipo tipo, HotelServicios serv)
        {
            InitializeComponent();
            _tipo = tipo;
            switch (_tipo)
            {
                case AbmTipo.Alta:
                    InicializarAlta();
                    break;
                case AbmTipo.Modificacion:
                    InicializarModificacion();
                    break;
            }
            _clienteServicios = serv;
        }
        private void InicializarAlta()
        {
            txtIdCliente.Enabled = false;
            btnBuscarCliente.Visible = false;
            Text = "Nuevo Cliente";
        }

        private void InicializarModificacion()
        {
            txtIdCliente.Enabled = false;
            btnBuscarCliente.Visible = false;
            Text = "Modificar Cliente";
        }
        private void Guardar()
        {
            lblResultado.Text = "";
           
            string mensaje = Estaticas.Validaciones(Controls);

            if (mensaje != "")
            {
                MessageBox.Show(mensaje);
            }
            else if (!ValidationHelper.IsValidEmail(txtMail.Text))
            {
                MessageBox.Show("Email invalido");
            }
            else
            {
                try
                {
                    Cliente cliente = new Cliente();
                    if (_tipo != AbmTipo.Alta)
                        cliente.Id = int.Parse(txtIdCliente.Text);

                    cliente.Dni = int.Parse(txtDni.Text);
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Email = txtMail.Text;
                    cliente.Telefono = int.Parse(txtTelefono.Text);
                    int resultado = -1;
                    switch (_tipo)
                    {
                        case AbmTipo.Alta:
                            resultado = _clienteServicios.IngresarCliente(cliente);
                            LogHelper.LogResultado(lblResultado, resultado, "Ingresar Cliente");
                            break;
                        case AbmTipo.Modificacion:
                            resultado = _clienteServicios.ModificarCliente(cliente);
                            LogHelper.LogResultado(lblResultado, resultado, "Modificar Cliente");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;           
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
