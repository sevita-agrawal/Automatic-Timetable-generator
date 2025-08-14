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

namespace AutoTimetableGenerator.LecturerSubjectForm
{
    public partial class frmLecturerSubject : Form
    {
        public frmLecturerSubject()
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
                    query = "select ProfSubID[ID],Title[Subject Title],ProfessorID,FirstName,LastName,SubjectID," +
                    "IsActive[Status] from v_AllSubjectsTeachers";
                }
                else
                {
                    query = "select ProfSubID[ID],Title,ProfessorID,FirstName,LastName,SubjectID, " + "IsActive[Status] from v_AllSubjectsTeachers " +
               " where(Title + ' ' + FirstName + ' ' + LastName) like '%" + searchString.Trim() + "%'";
                }

                DataTable programList = DatabaseLayer.Retrieve(query);
                dgvTeacher.DataSource = programList;
                if (dgvTeacher.Rows.Count > 0)
                {
                    dgvTeacher.Columns[0].Visible = false; //Professor Subject ID
                    dgvTeacher.Columns[1].Width = 200; //Course Title
                    dgvTeacher.Columns[2].Visible = false; // Professor ID
                    dgvTeacher.Columns[3].Width = 100; //First name
                    dgvTeacher.Columns[4].Width = 100; //Last Name 
                    dgvTeacher.Columns[5].Visible = false; //Subject ID
                    dgvTeacher.Columns[6].Width = 80; //Active Status
                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }
        public void clearForm()
        {
            cmbFirstName.SelectedIndex = 0;
            //cmbLastName.SelectedIndex = 0;
            cmbSubject.SelectedIndex = 0;
            chkbxStatus.Checked = true;
        }

        public void enableComponent()
        {
            dgvTeacher.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtTeacherSearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvTeacher.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtTeacherSearch.Enabled = true;
            clearForm();
            FillGrid(string.Empty);
        }
        private void frmLecturerSubject_Load(object sender, EventArgs e)
        {
            
            ComboHelper.AllTeachers(cmbFirstName);
           // ComboHelper.AllTeachers(cmbLastName);
            ComboHelper.AllSubjects(cmbSubject);
            FillGrid(String.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Ep.Clear();
                if (cmbSubject.SelectedIndex == 0)
                {
                    Ep.SetError(cmbSubject, "Please Select a Subject");
                    cmbSubject.Focus();
                    return;
                }
                if (cmbFirstName.SelectedIndex == 0)
                {
                    Ep.SetError(cmbFirstName, "Please Select Teacher");
                    cmbFirstName.Focus();
                    return;
                }
                //if (cmbLastName.SelectedIndex == 0)
                //{
                //    Ep.SetError(cmbLastName, "Please Select Teacher");
                //    cmbLastName.Focus();
                //    return;
                //}

                DataTable dt = DatabaseLayer.Retrieve("Select * from ProfessorSubjectTable " +
               "where ProfSubID='" + cmbFirstName.SelectedValue  + "'and SubjectID= '" + cmbFirstName.SelectedValue  + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        Ep.SetError(cmbFirstName, "Subject Already Registered");
                        cmbFirstName.Focus();
                        return;
                    }
                }
                string insertquery = string.Format("insert into ProfessorSubjectTable(ProfSubName,ProfessorID,SubjectID,IsActive) values('{0}','{1}','{2}','{3}')",
                  cmbSubject.Text + "(" + cmbFirstName.Text + ")", cmbFirstName.SelectedValue, cmbSubject.SelectedValue, chkbxStatus.Checked);
                bool result = DatabaseLayer.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Subjects Assigned Successfully");
                    disableComponent();
                }
                else
                {
                    MessageBox.Show("Error!,Please try again");
                }
            }
            catch
            {
                MessageBox.Show("Please Check SqL Connection");
            }
        }

        

        private void txtTeacherSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtTeacherSearch.Text.Trim());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTeacher != null)
                {
                    if (dgvTeacher.Rows.Count > 0)
                    {
                        if (dgvTeacher.SelectedRows.Count == 1)
                        {
                            if (MessageBox.Show("Are you sure you want to change the status?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                string id = Convert.ToString(dgvTeacher.CurrentRow.Cells[0].Value);
                                bool status = (Convert.ToBoolean(dgvTeacher.CurrentRow.Cells[6].Value) == true ? false : true);
                                string updatequery = "Update ProfessorSubjectTable isActive ='" + status + "' where  ProfSubID = '" + id + "'";
                                bool result = DatabaseLayer.Update(updatequery);
                                if (result == true)
                                {
                                    MessageBox.Show("Status Changed Successfully");
                                    disableComponent();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Error!,Please try again");
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void chkbxStatus_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
