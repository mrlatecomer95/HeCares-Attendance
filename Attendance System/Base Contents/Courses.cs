using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Attendance_System
{
    public partial class Courses : BaseControl.BaseContent
    {
        public Courses()
        {
            InitializeComponent();
        }

        #region Initializations

        DataSet CourseDS = new DataSet();

        private void InitControls()
        {
           
        }

        private void LoadCourses()
        {
            CourseGrid.DataSource = DB.CreateTable("SELECT *,CBOOL(0) AS Edited FROM tblAdmCourse");
            OleDbConnection sqlConn = new OleDbConnection(DB.getConnectionString);
            try
            {
                sqlConn.Open();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandText = "SELECT *,CBOOL(0) AS Edited FROM tblAdmCourse;SELECT *,CBOOL(0) AS Edited FROM tblCourseSeries ";
                    using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                    {
                        CourseDS = new DataSet();
                        adp.Fill(CourseDS, "Courses");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Open();
            }

        }

        private void GenerateCourseSeries()
        {
            CourseDS = DB.CreateDataSet(new string[]{"SELECT *,CBOOL(0) AS Edited FROM tblAdmCourse ORDER BY DateStarted DESC,Name",
                "SELECT *,CBOOL(0) AS Edited FROM tblCourseSeries ORDER BY SortCode, Name "});
            CourseDS.Tables[0].TableName = "Course";
            CourseDS.Tables[1].TableName = "Series";
            if (!CourseDS.Relations.Contains("Course_Series") )
            {
                CourseDS.Relations.Add("Course_Series", CourseDS.Tables["Course"].Columns["ID"], CourseDS.Tables["Series"].Columns["FKeyCourse"]);
            }
            CourseGrid.DataSource = CourseDS.Tables["Course"];
            CourseGrid.LevelTree.Nodes.Add("Course_Series", SeriesView);
           
        }

        #endregion
        
        #region MainFunction

        public override void RefreshData()
        {
            base.RefreshData();
            if (isLoaded)
            {
                InitControls();
                isLoaded = true;
            }
            //LoadCourses();
            GenerateCourseSeries();
            bModule.GridViewReadOnly(CourseView, true);
            bModule.GridViewReadOnly(SeriesView, true);
        }

        public override void AddData()
        {
            base.AddData();
            bModule.GridViewReadOnly(CourseView, !isAdding);
            bModule.GridViewReadOnly(SeriesView, !isAdding);
        }

        public override void EditData()
        {
            base.EditData();
            bModule.GridViewReadOnly(CourseView, !isEditing, false);
            bModule.GridViewReadOnly(SeriesView, !isEditing);
        }

        public override void SaveData()
        {
            this.Focus();
            base.SaveData();
            bool info = SaveCourses();
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

        public override void DeleteData()
        {
            base.DeleteData();
        }

        #endregion

        //Save Courses
        private bool SaveCourses()
        {
            bool retval = false;
            OleDbConnection sqlConn = new OleDbConnection(DB.getConnectionString);
            OleDbTransaction sqlTrans = null;
            int CourseID = 0; 
            bool toBeInserted = false;
            try
            {
                sqlConn.Open();
                sqlTrans = sqlConn.BeginTransaction();
                for (int i = 0; i < CourseView.RowCount; i++)
                {
                    if (Convert.ToBoolean(CourseView.GetRowCellValue(i, "Edited")))
                    {
                        if (string.IsNullOrEmpty(CourseView.GetRowCellValue(i, "ID").ToString()))
                        {
                            CourseID = 0;
                            using (OleDbCommand cmd = new OleDbCommand())
                            {
                                cmd.Connection = sqlConn;
                                cmd.Transaction = sqlTrans;
                                cmd.CommandText = "INSERT INTO tblAdmCourse(" +
                                    "Name" +
                                    ",SortCode" +
                                    ",Description" +
                                    ",DateStarted" +
                                    ",DateEnd" +
                                    ")VALUES(" +
                                    "@Name" +
                                    ",@SortCode" +
                                    ",@Description" +
                                    ",@DateStarted" +
                                    ",@DateEnd" +
                                    ")";
                                cmd.Parameters.AddWithValue("@Name", CourseView.GetRowCellValue(i, "Name"));
                                cmd.Parameters.AddWithValue("@SortCode", CourseView.GetRowCellValue(i, "SortCode"));
                                cmd.Parameters.AddWithValue("@Description", CourseView.GetRowCellValue(i, "Description"));
                                cmd.Parameters.AddWithValue("@DateStarted", CourseView.GetRowCellValue(i, "DateStarted"));
                                cmd.Parameters.AddWithValue("@DateEnd", CourseView.GetRowCellValue(i, "DateEnd"));
                                toBeInserted = cmd.ExecuteNonQuery().Equals(1);
                                cmd.CommandText = "SELECT @@IDENTITY";
                                CourseID = (int)cmd.ExecuteScalar();
                            }

                        }
                        else
                        {
                            CourseID = (int)CourseView.GetRowCellValue(i, "ID");
                            using (OleDbCommand cmd = new OleDbCommand())
                            {
                                cmd.Connection = sqlConn;
                                cmd.Transaction = sqlTrans;
                                cmd.CommandText = "UPDATE tblAdmCourse " +
                                    " SET [Name] = @Name" +
                                    ",[SortCode] = @SortCode" +
                                    ",[Description] = @Description" +
                                    ",[DateStarted] = @DateStarted" +
                                    ",[DateEnd] = @DateEnd" +
                                    ",[DateUpdated] = Now" +
                                    " WHERE [ID]=@ID";
                                cmd.Parameters.AddWithValue("@Name", CourseView.GetRowCellValue(i, "Name"));
                                cmd.Parameters.AddWithValue("@SortCode", CourseView.GetRowCellValue(i, "SortCode"));
                                cmd.Parameters.AddWithValue("@Description", CourseView.GetRowCellValue(i, "Description"));
                                cmd.Parameters.AddWithValue("@DateStarted", CourseView.GetRowCellValue(i, "DateStarted"));
                                cmd.Parameters.AddWithValue("@DateEnd", CourseView.GetRowCellValue(i, "DateEnd"));
                                cmd.Parameters.AddWithValue("@ID", CourseView.GetRowCellValue(i, "ID"));
                                toBeInserted = cmd.ExecuteNonQuery().Equals(1);
                            }
                        }

                        //Child Sub View
                        DevExpress.XtraGrid.Views.Grid.GridView childView = (DevExpress.XtraGrid.Views.Grid.GridView)CourseView.GetDetailView(i, CourseView.GetRelationIndex(i, "Course_Series"));
                        for (int subViewRow = 0; subViewRow < childView.RowCount; subViewRow++)
                        {
                            if (Convert.ToBoolean(childView.GetRowCellValue(subViewRow, "Edited")))
                            {
                                if (string.IsNullOrEmpty(childView.GetRowCellValue(subViewRow, "ID").ToString()))
                                {
                                    using (OleDbCommand cmd = new OleDbCommand())
                                    {
                                        cmd.Connection = sqlConn;
                                        cmd.Transaction = sqlTrans;
                                        cmd.CommandText = "INSERT INTO tblCourseSeries(" +
                                            "[FKeyCourse]" +
                                            ",[Name]" +
                                            ",[Description]" +
                                            ",[SortCode]" +
                                            ")VALUES(" +
                                            "@FKeyCourse" +
                                            ",@Name" +
                                            ",@Description" +
                                            ",@SortCode" +
                                            ")";
                                        cmd.Parameters.AddWithValue("@FKeyCourse", CourseID);
                                        cmd.Parameters.AddWithValue("@Name", childView.GetRowCellValue(subViewRow, "Name"));
                                        cmd.Parameters.AddWithValue("@Description", childView.GetRowCellValue(subViewRow, "Description"));
                                        cmd.Parameters.AddWithValue("@SortCode", childView.GetRowCellValue(subViewRow, "SortCode"));
                                        toBeInserted = cmd.ExecuteNonQuery().Equals(1);
                                    }
                                }
                                else
                                {
                                    using (OleDbCommand cmd = new OleDbCommand())
                                    {
                                        cmd.Connection = sqlConn;
                                        cmd.Transaction = sqlTrans;
                                        cmd.CommandText = "UPDATE tblCourseSeries " +
                                            " SET [Name] = @Name" +
                                            ",[SortCode] = @SortCode" +
                                            ",[Description] = @Description" +
                                            ",[DateUpdated] = (Now())" +
                                            " WHERE ((([ID])=@ID) AND (([FKeyCourse])=@FKeyCourse))";
                                        cmd.Parameters.AddWithValue("@Name", childView.GetRowCellValue(subViewRow, "Name").ToString());
                                        cmd.Parameters.AddWithValue("@SortCode", childView.GetRowCellValue(subViewRow, "SortCode"));
                                        cmd.Parameters.AddWithValue("@Description", childView.GetRowCellValue(subViewRow, "Description").ToString());
                                        cmd.Parameters.AddWithValue("@ID", childView.GetRowCellValue(subViewRow, "ID"));
                                        cmd.Parameters.AddWithValue("@FKeyCourse", childView.GetRowCellValue(subViewRow, "FKeyCourse"));
                                        toBeInserted = cmd.ExecuteNonQuery().Equals(1);
                                    }
                                }
                            }
                            
                        }
                    }
                }
                if (toBeInserted)
                {
                    sqlTrans.Commit();
                    retval = true;
                }
            }
            catch (Exception ex)
            {
                retval = false;
                sqlTrans.Rollback();
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }
            return retval;
        }

        private void SeriesView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            bModule.GridRowCellStyle(sender, e);
        }
        private void SeriesView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView _view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (!e.Column.FieldName.Equals("Edited"))
            {
                _view.SetRowCellValue(e.RowHandle, "Edited", true);
                DevExpress.XtraGrid.Views.Grid.GridView _masterView = (DevExpress.XtraGrid.Views.Grid.GridView)_view.ParentView;
                _masterView.SetRowCellValue(_view.SourceRowHandle, "Edited", true);
            }
        }
        private void SeriesView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView _view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            _view.SetRowCellValue(e.RowHandle, "Edited", true);
            DevExpress.XtraGrid.Views.Grid.GridView _masterView = (DevExpress.XtraGrid.Views.Grid.GridView)_view.ParentView;
            _masterView.SetRowCellValue(_view.SourceRowHandle, "Edited", true);
        }

        private void CourseView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            bModule.GridRowCellStyle(sender, e);
        }
        private void CourseView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView _view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (!e.Column.FieldName.Equals("Edited"))
            {
                _view.SetRowCellValue(e.RowHandle, "Edited", true);

            }
        }
        private void CourseView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView _view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            _view.SetRowCellValue(e.RowHandle, "Edited", true);
        }
        private void CourseView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView _v = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            //DevExpress.XtraGrid.Views.Grid.GridView _child = (DevExpress.XtraGrid.Views.Grid.GridView)_v.GetDetailView(e.FocusedRowHandle, _v.GetRelationIndex(e.FocusedRowHandle, "Course_Series"));

            //if (_child.IsRowLoaded(e.FocusedRowHandle))
            //{
            //    _v.ExpandMasterRow(e.FocusedRowHandle);
            //}
          
        }


    }
}
