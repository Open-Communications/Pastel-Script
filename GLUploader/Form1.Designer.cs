namespace GLUploader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileInputDialog = new System.Windows.Forms.OpenFileDialog();
            this.inputFileSelect = new System.Windows.Forms.Button();
            this.txtInvPeriod = new System.Windows.Forms.TextBox();
            this.txtVatAmount = new System.Windows.Forms.TextBox();
            this.fileOutputDialog = new System.Windows.Forms.SaveFileDialog();
            this.inputGLSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileInputDialog
            // 
            this.fileInputDialog.FileName = "openFileDialog1";
            // 
            // inputFileSelect
            // 
            this.inputFileSelect.Location = new System.Drawing.Point(22, 133);
            this.inputFileSelect.Name = "inputFileSelect";
            this.inputFileSelect.Size = new System.Drawing.Size(180, 40);
            this.inputFileSelect.TabIndex = 0;
            this.inputFileSelect.Text = "IMPORT LINE DATA";
            this.inputFileSelect.UseVisualStyleBackColor = true;
            this.inputFileSelect.Click += new System.EventHandler(this.inputFileSelect_Click);
            // 
            // txtInvPeriod
            // 
            this.txtInvPeriod.Location = new System.Drawing.Point(74, 54);
            this.txtInvPeriod.Name = "txtInvPeriod";
            this.txtInvPeriod.Size = new System.Drawing.Size(128, 20);
            this.txtInvPeriod.TabIndex = 1;
            // 
            // txtVatAmount
            // 
            this.txtVatAmount.Location = new System.Drawing.Point(74, 25);
            this.txtVatAmount.Name = "txtVatAmount";
            this.txtVatAmount.Size = new System.Drawing.Size(128, 20);
            this.txtVatAmount.TabIndex = 2;
            this.txtVatAmount.Text = "15";
            // 
            // inputGLSelect
            // 
            this.inputGLSelect.Location = new System.Drawing.Point(22, 86);
            this.inputGLSelect.Name = "inputGLSelect";
            this.inputGLSelect.Size = new System.Drawing.Size(180, 41);
            this.inputGLSelect.TabIndex = 3;
            this.inputGLSelect.Text = "IMPORT GL CODES";
            this.inputGLSelect.UseVisualStyleBackColor = true;
            this.inputGLSelect.Click += new System.EventHandler(this.inputGLSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "VAT %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Period";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 182);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputGLSelect);
            this.Controls.Add(this.txtVatAmount);
            this.Controls.Add(this.txtInvPeriod);
            this.Controls.Add(this.inputFileSelect);
            this.Name = "Form1";
            this.Text = "GLU v5.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileInputDialog;
        private System.Windows.Forms.Button inputFileSelect;
        private System.Windows.Forms.TextBox txtInvPeriod;
        private System.Windows.Forms.TextBox txtVatAmount;
        private System.Windows.Forms.SaveFileDialog fileOutputDialog;
        private System.Windows.Forms.Button inputGLSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

