using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;
using static System.Windows.Forms.ListViewItem;

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
        //public static void LimpiarTextBox(ControlCollection controls)
        //{
        //    foreach (Control a in controls)
        //    {
        //        if (a is TextBox && a.Enabled == true && ((TextBox)a).ReadOnly == false)
        //        {
        //            a.Text = string.Empty;
        //        }
        //    }
        //}    
        
        public static List<string[]> ToList(this ListView listView)
        {
            List<string[]> ret = new List<string[]>();

            string[] headers = listView.Columns.Cast<ColumnHeader>().Select(o => o.Text).ToArray();

            foreach (ListViewItem lvi in listView.Items)
            {
                string[] filas = lvi.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(o => o.Text).ToArray();
                ret.Add(filas);
                
            }
            return ret;
        }

        public static string[] ToHeaders(this ListView listView)
        {
            return listView.Columns.Cast<ColumnHeader>().Select(o => o.Text).ToArray();
            
        }

    }

    public  class LogHelper
    {
        public static void LogResultado(ToolStripLabel lblResultado, int resultado, string mensaje)
        {
            if (resultado == -1)
                lblResultado.Text = "ERROR -> " + mensaje;
            else
            {
                lblResultado.Text = "OK -> " + mensaje + ". ID: " + resultado;

            }
        }
        public static void LogResultado(ToolStripLabel lblResultado, bool resultado, string mensaje)
        {
            if (!resultado)
            {
                lblResultado.Text = "ERROR -> " + mensaje;
            }
            else
            {
                lblResultado.Text = "OK -> " + mensaje + ". ";

            }
        }
        public static void LimpiarLog(ToolStripLabel lblResultado)
        {
            lblResultado.Text = string.Empty;
        }


    }
}
