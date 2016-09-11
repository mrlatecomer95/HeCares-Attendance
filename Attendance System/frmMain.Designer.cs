namespace Attendance_System
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MainRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.Biodata = new DevExpress.XtraBars.BarButtonItem();
            this.cmdAdd = new DevExpress.XtraBars.BarButtonItem();
            this.cmdEdit = new DevExpress.XtraBars.BarButtonItem();
            this.cmdSave = new DevExpress.XtraBars.BarButtonItem();
            this.cmdDelete = new DevExpress.XtraBars.BarButtonItem();
            this.Attendance = new DevExpress.XtraBars.BarButtonItem();
            this.Courses = new DevExpress.XtraBars.BarButtonItem();
            this.ucEvent = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgAttendance = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgEditAttendance = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgAdmin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgEditAdmin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.SinglePannel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinglePannel)).BeginInit();
            this.SuspendLayout();
            // 
            // MainRibbon
            // 
            this.MainRibbon.AllowMinimizeRibbon = false;
            this.MainRibbon.ExpandCollapseItem.Id = 0;
            this.MainRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.MainRibbon.ExpandCollapseItem,
            this.Biodata,
            this.cmdAdd,
            this.cmdEdit,
            this.cmdSave,
            this.cmdDelete,
            this.Attendance,
            this.Courses,
            this.ucEvent});
            this.MainRibbon.Location = new System.Drawing.Point(0, 0);
            this.MainRibbon.MaxItemId = 2;
            this.MainRibbon.Name = "MainRibbon";
            this.MainRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.MainRibbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.MainRibbon.Size = new System.Drawing.Size(687, 143);
            this.MainRibbon.StatusBar = this.ribbonStatusBar;
            // 
            // Biodata
            // 
            this.Biodata.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.Biodata.Caption = "Biodata";
            this.Biodata.Glyph = ((System.Drawing.Image)(resources.GetObject("Biodata.Glyph")));
            this.Biodata.GroupIndex = 1;
            this.Biodata.Id = 1;
            this.Biodata.Name = "Biodata";
            this.Biodata.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            //this.Biodata.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Biodata_ItemClick);
            // 
            // cmdAdd
            // 
            this.cmdAdd.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.cmdAdd.Caption = "Add";
            this.cmdAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Glyph")));
            this.cmdAdd.Id = 2;
            this.cmdAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A));
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.cmdAdd.DownChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdAdd_DownChanged);
            // 
            // cmdEdit
            // 
            this.cmdEdit.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.cmdEdit.Caption = "Edit";
            this.cmdEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Glyph")));
            this.cmdEdit.Id = 3;
            this.cmdEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.cmdEdit.DownChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdEdit_DownChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Caption = "Save";
            this.cmdSave.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdSave.Glyph")));
            this.cmdSave.Id = 4;
            this.cmdSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.cmdSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSave_ItemClick);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Caption = "Delete";
            this.cmdDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Glyph")));
            this.cmdDelete.Id = 5;
            this.cmdDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.cmdDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdDelete_ItemClick);
            // 
            // Attendance
            // 
            this.Attendance.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.Attendance.Caption = "Attendance";
            this.Attendance.Glyph = ((System.Drawing.Image)(resources.GetObject("Attendance.Glyph")));
            this.Attendance.GroupIndex = 1;
            this.Attendance.Id = 1;
            this.Attendance.Name = "Attendance";
            this.Attendance.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // Courses
            // 
            this.Courses.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.Courses.Caption = "Course";
            this.Courses.Glyph = ((System.Drawing.Image)(resources.GetObject("Courses.Glyph")));
            this.Courses.GroupIndex = 1;
            this.Courses.Id = 2;
            this.Courses.Name = "Courses";
            this.Courses.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ucEvent
            // 
            this.ucEvent.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.ucEvent.Caption = "Events";
            this.ucEvent.Glyph = ((System.Drawing.Image)(resources.GetObject("ucEvent.Glyph")));
            this.ucEvent.GroupIndex = 1;
            this.ucEvent.Id = 1;
            this.ucEvent.Name = "ucEvent";
            this.ucEvent.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgAttendance,
            this.rpgEditAttendance});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Attendance";
            // 
            // rpgAttendance
            // 
            this.rpgAttendance.ItemLinks.Add(this.ucEvent);
            this.rpgAttendance.ItemLinks.Add(this.Attendance);
            this.rpgAttendance.Name = "rpgAttendance";
            this.rpgAttendance.Tag = 1;
            this.rpgAttendance.Text = "Attendance";
            // 
            // rpgEditAttendance
            // 
            this.rpgEditAttendance.ItemLinks.Add(this.cmdAdd);
            this.rpgEditAttendance.ItemLinks.Add(this.cmdEdit);
            this.rpgEditAttendance.ItemLinks.Add(this.cmdSave);
            this.rpgEditAttendance.ItemLinks.Add(this.cmdDelete);
            this.rpgEditAttendance.Name = "rpgEditAttendance";
            this.rpgEditAttendance.Text = "Edit Options";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgAdmin,
            this.rpgEditAdmin});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Admin";
            // 
            // rpgAdmin
            // 
            this.rpgAdmin.ItemLinks.Add(this.Biodata);
            this.rpgAdmin.ItemLinks.Add(this.Courses);
            this.rpgAdmin.Name = "rpgAdmin";
            this.rpgAdmin.Tag = 1;
            this.rpgAdmin.Text = "Attendance";
            // 
            // rpgEditAdmin
            // 
            this.rpgEditAdmin.ItemLinks.Add(this.cmdAdd);
            this.rpgEditAdmin.ItemLinks.Add(this.cmdEdit);
            this.rpgEditAdmin.ItemLinks.Add(this.cmdSave);
            this.rpgEditAdmin.ItemLinks.Add(this.cmdDelete);
            this.rpgEditAdmin.Name = "rpgEditAdmin";
            this.rpgEditAdmin.Tag = 2;
            this.rpgEditAdmin.Text = "Edit Options";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 408);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.MainRibbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(687, 31);
            // 
            // SinglePannel
            // 
            this.SinglePannel.AutoSize = true;
            this.SinglePannel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.SinglePannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SinglePannel.Location = new System.Drawing.Point(0, 143);
            this.SinglePannel.Name = "SinglePannel";
            this.SinglePannel.Size = new System.Drawing.Size(687, 265);
            this.SinglePannel.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 439);
            this.Controls.Add(this.SinglePannel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.MainRibbon);
            this.Name = "frmMain";
            this.Ribbon = this.MainRibbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Attendance System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinglePannel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MainRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgAdmin;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem Biodata;
        private DevExpress.XtraEditors.PanelControl SinglePannel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgEditAttendance;
        private DevExpress.XtraBars.BarButtonItem cmdAdd;
        private DevExpress.XtraBars.BarButtonItem cmdEdit;
        private DevExpress.XtraBars.BarButtonItem cmdSave;
        private DevExpress.XtraBars.BarButtonItem cmdDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgAttendance;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgEditAdmin;
        private DevExpress.XtraBars.BarButtonItem Attendance;
        private DevExpress.XtraBars.BarButtonItem Courses;
        private DevExpress.XtraBars.BarButtonItem ucEvent;
    }
}