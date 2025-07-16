using AutoTimetableGenerator.Forms;
using AutoTimetableGenerator.Forms.CofigurationForms;
using AutoTimetableGenerator.Forms.ProgramSemesterForms;
using AutoTimetableGenerator.LecturerSubjectForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTimetableGenerator
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmSessions());
            //Application.Run(new frmPrograms());
            //Application.Run(new frmSemesters());
            //Application.Run(new frmDays());
            //Application.Run(new frmRoom());
            //Application.Run(new frmLabs());
            //Application.Run(new frmLecturers());
            //Application.Run(new frmProgramSemester());
            //Application.Run(new frmCourses());
            //Application.Run(new frmDayTimeSlots());
            Application.Run(new frmLecturerSubject());
            Application.Run(new frmProgramSemesterSubject());
            Application.Run(new FrmGenerateTimeTable());
            Application.Run(new frmSemesterSections());
            Application.Run(new HomeForm());

        }
    }
}
