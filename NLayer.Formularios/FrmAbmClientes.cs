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
    public partial class FrmAbmClientes : Form
    {
        AbmTipo _tipo;
        ClienteServicios clienteServicios ;
        public FrmAbmClientes(AbmTipo tipo, ClienteServicios serv)
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
            clienteServicios = serv;
        }
        private void InicializarAlta()
        {
            txtIdCliente.Enabled = false;
            btnBuscarCliente.Visible = false;
        }

        private void InicializarModificacion()
        {
            txtIdCliente.Enabled = false;
            btnBuscarCliente.Visible = false;
        }
            
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            lblResultado.Text = "";
            Cliente cliente = new Cliente();
            string mensaje = Estaticas.Validaciones(Controls);
            if (mensaje != "")
                MessageBox.Show(mensaje);
            else
            {
                try
                {
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
                            resultado = clienteServicios.IngresarCliente(cliente);
                            LogResultado(resultado, "Ingresar Cliente");
                            break;
                        case AbmTipo.Modificacion:
                            resultado = clienteServicios.ModificarCliente(cliente);
                            LogResultado(resultado, "Modificar Cliente");
                            break;
                    }
                    this.Close();
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
                lblResultado.Text = "ERROR -> "+mensaje;
            else
            {
                lblResultado.Text = "OK -> "+ mensaje+". ID: "+resultado;
                Estaticas.LimpiarTextBox(Controls);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
