using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataFactory;
using BaseControl;
using System.Data.OleDb;

namespace BaseControl
{
    public partial class BaseContent : DevExpress.XtraEditors.XtraUserControl
    {
        public BaseContent()
        {
            InitializeComponent();
        }

        #region Declaration
            public OLEDB DB;
            protected bool isLoaded = false;
            protected BaseModule bModule = new BaseModule();
        #endregion

        #region Properties
            private bool _isEditing = false;
            public bool isEditing
            {
                get
                {
                    return _isEditing;
                    
                }
                set
                {
                    _isEditing = value;
                    if (value)
                    {
                        OnAddButtonDown(Name, !value);
                    }
                }
            }

            private bool _isAdding = false;
            public bool isAdding
            {
                get
                {
                    return _isAdding;
                }
                set
                {
                    _isAdding = value;
                    if (value)
                    {
                        OnEditDownChanged(Name, !value);
                    }
                }
            }
        #endregion

        #region Button Events And Handlers

            public delegate void ButtonDownChangedHandler(object sender, bool value);
            #region Button Down
                public event ButtonDownChangedHandler EditDownChanged;
                protected virtual void OnEditDownChanged(object sender, bool value)
                {
                    if (EditDownChanged != null)
                    {
                        EditDownChanged(sender, value);
                        isEditing = value;
	                }
                }
                public event ButtonDownChangedHandler AddDownChanged;
                protected virtual void OnAddButtonDown(object sender, bool value)
                {
                    if (AddDownChanged!=null)
                    {
                        AddDownChanged(sender, value);
                        isAdding = value;
                    }
                }
            #endregion

            public delegate void ButtonCaptionHandler(object sender, string value);
            #region Button Caption
            public event ButtonCaptionHandler AddButtonCaption;
            protected virtual void onAddButtonCaption(object sender, string value)
            {
                if (AddButtonCaption!=null)
                {
                    AddButtonCaption(sender, value);
                }
            }
            public event ButtonCaptionHandler SaveButtonCaption;
            protected void onSaveButtonCaption(object sender, string value)
            {
                if (SaveButtonCaption!=null)
                {
                    SaveButtonCaption(sender, value);
                }
            }
            public event ButtonCaptionHandler DeleteButtonCaption;
            protected void onDeleteButtonCaption(object sender, string value)
            {
                if (DeleteButtonCaption!=null)
                {
                    DeleteButtonCaption(sender, value);
                }
            }
            public event ButtonCaptionHandler EditButtonCaption;
            protected virtual void onEditButtonCaption(object sender, string value)
            {
                if (EditButtonCaption != null)
                {
                    EditButtonCaption(sender, value);
                }
            }
            #endregion

            public delegate void ButtonVisibilityHander(object sender, DevExpress.XtraBars.BarItemVisibility value);
            #region Button Visibility
                public event ButtonVisibilityHander EditButtonVisibility;
                protected virtual void onEditButtonVisibility(object sender, DevExpress.XtraBars.BarItemVisibility value)
                {
                    if (EditButtonVisibility != null)
                    {
                        EditButtonVisibility(sender, value);
                    }
                }
                public event ButtonVisibilityHander AddButtonVisiblity;
                protected virtual void onAddButtonVisibility(object sender, DevExpress.XtraBars.BarItemVisibility value)
                {
                    if (AddButtonVisiblity != null)
                    {
                        AddButtonVisiblity(sender, value);
                    }
                }
                public event ButtonVisibilityHander SaveButtonVisibility;
                protected virtual void onSaveButtonVisiblity(object sender, DevExpress.XtraBars.BarItemVisibility value)
                {
                    if (SaveButtonVisibility != null)
                    {
                        SaveButtonVisibility(sender, value);
                    }
                }
                public event ButtonVisibilityHander DeleteButtonVisiblity;
                protected virtual void onDeleteButtonVisibility(object sender, DevExpress.XtraBars.BarItemVisibility value)
                {
                    if (DeleteButtonVisiblity != null)
                    {
                        DeleteButtonVisiblity(sender, value);
                    }
                }
            #endregion

            public delegate void ButtonAllowHandler(object sender, bool value);
            #region Allow Button
                public event ButtonAllowHandler AllowAddButton;
                protected void onAllowAddButton(object sender, bool value)
                {
                    if (AllowAddButton!=null)
                    {
                        AllowAddButton(sender, value);
                    }
                }
                public event ButtonAllowHandler AllowEditButton;
                protected void onAllowEditButton(object sender, bool value)
                {
                    if (AllowEditButton!=null)
                    {
                        AllowEditButton(sender, value);
                    }
                }
                public event ButtonAllowHandler AllowSaveButton;
                protected void onAllowSaveButton(object sender, bool value)
                {
                    if (AllowSaveButton!=null)
                    {
                        AllowSaveButton(sender, value);
                    }
                }
                public event ButtonAllowHandler AllowDeleteButton;
                protected void onAllowDeleteButton(object sender, bool value)
                {
                    if (AllowDeleteButton!=null)
                    {
                        AllowDeleteButton(sender, value);
                    }
                }
            #endregion


        #endregion

        #region Main Functions

        #region RefreshData
            virtual public void RefreshData()
            {
                OnEditDownChanged(Name, false);
                OnAddButtonDown(Name, false);
                DefaultEditButtonNames();
            }
            private void DefaultEditButtonNames()
            {
                onAddButtonCaption(Name, "Add");
                onEditButtonCaption(Name, "Edit");
                onSaveButtonCaption(Name, "Save");
                onDeleteButtonCaption(Name, "Delete");
            }

        #endregion

            virtual public void AddData() { }
            virtual public void EditData() { }
            virtual public void SaveData() { }
            virtual public void DeleteData() { }
            virtual public void ExecuteCustomFunction(object[] param) { }
        #endregion

        #region BaseFunctions

            #region LayoutControls
            protected void ClearControls(DevExpress.XtraLayout.LayoutControlGroup _LayouControl)
            {
                foreach (DevExpress.XtraLayout.LayoutControlItem item in _LayouControl.Items)
                {
                    if (!item.GetType().Equals(typeof(DevExpress.XtraLayout.EmptySpaceItem)))
                    {
                        DevExpress.XtraEditors.BaseEdit ctr = (DevExpress.XtraEditors.BaseEdit)item.Control;
                        ctr.EditValue = null;
                    }
                }
            }

            protected void MakeControlsReadOnly(DevExpress.XtraLayout.LayoutControlGroup _LayoutControl, bool value)
            {
                foreach (DevExpress.XtraLayout.LayoutControlItem item in _LayoutControl.Items)
                {
                    if (!(item).GetType().Equals(typeof(DevExpress.XtraLayout.EmptySpaceItem)))
                    {
                        DevExpress.XtraEditors.BaseEdit ctr = (DevExpress.XtraEditors.BaseEdit)item.Control;
                        ctr.ReadOnly = value;
                    }
                }
            }
            #endregion
        #region GridView
            private void MakeViewReadOnly(DevExpress.XtraGrid.Views.Grid.GridView _GridView, bool value)
            {
                _GridView.OptionsBehavior.ReadOnly = value;
            }
        #endregion

        #endregion

    }
}
