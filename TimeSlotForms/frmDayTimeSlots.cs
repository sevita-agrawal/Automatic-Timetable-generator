using AutoTimetableGenerator.AllModels;
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
    public partial class frmDayTimeSlots : Form
    {
        public frmDayTimeSlots()
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
                    query = "select DaySlotID, DayID, DayName[Day], DaySlotName [Slot Title],StartTime [Start Time], EndTime[End Time], isActive[Status] from v_AllTimeSlots where isActive = 1";
                }
                else
                {
                    query = "select DaySlotID, DayID, DayName[Day], DaySlotName [Slot Title],StartTime [Start Time], EndTime[End Time], isActive[Status] from v_AllTimeSlots" +
                            "where isActive = 1 AND (DayName + ' ' + DaySlotName) like '%" + searchString.Trim() + "%'";
                }

                DataTable slotList = DatabaseLayer.Retrieve(query);
                dgvSlots.DataSource = slotList;
                if (dgvSlots.Rows.Count > 0)
                {
                    dgvSlots.Columns[0].Width = 80; //DaySlotID
                    dgvSlots.Columns[1].Visible = false; //DayID
                    dgvSlots.Columns[2].Width = 130; // DayName
                    dgvSlots.Columns[3].Width = 150; //DaySlotName
                    dgvSlots.Columns[4].Width = 100; //StartTime
                    dgvSlots.Columns[5].Width = 100; //EndTime
                    dgvSlots.Columns[6].Width = 80; //isActive
                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }
        private void frmDayTimeSlots_Load(object sender, EventArgs e)
        {
            dtpStartTime.Value = new DateTime(2025, 12, 12, 9, 0, 0);
            dtpEndTime.Value = new DateTime(2025, 12, 12, 17, 0, 0);
            ComboHelper.AllDays(cmbDays);
            ComboHelper.TimeSlotNumbers(cmbNumberOfTimeSlot);
            FillGrid(string.Empty);
        }
        public void clearForm()
        {
            cmbDays.SelectedIndex = 0;
            cmbNumberOfTimeSlot.SelectedIndex = 0;
            chkDayStatus.Checked = true;
        }

        public void enableComponent()
        {
            dgvSlots.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSlotSearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvSlots.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtSlotSearch.Enabled = true;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Ep.Clear();
                if (cmbDays.SelectedIndex == 0)
                {
                    Ep.SetError(cmbDays, "Please Select a Day");
                    cmbDays.Focus();
                    return;
                }
                if (cmbNumberOfTimeSlot.SelectedIndex == 0)
                {
                    Ep.SetError(cmbNumberOfTimeSlot, "Please Select Time Slot Number");
                    cmbNumberOfTimeSlot.Focus();
                    return;
                }

                string UpdateQuery = "update DaySlotTable set IsActive = 0 where DaySlotID ='" + cmbDays.SelectedValue + "'";
                bool updateResult = DatabaseLayer.Update(UpdateQuery);
                if (updateResult == true)
                {

                    List<TimeSlots> timeSlots = new List<TimeSlots>();
                    TimeSpan time = dtpEndTime.Value - dtpStartTime.Value;
                    int totalMinutes = (int)time.TotalMinutes;
                    int numOfTimeSlots = Convert.ToInt32(cmbNumberOfTimeSlot.SelectedValue);
                    int slotDuration = totalMinutes / numOfTimeSlots;

                    // Calculate and add each time slot to the list.
                    for (int i = 0; i < numOfTimeSlots; i++)
                    {
                        var timeSlot = new TimeSlots();
                        var fromTime = dtpStartTime.Value.AddMinutes(slotDuration * i);
                        var toTime = dtpStartTime.Value.AddMinutes(slotDuration * (i + 1));
                        string title = $"{fromTime:hh:mm tt}-{toTime:hh:mm tt}";

                        timeSlot.FromTime = fromTime;
                        timeSlot.ToTime = toTime;
                        timeSlot.DaySlotName = title;
                        timeSlots.Add(timeSlot);
                    }

                    foreach (var slot in timeSlots)
                    {
                        Console.WriteLine($"Slot: {slot.DaySlotName}, From: {slot.FromTime}, To: {slot.ToTime}");
                    }


                    bool insertstatus = true;
                    foreach (TimeSlots slottime in timeSlots)
                    {
                        string insertquery = string.Format("insert into DaySlotTable(DayID,DaySlotName,StartTime,EndTime,isActive) values ('{0}','{1}','{2}','{3}','{4}')",
                        cmbDays.SelectedValue, slottime.DaySlotName, slottime.FromTime, slottime.ToTime, chkDayStatus.Checked);
                        bool result = DatabaseLayer.Insert(insertquery);
                        if (result == false)
                        {
                            insertstatus = false;
                        }
                    }
                    if (insertstatus == true)
                    {
                        MessageBox.Show("Slots Created Successfully");
                        disableComponent();
                    }
                    else
                    {
                        MessageBox.Show("Please Provide Correct details");
                    }
                }
                else
                {
                    MessageBox.Show("Please Provide Correct details");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Check SQL Connection");
            }
        }

        private void dgvSlots_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void breakTimeToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (dgvSlots != null)
        //    {
        //        if (dgvSlots.Rows.Count > 0)
        //        {
        //            if (dgvSlots.SelectedRows.Count == 1)
        //            {
        //                string SlotId = Convert.ToString(dgvSlots.CurrentRow.Cells[0].Value);
        //                string updatequery = "Update DaySlotTable set isActive = 0 where DaySlotID = '" + Convert.ToString(dgvSlots.CurrentRow.Cells[0].Value) + "'";
        //                bool result = DatabaseLayer.Update(updatequery);
        //                if (result == true)
        //                {
        //                    MessageBox.Show("Break Time is marked and Excluded from TimeTable");
        //                    disableComponent();
        //                }
        //            }
        //        }
        //    }
        //}

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            if (dgvSlots != null)
            {
                if (dgvSlots.Rows.Count > 0)
                {
                    if (dgvSlots.SelectedRows.Count == 1)
                    {
                        string SlotId = Convert.ToString(dgvSlots.CurrentRow.Cells[0].Value);
                        string updatequery = "Update DaySlotTable set isActive = 0 where DaySlotID = '" + Convert.ToString(dgvSlots.CurrentRow.Cells[0].Value) + "'";
                        bool result = DatabaseLayer.Update(updatequery);
                        if (result == true)
                        {
                            MessageBox.Show("Break Time is marked and Excluded from TimeTable");
                            disableComponent();
                        }
                    }
                }
            }
        }

        private void txtSlotSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSlotSearch.Text.Trim());
        }
    }
}
