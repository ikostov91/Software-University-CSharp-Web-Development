namespace CurrencyConverter
{
    partial class FormConverter
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
            this.numericUpDownAmmount = new System.Windows.Forms.NumericUpDown();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmmount)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownAmmount
            // 
            this.numericUpDownAmmount.DecimalPlaces = 2;
            this.numericUpDownAmmount.Location = new System.Drawing.Point(13, 14);
            this.numericUpDownAmmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownAmmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownAmmount.Name = "numericUpDownAmmount";
            this.numericUpDownAmmount.Size = new System.Drawing.Size(125, 26);
            this.numericUpDownAmmount.TabIndex = 0;
            this.numericUpDownAmmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAmmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Items.AddRange(new object[] {
            "EUR",
            "USD",
            "GBP"});
            this.comboBoxCurrency.Location = new System.Drawing.Point(227, 12);
            this.comboBoxCurrency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(109, 28);
            this.comboBoxCurrency.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Location = new System.Drawing.Point(146, 15);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 22);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "BGN";
            // 
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.Color.Lime;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResult.Location = new System.Drawing.Point(13, 57);
            this.labelResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(323, 30);
            this.labelResult.TabIndex = 3;
            this.labelResult.Text = "label2";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "->";
            // 
            // FormConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 96);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.numericUpDownAmmount);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConverter";
            this.Text = "Currency Converter";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownAmmount;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label label3;
    }
}

