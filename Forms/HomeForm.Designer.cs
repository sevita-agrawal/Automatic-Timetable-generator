namespace AutoTimetableGenerator.Forms
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.addDayTimeSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.assignSubjectsToLecurerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.assignSubjectToSemesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignSemesterToProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSemesterSectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSemestersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripProgram = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Location = new System.Drawing.Point(-74, 62);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(986, 359);
            this.panelHeader.TabIndex = 7;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(63, 20);
            this.toolStripStatusLabel1.Text = "Ready ...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslblDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(916, 26);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblDateTime
            // 
            this.tsslblDateTime.Name = "tsslblDateTime";
            this.tsslblDateTime.Size = new System.Drawing.Size(838, 20);
            this.tsslblDateTime.Spring = true;
            this.tsslblDateTime.Text = "toolStripStatusLabel2";
            this.tsslblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Location = new System.Drawing.Point(0, 59);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(916, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::AutoTimetableGenerator.Properties.Resources.timetableicon;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(149, 56);
            this.toolStripButton4.Text = "Generate Time Table";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // addDayTimeSlotToolStripMenuItem
            // 
            this.addDayTimeSlotToolStripMenuItem.Name = "addDayTimeSlotToolStripMenuItem";
            this.addDayTimeSlotToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.addDayTimeSlotToolStripMenuItem.Text = "Day Time Slot";
            this.addDayTimeSlotToolStripMenuItem.Click += new System.EventHandler(this.addDayTimeSlotToolStripMenuItem_Click);
            // 
            // addDaysToolStripMenuItem
            // 
            this.addDaysToolStripMenuItem.Name = "addDaysToolStripMenuItem";
            this.addDaysToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.addDaysToolStripMenuItem.Text = "Add Days";
            this.addDaysToolStripMenuItem.Click += new System.EventHandler(this.addDaysToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDaysToolStripMenuItem,
            this.addDayTimeSlotToolStripMenuItem});
            this.toolStripDropDownButton4.Image = global::AutoTimetableGenerator.Properties.Resources.daysicon;
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(55, 56);
            this.toolStripDropDownButton4.Text = "Days";
            this.toolStripDropDownButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::AutoTimetableGenerator.Properties.Resources.subjecticon;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(62, 56);
            this.toolStripButton3.Text = "Subject";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // assignSubjectsToLecurerToolStripMenuItem
            // 
            this.assignSubjectsToLecurerToolStripMenuItem.Name = "assignSubjectsToLecurerToolStripMenuItem";
            this.assignSubjectsToLecurerToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.assignSubjectsToLecurerToolStripMenuItem.Text = "Assign Subjects to Lecurer";
            this.assignSubjectsToLecurerToolStripMenuItem.Click += new System.EventHandler(this.assignSubjectsToLecurerToolStripMenuItem_Click);
            // 
            // newTeacherToolStripMenuItem
            // 
            this.newTeacherToolStripMenuItem.Name = "newTeacherToolStripMenuItem";
            this.newTeacherToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.newTeacherToolStripMenuItem.Text = "New Lecturer";
            this.newTeacherToolStripMenuItem.Click += new System.EventHandler(this.newTeacherToolStripMenuItem_Click);
            // 
            // addLabsToolStripMenuItem
            // 
            this.addLabsToolStripMenuItem.Name = "addLabsToolStripMenuItem";
            this.addLabsToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.addLabsToolStripMenuItem.Text = "Add Labs";
            this.addLabsToolStripMenuItem.Click += new System.EventHandler(this.addLabsToolStripMenuItem_Click);
            // 
            // addRoomsToolStripMenuItem
            // 
            this.addRoomsToolStripMenuItem.Name = "addRoomsToolStripMenuItem";
            this.addRoomsToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.addRoomsToolStripMenuItem.Text = "Add Rooms";
            this.addRoomsToolStripMenuItem.Click += new System.EventHandler(this.addRoomsToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRoomsToolStripMenuItem,
            this.addLabsToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::AutoTimetableGenerator.Properties.Resources.roomsicon;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(111, 56);
            this.toolStripDropDownButton2.Text = "Room\'s/Lab\'s";
            this.toolStripDropDownButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // assignSubjectToSemesterToolStripMenuItem
            // 
            this.assignSubjectToSemesterToolStripMenuItem.Name = "assignSubjectToSemesterToolStripMenuItem";
            this.assignSubjectToSemesterToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.assignSubjectToSemesterToolStripMenuItem.Text = " Assign Subject to Semester";
            this.assignSubjectToSemesterToolStripMenuItem.Click += new System.EventHandler(this.assignSubjectToSemesterToolStripMenuItem_Click);
            // 
            // assignSemesterToProgramToolStripMenuItem
            // 
            this.assignSemesterToProgramToolStripMenuItem.Name = "assignSemesterToProgramToolStripMenuItem";
            this.assignSemesterToProgramToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.assignSemesterToProgramToolStripMenuItem.Text = "Assign Semester to Program";
            this.assignSemesterToProgramToolStripMenuItem.Click += new System.EventHandler(this.assignSemesterToProgramToolStripMenuItem_Click);
            // 
            // addSemesterSectionsToolStripMenuItem
            // 
            this.addSemesterSectionsToolStripMenuItem.Name = "addSemesterSectionsToolStripMenuItem";
            this.addSemesterSectionsToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.addSemesterSectionsToolStripMenuItem.Text = "Add Semester Sections";
            this.addSemesterSectionsToolStripMenuItem.Click += new System.EventHandler(this.addSemesterSectionsToolStripMenuItem_Click);
            // 
            // newSemestersToolStripMenuItem
            // 
            this.newSemestersToolStripMenuItem.Name = "newSemestersToolStripMenuItem";
            this.newSemestersToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.newSemestersToolStripMenuItem.Text = "New Semesters";
            this.newSemestersToolStripMenuItem.Click += new System.EventHandler(this.newSemestersToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSemestersToolStripMenuItem,
            this.addSemesterSectionsToolStripMenuItem,
            this.assignSemesterToProgramToolStripMenuItem,
            this.assignSubjectToSemesterToolStripMenuItem});
            this.toolStripDropDownButton3.Image = global::AutoTimetableGenerator.Properties.Resources.semestericon;
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(90, 56);
            this.toolStripDropDownButton3.Text = "Semesters";
            this.toolStripDropDownButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripDropDownButton3.Click += new System.EventHandler(this.toolStripDropDownButton3_Click);
            // 
            // toolStripProgram
            // 
            this.toolStripProgram.Image = global::AutoTimetableGenerator.Properties.Resources.programicon;
            this.toolStripProgram.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripProgram.Name = "toolStripProgram";
            this.toolStripProgram.Size = new System.Drawing.Size(70, 56);
            this.toolStripProgram.Text = "Program";
            this.toolStripProgram.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripProgram.Click += new System.EventHandler(this.toolStripProgram_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::AutoTimetableGenerator.Properties.Resources.sessionicon;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(62, 56);
            this.toolStripButton2.Text = "Session";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTeacherToolStripMenuItem,
            this.assignSubjectsToLecurerToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::AutoTimetableGenerator.Properties.Resources.teachericon;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(82, 56);
            this.toolStripDropDownButton1.Text = "Lecturers";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripProgram,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1,
            this.toolStripButton3,
            this.toolStripDropDownButton4,
            this.toolStripButton4,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(916, 59);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::AutoTimetableGenerator.Properties.Resources.printsicon;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(119, 56);
            this.toolStripButton1.Text = "Print Time Table";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 450);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblDateTime;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem addDayTimeSlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem assignSubjectsToLecurerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRoomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem assignSubjectToSemesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignSemesterToProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSemesterSectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSemestersToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripButton toolStripProgram;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}