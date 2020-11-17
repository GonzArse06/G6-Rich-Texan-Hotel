﻿using NLayer.Entidades;
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
                            //LogResultado(resultado, "Ingresar Cliente");
                            break;
                        case AbmTipo.Modificacion:
                            resultado = _clienteServicios.ModificarCliente(cliente);
                            LogHelper.LogResultado(lblResultado, resultado, "Modificar Cliente");
                                //LogResultado(resultado, "Modificar Cliente");
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

        ////drag Form
        //[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        //private extern static void ReleaseCapture();

        //[DllImport("user32.DLL", EntryPoint = "SendMessage")]
        //private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        //private void panelTop_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ReleaseCapture();
        //    SendMessage(this.Handle, 0x112, 0xf012, 0);
        //}
    }
}
