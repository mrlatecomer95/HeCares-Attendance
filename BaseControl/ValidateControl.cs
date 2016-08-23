using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseControl
{
    public class ValidateControl
    {

        #region Base Control Validations
        public virtual bool ValidateControls(DevExpress.XtraEditors.BaseEdit[] controlItems)
        {
            bool retval = false;
            foreach (DevExpress.XtraEditors.BaseEdit item in controlItems)
            {
                if (typeof(DevExpress.XtraEditors.TextEdit).Equals(item))
                {
                    if ((DevExpress.XtraEditors.TextEdit)item.EditValue != null || (DevExpress.XtraEditors.TextEdit)item.EditValue != null)
                    {
                        retval = false;
                    }
                    else
                        retval = true;
                }
            }
            return retval;
        }

        #endregion

        #region GridView Validations

        public bool GridValidations(DevExpress.XtraGrid.Views.Grid.GridView _View,string RequiredFieldNames)
        {
            bool retVal = false;
            foreach (DevExpress.XtraGrid.Columns.GridColumn grdColumn in _View.Columns)
            {
                if (grdColumn.FieldName.IndexOf(RequiredFieldNames)>0)
                {
                    
                }
            }

            return retVal;
        }

        #endregion

    }
}
