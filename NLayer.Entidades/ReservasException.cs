using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    public class ReservasException : Exception
    {
        public ReservasException(string message) : base(message)
        {
        }
    }
}
