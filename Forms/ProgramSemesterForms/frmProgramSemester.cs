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
using TimeTableGenerator.SourceCode;
namespace AutoTimetableGenerator.Forms.ProgramSemesterForms
{
    public partial class frmProgramSemester : Form
    {
        public frmProgramSemester()
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
                    query = "select ProgSemID [ID], ProgSemName, Capacity, isActive [Status], ProgramID, SemesterID from ProgramSemesterTable";
                }
                else
                {
                    query = "select ProgSemID [ID], ProgSemName, Capacity, isActive [Status], ProgramID, SemesterID from ProgramSemesterTable where ProgSemName like '%" + searchString.Trim() + "%'";
                }

                DataTable lecturerlist = DatabaseLayer.Retrieve(query);
                dgvLecturer.DataSource = lecturerlist;
                if (dgvLecturer.Rows.Count > 0)
                {
                    dgvLecturer.Columns[0].Width = 80;//ProgSemID
                    dgvLecturer.Columns[1].Width = 250;//ProgSemName
                    dgvLecturer.Columns[2].Width = 100;//Capacity
                    dgvLecturer.Columns[3].Width = 100;//ProgramSemesterIsActive
                    dgvLecturer.Columns[4].Visible = false;//ProgramID
                    dgvLecturer.Columns[5].Visible = false;//SemesterID
                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }

        private void frmProgramSemester_Load(object sender, EventArgs e)
        {
            ComboHelper.Semesters(cmbSelectSemester);
            ComboHelper.Programs(cmbSelectProgram);
            FillGrid(string.Empty);
        }

        private void cmbSelectProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!cmbSelectProgram.Text.Contains("Select"))
            {
                if (cmbSelectSemester.SelectedIndex > 0)
                {
                    txtProgSemTitle.Text = cmbSelectProgram.Text + " " + cmbSelectSemester.Text;
                }

            }
        }

        private void cmbSelectSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbSelectSemester.Text.Contains("Select"))
            {
                if (cmbSelectProgram.SelectedIndex > 0)
                {
                    txtProgSemTitle.Text = cmbSelectProgram.Text + " " + cmbSelectSemester.Text;
                }

            }
        }

        private void txtProgSemSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtProgSemSearch.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtProgSemTitle.Text.Length == 0 || txtProgSemTitle.Text.Length > 30)
            {
                Ep.SetError(txtProgSemTitle, "Enter correct First Name!");
                txtProgSemTitle.Focus();
                txtProgSemTitle.SelectAll();
                return;
            }

            if (cmbSelectProgram.SelectedIndex == 0 )
            {
                Ep.SetError(cmbSelectProgram, "Please Select Program!");
                cmbSelectProgram.Focus();
                
                return;
            }

            if (cmbSelectSemester.SelectedIndex == 0)
            {
                Ep.SetError(cmbSelectProgram, "Please Select Semester!");
                cmbSelectProgram.Focus();

                return;
            }

            if (txtCapacity.Text.Trim().Length == 0)
            {
                Ep.SetError(txtCapacity, "Please Enter Semester Capacity");
                txtCapacity.Focus(); 
                return;
            }


            DataTable chkLeturerName = DatabaseLayer.Retrieve("select * from ProgramSemesterTable where ProgramID = '" + cmbSelectProgram.SelectedValue + "'and SemesterID '" + cmbSelectSemester.SelectedValue + "'");
            if (chkLeturerName != null)
            {
                if (chkLeturerName.Rows.Count > 0)
                {
                    Ep.SetError(txtProgSemTitle, "Enter already exists!");
                    txtProgSemTitle.Focus();
                    txtProgSemTitle.SelectAll();
                    return;
                }
            }

            string insertQuery = string.Format("insert into ProgramSemesterTable(ProgSemName,ProgramID,SemesterID,Capacity,isActive) values('{0}','{1}','{2}','{3}','{4}')",
                txtProgSemTitle.Text.Trim(), cmbSelectProgram.SelectedValue, cmbSelectSemester.SelectedValue, txtCapacity.Text.Trim(),chkSemesterStatus.Checked);
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
        public void clearForm()
        {
            txtProgSemTitle.Clear();
            cmbSelectSemester.SelectedIndex = 0;
            cmbSelectProgram.SelectedIndex = 0;
            txtCapacity.Clear();
            chkSemesterStatus.Checked = false;
        }

        public void enableComponent()
        {
            dgvLecturer.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtProgSemSearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvLecturer.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtProgSemSearch.Enabled = true;
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
                        txtProgSemTitle.Text = Convert.ToString(dgvLecturer.CurrentRow.Cells[1].Value);
                        txtProgSemTitle.Text = Convert.ToString(dgvLecturer.CurrentRow.Cells[2].Value);
                        chkSemesterStatus.Checked = Convert.ToBoolean(dgvLecturer.CurrentRow.Cells[3].Value);
                        cmbSelectProgram.SelectedValue = Convert.ToString(dgvLecturer.CurrentRow.Cells[4].Value);//ProgramID
                        cmbSelectSemester.SelectedValue = Convert.ToString(dgvLecturer.CurrentRow.Cells[5].Value);//SemesterID
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
            if (txtProgSemTitle.Text.Length == 0 || txtProgSemTitle.Text.Length > 30)
            {
                Ep.SetError(txtProgSemTitle, "Enter correct First Name!");
                txtProgSemTitle.Focus();
                txtProgSemTitle.SelectAll();
                return;
            }

            if (cmbSelectProgram.SelectedIndex == 0)
            {
                Ep.SetError(cmbSelectProgram, "Please Select Program!");
                cmbSelectProgram.Focus();

                return;
            }

            if (cmbSelectSemester.SelectedIndex == 0)
            {
                Ep.SetError(cmbSelectProgram, "Please Select Semester!");
                cmbSelectProgram.Focus();

                return;
            }


            DataTable chkLeturerName = DatabaseLayer.Retrieve("select * from ProgramSemesterTable where ProgramID = '" + cmbSelectProgram.SelectedValue + "'and SemesterID '" + cmbSelectSemester.SelectedValue + "'and ProgSemID !='" + Convert.ToString(dgvLecturer.CurrentRow.Cells[0].Value)+"'");
            if (chkLeturerName != null)
            {
                if (chkLeturerName.Rows.Count > 0)
                {
                    Ep.SetError(txtProgSemTitle, "Enter already exists!");
                    txtProgSemTitle.Focus();
                    txtProgSemTitle.SelectAll();
                    return;
                }
            }

            string updateQuery = string.Format("update ProgramSemesterTable set ProgSemName = '{0}',ProgramID = '{1}',SemesterID = '{2}',Capacity = '{3}',isActive = '{4}' Where ProgSemID = '{5}'",
                txtProgSemTitle.Text.Trim(), cmbSelectProgram.SelectedValue, cmbSelectSemester.SelectedValue, txtCapacity.Text.Trim(), chkSemesterStatus.Checked, Convert.ToString(dgvLecturer.CurrentRow.Cells[0].Value));
            bool result = DatabaseLayer.Update(updateQuery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Details.");
            }
        }

        private void txtProgSemTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
