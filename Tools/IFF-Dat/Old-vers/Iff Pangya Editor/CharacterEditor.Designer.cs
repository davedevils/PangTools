namespace Iff_Pangya_Editor
{
    partial class CharacterEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterEditor));
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
            this.lstStrings = new System.Windows.Forms.ListView();
            this.columnHeader_0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.basic = new System.Windows.Forms.TabPage();
            this.modelandtex = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.CharacterName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.TextBox();
            this.tex1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tex2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tex3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tex4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.basic.SuspendLayout();
            this.modelandtex.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.encodeFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(637, 24);
            this.menuStrip1.TabIndex = 33;
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
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.lstStrings.Size = new System.Drawing.Size(227, 402);
            this.lstStrings.TabIndex = 34;
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
            this.btnFilter.Location = new System.Drawing.Point(169, 435);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(58, 24);
            this.btnFilter.TabIndex = 36;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(0, 435);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(156, 21);
            this.txtFilter.TabIndex = 35;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.basic);
            this.tabControl1.Controls.Add(this.modelandtex);
            this.tabControl1.Location = new System.Drawing.Point(233, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(404, 432);
            this.tabControl1.TabIndex = 37;
            // 
            // basic
            // 
            this.basic.Controls.Add(this.CharacterName);
            this.basic.Controls.Add(this.label1);
            this.basic.Location = new System.Drawing.Point(4, 22);
            this.basic.Name = "basic";
            this.basic.Padding = new System.Windows.Forms.Padding(3);
            this.basic.Size = new System.Drawing.Size(396, 406);
            this.basic.TabIndex = 0;
            this.basic.Text = "Basic";
            this.basic.UseVisualStyleBackColor = true;
            // 
            // modelandtex
            // 
            this.modelandtex.Controls.Add(this.tex4);
            this.modelandtex.Controls.Add(this.label6);
            this.modelandtex.Controls.Add(this.tex3);
            this.modelandtex.Controls.Add(this.label5);
            this.modelandtex.Controls.Add(this.tex2);
            this.modelandtex.Controls.Add(this.label4);
            this.modelandtex.Controls.Add(this.tex1);
            this.modelandtex.Controls.Add(this.label3);
            this.modelandtex.Controls.Add(this.Model);
            this.modelandtex.Controls.Add(this.label2);
            this.modelandtex.Location = new System.Drawing.Point(4, 22);
            this.modelandtex.Name = "modelandtex";
            this.modelandtex.Padding = new System.Windows.Forms.Padding(3);
            this.modelandtex.Size = new System.Drawing.Size(396, 406);
            this.modelandtex.TabIndex = 1;
            this.modelandtex.Text = "Model And Texture";
            this.modelandtex.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Character Name";
            // 
            // CharacterName
            // 
            this.CharacterName.Location = new System.Drawing.Point(9, 19);
            this.CharacterName.Name = "CharacterName";
            this.CharacterName.Size = new System.Drawing.Size(175, 20);
            this.CharacterName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Model";
            // 
            // Model
            // 
            this.Model.Location = new System.Drawing.Point(6, 19);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(225, 20);
            this.Model.TabIndex = 1;
            // 
            // tex1
            // 
            this.tex1.Location = new System.Drawing.Point(6, 68);
            this.tex1.Name = "tex1";
            this.tex1.Size = new System.Drawing.Size(225, 20);
            this.tex1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Texture 1";
            // 
            // tex2
            // 
            this.tex2.Location = new System.Drawing.Point(6, 113);
            this.tex2.Name = "tex2";
            this.tex2.Size = new System.Drawing.Size(225, 20);
            this.tex2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Texture 2";
            // 
            // tex3
            // 
            this.tex3.Location = new System.Drawing.Point(6, 160);
            this.tex3.Name = "tex3";
            this.tex3.Size = new System.Drawing.Size(225, 20);
            this.tex3.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Texture 3";
            // 
            // tex4
            // 
            this.tex4.Location = new System.Drawing.Point(9, 302);
            this.tex4.Name = "tex4";
            this.tex4.Size = new System.Drawing.Size(225, 20);
            this.tex4.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Additional Texture";
            // 
            // CharacterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 462);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lstStrings);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CharacterEditor";
            this.Text = "Character Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.basic.ResumeLayout(false);
            this.basic.PerformLayout();
            this.modelandtex.ResumeLayout(false);
            this.modelandtex.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encodeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eNGLISHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jAPANToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tHAIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kOREANToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oTHERToolStripMenuItem;
        private System.Windows.Forms.ListView lstStrings;
        private System.Windows.Forms.ColumnHeader columnHeader_0;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage basic;
        private System.Windows.Forms.TabPage modelandtex;
        private System.Windows.Forms.TextBox CharacterName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tex1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Model;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tex3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tex2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tex4;
        private System.Windows.Forms.Label label6;
    }
}