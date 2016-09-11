using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Attendance_System.Base_Contents
{
    public partial class ucEvent : BaseControl.BaseContent
    {
        public ucEvent()
        {
            InitializeComponent();
        }

        private DataTable tblCourse = new DataTable();
        private DataTable tblSeries = new DataTable();

        private void InitControls()
        {
            InitDatatable();
            cboCourse.Properties.DataSource = tblCourse;
            repEvntCourse.DataSource = tblCourse;
            repEvntSeries.DataSource = tblSeries;
            MakeViewReadOnly(EventListView, true);
        }

        private void InitDatatable()
        {
            tblCourse = DB.CreateTable("SELECT * FROM tblAdmCourse ORDER BY Name");
            tblSeries = DB.CreateTable("SELECT * FROM tblCourseSeries ORDER BY SortCode, Name");
        }
        
        private void LoadEventList()
        {
            EventListGrid.DataSource = DB.CreateTable("SELECT * FROM tblEvents ORDER BY DateCreated DESC");
        }

        #region Main Function
        public override void RefreshData()
        {
            base.RefreshData();
            if (!isLoaded)
            {
                //init
                InitControls();
                isLoaded = true;
            }
            LoadEventList();
            MakeControlsReadOnly(LCGEventDetails, true);
        }

        public override void AddData()
        {
            base.AddData();
            ClearControls(LCGEventDetails);
            MakeControlsReadOnly(LCGEventDetails, !isAdding);
            if (!isAdding)
            {
                RefreshEventListDetails(EventListView);
            }

        }

        public override void EditData()
        {
            base.EditData();
            MakeControlsReadOnly(LCGEventDetails, !isEditing);
        }

        public override void SaveData()
        {
            base.SaveData();
            bool info = false;
            if (isAdding)
            {
                string strSQL = "INSERT INTO tblEvents(FKeyCourse,FKeySeries,DateCreated,Remarks)" +
                    "VALUES(@FKeyCourse,@FKeySeries,@DateCreated,@Remarks)";
                System.Data.OleDb.OleDbParameter[] sqlParam = 
                {
                    new System.Data.OleDb.OleDbParameter("@FKeyCourse",cboCourse.EditValue),
                    new System.Data.OleDb.OleDbParameter("@FKeySeries",cboSeries.EditValue),
                    new System.Data.OleDb.OleDbParameter("@DateCreated",txtDateCreated.Text),
                    new System.Data.OleDb.OleDbParameter("@Remarks",txtRemarks.Text),
                };
                info = DB.RunSql(strSQL, sqlParam);
            }
            else
            {

            }

            if (info)
            {
                bModule.GetMessage(3, info);
                RefreshData();
            }
            else
            {
                bModule.GetMessage(3, info);
            }
        }
        #endregion

        #region EventListView
        private void RefreshEventListDetails(DevExpress.XtraGrid.Views.Grid.GridView _view)
        {
            cboCourse.EditValue = _view.GetFocusedRowCellValue("FKeyCourse");
            cboSeries.EditValue = _view.GetFocusedRowCellValue("FKeySeries");
            txtDateCreated.EditValue = _view.GetFocusedRowCellValue("DateCreated");
            txtRemarks.Text = (string)_view.GetFocusedRowCellValue("Remarks");
        }
        private void EventListView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView _view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            RefreshEventListDetails(_view);
        }
        private void EventListView_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView _view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            RefreshEventListDetails(_view);
        }
        #endregion

        private void cboCourse_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit _l = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (_l.EditValue != null)
            {
                if (tblSeries.Select("FKeyCourse = " + _l.EditValue).Length > 0)
                {
                    cboSeries.Properties.DataSource = tblSeries.Select("FKeyCourse = " + _l.EditValue).CopyToDataTable();
                }
                else
                {
                    cboCourse.Properties.DataSource = tblSeries.Clone();
                }
                
            }
        }

    }
}
