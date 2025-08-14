using AutoTimeTableGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTimetableGenerator.Forms.CofigurationForms
{
    public partial class frmDays : Form
    {
        public frmDays()
        {
            InitializeComponent();
        }
        public void FillGrid(string searchString)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchString.Trim()))
                {
                    query = "select DayID [ID], DayName [Day], isActive [Status] from DayTable";
                }
                else
                {
                    query = "select DayID [ID], DayName [Day], isActive [Status] from DayTable where DayName like '%" + searchString.Trim() + "%'";
                }
                
                DataTable dayList = DatabaseLayer.Retrieve(query);
                dgvDays.DataSource = dayList;
                if (dgvDays.Rows.Count > 0)
                {
                    dgvDays.Columns[0].Width = 80;
                    dgvDays.Columns[1].Width = 150;
                    dgvDays.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }
        private void frmDays_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void txtDaySearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtDaySearch.Text.ToUpper());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtDayName.Text.Length == 0)
            {
                Ep.SetError(txtDayName, "Enter correct Day name!");
                txtDayName.Focus();
                txtDayName.SelectAll();
                return;
            }

            DataTable chkProgName = DatabaseLayer.Retrieve("select * from DayTable where DayName = '" + txtDayName.Text.Trim() + "'");
            if (chkProgName != null)
            {
                if (chkProgName.Rows.Count > 0)
                {
                    Ep.SetError(txtDayName, "Enter already exists!");
                    txtDayName.Focus();
                    txtDayName.SelectAll();
                    return;
                }
            }

            string insertQuery = string.Format("insert into DayTable(DayName,isActive) values('{0}','{1}')",
                txtDayName.Text.Trim(), chkDayStatus.Checked);
            bool result = DatabaseLayer.Insert(insertQuery);
            if (result == true)
            {
                MessageBox.Show("Saved Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Program Details.");
            }
        }
        public void clearForm()
        {
            txtDayName.Clear();
            chkDayStatus.Checked = false;
        }

        public void enableComponent()
        {
            dgvDays.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtDaySearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvDays.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtDaySearch.Enabled = true;
            clearForm();
            FillGrid(string.Empty);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtDayName.Text.Length == 0 )
            {
                Ep.SetError(txtDayName, "Enter correct Day ");
                txtDayName.Focus();
                txtDayName.SelectAll();
                return;
            }


            DataTable chkDayName = DatabaseLayer.Retrieve("select * from DayTable where DayName = '" + txtDayName.Text.Trim() + "' and DayID != '" + Convert.ToString(dgvDays.CurrentRow.Cells[0].Value) + "'");
            if (chkDayName != null)
            {
                if (chkDayName.Rows.Count > 0)
                {
                    Ep.SetError(txtDayName, "Enter already exists!");
                    txtDayName.Focus();
                    txtDayName.SelectAll();
                    return;
                }
            }

            string updateQuery = string.Format("update DayTable set DayName = '{0}',isActive = '{1}' where DayID = '{2}'",
                txtDayName.Text.Trim(), chkDayStatus.Checked, Convert.ToString(dgvDays.CurrentRow.Cells[0].Value));
            bool result = DatabaseLayer.Update(updateQuery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Day Details.");
            }
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            if (dgvDays != null)
            {
                if (dgvDays.Rows.Count > 0)
                {
                    if (dgvDays.SelectedRows.Count == 1)
                    {
                        txtDayName.Text = Convert.ToString(dgvDays.CurrentRow.Cells[1].Value);
                        chkDayStatus.Checked = Convert.ToBoolean(dgvDays.CurrentRow.Cells[2].Value);
                        enableComponent();
                    }
                    else
                    {
                        MessageBox.Show("Select only 1 row.");
                    }
                }
                else
                {
                    MessageBox.Show("Empty List!");
                }
            }
        }
    }
}
