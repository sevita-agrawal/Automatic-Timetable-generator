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
    public partial class frmProgramSemesterSubject : Form
    {
        public frmProgramSemesterSubject()
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
                    query = "select [ProgramSemesterSubjectID] [ID], [ProgramID], [Program], ProgSemID, ProgSemName [Semester], ProfSubID, SemSubTitle [Subject], Capacity, IsSubjectActive [Status]" +
                            "from v_AllSemesterSubjects where [ProgramSemesterIsActive] = 1 or [ProgramIsActive] = 1 or [SemesterIsActive] = 1 or [subjectIsActive] = 1 order by ProgSemID";
                }
                else
                {
                    query = "select [ProgramSemesterSubjectID] [ID], [ProgramID], [Program], ProgSemID, ProgSemName [Semester], ProfSubID, SemSubTitle [Subject], Capacity, IsSubjectActive [Status]" +
                            "from v_AllSemesterSubjects where [ProgramSemesterIsActive] = 1 or [ProgramIsActive] = 1 or [SemesterIsActive] = 1 or [subjectIsActive] = 1" +
                            " and (Program + ' ' + ProgSemName + ' ' + SemSubTitle) like '%" + searchString.Trim() +"%' order by ProgSemID";
                }

                DataTable semesterlist = DatabaseLayer.Retrieve(query);
                dgvTeacherSubjects.DataSource = semesterlist;
                if (dgvTeacherSubjects.Rows.Count > 0)
                {
                    dgvTeacherSubjects.Columns[0].Visible = false;
                    dgvTeacherSubjects.Columns[1].Visible = false;
                    dgvTeacherSubjects.Columns[2].Width = 120;
                    dgvTeacherSubjects.Columns[3].Visible = false;
                    dgvTeacherSubjects.Columns[4].Width = 150;
                    dgvTeacherSubjects.Columns[5].Visible = false;
                    dgvTeacherSubjects.Columns[6].Width = 300;
                    dgvTeacherSubjects.Columns[7].Width = 80;
                    dgvTeacherSubjects.Columns[8].Width = 80;
                    dgvTeacherSubjects.ClearSelection();
                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }

        private void frmProgramSemesterSubject_Load(object sender, EventArgs e)
        {
            ComboHelper.AllProgramSemesters(cmbSem);
            ComboHelper.AllTeacherSubjects(cmbSub);
            FillGrid(string.Empty);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();

        }

        public void enableComponent()
        {
            dgvTeacherSubjects.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSemSubSearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvTeacherSubjects.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtSemSubSearch.Enabled = true;
            clearForm();
            FillGrid(string.Empty);
        }
        public void clearForm()
        {
            txtSemSubTitle.Clear();
            cmbSub.SelectedIndex = 0;
        }

        private void txtSemSubSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSemSubSearch.Text.Trim());

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Ep.Clear();
            if (txtSemSubTitle.Text.Length == 0)
            {
                Ep.SetError(txtSemSubTitle, "Enter enter correct Semester Subject!");
                txtSemSubTitle.Focus();
                txtSemSubTitle.SelectAll();
                return;
            }

            if (cmbSem.SelectedIndex == 0)
            {
                Ep.SetError(cmbSem, "Please select Semester!");
                cmbSem.Focus();

                return;
            }

            if (cmbSub.SelectedIndex == 0)
            {
                Ep.SetError(cmbSub, "Please select Subject!");
                cmbSub.Focus();

                return;
            }

            string chkquery = "select * from ProgramSemesterSubjectTable where ProgSemID = '" + cmbSem.SelectedValue + "' and ProfSubID = '" + cmbSub.SelectedValue + "'";
            DataTable dt = DatabaseLayer.Retrieve(chkquery);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Ep.SetError(cmbSub, "Enter already exists!");
                    cmbSub.Focus();
                    cmbSub.SelectAll();
                    return;
                }
            }

            string insertQuery = string.Format("insert into ProgramSemesterSubjectTable(SemSubTitle,ProgSemID,ProfSubID) values('{0}','{1}','{2}')",
                txtSemSubTitle.Text.Trim(), cmbSem.SelectedValue, cmbSub.SelectedValue);
            bool result = DatabaseLayer.Insert(insertQuery);
            if (result == true)
            {
                MessageBox.Show("Subject assigned Successfully.");
                FillGrid(string.Empty);
                clearForm();
            }
            else
            {
                MessageBox.Show("Please provide correct details.");
            }
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {

            if (dgvTeacherSubjects != null)
            {
                if (dgvTeacherSubjects.Rows.Count > 0)
                {
                    if (dgvTeacherSubjects.SelectedRows.Count == 1)
                    {
                        if (MessageBox.Show("Are you sure you want to change status?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bool existStatus = Convert.ToBoolean(dgvTeacherSubjects.CurrentRow.Cells[8].Value);
                            int semSubID = Convert.ToInt32(dgvTeacherSubjects.CurrentRow.Cells[0].Value);
                            bool status = false;
                            if (existStatus == true)
                            {
                                status = false;
                            }
                            else
                            {
                                status = true;
                            }

                            string updateQuery = string.Format("update ProgramSemesterSubjectTable set isSubjectActive = '{0}' where ProgramSemesterSubjectID = '{1}'", status, semSubID);
                            bool result = DatabaseLayer.Update(updateQuery);
                            if (result == true)
                            {
                                MessageBox.Show("Change successful!");
                                FillGrid(string.Empty);
                            }
                            else
                            {
                                MessageBox.Show("Please try again!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a single record!");
                    }
                }
                else
                {
                    MessageBox.Show("List is empty!");
                }
            }
            else
            {
                MessageBox.Show("List is empty!");
            }

        }

        private void txtSemSubTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbSub_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtSemSubTitle.Text = cmbSub.SelectedIndex == 0 ? string.Empty : cmbSub.Text;

        }

        private void dgvTeacherSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}

