namespace plooClicker
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.picToggle = new System.Windows.Forms.PictureBox();
            this.metroCheckBoxBoth = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBoxRight = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabelMaxCpsValue = new MetroFramework.Controls.MetroLabel();
            this.metroLabelMinCpsValue = new MetroFramework.Controls.MetroLabel();
            this.metroTrackBarMin = new MetroFramework.Controls.MetroTrackBar();
            this.metroTrackBarMax = new MetroFramework.Controls.MetroTrackBar();
            this.lblMinCps = new System.Windows.Forms.Label();
            this.lblMaxCps = new System.Windows.Forms.Label();
            this.panelSettings = new MetroFramework.Controls.MetroPanel();
            this.btnSetHotkey = new MetroFramework.Controls.MetroButton();
            this.metroCheckAlwaysOnTop = new MetroFramework.Controls.MetroCheckBox();
            this.btnToggleSettings = new MetroFramework.Controls.MetroLink();
            this.lblCpsCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picToggle)).BeginInit();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(23, 51);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(60, 25);
            this.metroLabel1.TabIndex = 14;
            this.metroLabel1.Text = "clicker";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseCustomForeColor = true;
            // 
            // picToggle
            // 
            this.picToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.picToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picToggle.Image = global::plooClicker.Properties.Resources.statusoff;
            this.picToggle.Location = new System.Drawing.Point(102, 12);
            this.picToggle.Name = "picToggle";
            this.picToggle.Size = new System.Drawing.Size(144, 144);
            this.picToggle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picToggle.TabIndex = 15;
            this.picToggle.TabStop = false;
            this.picToggle.Click += new System.EventHandler(this.picToggle_Click);
            // 
            // metroCheckBoxBoth
            // 
            this.metroCheckBoxBoth.AutoSize = true;
            this.metroCheckBoxBoth.Location = new System.Drawing.Point(15, 141);
            this.metroCheckBoxBoth.Name = "metroCheckBoxBoth";
            this.metroCheckBoxBoth.Size = new System.Drawing.Size(82, 15);
            this.metroCheckBoxBoth.TabIndex = 17;
            this.metroCheckBoxBoth.Text = "Both Clicks";
            this.metroCheckBoxBoth.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBoxBoth.UseSelectable = true;
            this.metroCheckBoxBoth.CheckedChanged += new System.EventHandler(this.metroCheckBoxBoth_CheckedChanged);
            // 
            // metroCheckBoxRight
            // 
            this.metroCheckBoxRight.AutoSize = true;
            this.metroCheckBoxRight.Location = new System.Drawing.Point(15, 120);
            this.metroCheckBoxRight.Name = "metroCheckBoxRight";
            this.metroCheckBoxRight.Size = new System.Drawing.Size(80, 15);
            this.metroCheckBoxRight.TabIndex = 16;
            this.metroCheckBoxRight.Text = "Right Click";
            this.metroCheckBoxRight.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBoxRight.UseSelectable = true;
            this.metroCheckBoxRight.CheckedChanged += new System.EventHandler(this.metroCheckBoxRight_CheckedChanged);
            // 
            // metroLabelMaxCpsValue
            // 
            this.metroLabelMaxCpsValue.AutoSize = true;
            this.metroLabelMaxCpsValue.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabelMaxCpsValue.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelMaxCpsValue.Location = new System.Drawing.Point(15, 79);
            this.metroLabelMaxCpsValue.Name = "metroLabelMaxCpsValue";
            this.metroLabelMaxCpsValue.Size = new System.Drawing.Size(32, 25);
            this.metroLabelMaxCpsValue.TabIndex = 13;
            this.metroLabelMaxCpsValue.Text = "12";
            this.metroLabelMaxCpsValue.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabelMaxCpsValue.UseCustomForeColor = true;
            // 
            // metroLabelMinCpsValue
            // 
            this.metroLabelMinCpsValue.AutoSize = true;
            this.metroLabelMinCpsValue.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabelMinCpsValue.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelMinCpsValue.Location = new System.Drawing.Point(15, 22);
            this.metroLabelMinCpsValue.Name = "metroLabelMinCpsValue";
            this.metroLabelMinCpsValue.Size = new System.Drawing.Size(22, 25);
            this.metroLabelMinCpsValue.TabIndex = 12;
            this.metroLabelMinCpsValue.Text = "8";
            this.metroLabelMinCpsValue.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabelMinCpsValue.UseCustomForeColor = true;
            // 
            // metroTrackBarMin
            // 
            this.metroTrackBarMin.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBarMin.Location = new System.Drawing.Point(45, 22);
            this.metroTrackBarMin.Maximum = 20;
            this.metroTrackBarMin.Minimum = 1;
            this.metroTrackBarMin.Name = "metroTrackBarMin";
            this.metroTrackBarMin.Size = new System.Drawing.Size(256, 23);
            this.metroTrackBarMin.TabIndex = 11;
            this.metroTrackBarMin.Text = "metroTrackBar2";
            this.metroTrackBarMin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTrackBarMin.Value = 8;
            this.metroTrackBarMin.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBarMin_Scroll);
            // 
            // metroTrackBarMax
            // 
            this.metroTrackBarMax.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBarMax.Location = new System.Drawing.Point(45, 82);
            this.metroTrackBarMax.Maximum = 20;
            this.metroTrackBarMax.Minimum = 1;
            this.metroTrackBarMax.Name = "metroTrackBarMax";
            this.metroTrackBarMax.Size = new System.Drawing.Size(256, 23);
            this.metroTrackBarMax.TabIndex = 10;
            this.metroTrackBarMax.Text = "metroTrackBar1";
            this.metroTrackBarMax.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTrackBarMax.Value = 12;
            this.metroTrackBarMax.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBarMax_Scroll);
            // 
            // lblMinCps
            // 
            this.lblMinCps.AutoSize = true;
            this.lblMinCps.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinCps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.lblMinCps.Location = new System.Drawing.Point(39, 4);
            this.lblMinCps.Name = "lblMinCps";
            this.lblMinCps.Size = new System.Drawing.Size(46, 15);
            this.lblMinCps.TabIndex = 4;
            this.lblMinCps.Text = "Min CPS";
            // 
            // lblMaxCps
            // 
            this.lblMaxCps.AutoSize = true;
            this.lblMaxCps.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxCps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.lblMaxCps.Location = new System.Drawing.Point(39, 64);
            this.lblMaxCps.Name = "lblMaxCps";
            this.lblMaxCps.Size = new System.Drawing.Size(47, 15);
            this.lblMaxCps.TabIndex = 3;
            this.lblMaxCps.Text = "Max CPS";
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.btnSetHotkey);
            this.panelSettings.Controls.Add(this.metroCheckAlwaysOnTop);
            this.panelSettings.Controls.Add(this.lblMaxCps);
            this.panelSettings.Controls.Add(this.lblMinCps);
            this.panelSettings.Controls.Add(this.metroTrackBarMax);
            this.panelSettings.Controls.Add(this.metroTrackBarMin);
            this.panelSettings.Controls.Add(this.metroLabelMinCpsValue);
            this.panelSettings.Controls.Add(this.metroLabelMaxCpsValue);
            this.panelSettings.Controls.Add(this.metroCheckBoxRight);
            this.panelSettings.Controls.Add(this.metroCheckBoxBoth);
            this.panelSettings.HorizontalScrollbarBarColor = true;
            this.panelSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.panelSettings.HorizontalScrollbarSize = 10;
            this.panelSettings.Location = new System.Drawing.Point(0, 186);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(348, 172);
            this.panelSettings.TabIndex = 18;
            this.panelSettings.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.panelSettings.VerticalScrollbarBarColor = true;
            this.panelSettings.VerticalScrollbarHighlightOnWheel = false;
            this.panelSettings.VerticalScrollbarSize = 10;
            this.panelSettings.Visible = false;
            // 
            // btnSetHotkey
            // 
            this.btnSetHotkey.Location = new System.Drawing.Point(199, 142);
            this.btnSetHotkey.Name = "btnSetHotkey";
            this.btnSetHotkey.Size = new System.Drawing.Size(102, 14);
            this.btnSetHotkey.TabIndex = 19;
            this.btnSetHotkey.Text = "Hotkey: K";
            this.btnSetHotkey.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnSetHotkey.UseSelectable = true;
            this.btnSetHotkey.Click += new System.EventHandler(this.btnSetHotkey_Click);
            // 
            // metroCheckAlwaysOnTop
            // 
            this.metroCheckAlwaysOnTop.AutoSize = true;
            this.metroCheckAlwaysOnTop.Location = new System.Drawing.Point(199, 120);
            this.metroCheckAlwaysOnTop.Name = "metroCheckAlwaysOnTop";
            this.metroCheckAlwaysOnTop.Size = new System.Drawing.Size(102, 15);
            this.metroCheckAlwaysOnTop.TabIndex = 18;
            this.metroCheckAlwaysOnTop.Text = "Always On Top";
            this.metroCheckAlwaysOnTop.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckAlwaysOnTop.UseSelectable = true;
            this.metroCheckAlwaysOnTop.CheckedChanged += new System.EventHandler(this.metroCheckAlwaysOnTop_CheckedChanged);
            // 
            // btnToggleSettings
            // 
            this.btnToggleSettings.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.btnToggleSettings.Location = new System.Drawing.Point(0, 162);
            this.btnToggleSettings.Name = "btnToggleSettings";
            this.btnToggleSettings.Size = new System.Drawing.Size(348, 25);
            this.btnToggleSettings.TabIndex = 20;
            this.btnToggleSettings.Text = "▼ Settings ▼";
            this.btnToggleSettings.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnToggleSettings.UseCustomForeColor = true;
            this.btnToggleSettings.UseSelectable = true;
            this.btnToggleSettings.Click += new System.EventHandler(this.btnToggleSettings_Click);
            // 
            // lblCpsCounter
            // 
            this.lblCpsCounter.Font = new System.Drawing.Font("Arial Narrow", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpsCounter.Location = new System.Drawing.Point(252, 51);
            this.lblCpsCounter.Name = "lblCpsCounter";
            this.lblCpsCounter.Size = new System.Drawing.Size(93, 79);
            this.lblCpsCounter.TabIndex = 21;
            this.lblCpsCounter.Text = "12";
            this.lblCpsCounter.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 360);
            this.Controls.Add(this.lblCpsCounter);
            this.Controls.Add(this.btnToggleSettings);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.picToggle);
            this.Controls.Add(this.metroLabel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.Name = "Form1";
            this.Text = "ploo";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picToggle)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox picToggle;
        private MetroFramework.Controls.MetroCheckBox metroCheckBoxBoth;
        private MetroFramework.Controls.MetroCheckBox metroCheckBoxRight;
        private MetroFramework.Controls.MetroLabel metroLabelMaxCpsValue;
        private MetroFramework.Controls.MetroLabel metroLabelMinCpsValue;
        private MetroFramework.Controls.MetroTrackBar metroTrackBarMin;
        private MetroFramework.Controls.MetroTrackBar metroTrackBarMax;
        private System.Windows.Forms.Label lblMinCps;
        private System.Windows.Forms.Label lblMaxCps;
        private MetroFramework.Controls.MetroPanel panelSettings;
        private MetroFramework.Controls.MetroLink btnToggleSettings;
        private MetroFramework.Controls.MetroCheckBox metroCheckAlwaysOnTop;
        private System.Windows.Forms.Label lblCpsCounter;
        private MetroFramework.Controls.MetroButton btnSetHotkey;
    }
}

