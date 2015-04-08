namespace Language_Editor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itmOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportEng = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportAlt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.itmExportNewEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.itmImportAlt = new System.Windows.Forms.ToolStripMenuItem();
            this.itmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSupportForum = new System.Windows.Forms.ToolStripMenuItem();
            this.itmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPhrases = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNotTranslated = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cbxGroups = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.itmAddNewPhrases = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.pnlEditor.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.itmHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(756, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmOpenFile,
            this.itmSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // itmOpenFile
            // 
            this.itmOpenFile.Image = global::Language_Editor.Properties.Resources.open;
            this.itmOpenFile.Name = "itmOpenFile";
            this.itmOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.itmOpenFile.Size = new System.Drawing.Size(155, 22);
            this.itmOpenFile.Text = "Open...";
            this.itmOpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // itmSave
            // 
            this.itmSave.Image = global::Language_Editor.Properties.Resources.save;
            this.itmSave.Name = "itmSave";
            this.itmSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.itmSave.Size = new System.Drawing.Size(155, 22);
            this.itmSave.Text = "Save";
            this.itmSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmExportEng,
            this.itmExportAlt,
            this.toolStripSeparator4,
            this.itmExportNewEnglish,
            this.toolStripSeparator5,
            this.itmImportAlt,
            this.itmAddNewPhrases});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // itmExportEng
            // 
            this.itmExportEng.Name = "itmExportEng";
            this.itmExportEng.Size = new System.Drawing.Size(213, 22);
            this.itmExportEng.Text = "Export English Phrases";
            this.itmExportEng.ToolTipText = "Export all English phrases to a plane text file.";
            this.itmExportEng.Click += new System.EventHandler(this.ItmExportEng_Click);
            // 
            // itmExportAlt
            // 
            this.itmExportAlt.Name = "itmExportAlt";
            this.itmExportAlt.Size = new System.Drawing.Size(213, 22);
            this.itmExportAlt.Text = "Export Alternative Phrases";
            this.itmExportAlt.ToolTipText = "Export all alternative phrases to a plane text file.";
            this.itmExportAlt.Click += new System.EventHandler(this.ItmExportAlt_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(210, 6);
            // 
            // itmExportNewEnglish
            // 
            this.itmExportNewEnglish.Name = "itmExportNewEnglish";
            this.itmExportNewEnglish.Size = new System.Drawing.Size(213, 22);
            this.itmExportNewEnglish.Text = "Export New Language File";
            this.itmExportNewEnglish.Click += new System.EventHandler(this.ItmExportNewEnglish_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(210, 6);
            // 
            // itmImportAlt
            // 
            this.itmImportAlt.Name = "itmImportAlt";
            this.itmImportAlt.Size = new System.Drawing.Size(213, 22);
            this.itmImportAlt.Text = "Import Alternative Phrases";
            this.itmImportAlt.ToolTipText = "Import a translation from a text file. It overrides the current translation.";
            this.itmImportAlt.Click += new System.EventHandler(this.ItmImportAlt_Click);
            // 
            // itmHelp
            // 
            this.itmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmSupportForum,
            this.itmAbout});
            this.itmHelp.Name = "itmHelp";
            this.itmHelp.Size = new System.Drawing.Size(44, 20);
            this.itmHelp.Text = "Help";
            // 
            // itmSupportForum
            // 
            this.itmSupportForum.Name = "itmSupportForum";
            this.itmSupportForum.Size = new System.Drawing.Size(163, 22);
            this.itmSupportForum.Text = "Support Forum...";
            this.itmSupportForum.Click += new System.EventHandler(this.ItmSupportForum_Click);
            // 
            // itmAbout
            // 
            this.itmAbout.Name = "itmAbout";
            this.itmAbout.Size = new System.Drawing.Size(163, 22);
            this.itmAbout.Text = "About...";
            this.itmAbout.Click += new System.EventHandler(this.ItmAbout_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblPhrases,
            this.toolStripStatusLabel2,
            this.lblNotTranslated});
            this.statusBar.Location = new System.Drawing.Point(0, 475);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusBar.Size = new System.Drawing.Size(756, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel1.Text = "Phrases:";
            // 
            // lblPhrases
            // 
            this.lblPhrases.AutoSize = false;
            this.lblPhrases.Name = "lblPhrases";
            this.lblPhrases.Size = new System.Drawing.Size(50, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(88, 17);
            this.toolStripStatusLabel2.Text = "Not Translated:";
            // 
            // lblNotTranslated
            // 
            this.lblNotTranslated.AutoSize = false;
            this.lblNotTranslated.Name = "lblNotTranslated";
            this.lblNotTranslated.Size = new System.Drawing.Size(50, 17);
            // 
            // pnlEditor
            // 
            this.pnlEditor.Controls.Add(this.vScrollBar);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEditor.Location = new System.Drawing.Point(0, 49);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(756, 426);
            this.pnlEditor.TabIndex = 2;
            this.pnlEditor.Resize += new System.EventHandler(this.PnlEditor_Resize);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Location = new System.Drawing.Point(739, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 426);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator1,
            this.cbxGroups,
            this.toolStripSeparator2,
            this.btnNext,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.tbxSearch,
            this.btnSearch});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(756, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::Language_Editor.Properties.Resources.open;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.Text = "Open Language File";
            this.btnOpen.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::Language_Editor.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save Translation";
            this.btnSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cbxGroups
            // 
            this.cbxGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGroups.Name = "cbxGroups";
            this.cbxGroups.Size = new System.Drawing.Size(150, 25);
            this.cbxGroups.SelectedIndexChanged += new System.EventHandler(this.Groups_SelectedIndexChanged);
            this.cbxGroups.TextChanged += new System.EventHandler(this.Groups_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::Language_Editor.Properties.Resources.goto_next;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 22);
            this.btnNext.Text = "Next not translated";
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Search:";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(150, 25);
            this.tbxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = global::Language_Editor.Properties.Resources.search;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "toolStripButton1";
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.Filter = "Language Files|*.xml";
            this.openFileDialog.Title = "Open Language File";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.Filter = "Language Files|*.xml";
            this.saveFileDialog.Title = "Save Language File";
            // 
            // itmAddNewPhrases
            // 
            this.itmAddNewPhrases.Name = "itmAddNewPhrases";
            this.itmAddNewPhrases.Size = new System.Drawing.Size(213, 22);
            this.itmAddNewPhrases.Text = "Add New Phrases";
            this.itmAddNewPhrases.ToolTipText = "Add new phrases from a .txt file to the current group.";
            this.itmAddNewPhrases.Click += new System.EventHandler(this.ItmAddNewPhrases_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 497);
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Language Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.pnlEditor.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itmOpenFile;
        private System.Windows.Forms.ToolStripMenuItem itmSave;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripComboBox cbxGroups;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblPhrases;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblNotTranslated;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbxSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripMenuItem itmExportEng;
        private System.Windows.Forms.ToolStripMenuItem itmExportAlt;
        private System.Windows.Forms.ToolStripMenuItem itmImportAlt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem itmExportNewEnglish;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem itmHelp;
        private System.Windows.Forms.ToolStripMenuItem itmSupportForum;
        private System.Windows.Forms.ToolStripMenuItem itmAbout;
        private System.Windows.Forms.ToolStripMenuItem itmAddNewPhrases;
    }
}

