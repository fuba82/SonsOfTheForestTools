namespace SonsOfTheForestTools
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Kelvin",
            "False",
            "0",
            "-929.069031",
            "115.889206",
            "21.820982"}, -1);
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.column_SaveGameFolder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_SaveDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Difficulty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_GameDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_GameTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_MoveToKelvin_Virginia = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.column_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_IsDead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_KilledByPlayer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_PosX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_PosY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_PosZ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_MoveToPlayer_Kelvin = new System.Windows.Forms.Button();
            this.button_MoveToPlayer_Virginia = new System.Windows.Forms.Button();
            this.button_MoveToVirginia_Kelvin = new System.Windows.Forms.Button();
            this.button_Revive_Kelvin = new System.Windows.Forms.Button();
            this.button_Revive_Virginia = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openSavegameFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(82, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Singleplayer";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(100, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Multiplayer";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_SaveGameFolder,
            this.column_SaveDateTime,
            this.column_Difficulty,
            this.column_GameDay,
            this.column_GameTime});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 35);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(470, 214);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // column_SaveGameFolder
            // 
            this.column_SaveGameFolder.Text = "SaveGame";
            this.column_SaveGameFolder.Width = 100;
            // 
            // column_SaveDateTime
            // 
            this.column_SaveDateTime.Text = "Savegame Date &  Time";
            this.column_SaveDateTime.Width = 130;
            // 
            // column_Difficulty
            // 
            this.column_Difficulty.Text = "Difficulty";
            this.column_Difficulty.Width = 75;
            // 
            // column_GameDay
            // 
            this.column_GameDay.Text = "Game Day";
            this.column_GameDay.Width = 65;
            // 
            // column_GameTime
            // 
            this.column_GameTime.Text = "Game Time";
            this.column_GameTime.Width = 70;
            // 
            // button_MoveToKelvin_Virginia
            // 
            this.button_MoveToKelvin_Virginia.Enabled = false;
            this.button_MoveToKelvin_Virginia.Location = new System.Drawing.Point(488, 93);
            this.button_MoveToKelvin_Virginia.Name = "button_MoveToKelvin_Virginia";
            this.button_MoveToKelvin_Virginia.Size = new System.Drawing.Size(160, 23);
            this.button_MoveToKelvin_Virginia.TabIndex = 7;
            this.button_MoveToKelvin_Virginia.Text = "Move Virginia to Kelvin";
            this.button_MoveToKelvin_Virginia.UseVisualStyleBackColor = true;
            this.button_MoveToKelvin_Virginia.Click += new System.EventHandler(this.button_MoveToKelvin_Virginia_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Name,
            this.column_IsDead,
            this.column_KilledByPlayer,
            this.column_PosX,
            this.column_PosY,
            this.column_PosZ});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4});
            this.listView2.Location = new System.Drawing.Point(12, 255);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(636, 78);
            this.listView2.TabIndex = 8;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // column_Name
            // 
            this.column_Name.Text = "NPC Name";
            this.column_Name.Width = 100;
            // 
            // column_IsDead
            // 
            this.column_IsDead.Text = "IsDead?";
            this.column_IsDead.Width = 90;
            // 
            // column_KilledByPlayer
            // 
            this.column_KilledByPlayer.Text = "Killed by Player?";
            this.column_KilledByPlayer.Width = 90;
            // 
            // column_PosX
            // 
            this.column_PosX.Text = "Position X";
            this.column_PosX.Width = 100;
            // 
            // column_PosY
            // 
            this.column_PosY.Text = "Position Y";
            this.column_PosY.Width = 100;
            // 
            // column_PosZ
            // 
            this.column_PosZ.Text = "Position Z";
            this.column_PosZ.Width = 100;
            // 
            // button_MoveToPlayer_Kelvin
            // 
            this.button_MoveToPlayer_Kelvin.Enabled = false;
            this.button_MoveToPlayer_Kelvin.Location = new System.Drawing.Point(488, 35);
            this.button_MoveToPlayer_Kelvin.Name = "button_MoveToPlayer_Kelvin";
            this.button_MoveToPlayer_Kelvin.Size = new System.Drawing.Size(160, 23);
            this.button_MoveToPlayer_Kelvin.TabIndex = 9;
            this.button_MoveToPlayer_Kelvin.Text = "Move Kelvin to Player";
            this.button_MoveToPlayer_Kelvin.UseVisualStyleBackColor = true;
            this.button_MoveToPlayer_Kelvin.Click += new System.EventHandler(this.button_MoveToPlayer_Kelvin_Click);
            // 
            // button_MoveToPlayer_Virginia
            // 
            this.button_MoveToPlayer_Virginia.Enabled = false;
            this.button_MoveToPlayer_Virginia.Location = new System.Drawing.Point(488, 64);
            this.button_MoveToPlayer_Virginia.Name = "button_MoveToPlayer_Virginia";
            this.button_MoveToPlayer_Virginia.Size = new System.Drawing.Size(160, 23);
            this.button_MoveToPlayer_Virginia.TabIndex = 10;
            this.button_MoveToPlayer_Virginia.Text = "Move Virginia to Player";
            this.button_MoveToPlayer_Virginia.UseVisualStyleBackColor = true;
            this.button_MoveToPlayer_Virginia.Click += new System.EventHandler(this.button_MoveToPlayer_Virginia_Click);
            // 
            // button_MoveToVirginia_Kelvin
            // 
            this.button_MoveToVirginia_Kelvin.Enabled = false;
            this.button_MoveToVirginia_Kelvin.Location = new System.Drawing.Point(488, 122);
            this.button_MoveToVirginia_Kelvin.Name = "button_MoveToVirginia_Kelvin";
            this.button_MoveToVirginia_Kelvin.Size = new System.Drawing.Size(160, 23);
            this.button_MoveToVirginia_Kelvin.TabIndex = 11;
            this.button_MoveToVirginia_Kelvin.Text = "Move Kelvin to Virginia";
            this.button_MoveToVirginia_Kelvin.UseVisualStyleBackColor = true;
            this.button_MoveToVirginia_Kelvin.Click += new System.EventHandler(this.button_MoveToVirginia_Kelvin_Click);
            // 
            // button_Revive_Kelvin
            // 
            this.button_Revive_Kelvin.Enabled = false;
            this.button_Revive_Kelvin.Location = new System.Drawing.Point(488, 151);
            this.button_Revive_Kelvin.Name = "button_Revive_Kelvin";
            this.button_Revive_Kelvin.Size = new System.Drawing.Size(160, 23);
            this.button_Revive_Kelvin.TabIndex = 12;
            this.button_Revive_Kelvin.Text = "Revive Kelvin";
            this.button_Revive_Kelvin.UseVisualStyleBackColor = true;
            this.button_Revive_Kelvin.Click += new System.EventHandler(this.button_Revive_Kelvin_Click);
            // 
            // button_Revive_Virginia
            // 
            this.button_Revive_Virginia.Enabled = false;
            this.button_Revive_Virginia.Location = new System.Drawing.Point(488, 180);
            this.button_Revive_Virginia.Name = "button_Revive_Virginia";
            this.button_Revive_Virginia.Size = new System.Drawing.Size(160, 23);
            this.button_Revive_Virginia.TabIndex = 13;
            this.button_Revive_Virginia.Text = "Revive Virginia";
            this.button_Revive_Virginia.UseVisualStyleBackColor = true;
            this.button_Revive_Virginia.Click += new System.EventHandler(this.button_Revive_Virginia_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSavegameFolderToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 26);
            // 
            // openSavegameFolderToolStripMenuItem
            // 
            this.openSavegameFolderToolStripMenuItem.Name = "openSavegameFolderToolStripMenuItem";
            this.openSavegameFolderToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.openSavegameFolderToolStripMenuItem.Text = "Open Savegame Folder";
            this.openSavegameFolderToolStripMenuItem.Click += new System.EventHandler(this.openSavegameFolderToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 343);
            this.Controls.Add(this.button_Revive_Virginia);
            this.Controls.Add(this.button_Revive_Kelvin);
            this.Controls.Add(this.button_MoveToVirginia_Kelvin);
            this.Controls.Add(this.button_MoveToPlayer_Virginia);
            this.Controls.Add(this.button_MoveToPlayer_Kelvin);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.button_MoveToKelvin_Virginia);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sons of the Forest Tools for Windows";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader column_SaveGameFolder;
        private System.Windows.Forms.ColumnHeader column_SaveDateTime;
        private System.Windows.Forms.Button button_MoveToKelvin_Virginia;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader column_Name;
        private System.Windows.Forms.ColumnHeader column_IsDead;
        private System.Windows.Forms.ColumnHeader column_KilledByPlayer;
        private System.Windows.Forms.ColumnHeader column_PosX;
        private System.Windows.Forms.Button button_MoveToPlayer_Kelvin;
        private System.Windows.Forms.Button button_MoveToPlayer_Virginia;
        private System.Windows.Forms.Button button_MoveToVirginia_Kelvin;
        private System.Windows.Forms.Button button_Revive_Kelvin;
        private System.Windows.Forms.Button button_Revive_Virginia;
        private System.Windows.Forms.ColumnHeader column_PosY;
        private System.Windows.Forms.ColumnHeader column_PosZ;
        private System.Windows.Forms.ColumnHeader column_Difficulty;
        private System.Windows.Forms.ColumnHeader column_GameDay;
        private System.Windows.Forms.ColumnHeader column_GameTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openSavegameFolderToolStripMenuItem;
    }
}

