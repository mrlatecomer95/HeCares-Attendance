using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using BaseControl;

namespace Attendance_System
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BaseContent _BaseContent; //BaseContent

        public frmMain()
        {
            InitializeComponent();
            InitRibbonItems();
        }

        public void BaseContentHandler()
        {
            //Visibility
            _BaseContent.EditButtonVisibility += EditButtonVisibility;
            _BaseContent.AddButtonVisiblity += AddButtonVisiblity;
            _BaseContent.SaveButtonVisibility += SaveButtonVisiblity;
            _BaseContent.DeleteButtonVisiblity += DeleteButtonVisiblity;
            //Caption
            _BaseContent.EditButtonCaption += EditButtonCaption;
            _BaseContent.AddButtonCaption += AddButtonCaption;
            _BaseContent.SaveButtonCaption += SaveButtonCaption;
            _BaseContent.DeleteButtonCaption += DeletButtonCaption;
            //Enable
            _BaseContent.AllowAddButton += AddButtonEnable;
            _BaseContent.AllowDeleteButton += DeleteButtonEnable;
            _BaseContent.AllowEditButton += EditButtonEnable;
            _BaseContent.AllowSaveButton += SaveButtonEnable;
            //Down
            _BaseContent.EditDownChanged += EditButtonDown;
            _BaseContent.AddDownChanged += AddButtonDown;
        }

        public void InitRibbonItems()
        {
            foreach (DevExpress.XtraBars.Ribbon.RibbonPage rp in MainRibbon.Pages) {
                foreach (DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg in rp.Groups){
                    if (rpg.Tag!=null)
                    {
                        if (rpg.Tag.Equals(1))
                        {
                            foreach (DevExpress.XtraBars.BarButtonItemLink bLink in rpg.ItemLinks)
                            {
                                if (bLink.Item is DevExpress.XtraBars.BarButtonItem)
                                {
                                    DevExpress.XtraBars.BarButtonItem btn = bLink.Item;
                                    btn.ItemClick += new ItemClickEventHandler(btn_ItemClick);
                                }
                            }
                        }
                    }
                }
            }
                    
        }

        //Button Handler
        void btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadContent(e.Item.Name);
        }

        /// <summary>
        /// Load Content
        /// </summary>
        /// <param name="ObjectID"></param>
        private void LoadContent(string ObjectID){

            //Load Object to Pannel
            LoadObject(ObjectID);
            //Load Data
            LoadData();
        }
        
        /// <summary>
        /// Load Objects to Pannel
        /// </summary>
        /// <param name="ObjectID"></param>
        private void LoadObject(string ObjectID) {
            _BaseContent = ucFactory.LoadContentItem(ObjectID);
            if (_BaseContent != null)
            {
                BaseContentHandler(); //Place the Handlers
                SinglePannel.Controls.Clear();
                _BaseContent.DB = GLOBALS.AttendanceDB;
                Control ctr = (Control)_BaseContent;
                SinglePannel.Controls.Add(ctr);
                ctr.Dock = DockStyle.Fill;
            }
            else
            {
                SinglePannel.Controls.Clear();
            }
 
        }

        /// <summary>
        /// Load the Data of the Object
        /// </summary>
        private void LoadData() {
            if (_BaseContent != null)
            {
                _BaseContent.RefreshData();
            }
        }

        //Frm Load
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!InitializeDatabase())
            {
                Application.Exit();
            }
        }

        private bool InitializeDatabase()
        {
            string strConn = "";
            strConn = Attendance_System.Properties.Settings.Default["AttendanceConnectionString"].ToString();
            try
            {
                GLOBALS.AttendanceDB = new DataFactory.OLEDB(strConn);
                GLOBALS.AttendanceDB.setConnectionString = strConn;
                if (GLOBALS.AttendanceDB.TestConnection(strConn))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Unable to connect to Database.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;
            }
 

        }

        #region Editing Options

        #region Button Click
        private void cmdSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            _BaseContent.SaveData();
        }
        //Delete Button
        private void cmdDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            _BaseContent.DeleteData();
        }
        #endregion

        #region Button Visibility
        private void EditButtonVisibility(object sender, DevExpress.XtraBars.BarItemVisibility value)
        {
            cmdEdit.Visibility = value;
        }
        private void AddButtonVisiblity(object sender, DevExpress.XtraBars.BarItemVisibility value)
        {
            cmdAdd.Visibility =  value;
        }
        private void SaveButtonVisiblity(object sender, DevExpress.XtraBars.BarItemVisibility value)
        {
            cmdSave.Visibility = value;
        }
        private void DeleteButtonVisiblity(object sender, DevExpress.XtraBars.BarItemVisibility value)
        {
            cmdDelete.Visibility = value;
        }
        #endregion

        #region Button Caption
        private void EditButtonCaption(object sender, string value)
        {
            cmdEdit.Caption = value;
        }
        private void AddButtonCaption(object sender, string value)
        {
            cmdAdd.Caption = value;
        }
        private void SaveButtonCaption(object sender, string value)
        {
            cmdSave.Caption = value;
        }
        private void DeletButtonCaption(object sender, string value)
        {
            cmdDelete.Caption = value;
        }
        #endregion

        #region Button Enable
        private void AddButtonEnable(object sender, bool value)
        {
            cmdAdd.Enabled = value;
        }
        private void EditButtonEnable(object sender, bool value)
        {
            cmdEdit.Enabled = value;
        }
        private void SaveButtonEnable(object sender, bool value)
        {
            cmdSave.Enabled = value;
        }
        private void DeleteButtonEnable(object sender, bool value)
        {
            cmdDelete.Enabled = value;
        }
        
        #endregion

        #region ButtonDown
        private void EditButtonDown(object sender, bool value)
        {
            cmdEdit.Down = value;

        }
        private void AddButtonDown(object sender, bool value)
        {
            cmdAdd.Down = value;
        }

        private void cmdEdit_DownChanged(object sender, ItemClickEventArgs e)
        {
            DevExpress.XtraBars.BarButtonItem btn = (DevExpress.XtraBars.BarButtonItem)sender;
            //if (btn.Down)
            //{
                if (_BaseContent != null)
                {
                    _BaseContent.isEditing = btn.Down;
                    _BaseContent.EditData();
                }
            //}
        }

        private void cmdAdd_DownChanged(object sender, ItemClickEventArgs e)
        {
            DevExpress.XtraBars.BarButtonItem btn = (DevExpress.XtraBars.BarButtonItem)sender;
            //if (btn.Down)
            //{
                if (_BaseContent != null)
                {
                    _BaseContent.isAdding = btn.Down;
                    _BaseContent.AddData();
                }
            //}
        }
        #endregion


        #endregion



    }
}