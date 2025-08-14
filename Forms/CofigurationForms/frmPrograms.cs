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
    public partial class frmPrograms : Form
    {
        public frmPrograms()
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
                    query = "select ProgramID [ID], ProgramName [Program], isActive [Status] from ProgramTable";
                }
                else
                {
                    query = "select ProgramID [ID], ProgramName [Program], isActive [Status] from ProgramTable where ProgramName like '%" + searchString.Trim() + "%'";
                }

                DataTable programList = DatabaseLayer.Retrieve(query);
                dgvPrograms.DataSource = programList;
                if (dgvPrograms.Rows.Count > 0)
                {
                    dgvPrograms.Columns[0].Width = 80;
                    dgvPrograms.Columns[1].Width = 150;
                    dgvPrograms.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }

        public void clearForm()
        {
            txtbxProgName.Clear();
            chkbxProgStatus.Checked = false;
        }

        public void enableComponent()
        {
            dgvPrograms.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtProgSearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvPrograms.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtProgSearch.Enabled = true;
            clearForm();
            FillGrid(string.Empty);
        }
        private void frmPrograms_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void txtProgSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtProgSearch.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtbxProgName.Text.Length == 0)
            {
                Ep.SetError(txtbxProgName, "Enter correct Program name!");
                txtbxProgName.Focus();
                txtbxProgName.SelectAll();
                return;
            }

            DataTable chkProgName = DatabaseLayer.Retrieve("select * from ProgramTable where ProgramName = '" + txtbxProgName.Text.Trim() + "'");
            if (chkProgName != null)
            {
                if (chkProgName.Rows.Count > 0)
                {
                    Ep.SetError(txtbxProgName, "Enter already exists!");
                    txtbxProgName.Focus();
                    txtbxProgName.SelectAll();
                    return;
                }
            }

            string insertQuery = string.Format("insert into ProgramTable(ProgramName,isActive) values('{0}','{1}')",
                txtbxProgName.Text.Trim(), chkbxProgStatus.Checked);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableComponent();
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            if (dgvPrograms != null)
            {
                if (dgvPrograms.Rows.Count > 0)
                {
                    if (dgvPrograms.SelectedRows.Count == 1)
                    {
                        txtbxProgName.Text = Convert.ToString(dgvPrograms.CurrentRow.Cells[1].Value);
                        chkbxProgStatus.Checked = Convert.ToBoolean(dgvPrograms.CurrentRow.Cells[2].Value);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtbxProgName.Text.Length == 0)
            {
                Ep.SetError(txtbxProgName, "Enter correct Program name!");
                txtbxProgName.Focus();
                txtbxProgName.SelectAll();
                return;
            }

            DataTable chkProgName = DatabaseLayer.Retrieve("select * from ProgramTable where ProgramName = '" + txtbxProgName.Text.Trim() + "' and ProgramID != '" + Convert.ToString(dgvPrograms.CurrentRow.Cells[0].Value) + "'");
            if (chkProgName != null)
            {
                if (chkProgName.Rows.Count > 0)
                {
                    Ep.SetError(txtbxProgName, "Enter already exists!");
                    txtbxProgName.Focus();
                    txtbxProgName.SelectAll();
                    return;
                }
            }

            string updateQuery = string.Format("update ProgramTable set ProgramName = '{0}',isActive = '{1}' where ProgramID = '{2}'",
                txtbxProgName.Text.Trim(), chkbxProgStatus.Checked, Convert.ToString(dgvPrograms.CurrentRow.Cells[0].Value));
            bool result = DatabaseLayer.Update(updateQuery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Program Details.");
            }
        }
    }
}

