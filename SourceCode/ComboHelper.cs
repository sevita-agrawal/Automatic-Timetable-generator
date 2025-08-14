using AutoTimeTableGenerator;

using System.Data;

using System.Windows.Forms;

namespace TimeTableGenerator.SourceCode
{
    public class ComboHelper
    {
        public static void Semesters(ComboBox cmb)
        {
            DataTable dtSemesters = new DataTable();
            dtSemesters.Columns.Add("SemesterID");
            dtSemesters.Columns.Add("SemesterName");
            dtSemesters.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("Select SemesterID,SemesterName from SemesterTable where isActive = 1");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow semester in dt.Rows)
                        {
                            dtSemesters.Rows.Add(semester["SemesterID"], semester["SemesterName"]);
                        }
                    }
                }
                cmb.DataSource = dtSemesters;
                cmb.ValueMember = "SemesterID";
                cmb.DisplayMember = "SemesterName";
            }
            catch
            {
                cmb.DataSource = dtSemesters;
            }
        }
        public static void Programs(ComboBox cmb)
        {
            DataTable dtPrograms = new DataTable();
            dtPrograms.Columns.Add("ProgramID");
            dtPrograms.Columns.Add("ProgramName");
            dtPrograms.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("Select ProgramID,ProgramName from ProgramTable ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow program in dt.Rows)
                        {
                            dtPrograms.Rows.Add(program["ProgramID"],
                                program["ProgramName"]);
                        }
                    }
                }
                cmb.DataSource = dtPrograms;
                cmb.ValueMember = "ProgramID";
                cmb.DisplayMember = "ProgramName";
            }
            catch
            {
                cmb.DataSource = dtPrograms;
            }
        }
        public static void RoomTypes(ComboBox cmb)
        {
            DataTable dtTypes = new DataTable();
            dtTypes.Columns.Add("RoomTypeID");
            dtTypes.Columns.Add("RoomTypeName");
            dtTypes.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("Select RoomTypeID,RoomTypeName from RoomTypeTable ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtTypes.Rows.Add(type["RoomTypeID"],
                                type["RoomTypeName"]);
                        }
                    }
                }
                cmb.DataSource = dtTypes;
                cmb.ValueMember = "RoomTypeID";
                cmb.DisplayMember = "RoomTypeName";
            }
            catch
            {
                cmb.DataSource = dtTypes;
            }
        }
        public static void AllDays(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("DayID");
            dtList.Columns.Add("DayName");
            dtList.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("Select DayID,DayName from DayTable where IsActive = 1");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtList.Rows.Add(type["DayID"],
                                type["DayName"]);
                        }
                    }
                }
                cmb.DataSource = dtList;
                cmb.ValueMember = "DayID";
                cmb.DisplayMember = "DayName";
            }
            catch
            {
                cmb.DataSource = dtList;
            }
        }
        public static void TimeSlotNumbers(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("ID");
            dtList.Columns.Add("Number");
            dtList.Rows.Add("0", "---Select---");
            dtList.Rows.Add("1", "1");
            dtList.Rows.Add("2", "2");
            dtList.Rows.Add("3", "3");
            dtList.Rows.Add("4", "4");
            dtList.Rows.Add("5", "5");
            dtList.Rows.Add("6", "6");
            dtList.Rows.Add("7", "7");
            dtList.Rows.Add("8", "8");
            dtList.Rows.Add("9", "9");
            dtList.Rows.Add("10", "10");

            cmb.DataSource = dtList;
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "Number";
        }
        public static void AllTeachers(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("LecturerID");
            dtList.Columns.Add("FullName");
           // dtList.Columns.Add("LastName");
            dtList.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("Select LecturerID,FirstName,LastName from LecturerTable where IsActive = 1 ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            string fullName = type["FirstName"].ToString() + " " + type["LastName"].ToString();
                            dtList.Rows.Add(type["LecturerID"], fullName);

                        }
                    }
                }
                cmb.DataSource = dtList;
                cmb.ValueMember = "LecturerID";
                cmb.DisplayMember = "FullName";
                //cmb.DisplayMember = "LastName";
            }
            catch
            {
                cmb.DataSource = dtList;
            }
        }
        public static void AllSubjects(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("CourseID");
            dtList.Columns.Add("Title");
            dtList.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("Select CourseID,Title from CourseTable where IsActive = 1 ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtList.Rows.Add(type["CourseID"], type["Title"]);
                        }
                    }
                }
                cmb.DataSource = dtList;
                cmb.ValueMember = "CourseID";
                cmb.DisplayMember = "Title";
            }
            catch
            {
                cmb.DataSource = dtList;
            }
        }

        public static void AllProgramSemesters(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("ProgSemID");
            dtList.Columns.Add("Title");
            dtList.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("Select ProgSemID,Title from v_ProgramSemesterActiveList where ProgramSemesterIsActive = 1 ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtList.Rows.Add(type["ProgSemID"],
                                type["Title"]);
                        }
                    }
                }
                cmb.DataSource = dtList;
                cmb.ValueMember = "ProgSemID";
                cmb.DisplayMember = "Title";
            }
            catch
            {
                cmb.DataSource = dtList;
            }
        }

        public static void AllTeacherSubjects(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("ProfSubID");
            dtList.Columns.Add("Title");
            dtList.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("Select ProfSubID,Title from v_AllSubjectsTeachers where isActive = 1 ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtList.Rows.Add(type["ProfSubID"],
                                type["Title"]);
                        }
                    }
                }
                cmb.DataSource = dtList;
                cmb.ValueMember = "ProfSubID";
                cmb.DisplayMember = "Title";
            }
            catch
            {
                cmb.DataSource = dtList;
            }
        }

    }
}