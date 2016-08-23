using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseControl;
using System.Data.OleDb;
namespace Attendance_System
{
    public partial class Biodata : BaseControl.BaseContent
    {
        public Biodata()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
            base.RefreshData();
            if (!isLoaded)
            {
                InitializeControl();
                isLoaded = true;
            }
            LoadBiodata();
         bModule.GridViewReadOnly(BiodataView, true);
        }

        private DataTable Gender()
        {
            DataTable retval= new DataTable();
            retval.Columns.Add(new DataColumn("ID",typeof(string)));
            retval.Columns.Add(new DataColumn("Name",typeof(string)));

            DataRow nRow = retval.NewRow();
            nRow["ID"] = "Male";
            nRow["Name"] = "Male";
            retval.Rows.Add(nRow);

            nRow = retval.NewRow();
            nRow["ID"] = "Female";
            nRow["Name"] = "Female";
            retval.Rows.Add(nRow);

            return retval;
        }
        
        private void InitializeControl()
        {
            repGender.DataSource = Gender();
        }

        public void LoadBiodata()
        {
            BiodataGrid.DataSource = DB.CreateTable("SELECT *,CBOOL(0) AS Edited FROM tblBiodata ORDER BY LName,FName,MName");
        }

        public override void AddData()
        {
            base.AddData();
            bModule.GridViewReadOnly(BiodataView, false,true);
        }

        public override void EditData()
        {
            base.EditData();
            bModule.GridViewReadOnly(BiodataView, false,false);
        }

        public override void SaveData()
        {
            this.Focus();
            base.SaveData();
            SaveBiodata();
        }

        private void SaveBiodata()
        {
            this.Focus();
            bool info = false;
            int sqltype = 0;
            for (int i = 0; i < BiodataView.RowCount; i++)
            {
                if (Convert.ToBoolean(BiodataView.GetRowCellValue(i,"Edited")))
                {
                    if (string.IsNullOrEmpty(BiodataView.GetRowCellValue(i, "ID").ToString()))
                    {
                        string sql =
                            "INSERT INTO tblBiodata("+
                            "IDNbr," +
                            "LName," +
                            "FName," +
                            "MName," +
                            "DOB," +
                            "Gender," +
                            "POB," +
                            "Inactive)" +
                            "VALUES("+
                            "@IDNbr," +
                            "@LName," +
                            "@FName," +
                            "@MName," +
                            "@DOB," +
                            "@Gender," +
                            "@POB," +
                            "@Inactive)";
                        OleDbParameter[] sqlParam = {
                                                    new OleDbParameter("@IDNbr",DB.GenerateID("IDNbr","tblBiodata")),
                                                    new OleDbParameter("@LName",BiodataView.GetRowCellValue(i,"LName")),
                                                    new OleDbParameter("@FName",BiodataView.GetRowCellValue(i,"FName")),
                                                    new OleDbParameter("@MName",BiodataView.GetRowCellValue(i,"MName")),
                                                    new OleDbParameter("@DOB",BiodataView.GetRowCellValue(i,"DOB")),
                                                    new OleDbParameter("@Gender",BiodataView.GetRowCellValue(i,"Gender")),
                                                    new OleDbParameter("@POB",BiodataView.GetRowCellValue(i,"POB")),
                                                    new OleDbParameter("@Inactive",BiodataView.GetRowCellValue(i,"Inactive"))
                                                    };
                        sqltype = 1;
                        info = DB.RunSql(sql, sqlParam);
                    }
                    else
                    {
                        try
                        {
                            string sql =
                                "UPDATE tblBiodata SET " +
                                "[IDNbr]=@IDNbr," +
                                "[LName]=@LName," +
                                "[FName]=@FName," +
                                "[MName]=@MName," +
                                "[DOB]=@DOB," +
                                "[Gender]=@Gender," +
                                "[POB]=@POB," +
                                "[Inactive]=@Inactive" +
                                " WHERE [ID] = @ID";
                            OleDbParameter[] sqlParam = {
                                                    new OleDbParameter("@IDNbr",DB.GenerateID("IDNbr","tblBiodata")),
                                                    new OleDbParameter("@LName",BiodataView.GetRowCellValue(i,"LName")),
                                                    new OleDbParameter("@FName",BiodataView.GetRowCellValue(i,"FName")),
                                                    new OleDbParameter("@MName",BiodataView.GetRowCellValue(i,"MName")),
                                                    new OleDbParameter("@DOB",BiodataView.GetRowCellValue(i,"DOB")),
                                                    new OleDbParameter("@Gender",BiodataView.GetRowCellValue(i,"Gender")),
                                                    new OleDbParameter("@POB",BiodataView.GetRowCellValue(i,"POB")),
                                                    new OleDbParameter("@Inactive",BiodataView.GetRowCellValue(i,"Inactive")),
                                                    new OleDbParameter("@ID",BiodataView.GetRowCellValue(i,"ID"))
                                                    };
                            sqltype = 2;
                            info = DB.RunSql(sql, sqlParam);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    if (info)
                    {
                        //RefreshData();
                        LoadBiodata();
                    }
                    bModule.GetMessage(sqltype, info);

                }
            }
        }

        private void BiodataView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            bModule.GridRowCellStyle(sender, e);
        }

        private void BiodataView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView _view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            _view.SetRowCellValue(e.RowHandle,"Edited",true);
            _view.SetRowCellValue(e.RowHandle,"IDNbr",DB.GenerateID("IDNbr","tblBiodata"));
        }

        private void BiodataView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView _view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (!e.Column.FieldName.Equals("Edited"))
            {
                _view.SetRowCellValue(e.RowHandle, "Edited", true);
            }
        }

    }
}
