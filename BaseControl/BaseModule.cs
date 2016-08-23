using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
namespace BaseControl
{
    public class BaseModule
    {
        public  void  GridViewReadOnly(DevExpress.XtraGrid.Views.Grid.GridView _view, bool value,bool showNewRows=true)
        {
            _view.OptionsBehavior.ReadOnly = value;
            _view.OptionsBehavior.Editable = !(value);
            if (_view.OptionsBehavior.Editable == true)
            {
                if (showNewRows)
                {
                    _view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                }
                else
                {
                    _view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                }
            }
            else
            {
                _view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }

        }
        public void GridRowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView _view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (Convert.ToBoolean(_view.GetRowCellValue(e.RowHandle,"Edited")))
            {
                e.Appearance.BackColor = UtilColor.EditedColor;
            }
        }
        //Generic Messages
        public void GetMessage(int Criteria,bool Status)
        {
            string strMsg = "";
            switch (Criteria)
            {
                case 1: //Add
                    if (Status)
                    {
                        strMsg =  "Record(s) Added.";
                    }
                    else
                    {
                        strMsg =  "Unable to Add Record(s).";
                    }
                    break;
                case 2: //Edit
                    if (Status)
                    {
                        strMsg =  "Record(s) Edited.";
                    }
                    else
                    {
                        strMsg =  "Unable to Edit Record(s).";
                    }
                    break;
                case 3: //Save
                    if (Status)
                    {
                        strMsg = "Record(s) Saved.";
                    }
                    else
                    {
                        strMsg = "Unable to Save Record(s).";
                    }
                    break;
                case 4: //Delete
                    if (Status)
                    {
                        strMsg = "Record(s) Deleted.";
                    }
                    else
                    {
                        strMsg = "Unable to Delete Record(s).";
                    }
                    break;
                default:
                    strMsg = "Error";
                    break;
            }
            MessageBox.Show(strMsg, Application.ProductName, MessageBoxButtons.OK, Status ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }
    }
}
