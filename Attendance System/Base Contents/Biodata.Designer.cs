namespace Attendance_System
{
    partial class Biodata
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.BiodataGrid = new DevExpress.XtraGrid.GridControl();
            this.BiodataView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDNbr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repGender = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDOB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BiodataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BiodataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repGender)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.BiodataGrid);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(384, 298);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Child Information";
            // 
            // BiodataGrid
            // 
            this.BiodataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BiodataGrid.Location = new System.Drawing.Point(2, 21);
            this.BiodataGrid.MainView = this.BiodataView;
            this.BiodataGrid.Name = "BiodataGrid";
            this.BiodataGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repGender});
            this.BiodataGrid.Size = new System.Drawing.Size(380, 275);
            this.BiodataGrid.TabIndex = 0;
            this.BiodataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.BiodataView});
            // 
            // BiodataView
            // 
            this.BiodataView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BiodataView.Appearance.EvenRow.Options.UseBackColor = true;
            this.BiodataView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BiodataView.Appearance.OddRow.Options.UseBackColor = true;
            this.BiodataView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colIDNbr,
            this.colLName,
            this.colFName,
            this.colMName,
            this.gridColumn3,
            this.colDOB,
            this.colPOB,
            this.gridColumn2,
            this.gridColumn1});
            this.BiodataView.GridControl = this.BiodataGrid;
            this.BiodataView.Name = "BiodataView";
            this.BiodataView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.BiodataView.OptionsView.RowAutoHeight = true;
            this.BiodataView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.BiodataView_RowCellStyle);
            this.BiodataView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.BiodataView_InitNewRow);
            this.BiodataView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.BiodataView_CellValueChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            // 
            // colIDNbr
            // 
            this.colIDNbr.Caption = "ID Number";
            this.colIDNbr.FieldName = "IDNbr";
            this.colIDNbr.Name = "colIDNbr";
            this.colIDNbr.OptionsColumn.AllowFocus = false;
            this.colIDNbr.OptionsColumn.ReadOnly = true;
            this.colIDNbr.OptionsColumn.TabStop = false;
            this.colIDNbr.Visible = true;
            this.colIDNbr.VisibleIndex = 0;
            this.colIDNbr.Width = 151;
            // 
            // colLName
            // 
            this.colLName.Caption = "Last Name";
            this.colLName.FieldName = "LName";
            this.colLName.Name = "colLName";
            this.colLName.Visible = true;
            this.colLName.VisibleIndex = 1;
            this.colLName.Width = 151;
            // 
            // colFName
            // 
            this.colFName.Caption = "First Name";
            this.colFName.FieldName = "FName";
            this.colFName.Name = "colFName";
            this.colFName.Visible = true;
            this.colFName.VisibleIndex = 2;
            this.colFName.Width = 151;
            // 
            // colMName
            // 
            this.colMName.Caption = "Middle Name";
            this.colMName.FieldName = "MName";
            this.colMName.Name = "colMName";
            this.colMName.Visible = true;
            this.colMName.VisibleIndex = 3;
            this.colMName.Width = 151;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Gender";
            this.gridColumn3.ColumnEdit = this.repGender;
            this.gridColumn3.FieldName = "Gender";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 74;
            // 
            // repGender
            // 
            this.repGender.AutoHeight = false;
            this.repGender.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repGender.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.False)});
            this.repGender.DisplayMember = "Name";
            this.repGender.Name = "repGender";
            this.repGender.NullText = "";
            this.repGender.ShowFooter = false;
            this.repGender.ShowHeader = false;
            this.repGender.ValueMember = "ID";
            // 
            // colDOB
            // 
            this.colDOB.Caption = "Birth Date";
            this.colDOB.FieldName = "DOB";
            this.colDOB.Name = "colDOB";
            this.colDOB.Visible = true;
            this.colDOB.VisibleIndex = 4;
            this.colDOB.Width = 123;
            // 
            // colPOB
            // 
            this.colPOB.Caption = "Place Of Birth";
            this.colPOB.FieldName = "POB";
            this.colPOB.Name = "colPOB";
            this.colPOB.Visible = true;
            this.colPOB.VisibleIndex = 6;
            this.colPOB.Width = 279;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Inactive";
            this.gridColumn2.FieldName = "Inactive";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 56;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Edited";
            this.gridColumn1.DisplayFormat.FormatString = "{0}";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn1.FieldName = "Edited";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            // 
            // Biodata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.groupControl1);
            this.Name = "Biodata";
            this.Size = new System.Drawing.Size(384, 298);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BiodataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BiodataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repGender)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl BiodataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView BiodataView;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colIDNbr;
        private DevExpress.XtraGrid.Columns.GridColumn colLName;
        private DevExpress.XtraGrid.Columns.GridColumn colFName;
        private DevExpress.XtraGrid.Columns.GridColumn colMName;
        private DevExpress.XtraGrid.Columns.GridColumn colDOB;
        private DevExpress.XtraGrid.Columns.GridColumn colPOB;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repGender;
    }
}
