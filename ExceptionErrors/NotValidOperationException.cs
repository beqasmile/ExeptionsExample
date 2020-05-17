using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionErrors
{
    public class NotValidOperationException : Exception
    {
        private string wrongOperation;

        public NotValidOperationException(string wrongOperation, string errorMessage) : base(errorMessage)
        {
            this.wrongOperation = wrongOperation;
        }

        public string WrongOperation { get => wrongOperation; set => wrongOperation = value; }

        public override string ToString()
        {
            return " Wrong operation was taken "  + wrongOperation + " message = " + this.Message;
        }
    }
}
