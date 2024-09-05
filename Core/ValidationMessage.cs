using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ValidationMessage
    {
        public int Code { get; set; }
        public string? Message { get; set; }

        public ValidationMessage(int code, string? messageText)
        {
            this.Code = code;
            this.Message = messageText;
        }

        private readonly int id;
        public int Id
        {

            get { return id; }
        }

        private readonly string messageText;
        public string MessageText
        {
            get { return messageText; }
        }

        public override string ToString()
        {
            return this.MessageText;
        }
    }
}
