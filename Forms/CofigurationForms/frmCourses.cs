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

namespace AutoTimetableGenerator.Forms.CofigurationForms
{
    public partial class frmCourses : Form
    {
        public frmCourses()
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
                    query = "select CourseID [ID] , Title [Subject], CourseCredit, RoomTypeID , RoomTypeName [Type], IsActive from v_AllSubjects";
                }
                else
                {
                    query = "select CourseID [ID] , Title [Subject], CourseCredit, RoomTypeID , RoomTypeName [Type], IsActive from v_AllSubjects where (Title + ' ' +RoomTypeName) like '%" + searchString.Trim() + "%'";
                }

                DataTable programList = DatabaseLayer.Retrieve(query);
                dgvSubjects.DataSource = programList;
                if (dgvSubjects.Rows.Count > 0)
                {
                    dgvSubjects.Columns[0].Width = 80; //CourseID
                    dgvSubjects.Columns[1].Width = 250; //CourseTitle
                    dgvSubjects.Columns[2].Width = 60;  //Course Credit
                    dgvSubjects.Columns[3].Visible = false; //RoomTypeID
                    dgvSubjects.Columns[4].Width = 250; //TypeName
                    dgvSubjects.Columns[5].Width = 80; // IsActive

                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }
        private void frmCourses_Load(object sender, EventArgs e)
        {
            cmbCrHrs.SelectedIndex = 0;
            ComboHelper.RoomTypes(cmbSelectType);
            FillGrid(string.Empty);
        }
        public void clearForm()
        {
            txtbxSubName.Clear();
            cmbSelectType.SelectedIndex = 0;
            cmbCrHrs.SelectedIndex = 0;
            chkbxSubStatus.Checked = false;
        }

        public void enableComponent()
        {
            dgvSubjects.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSubSearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvSubjects.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtSubSearch.Enabled = true;
            clearForm();
            FillGrid(string.Empty);
        }

        private void txtSubSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSubSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtbxSubName.Text.Length == 0)
            {
                Ep.SetError(txtbxSubName, "Enter correct Subject Name!");
                txtbxSubName.Focus();
                txtbxSubName.SelectAll();
                return;
            }
            if (cmbSelectType.SelectedIndex == 0)
            {
                Ep.SetError(cmbSelectType, "Please select Subject Type");
                cmbSelectType.Focus();
                return;
            }

            DataTable chkSubName = DatabaseLayer.Retrieve("select * from CourseTable where Title = '" + txtbxSubName.Text.Trim() + "'and RoomTypeID = '"+ cmbSelectType +"'");
            if (chkSubName != null)
            {
                if (chkSubName.Rows.Count > 0)
                {
                    Ep.SetError(txtbxSubName, "Enter already exists!");
                    txtbxSubName.Focus();
                    txtbxSubName.SelectAll();
                    return;
                }
            }

            string insertQuery = string.Format("insert into CourseTable(Title,CourseCredit,isActive,RoomTypeID) values('{0}','{1}','{2}','{3}')",
                txtbxSubName.Text.ToUpper().Trim(), cmbCrHrs.Text, chkbxSubStatus.Checked, cmbSelectType.SelectedValue);
            bool result = DatabaseLayer.Insert(insertQuery);
            if (result == true)
            {
                MessageBox.Show("Saved Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Subject Details.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtbxSubName.Text.Length == 0)
            {
                Ep.SetError(txtbxSubName, "Enter correct Subject Name!");
                txtbxSubName.Focus();
                txtbxSubName.SelectAll();
                return;
            }
            if (cmbSelectType.SelectedIndex == 0)
            {
                Ep.SetError(cmbSelectType, "Please select Subject Type");
                cmbSelectType.Focus();
                return;
            }

            DataTable chkSubName = DatabaseLayer.Retrieve("select * from CourseTable where Title = '" + txtbxSubName.Text.Trim() + "'and CourseID !='" + Convert.ToString(dgvSubjects.CurrentRow.Cells[0].Value) + "'");
            {
                if (chkSubName.Rows.Count > 0)
                {
                    Ep.SetError(txtbxSubName, "Enter already exists!");
                    txtbxSubName.Focus();
                    txtbxSubName.SelectAll();
                    return;
                }
            }

            string updateQuery = string.Format("update CourseTable set Title = '{0}',CourseCredit = '{1}',RoomTypeID = '{2}',isActive = '{3}' where CourseID = '{4}'",
                txtbxSubName.Text.Trim(), chkbxSubStatus.Checked, Convert.ToString(dgvSubjects.CurrentRow.Cells[0].Value));
            bool result = DatabaseLayer.Update(updateQuery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Subject Details.");
            }
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            if (dgvSubjects != null)
            {
                if (dgvSubjects.Rows.Count > 0)
                {
                    if (dgvSubjects.SelectedRows.Count == 1)
                    {
                        txtbxSubName.Text = Convert.ToString(dgvSubjects.CurrentRow.Cells[1].Value);
                        //cmb.Text = Convert.ToString(dgvSubjects.CurrentRow.Cells[2].Value);
                        cmbSelectType.Text = Convert.ToString(dgvSubjects.CurrentRow.Cells[3].Value);
                        cmbCrHrs.SelectedValue = Convert.ToString(dgvSubjects.CurrentRow.Cells[2].Value);//ProgramID
                        chkbxSubStatus.Checked = Convert.ToBoolean(dgvSubjects.CurrentRow.Cells[5].Value);//SemesterID
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
