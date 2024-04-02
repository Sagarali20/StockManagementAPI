using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityModels
{
    public class ValidationModel
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string SecondLastName { get; set; }
        }

        public class SenderReceiver
        {
            public Person Person { get; set; }
        }

        public class ReceiveAmount1
        {
            public string Value { get; set; }
            public string CurrencyCode { get; set; }
        }

     
        public SenderReceiver Sender { get; set; }
        public SenderReceiver Receiver { get; set; }
        public string AccountCode { get; set; }
        public string AccountNumber { get; set; }
        public string ReceiveCountryCode { get; set; }
        public ReceiveAmount1 ReceiveAmount { get; set; }
        
    }
}
