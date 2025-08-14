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
    public partial class frmSessions : Form
    {
        public frmSessions()
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
                    query = "select SessionID [ID], SessionName [Title], isActive [Status] from SessionTable";
                }
                else
                {
                    query = "select SessionID [ID], SessionName [Title], isActive [Status] from SessionTable where SessionName like '%" + searchString.Trim() + "%'";
                }

                DataTable sessionList = DatabaseLayer.Retrieve(query);
                dgvSessions.DataSource = sessionList;
                if (dgvSessions.Rows.Count > 0)
                {
                    dgvSessions.Columns[0].Width = 80;
                    dgvSessions.Columns[1].Width = 150;
                    dgvSessions.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }
        public void clearForm()
        {
            txtbxSessionTitle.Clear();
            chkbxSessionStatus.Checked = false;
        }

        private void frmSessions_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtbxSessionTitle.Text.Length < 9)
            {
                Ep.SetError(txtbxSessionTitle, "Enter correct academic year!");
                txtbxSessionTitle.Focus();
                txtbxSessionTitle.SelectAll();
                return;
            }

            DataTable chkSessionName = DatabaseLayer.Retrieve("select * from SessionTable where SessionName = '" + txtbxSessionTitle.Text.Trim() + "'");
            if (chkSessionName != null)
            {
                if (chkSessionName.Rows.Count > 0)
                {
                    Ep.SetError(txtbxSessionTitle, "Enter already exists!");
                    txtbxSessionTitle.Focus();
                    txtbxSessionTitle.SelectAll();
                    return;
                }
            }

            string insertQuery = string.Format("insert into SessionTable(SessionName,isActive) values('{0}','{1}')",
                txtbxSessionTitle.Text.Trim(), chkbxSessionStatus.Checked);
            bool result = DatabaseLayer.Insert(insertQuery);
            if (result == true)
            {
                MessageBox.Show("Saved Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Session Details.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void txtSessionSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSessionSearch.Text.Trim());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtbxSessionTitle.Text.Length < 9)
            {
                Ep.SetError(txtbxSessionTitle, "Enter correct academic year!");
                txtbxSessionTitle.Focus();
                txtbxSessionTitle.SelectAll();
                return;
            }

            DataTable chkSessionName = DatabaseLayer.Retrieve("select * from SessionTable where SessionName = '" + txtbxSessionTitle.Text.Trim() + "' and SessionID != '" + Convert.ToString(dgvSessions.CurrentRow.Cells[0].Value) + "'");
            if (chkSessionName != null)
            {
                if (chkSessionName.Rows.Count > 0)
                {
                    Ep.SetError(txtbxSessionTitle, "Enter already exists!");
                    txtbxSessionTitle.Focus();
                    txtbxSessionTitle.SelectAll();
                    return;
                }
            }

            string updateQuery = string.Format("update SessionTable set SessionName = '{0}',isActive = '{1}' where SessionID = '{2}'",
                txtbxSessionTitle.Text.Trim(), chkbxSessionStatus.Checked, Convert.ToString(dgvSessions.CurrentRow.Cells[0].Value));
            bool result = DatabaseLayer.Update(updateQuery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Session Details.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableComponent();
        }
        public void enableComponent()
        {
            dgvSessions.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSessionSearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvSessions.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtSessionSearch.Enabled = true;
            clearForm();
            FillGrid(string.Empty);
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            if (dgvSessions != null)
            {
                if (dgvSessions.Rows.Count > 0)
                {
                    if (dgvSessions.SelectedRows.Count == 1)
                    {
                        txtbxSessionTitle.Text = Convert.ToString(dgvSessions.CurrentRow.Cells[1].Value);
                        chkbxSessionStatus.Checked = Convert.ToBoolean(dgvSessions.CurrentRow.Cells[2].Value);
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

        private void dgvSessions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chkbxSessionStatus_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
