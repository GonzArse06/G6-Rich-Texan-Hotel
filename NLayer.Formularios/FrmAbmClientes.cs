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

namespace NLayer.Formularios
{
    public partial class FrmAbmClientes : Form
    {
        
        public FrmAbmClientes(AbmTipo tipo)
        {
            InitializeComponent();
            switch (tipo)
            {
                case AbmTipo.Alta:
                    InicializarAlta();
                    break;
                case AbmTipo.Baja:
                    //
                    break;
                case AbmTipo.Modificacion:
                    //
                    break;

            }
        }
        private void InicializarAlta()
        {
            txtIdCliente.Enabled = false;
            btnBuscarCliente.Visible = false;
        }
            
        private void btnGuardar_Click(object sender, EventArgs e)
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
                int resultado = clienteServicios.IngresarCliente(cliente);
                if (resultado == -1)
                    lblResultado.Text = "No se pudo crear el cliente";
                else
                { 
                    lblResultado.Text = "Se creo con exito el cliente ID " + resultado;
                    LimpiarTextBox();
                }

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
                        mensaje = "No puede haber textos vacios";
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
