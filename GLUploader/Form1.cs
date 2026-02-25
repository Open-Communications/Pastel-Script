using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GLUploader
{
    public partial class Form1 : Form
    {
        private List<GLEntry> GLEntries = new List<GLEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        private void inputFileSelect_Click(object sender, EventArgs e)
        {
            decimal thisVATAmount;
            
            try
            {
                thisVATAmount = decimal.Parse(txtVatAmount.Text, CultureInfo.InvariantCulture);
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid VAT Amount!", "VAT Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if(txtInvPeriod.Text == "")
            {
                MessageBox.Show("Period is blank!", "Period Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (GLEntries.Count == 0)
            {
                MessageBox.Show("Please load GL Mappings first!","GL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult inputFileResult = fileInputDialog.ShowDialog();

            if(inputFileResult == DialogResult.OK)
            {
                string strFileName = fileInputDialog.FileName;
                //MessageBox.Show("File OK: " + strFileName, "File loaded!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                TextReader reader;

                try
                {
                    reader = File.OpenText(strFileName);
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message, "File Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }                

                string line;

                List<InputLineItem> lineItemList = new List<InputLineItem>();
                
                //Ignore Header Line
                line = reader.ReadLine();

                int ThisLine = 2;
                while((line = reader.ReadLine()) != null)
                {
                    //MessageBox.Show("Line: " + line, "New Line...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    InputLineItem thisLine = new InputLineItem(line);

                    if(thisLine.IsOK())
                    {
                        lineItemList.Add(new InputLineItem(line));
                    }
                    
                    ThisLine++;
                }

                if (lineItemList.Count > 0)
                {
                    MessageBox.Show("Imported: " + lineItemList.Count + " Invoice Lines", "Import Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    OutputObject outputObject = new OutputObject(GLEntries, int.Parse(txtInvPeriod.Text), thisVATAmount);

                    foreach (InputLineItem thisLine in lineItemList)
                    {
                        outputObject.AddLine(thisLine);
                    }



                    DialogResult saveDialogResult = fileOutputDialog.ShowDialog();

                    if (saveDialogResult == DialogResult.OK)
                    {
                        outputObject.SaveCSV(fileOutputDialog.FileName);
                    }
                }
                else
                {
                    MessageBox.Show("Imported: " + lineItemList.Count + " Invoice Lines", "Import Summary", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                         

            }
            else
            {
                MessageBox.Show("File not loaded!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void inputGLSelect_Click(object sender, EventArgs e)
        {
            DialogResult inputFileResult = fileInputDialog.ShowDialog();

            if (inputFileResult == DialogResult.OK)
            {
                string strFileName = fileInputDialog.FileName;
                //MessageBox.Show("File OK: " + strFileName, "File loaded!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                TextReader reader;

                try
                {
                    reader = File.OpenText(strFileName);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "File Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string line;

                GLEntries = new List<GLEntry>();
                                
                while ((line = reader.ReadLine()) != null)
                {
                    GLEntries.Add(new GLEntry(line));
                }
            }

            MessageBox.Show("Imported: " + GLEntries.Count+" GL Entries", "Import Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
