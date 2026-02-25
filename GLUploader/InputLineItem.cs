using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLUploader
{
    class InputLineItem
    {
        private string invoiceNumber;
        private string accountingCode;
        private string accountName;
        private string invoiceDate;
        private string invoiceFrom;
        private string invoiceTo;
        private string description;
        private int numberOfCalls;
        private int callDuration;
        private decimal feeAmountExVat;

        private bool isConversionOK;

        public InputLineItem(string lineString)
        {
            string[] tokens = lineString.Split(',');

            if(tokens.Length == 10)
            {
                isConversionOK = true;

                invoiceNumber = tokens[0];
                accountingCode = tokens[1];
                accountName = tokens[2];
                invoiceDate = tokens[3];
                invoiceFrom = tokens[4];
                invoiceTo = tokens[5];
                description = tokens[6];

                try
                {
                    numberOfCalls = int.Parse(tokens[7]);
                    callDuration = int.Parse(tokens[8]);
                    feeAmountExVat = decimal.Parse(tokens[9], CultureInfo.InvariantCulture);

                    isConversionOK = true;

                }
                catch(Exception e)
                {
                    isConversionOK = false;
                }                
            }
            else
            {
                isConversionOK = false;
            }
        }
        
        public bool IsOK()
        {
            return isConversionOK;
        }

        public string GetAccountingCode()
        {
            return accountingCode;
        }

        public string GetInvoiceDate()
        {
            return invoiceDate;
        }

        public string GetInvoiceFrom()
        {
            return invoiceFrom;
        }

        public string GetDescription()
        {
            return description;
        }
        public decimal GetExVatAmt()
        {
            return feeAmountExVat;
        }
    }
}
