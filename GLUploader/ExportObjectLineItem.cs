using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLUploader
{
    class ExportObjectLineItem
    {
        private decimal exVatAmt;
        private string glName;
        private string glCode="NO GL MATCH";
        public int GlCodeOrder = 0;

        public ExportObjectLineItem(List<GLEntry> objGLEntriesIn, string glNameIn, decimal exVatAmtIn)
        {
            glName = glNameIn;

            foreach (GLEntry thisGL in objGLEntriesIn)
            {
                if(thisGL.GetGLName() == glNameIn)
                {
                    glCode = thisGL.GetGLCode().ToString();
                    GlCodeOrder = thisGL.GetGLOrder();
                }
            }

            exVatAmt = exVatAmtIn;            
        }

        public void AddAmount(decimal AmountToAdd)
        {
            exVatAmt += AmountToAdd;
        }

        public string GetGLName()
        {
            return glName;
        }

        public string GenerateExportContent(decimal vatRateIn, string accountingCodeIn)
        {
            string thisLine = "Detail,0,1," + exVatAmt.ToString("G", CultureInfo.InvariantCulture) +","+ GetInclVatAmt(vatRateIn).ToString("G", CultureInfo.InvariantCulture) +",,"+ vatRateIn+",0,,"+ glCode+","+glName+",6,"+ accountingCodeIn+",,,,,,,,";

            //Console.WriteLine(thisLine);

            return thisLine;
        }

        private decimal GetInclVatAmt(decimal vatRateIn)
        {
            return (1+(vatRateIn / 100)) * exVatAmt;
        }

    }
}
