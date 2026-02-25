using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GLUploader
{
    class OutputObject
    {
        List<ExportObject> exportObjects = new List<ExportObject>();
        decimal vatRate;
        int period;
        private List<GLEntry> objGLEntries;

        public OutputObject(List<GLEntry> objGLEntriesIn, int periodIn, decimal vatRateIn)
        {
            vatRate = vatRateIn;
            period = periodIn;
            objGLEntries = objGLEntriesIn;
        }

        public void AddLine(InputLineItem thisLine)
        {
            bool addedToObject = false;

            foreach (ExportObject thisExportObject in exportObjects)
            {
                if (thisLine.GetAccountingCode() == thisExportObject.GetInvoiceCustomerCode())
                {
                    thisExportObject.AddInputLine(thisLine);
                    addedToObject = true;
                    break;
                }
            }

            if (!addedToObject)
            {
                ExportObject thisExportObject = new ExportObject(objGLEntries, thisLine);
                thisExportObject.AddInputLine(thisLine);
                exportObjects.Add(thisExportObject);
            }
        }

        public void SaveCSV(string FileName)
        {
            List<string> finalContent = new List<string>();

            foreach (ExportObject thisExportObject in exportObjects)
            {
                //FileContent += thisExportObject.
                foreach (string objStrLine in thisExportObject.GenerateExportContent(period, vatRate))
                {
                    finalContent.Add(objStrLine);
                }   
            }

            System.IO.File.WriteAllLines(FileName, finalContent);

            MessageBox.Show("The export process is complete.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
