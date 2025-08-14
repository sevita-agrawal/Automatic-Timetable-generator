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
    public partial class frmLabs : Form
    {
        public frmLabs()
        {
            InitializeComponent();
        }

        private void frmLabs_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void txtCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void FillGrid(string searchString)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchString.Trim()))
                {
                    query = "select LabID [ID],LabNo [Lab], Capacity, isActive [Status] from LabTable";
                }
                else
                {
                    query = "select LabID [ID],LabNo [Lab], Capacity , isActive [Status] from LabTable where LabNo like '%" + searchString.Trim() + "%'";
                }

                DataTable lablist = DatabaseLayer.Retrieve(query);
                dgvLabs.DataSource = lablist;
                if (dgvLabs.Rows.Count > 0)
                {
                    dgvLabs.Columns[0].Width = 80;
                    dgvLabs.Columns[1].Width = 150;
                    dgvLabs.Columns[2].Width = 100;
                    dgvLabs.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }
        public void clearForm()
        {
            txtLabNo.Clear();
            txtCapacity.Clear();
            chkLabStatus.Checked = false;
        }

        public void enableComponent()
        {
            dgvLabs.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtLabSearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvLabs.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtLabSearch.Enabled = true;
            clearForm();
            FillGrid(string.Empty);
        }

        private void txtLabSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtLabSearch.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtLabNo.Text.Length == 0 || txtLabNo.Text.Length > 10)
            {
                Ep.SetError(txtLabNo, "Enter correct Lab Number!");
                txtLabNo.Focus();
                txtLabNo.SelectAll();
                return;
            }

            if (txtCapacity.Text.Length == 0)
            {
                Ep.SetError(txtCapacity, "Enter correct Capacity !");
                txtCapacity.Focus();
                txtCapacity.SelectAll();
                return;
            }

            DataTable chkLabNo = DatabaseLayer.Retrieve("select * from LabTable where txtLabNo = '" + txtLabNo.Text.Trim() + "'");
            if (chkLabNo != null)
            {
                if (chkLabNo.Rows.Count > 0)
                {
                    Ep.SetError(txtLabNo, "Enter already exists!");
                    txtLabNo.Focus();
                    txtLabNo.SelectAll();
                    return;
                }
            }

            string insertQuery = string.Format("insert into LabTable(LabNo,Capacity,isActive) values('{0}','{1}','{2}')",
                txtLabNo.Text.Trim(), txtCapacity.Text.Trim(), chkLabStatus.Checked);
            bool result = DatabaseLayer.Insert(insertQuery);
            if (result == true)
            {
                MessageBox.Show("Saved Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Lab Details.");
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
            if (dgvLabs != null)
            {
                if (dgvLabs.Rows.Count > 0)
                {
                    if (dgvLabs.SelectedRows.Count == 1)
                    {
                        txtLabNo.Text = Convert.ToString(dgvLabs.CurrentRow.Cells[1].Value);
                        txtCapacity.Text = Convert.ToString(dgvLabs.CurrentRow.Cells[2].Value);
                        chkLabStatus.Checked = Convert.ToBoolean(dgvLabs.CurrentRow.Cells[3].Value);
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
            if (txtLabNo.Text.Length == 0)
            {
                Ep.SetError(txtLabNo, "Enter correct Lab Number!");
                txtLabNo.Focus();
                txtLabNo.SelectAll();
                return;
            }

            DataTable chkLabNo = DatabaseLayer.Retrieve("select * from LabTable where LabNo = '" + txtLabNo.Text.Trim() + "' and LabID != '" + Convert.ToString(dgvLabs.CurrentRow.Cells[0].Value) + "'");
            if (chkLabNo != null)
            {
                if (chkLabNo.Rows.Count > 0)
                {
                    Ep.SetError(txtLabNo, "Enter already exists!");
                    txtLabNo.Focus();
                    txtLabNo.SelectAll();
                    return;
                }
            }

            string updateQuery = string.Format("update LabTable set LabNo = '{0}',Capacity = '{1}',isActive = '{2}' where LabID = '{3}'",
                txtLabNo.Text.Trim(),txtCapacity.Text.Trim(), chkLabStatus.Checked, Convert.ToString(dgvLabs.CurrentRow.Cells[0].Value));
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
