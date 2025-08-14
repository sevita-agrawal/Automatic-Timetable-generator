using AutoTimetableGenerator.SourceCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTimetableGenerator.Forms
{
    public partial class FrmGenerateTimeTable : Form
    {
        public FrmGenerateTimeTable()
        {
            InitializeComponent();
        }

        private void btnGenerateTimeTables_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                string message = GenerateTimeTable.AutoGenerateTimeTable(dtpStartDate.Value, dtpEndDate.Value);
                MessageBox.Show(message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmGenerateTimeTable_Load(object sender, EventArgs e)
        {

        }
    }
}
