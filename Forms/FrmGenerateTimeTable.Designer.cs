namespace AutoTimetableGenerator.Forms
{
    partial class FrmGenerateTimeTable
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateTimeTables = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 59);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Start Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = " ddMMMMyyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(6, 21);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(457, 22);
            this.dtpStartDate.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpEndDate);
            this.groupBox2.Location = new System.Drawing.Point(7, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 59);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select End Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = " ddMMMMyyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(6, 21);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(457, 22);
            this.dtpEndDate.TabIndex = 1;
            // 
            // btnGenerateTimeTables
            // 
            this.btnGenerateTimeTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateTimeTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateTimeTables.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerateTimeTables.Location = new System.Drawing.Point(7, 203);
            this.btnGenerateTimeTables.Name = "btnGenerateTimeTables";
            this.btnGenerateTimeTables.Size = new System.Drawing.Size(469, 59);
            this.btnGenerateTimeTables.TabIndex = 8;
            this.btnGenerateTimeTables.Text = "Generate Time Table";
            this.btnGenerateTimeTables.UseVisualStyleBackColor = true;
            this.btnGenerateTimeTables.Click += new System.EventHandler(this.btnGenerateTimeTables_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(13, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 18);
            this.panel1.TabIndex = 7;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // FrmGenerateTimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(485, 286);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGenerateTimeTables);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGenerateTimeTable";
            this.Text = "Generate Time Table";
            this.Load += new System.EventHandler(this.FrmGenerateTimeTable_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnGenerateTimeTables;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider ep;
    }
}