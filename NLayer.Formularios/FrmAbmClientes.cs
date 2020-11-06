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
        public FrmAbmClientes(AbmTipo tipo)
        {
            InitializeComponent();
            _tipo = tipo;
            switch (_tipo)
            {
                case AbmTipo.Alta:
                    InicializarAlta();
                    break;
                case AbmTipo.Baja:
                    //
                    break;
                case AbmTipo.Modificacion:
                    InicializarModificacion();
                    break;
            }
        }
        private void InicializarAlta()
        {
            txtIdCliente.Enabled = false;
            btnBuscarCliente.Visible = false;
        }

        private void InicializarModificacion()
        {
            txtIdCliente.Enabled = false;
            btnBuscarCliente.Visible = true;
        }
            
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            lblResultado.Text = "";
            Cliente cliente = new Cliente();
            string mensaje = Validaciones();
            if (mensaje != "")
                MessageBox.Show(mensaje);
            else
            {
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Telefono = int.Parse(txtTelefono.Text);
                cliente.Email = txtMail.Text;
                ClienteServicios clienteServicios = new ClienteServicios();
                int resultado=-1;
                switch (_tipo)
                {
                    case AbmTipo.Alta:
                        resultado = clienteServicios.IngresarCliente(cliente);
                        LogResultado(resultado, "Ingresar Cliente");
                        break;
                    case AbmTipo.Baja:
                        //
                        break;
                    case AbmTipo.Modificacion:
                        resultado = clienteServicios.ModificarCliente(cliente);
                        LogResultado(resultado, "Modificar Cliente");
                        break;
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
                LimpiarTextBox();
            }
        }

        private string Validaciones()
        {
            string mensaje = "";

            foreach (Control a in Controls)
            {
                if (a is TextBox && a.Enabled == true)
                {
                    if (string.IsNullOrEmpty(a.Text))
                        mensaje = "Hay campos vacios. Revisar!";
                }
            }
            return mensaje;
        }
        private void LimpiarTextBox()
        {
            foreach (Control a in Controls)
            {
                if (a is TextBox && a.Enabled == true)
                {
                    a.Text = string.Empty;
                }
            }
        }
    }
}
