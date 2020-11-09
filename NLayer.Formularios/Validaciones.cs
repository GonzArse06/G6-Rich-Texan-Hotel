using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace NLayer.Formularios
{
    public static class Estaticas
    {
        public static string Validaciones(ControlCollection controls)
        {
            string mensaje = "";

            foreach (Control a in controls)
            {
                if (a is TextBox && a.Enabled == true && ((TextBox) a).ReadOnly == false )
                {
                    if (string.IsNullOrEmpty(a.Text))
                        mensaje = "Hay campos vacios. Revisar!";
                }
            }
            return mensaje;
        }
        public static void LimpiarTextBox(ControlCollection controls)
        {
            foreach (Control a in controls)
            {
                if (a is TextBox && a.Enabled == true && ((TextBox)a).ReadOnly == false)
                {
                    a.Text = string.Empty;
                }
            }
        }
    }
}
