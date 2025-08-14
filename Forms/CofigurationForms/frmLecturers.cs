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
    public partial class frmLecturers : Form
    {
        public frmLecturers()
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
                    query = "select LecturerID [ID],FirstName [FirstName],LastName [LastName], ContactNo [Contact No], isActive [Status] from LecturerTable";
                }
                else
                {
                    query = "select LecturerID [ID],FirstName [FirstName],LastName [LastName], ContactNo [Contact No] , isActive [Status] from LecturerTable where (FirstName +' ' +ContactNo) like '%" + searchString.Trim() + "%'";
                }

                DataTable lecturerlist = DatabaseLayer.Retrieve(query);
                dgvLecturer.DataSource = lecturerlist;
                if (dgvLecturer.Rows.Count > 0)
                {
                    dgvLecturer.Columns[0].Width = 50;
                    dgvLecturer.Columns[1].Width = 80;
                    dgvLecturer.Columns[2].Width = 100;
                    dgvLecturer.Columns[3].Width = 100;
                    dgvLecturer.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtLecturerFirstName.Text.Length == 0 || txtLecturerFirstName.Text.Length > 30)
            {
                Ep.SetError(txtLecturerFirstName, "Enter correct First Name!");
                txtLecturerFirstName.Focus();
                txtLecturerFirstName.SelectAll();
                return;
            }

            if (txtLecturerLastName.Text.Length == 0 || txtLecturerLastName.Text.Length > 30)
            {
                Ep.SetError(txtLecturerLastName, "Enter correct Last Name!");
                txtLecturerLastName.Focus();
                txtLecturerLastName.SelectAll();
                return;
            }

            if (txtContactNo.Text.Length == 0 || txtContactNo.Text.Length < 10)
            {
                Ep.SetError(txtContactNo, "Enter correct Contact Number !");
                txtContactNo.Focus();
                txtContactNo.SelectAll();
                return;
            }

            DataTable chkLecturerName = DatabaseLayer.Retrieve("select * from LecturerTable where FirstName = '" + txtLecturerFirstName.Text.Trim() +"' and ContactNo = '"+ txtContactNo.Text.Trim() +"' and LecturerID != '" + Convert.ToString(dgvLecturer.CurrentRow.Cells[0].Value) + "'");
            if (chkLecturerName != null)
            {
                if (chkLecturerName.Rows.Count > 0)
                {
                    Ep.SetError(txtLecturerFirstName, "Enter already exists!");
                    txtLecturerFirstName.Focus();
                    txtLecturerFirstName.SelectAll();
                    return;
                }
            }

            string updateQuery = string.Format("update LecturerTable set FirstName = '{0}',LastName = '{1}',ContactNo = '{2}',isActive = '{3}' where LecturerID = '{4}'",
                txtLecturerFirstName.Text.Trim(), txtLecturerLastName.Text.Trim(), txtContactNo.Text.Trim(), chkLecturerStatus.Checked, Convert.ToString(dgvLecturer.CurrentRow.Cells[0].Value));
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableComponent();
        }

        private void frmLecturers_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void txtLecturerSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtLecturerSearch.Text.Trim());
        }

        public void clearForm()
        {
            txtLecturerFirstName.Clear();
            txtLecturerLastName.Clear();
            txtContactNo.Clear();
            chkLecturerStatus.Checked = false;
        }

        public void enableComponent()
        {
            dgvLecturer.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtLecturerSearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvLecturer.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtLecturerSearch.Enabled = true;
            clearForm();
            FillGrid(string.Empty);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtLecturerFirstName.Text.Length == 0 || txtLecturerFirstName.Text.Length > 30)
            {
                Ep.SetError(txtLecturerFirstName, "Enter correct First Name!");
                txtLecturerFirstName.Focus();
                txtLecturerFirstName.SelectAll();
                return;
            }

            if (txtLecturerLastName.Text.Length == 0 || txtLecturerLastName.Text.Length > 30)
            {
                Ep.SetError(txtLecturerLastName, "Enter correct Last Name!");
                txtLecturerLastName.Focus();
                txtLecturerLastName.SelectAll();
                return;
            }

            if (txtContactNo.Text.Length == 0 || txtContactNo.Text.Length < 10 )
            {
                Ep.SetError(txtContactNo, "Enter correct Contact Number !");
                txtContactNo.Focus();
                txtContactNo.SelectAll();
                return;
            }

            DataTable chkLeturerName = DatabaseLayer.Retrieve("select * from LecturerTable where FirstName = '" + txtLecturerFirstName.Text.Trim() + "'and ContactNo '"+ txtContactNo.Text.Trim() +"'");
            if (chkLeturerName != null)
            {
                if (chkLeturerName.Rows.Count > 0)
                {
                    Ep.SetError(txtLecturerFirstName, "Enter already exists!");
                    txtLecturerFirstName.Focus();
                    txtLecturerFirstName.SelectAll();
                    return;
                }
            }

            string insertQuery = string.Format("insert into LecturerTable(FirstName,LastName,ContactNo,isActive) values('{0}','{1}','{2}','{3}')",
                txtLecturerFirstName.Text.Trim(), txtLecturerLastName.Text.Trim(),txtContactNo.Text.Trim(), chkLecturerStatus.Checked);
            bool result = DatabaseLayer.Insert(insertQuery);
            if (result == true)
            {
                MessageBox.Show("Saved Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Lecturer Details.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void cmsSessions_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            if (dgvLecturer != null)
            {
                if (dgvLecturer.Rows.Count > 0)
                {
                    if (dgvLecturer.SelectedRows.Count == 1)
                    {
                        txtLecturerFirstName.Text = Convert.ToString(dgvLecturer.CurrentRow.Cells[1].Value);
                        txtLecturerLastName.Text = Convert.ToString(dgvLecturer.CurrentRow.Cells[2].Value);
                        txtContactNo.Text = Convert.ToString(dgvLecturer.CurrentRow.Cells[3].Value);
                        chkLecturerStatus.Checked = Convert.ToBoolean(dgvLecturer.CurrentRow.Cells[4].Value);
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
