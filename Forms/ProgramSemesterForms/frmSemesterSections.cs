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
    public partial class frmSemesterSections : Form
    {
        public frmSemesterSections()
        {
            InitializeComponent();
        }

        private void frmSemesterSections_Load(object sender, EventArgs e)
        {
            ComboHelper.AllProgramSemesters(cmbSem);
            FillGrid(string.Empty);
        }
        public void FillGrid(string searchvalue)
        {

            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchvalue.Trim()))
                {
                    query = " select SectionID, SectionTitle [Section], ProgSemID, Title [Semester],IsActive [Status] from v_AllSemesterSections order by ProgSemID ";
                }
                else
                {
                    query = " select SectionID, SectionTitle [Section], ProgSemID, Title [Semester],IsActive [Status] from v_AllSemesterSections " +
                            " WHERE (SectionTitle + ' ' + Title) like '%" + searchvalue.Trim() + "%' order by ProgSemID";
                }

                DataTable sectionlist = DatabaseLayer.Retrieve(query);
                dgvSections.DataSource = sectionlist;
                if (dgvSections.Rows.Count > 0)
                {
                    dgvSections.Columns[0].Visible = false; // SectionID
                    dgvSections.Columns[1].Width = 200; //SectionTitle
                    dgvSections.Columns[2].Visible = false; // ProgramSemesterID
                    dgvSections.Columns[3].Width = 200; // Title
                    dgvSections.Columns[4].Width = 80; // IsActive

                    dgvSections.ClearSelection();
                }
            }
            catch
            {
                MessageBox.Show("Some unexpected issue occure plz try again!");
            }
        }

        public void enableComponent()
        {
            dgvSections.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSectionTitle.Enabled = false;
        }

        public void disableComponent()
        {
            dgvSections.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtSectionTitle.Enabled = true;
            clearForm();
            FillGrid(string.Empty);
        }
        public void clearForm()
        {
            txtSectionTitle.Clear();
            cmbSem.SelectedIndex = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void txtSemSecSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSemSecSearch.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Ep.Clear();
                if (txtSectionTitle.Text.Trim().Length == 0)
                {
                    Ep.SetError(txtSectionTitle, "Please Enter Section Title!");
                    txtSectionTitle.Focus();
                    return;
                }

                if (cmbSem.SelectedIndex == 0)
                {
                    Ep.SetError(cmbSemesters, "Please Select Semester!");
                    cmbSemesters.Focus();
                    return;
                }
                // Check Existing Record, if found show "Already Exists" message near txtTitle
                DataTable dt = DatabaseLayer.Retrieve("select * from SectionTable where SectionTitle = '" + txtSectionTitle.Text.Trim() + "' and ProgramSemesterID = '" + cmbSem.SelectedValue + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        Ep.SetError(txtSectionTitle, "Already Exists!");
                        txtSectionTitle.Focus();
                        return;
                    }
                }
                // Query for save/insert record in sectiontable
                string insertquery = string.Format("insert into SectionTable(SectionTitle,ProgSemID) values('{0}','{1}')", txtSectionTitle.Text.Trim(), cmbSem.SelectedValue);
                bool result = DatabaseLayer.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Save Successfully!");
                    FillGrid(string.Empty);
                    clearForm();
                }
                else
                {
                    MessageBox.Show("Please Try Again!");
                }
            }
            catch (Exception ex) // Show Error message in any case if exception generate
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            if (dgvSections != null)
            {
                if (dgvSections.Rows.Count > 0)
                {
                    if (dgvSections.SelectedRows.Count == 1)
                    {

                        if (MessageBox.Show("Are you sure you want to change status?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bool existstatus = Convert.ToBoolean(dgvSections.CurrentRow.Cells[4].Value);
                            int sectionid = Convert.ToInt32(dgvSections.CurrentRow.Cells[0].Value);
                            bool status = false;
                            if (existstatus == true)
                            {
                                status = false;
                            }
                            else
                            {
                                status = true;
                            }
                            string updatequery = string.Format("update SectionTable set IsActive = '{0}' where SectionID = '{1}'", status, sectionid);
                            bool result = DatabaseLayer.Update(updatequery);
                            if (result == true)
                            {
                                MessageBox.Show("Change Successfully!");
                                FillGrid(string.Empty);
                            }
                            else
                            {
                                MessageBox.Show("Please Try Again!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record!");
                    }
                }
                else
                {
                    MessageBox.Show("List is Empty!");
                }
            }
            else
            {
                MessageBox.Show("List is Empty!");
            }
        }

        private void txtCapacity_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
