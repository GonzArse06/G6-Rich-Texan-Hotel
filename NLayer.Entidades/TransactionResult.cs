using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    //[DataContract]
    public class TransactionResult
    {
        private bool _isOk;
        private int _id;
        private string _error;
        public bool IsOk { get => _isOk; set => _isOk = value; }
        public int Id { get => _id; set => _id = value; }
        public string Error { get => _error; set => _error = value; }
    }
}
