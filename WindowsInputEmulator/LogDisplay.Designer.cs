namespace WindowsInputEmulator
{
    partial class LogDisplay
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
            this.buttonCopy = new System.Windows.Forms.Button();
            this.dataLog = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataLog)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(12, 470);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(152, 39);
            this.buttonCopy.TabIndex = 1;
            this.buttonCopy.Text = "Copy Output";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // dataLog
            // 
            this.dataLog.AllowUserToAddRows = false;
            this.dataLog.AllowUserToDeleteRows = false;
            this.dataLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.message,
            this.status});
            this.dataLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataLog.Location = new System.Drawing.Point(0, 0);
            this.dataLog.Name = "dataLog";
            this.dataLog.ReadOnly = true;
            this.dataLog.RowTemplate.Height = 28;
            this.dataLog.Size = new System.Drawing.Size(568, 464);
            this.dataLog.TabIndex = 2;
            // 
            // time
            // 
            this.time.DataPropertyName = "time";
            this.time.HeaderText = "Time";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // message
            // 
            this.message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.message.DataPropertyName = "message";
            this.message.HeaderText = "Message";
            this.message.Name = "message";
            this.message.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "s";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // LogDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 521);
            this.Controls.Add(this.dataLog);
            this.Controls.Add(this.buttonCopy);
            this.Name = "LogDisplay";
            this.Text = "LogDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.dataLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.DataGridView dataLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}