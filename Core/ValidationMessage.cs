using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ValidationMessage
    {
        public int Code { get;private set; }
        public string Message { get;private set; }

        public ValidationMessage(int code, string message)
        {
            this.Code = code;
            this.Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public override string ToString()
        {
            return $"Code: {Code}, Message: {Message}";
        }
    }
}
