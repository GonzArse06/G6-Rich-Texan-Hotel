using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Control de usuario personalizado para los textbox que requieren textos.
/// </summary>

namespace NLayer.Formularios
{
    public partial class TextoOnlyString : TextBox
    {
        public TextoOnlyString()
        {
            InitializeComponent();
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false; //Permite el caracter
            else
                e.Handled = true; //rechaza el caracter
        }

    }
}
