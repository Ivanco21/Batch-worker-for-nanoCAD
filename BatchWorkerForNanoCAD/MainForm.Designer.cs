namespace BatchWorker
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
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.fbdSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDGNdelete = new System.Windows.Forms.Button();
            this.btnSPDSobjDestroy = new System.Windows.Forms.Button();
            this.pnSPDSdestroy = new System.Windows.Forms.Panel();
            this.cbSaveDwg = new System.Windows.Forms.CheckBox();
            this.pnSPDSdestroy.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(11, 25);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(194, 38);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Выберите папку";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnDGNdelete
            // 
            this.btnDGNdelete.Enabled = false;
            this.btnDGNdelete.Location = new System.Drawing.Point(10, 100);
            this.btnDGNdelete.Name = "btnDGNdelete";
            this.btnDGNdelete.Size = new System.Drawing.Size(194, 25);
            this.btnDGNdelete.TabIndex = 1;
            this.btnDGNdelete.Text = "Удалить DGN стили";
            this.btnDGNdelete.UseVisualStyleBackColor = true;
            this.btnDGNdelete.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSPDSobjDestroy
            // 
            this.btnSPDSobjDestroy.Enabled = false;
            this.btnSPDSobjDestroy.Location = new System.Drawing.Point(3, 3);
            this.btnSPDSobjDestroy.Name = "btnSPDSobjDestroy";
            this.btnSPDSobjDestroy.Size = new System.Drawing.Size(193, 23);
            this.btnSPDSobjDestroy.TabIndex = 2;
            this.btnSPDSobjDestroy.Text = "Разрушить СПДС объекты";
            this.btnSPDSobjDestroy.UseVisualStyleBackColor = true;
            this.btnSPDSobjDestroy.Click += new System.EventHandler(this.btnSPDSobjDestroy_Click);
            // 
            // pnSPDSdestroy
            // 
            this.pnSPDSdestroy.Controls.Add(this.cbSaveDwg);
            this.pnSPDSdestroy.Controls.Add(this.btnSPDSobjDestroy);
            this.pnSPDSdestroy.Location = new System.Drawing.Point(8, 151);
            this.pnSPDSdestroy.Name = "pnSPDSdestroy";
            this.pnSPDSdestroy.Size = new System.Drawing.Size(198, 70);
            this.pnSPDSdestroy.TabIndex = 3;
            // 
            // cbSaveDwg
            // 
            this.cbSaveDwg.AutoSize = true;
            this.cbSaveDwg.Location = new System.Drawing.Point(4, 44);
            this.cbSaveDwg.Name = "cbSaveDwg";
            this.cbSaveDwg.Size = new System.Drawing.Size(176, 17);
            this.cbSaveDwg.TabIndex = 3;
            this.cbSaveDwg.Text = "Закрывать и сохранять DWG";
            this.cbSaveDwg.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 224);
            this.Controls.Add(this.pnSPDSdestroy);
            this.Controls.Add(this.btnDGNdelete);
            this.Controls.Add(this.btnSelectFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Автор - soldatov@infoind.info";
            this.pnSPDSdestroy.ResumeLayout(false);
            this.pnSPDSdestroy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog fbdSelectFolder;
        private System.Windows.Forms.Button btnDGNdelete;
        private System.Windows.Forms.Button btnSPDSobjDestroy;
        private System.Windows.Forms.Panel pnSPDSdestroy;
        private System.Windows.Forms.CheckBox cbSaveDwg;
    }
}