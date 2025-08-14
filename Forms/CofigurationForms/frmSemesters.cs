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
    public partial class frmSemesters : Form
    {
        public frmSemesters()
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
                    query = "select SemesterID [ID], SemesterName [Semester], isActive [Status] from SemesterTable";
                }
                else
                {
                    query = "select SemesterID [ID], SemesterName [Semester], isActive [Status] from SemesterTable where SemesterName like '%" + searchString.Trim() + "%'";
                }

                DataTable semesterList = DatabaseLayer.Retrieve(query);
                dgvSemesters.DataSource = semesterList;
                if (dgvSemesters.Rows.Count > 0)
                {
                    dgvSemesters.Columns[0].Width = 80;
                    dgvSemesters.Columns[1].Width = 150;
                    dgvSemesters.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }
        private void frmSemesters_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void txtSemSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSemSearch.Text.Trim());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtbxSemName.Text.Length == 0)
            {
                Ep.SetError(txtbxSemName, "Enter correct Semester name!");
                txtbxSemName.Focus();
                txtbxSemName.SelectAll();
                return;
            }

            DataTable chkSemName = DatabaseLayer.Retrieve("select * from SemesterTable where SemesterName = '" + txtbxSemName.Text.Trim() + "' and SemesterID != '" + Convert.ToString(dgvSemesters.CurrentRow.Cells[0].Value) + "'");
            if (chkSemName != null)
            {
                if (chkSemName.Rows.Count > 0)
                {
                    Ep.SetError(txtbxSemName, "Enter already exists!");
                    txtbxSemName.Focus();
                    txtbxSemName.SelectAll();
                    return;
                }
            }

            string updateQuery = string.Format("update SemesterTable set SemesterName = '{0}',isActive = '{1}' where SemesterID = '{2}'",
                txtbxSemName.Text.Trim(), chkbxSemStatus.Checked, Convert.ToString(dgvSemesters.CurrentRow.Cells[0].Value));
            bool result = DatabaseLayer.Update(updateQuery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Semester Details.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            List<string> validSemesters = new List<string> { "Semester I", "Semester II", "Semester III", "Semester IV" };
            if (txtbxSemName.Text.Length == 0 || !validSemesters.Contains(txtbxSemName.Text.Trim()))
            {
                Ep.SetError(txtbxSemName, "Enter correct Semester name!");
                txtbxSemName.Focus();
                txtbxSemName.SelectAll();
                return;
            }

            DataTable chkSemName = DatabaseLayer.Retrieve("select * from SemesterTable where SemesterName = '" + txtbxSemName.Text.Trim() + "'");
            if (chkSemName != null)
            {
                if (chkSemName.Rows.Count > 0)
                {
                    Ep.SetError(txtbxSemName, "Enter already exists!");
                    txtbxSemName.Focus();
                    txtbxSemName.SelectAll();
                    return;
                }
            }

            string insertQuery = string.Format("insert into SemesterTable(SemesterName,isActive) values('{0}','{1}')",
                txtbxSemName.Text.Trim(), chkbxSemStatus.Checked);
            bool result = DatabaseLayer.Insert(insertQuery);
            if (result == true)
            {
                MessageBox.Show("Saved Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Semester Details.");
            }
        }
        public void clearForm()
        {
            txtbxSemName.Clear();
            chkbxSemStatus.Checked = false;
        }

        public void enableComponent()
        {
            dgvSemesters.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSemSearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvSemesters.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtSemSearch.Enabled = true;
            clearForm();
            FillGrid(string.Empty);
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            if (dgvSemesters != null)
            {
                if (dgvSemesters.Rows.Count > 0)
                {
                    if (dgvSemesters.SelectedRows.Count == 1)
                    {
                        txtbxSemName.Text = Convert.ToString(dgvSemesters.CurrentRow.Cells[1].Value);
                        chkbxSemStatus.Checked = Convert.ToBoolean(dgvSemesters.CurrentRow.Cells[2].Value);
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
