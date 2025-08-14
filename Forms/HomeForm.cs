using AutoTimetableGenerator.Forms.CofigurationForms;
using AutoTimetableGenerator.Forms.ProgramSemesterForms;
using AutoTimetableGenerator.LecturerSubjectForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTimetableGenerator.Forms
{
    public partial class HomeForm : Form
    {
        frmCourses CoursesForm;
        frmDays DaysForm;
        frmLabs LabsForm;
        frmLecturers LecturesForm;
        frmPrograms ProgramForm;
        frmRoom RoomForm;
        frmSemesters SemestersForm;
        frmSessions SessionForm;
        frmLecturerSubject LecturesSubjectForm;
        frmProgramSemester ProgramSemestersForm;
        frmProgramSemesterSubject ProgramSemesterSubjectForm;
        frmDayTimeSlots DayTimeSlotsForm;
        frmSemesterSections SemesterSectionsForm;
        frmTimeTableManualEntry TimeTableManualEntryForm;
         FrmGenerateTimeTable AutoGenerateTimeTableForm;
        frmPrintAllTimeTables PrintAllTimeTablesForm;
        // FrmPrintTeacherWiseTimeTable PrintAllTeacherTimeTablesForm;
        frmPrintDaysWise PrintAllDaysTimeTablesForm;
        public HomeForm()
        {
            InitializeComponent();
            tsslblDateTime.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripProgram_Click(object sender, EventArgs e)
        {
            if (ProgramForm == null)
            {
                ProgramForm = new frmPrograms();
            }
            ProgramForm.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (SessionForm == null)
            {
                SessionForm = new frmSessions();
            }
              SessionForm.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (CoursesForm == null)
            {
                CoursesForm = new frmCourses();
            }
            CoursesForm.ShowDialog();
        }

        private void newTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LecturesForm == null)
            {
                LecturesForm = new frmLecturers();
            }
            LecturesForm.ShowDialog();
        }

        private void assignSubjectsToLecurerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LecturesSubjectForm == null)
            {
                LecturesSubjectForm = new frmLecturerSubject();
            }
            LecturesSubjectForm.ShowDialog();
        }

        private void addRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RoomForm == null)
            {
                RoomForm = new frmRoom();
            }
            RoomForm.ShowDialog();
        }

        private void addLabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LabsForm == null)
            {
                LabsForm = new frmLabs();
            }
            LabsForm.ShowDialog();
        }

        private void newSemestersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SemestersForm == null)
            {
                SemestersForm = new frmSemesters();
            }
            SemestersForm.ShowDialog();
        }

        private void addSemesterSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SemesterSectionsForm == null)
            {
                SemesterSectionsForm = new frmSemesterSections();
            }
            SemesterSectionsForm.ShowDialog();
        }

        private void assignSemesterToProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramSemestersForm == null)
            {
                ProgramSemestersForm = new frmProgramSemester();
            }
            ProgramSemestersForm.ShowDialog();
        }

        private void assignSubjectToSemesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramSemesterSubjectForm == null)
            {
                ProgramSemesterSubjectForm = new frmProgramSemesterSubject();
            }
            ProgramSemesterSubjectForm.ShowDialog();
        }

        private void addDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DaysForm == null)
            {
                DaysForm = new frmDays();
            }
            DaysForm.ShowDialog();
        }

        private void addDayTimeSlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DayTimeSlotsForm == null)
            {
                DayTimeSlotsForm = new frmDayTimeSlots();
            }
            DayTimeSlotsForm.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (AutoGenerateTimeTableForm == null)
            {
                AutoGenerateTimeTableForm = new FrmGenerateTimeTable();
            }
            AutoGenerateTimeTableForm.ShowDialog();
        }

       

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //if (PrintAllTimeTablesForm == null)
            //{
            //    PrintAllTimeTablesForm = new frmPrintAllTimeTables();
            //}
            //PrintAllTimeTablesForm.TopLevel = false;
            //panelHeader.Controls.Add(PrintAllTimeTablesForm);
            //PrintAllTimeTablesForm.Dock = DockStyle.Fill;
            //PrintAllTimeTablesForm.FormBorderStyle = FormBorderStyle.None;
            //PrintAllTimeTablesForm.BringToFront();
            //PrintAllTimeTablesForm.Show();

        }

        private void toolStripDropDownButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
