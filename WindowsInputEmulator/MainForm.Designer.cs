namespace WindowsInputEmulator
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxA = new System.Windows.Forms.CheckBox();
            this.checkBoxUp = new System.Windows.Forms.CheckBox();
            this.checkBoxDown = new System.Windows.Forms.CheckBox();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataConnections = new System.Windows.Forms.DataGridView();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnections)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLogToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(175, 30);
            this.showLogToolStripMenuItem.Text = "Show Log";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // checkBoxA
            // 
            this.checkBoxA.AutoCheck = false;
            this.checkBoxA.AutoSize = true;
            this.checkBoxA.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkBoxA.Location = new System.Drawing.Point(12, 36);
            this.checkBoxA.Name = "checkBoxA";
            this.checkBoxA.Size = new System.Drawing.Size(46, 24);
            this.checkBoxA.TabIndex = 2;
            this.checkBoxA.Text = "A";
            this.checkBoxA.UseVisualStyleBackColor = true;
            // 
            // checkBoxUp
            // 
            this.checkBoxUp.AutoCheck = false;
            this.checkBoxUp.AutoSize = true;
            this.checkBoxUp.Location = new System.Drawing.Point(12, 66);
            this.checkBoxUp.Name = "checkBoxUp";
            this.checkBoxUp.Size = new System.Drawing.Size(56, 24);
            this.checkBoxUp.TabIndex = 3;
            this.checkBoxUp.Text = "Up";
            this.checkBoxUp.UseVisualStyleBackColor = true;
            // 
            // checkBoxDown
            // 
            this.checkBoxDown.AutoCheck = false;
            this.checkBoxDown.AutoSize = true;
            this.checkBoxDown.Location = new System.Drawing.Point(13, 97);
            this.checkBoxDown.Name = "checkBoxDown";
            this.checkBoxDown.Size = new System.Drawing.Size(76, 24);
            this.checkBoxDown.TabIndex = 4;
            this.checkBoxDown.Text = "Down";
            this.checkBoxDown.UseVisualStyleBackColor = true;
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // dataConnections
            // 
            this.dataConnections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataConnections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientName,
            this.ClientStatus,
            this.ip});
            this.dataConnections.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataConnections.Location = new System.Drawing.Point(0, 125);
            this.dataConnections.Name = "dataConnections";
            this.dataConnections.RowTemplate.Height = 28;
            this.dataConnections.Size = new System.Drawing.Size(1038, 534);
            this.dataConnections.TabIndex = 5;
            // 
            // ClientName
            // 
            this.ClientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClientName.DataPropertyName = "name";
            this.ClientName.HeaderText = "Name";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            // 
            // ClientStatus
            // 
            this.ClientStatus.DataPropertyName = "status";
            this.ClientStatus.HeaderText = "Status";
            this.ClientStatus.Name = "ClientStatus";
            this.ClientStatus.ReadOnly = true;
            this.ClientStatus.Width = 500;
            // 
            // ip
            // 
            this.ip.DataPropertyName = "client_ip";
            this.ip.HeaderText = "IP";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 659);
            this.Controls.Add(this.dataConnections);
            this.Controls.Add(this.checkBoxDown);
            this.Controls.Add(this.checkBoxUp);
            this.Controls.Add(this.checkBoxA);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Input Emulator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnections)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxA;
        private System.Windows.Forms.CheckBox checkBoxUp;
        private System.Windows.Forms.CheckBox checkBoxDown;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataConnections;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
    }
}

