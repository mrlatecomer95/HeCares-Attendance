using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Attendance_System.Base_Contents
{
    public partial class Attendance : BaseControl.BaseContent
    {
        public Attendance()
        {
            InitializeComponent();
        }

        private DataTable tblSeries;
        private void InitControls()
        {
            //cboEvent.Properties.DataSource = DB.CreateTable("SELECT * FROM tblAdmCourse ORDER BY Name");
            //tblSeries = DB.CreateTable("SELECT * FROM tblCourseSeries ORDER BY SortCode, Name");
        }

        private void LoadAttendee()
        {
            AttendeeGrid.DataSource = DB.CreateTable(" SELECT * FROM qSelAttendee ");
        }
      
        public override void RefreshData()
        {
            base.RefreshData();

            if (!isLoaded)
            {
                InitControls();
                isLoaded = true;
            }
            LoadAttendee();
        }
        
        public override void AddData()
        {
            base.AddData();
        }
        
        public override void EditData()
        {
            base.EditData();
        }
        
        public override void SaveData()
        {
            base.SaveData();
        }

        private void cboEvent_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}
