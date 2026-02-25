using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLUploader
{
    class ExportObject
    {
        private string invCustomerCode;
        private string invDate;
        private string invFrom;
        
        private List<GLEntry> objGLEntries;

        List<ExportObjectLineItem> expObjectLines = new List<ExportObjectLineItem>();

        public ExportObject(List<GLEntry> objGLEntriesIn, InputLineItem inputLine)
        {
            invCustomerCode = inputLine.GetAccountingCode();
            invDate = inputLine.GetInvoiceDate();
            invFrom = inputLine.GetInvoiceFrom();

            objGLEntries = objGLEntriesIn;
        }

        public bool AddInputLine(InputLineItem inputLine)            
        {
            bool addedToObject = false;

            foreach (ExportObjectLineItem thisLineItem in expObjectLines)
            {
                if(thisLineItem.GetGLName() == inputLine.GetDescription())
                {
                    thisLineItem.AddAmount(inputLine.GetExVatAmt());
                    addedToObject = true;
                    break;
                }
            }

            if (!addedToObject)
            {
                expObjectLines.Add(new ExportObjectLineItem(objGLEntries, inputLine.GetDescription(), inputLine.GetExVatAmt()));
            }

            return true;
        }
         
        public string GetInvoiceCustomerCode()
        {
            return invCustomerCode;
        }

        public List<string> GenerateExportContent(int periodIn, decimal vatRateIn)
        {
            List<string> outputStrArr = new List<string>();

            outputStrArr.Add(GenerateExportHeader(periodIn));

            //Order expObjectLines Array by GL Order
            List<ExportObjectLineItem> orderedArray;

            orderedArray = expObjectLines.OrderBy(r => r.GlCodeOrder).ToList();

            string accountingCode = GetInvoiceCustomerCode();

            foreach (ExportObjectLineItem thisExportLine in orderedArray)
            {
                outputStrArr.Add(thisExportLine.GenerateExportContent(vatRateIn, accountingCode));
            }

            outputStrArr.Add(GenerateGapLine());
            outputStrArr.Add(GenerateFinalLine());

            return outputStrArr;
        }

        public string GenerateExportHeader(int periodIn)
        {
            return "Header,,,,"+GetInvoiceCustomerCode()+","+ periodIn+","+invDate+",Call Charges,N,,,,,,,,,,,,"+invDate;            
        }

        public string GenerateGapLine()
        {
            return "Detail,,,,,,,,,,,7,"+ GetInvoiceCustomerCode()+",,,,,,,,";
        }
        public string GenerateFinalLine()
        {
            return "Detail,0,1,0,0,,0,0,,0,"+invDate+" - "+invFrom+",7,"+ GetInvoiceCustomerCode()+",,,,,,,,";
        }
    }
}
