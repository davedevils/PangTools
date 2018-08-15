namespace Iff_Pangya_Editor
{
    partial class Desc_Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Desc_Editor));
            this.lstStrings = new System.Windows.Forms.ListView();
            this.columnHeader_0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CaractNum = new System.Windows.Forms.Label();
            this.ObjectId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addnew = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eNGLISHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jAPANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tHAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kOREANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oTHERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstStrings
            // 
            this.lstStrings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_0});
            this.lstStrings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStrings.FullRowSelect = true;
            this.lstStrings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstStrings.Location = new System.Drawing.Point(0, 27);
            this.lstStrings.MultiSelect = false;
            this.lstStrings.Name = "lstStrings";
            this.lstStrings.Size = new System.Drawing.Size(227, 347);
            this.lstStrings.TabIndex = 0;
            this.lstStrings.UseCompatibleStateImageBehavior = false;
            this.lstStrings.View = System.Windows.Forms.View.Details;
            this.lstStrings.SelectedIndexChanged += new System.EventHandler(this.lstStrings_SelectedIndexChanged);
            // 
            // columnHeader_0
            // 
            this.columnHeader_0.Text = "Item Name";
            this.columnHeader_0.Width = 240;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(169, 381);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(58, 24);
            this.btnFilter.TabIndex = 24;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(0, 381);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(156, 21);
            this.txtFilter.TabIndex = 23;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(620, 380);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 24);
            this.btnApply.TabIndex = 22;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtString
            // 
            this.txtString.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtString.Location = new System.Drawing.Point(233, 109);
            this.txtString.Multiline = true;
            this.txtString.Name = "txtString";
            this.txtString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtString.Size = new System.Drawing.Size(461, 265);
            this.txtString.TabIndex = 21;
            this.txtString.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Description :";
            // 
            // CaractNum
            // 
            this.CaractNum.AutoSize = true;
            this.CaractNum.Location = new System.Drawing.Point(295, 94);
            this.CaractNum.Name = "CaractNum";
            this.CaractNum.Size = new System.Drawing.Size(0, 13);
            this.CaractNum.TabIndex = 27;
            // 
            // ObjectId
            // 
            this.ObjectId.Location = new System.Drawing.Point(233, 46);
            this.ObjectId.Name = "ObjectId";
            this.ObjectId.Size = new System.Drawing.Size(136, 20);
            this.ObjectId.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Object ID :";
            // 
            // addnew
            // 
            this.addnew.Location = new System.Drawing.Point(626, 42);
            this.addnew.Name = "addnew";
            this.addnew.Size = new System.Drawing.Size(75, 24);
            this.addnew.TabIndex = 30;
            this.addnew.Text = "Add New";
            this.addnew.UseVisualStyleBackColor = true;
            this.addnew.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(528, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 24);
            this.button1.TabIndex = 31;
            this.button1.Text = "Delete Selected";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.encodeFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(701, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.saveFileToolStripMenuItem.Text = "Save File";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // encodeFileToolStripMenuItem
            // 
            this.encodeFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.eNGLISHToolStripMenuItem,
            this.jAPANToolStripMenuItem,
            this.tHAIToolStripMenuItem,
            this.kOREANToolStripMenuItem,
            this.oTHERToolStripMenuItem});
            this.encodeFileToolStripMenuItem.Name = "encodeFileToolStripMenuItem";
            this.encodeFileToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.encodeFileToolStripMenuItem.Text = "Encode File";
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Checked = true;
            this.autoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.autoToolStripMenuItem.Text = "Default";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // eNGLISHToolStripMenuItem
            // 
            this.eNGLISHToolStripMenuItem.Name = "eNGLISHToolStripMenuItem";
            this.eNGLISHToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eNGLISHToolStripMenuItem.Text = "ENGLISH";
            this.eNGLISHToolStripMenuItem.Click += new System.EventHandler(this.eNGLISHToolStripMenuItem_Click);
            // 
            // jAPANToolStripMenuItem
            // 
            this.jAPANToolStripMenuItem.Name = "jAPANToolStripMenuItem";
            this.jAPANToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.jAPANToolStripMenuItem.Text = "JAPAN";
            this.jAPANToolStripMenuItem.Click += new System.EventHandler(this.jAPANToolStripMenuItem_Click);
            // 
            // tHAIToolStripMenuItem
            // 
            this.tHAIToolStripMenuItem.Name = "tHAIToolStripMenuItem";
            this.tHAIToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tHAIToolStripMenuItem.Text = "THAI";
            this.tHAIToolStripMenuItem.Click += new System.EventHandler(this.tHAIToolStripMenuItem_Click);
            // 
            // kOREANToolStripMenuItem
            // 
            this.kOREANToolStripMenuItem.Name = "kOREANToolStripMenuItem";
            this.kOREANToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kOREANToolStripMenuItem.Text = "KOREAN";
            this.kOREANToolStripMenuItem.Click += new System.EventHandler(this.kOREANToolStripMenuItem_Click);
            // 
            // oTHERToolStripMenuItem
            // 
            this.oTHERToolStripMenuItem.Name = "oTHERToolStripMenuItem";
            this.oTHERToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oTHERToolStripMenuItem.Text = "OTHER";
            this.oTHERToolStripMenuItem.Click += new System.EventHandler(this.oTHERToolStripMenuItem_Click);
            // 
            // Desc_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 414);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addnew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ObjectId);
            this.Controls.Add(this.CaractNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstStrings);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Desc_Editor";
            this.Text = "Desc Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lstStrings;
        private System.Windows.Forms.ColumnHeader columnHeader_0;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CaractNum;
        private System.Windows.Forms.TextBox ObjectId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addnew;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encodeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eNGLISHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jAPANToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tHAIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oTHERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kOREANToolStripMenuItem;
    }
}