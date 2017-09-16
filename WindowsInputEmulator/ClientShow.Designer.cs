namespace WindowsInputEmulator
{
    partial class ClientShow
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.dataInput = new System.Windows.Forms.DataGridView();
            this.pressed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(122, 9);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(24, 32);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "-";
            // 
            // dataInput
            // 
            this.dataInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pressed});
            this.dataInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataInput.Location = new System.Drawing.Point(0, 44);
            this.dataInput.Name = "dataInput";
            this.dataInput.ReadOnly = true;
            this.dataInput.RowTemplate.Height = 40;
            this.dataInput.Size = new System.Drawing.Size(780, 472);
            this.dataInput.TabIndex = 2;
            // 
            // pressed
            // 
            this.pressed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pressed.HeaderText = "Pressed";
            this.pressed.Name = "pressed";
            this.pressed.ReadOnly = true;
            // 
            // ClientShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 516);
            this.Controls.Add(this.dataInput);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label1);
            this.Name = "ClientShow";
            this.Text = "ClientShow";
            ((System.ComponentModel.ISupportInitialize)(this.dataInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.DataGridView dataInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn pressed;
    }
}