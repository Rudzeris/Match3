namespace Match3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridPanel = new Panel();
            mainMenuPanel = new Panel();
            playButton = new Button();
            statusStrip1 = new StatusStrip();
            timerStatus = new ToolStripStatusLabel();
            timerProgressStatus = new ToolStripProgressBar();
            scoreStatus = new ToolStripStatusLabel();
            overPanel = new Panel();
            label1 = new Label();
            overButton = new Button();
            mainMenuPanel.SuspendLayout();
            statusStrip1.SuspendLayout();
            overPanel.SuspendLayout();
            SuspendLayout();
            // 
            // gridPanel
            // 
            gridPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridPanel.Location = new Point(12, 12);
            gridPanel.Name = "gridPanel";
            gridPanel.Size = new Size(680, 417);
            gridPanel.TabIndex = 0;
            // 
            // mainMenuPanel
            // 
            mainMenuPanel.Controls.Add(playButton);
            mainMenuPanel.Location = new Point(12, 12);
            mainMenuPanel.Name = "mainMenuPanel";
            mainMenuPanel.Size = new Size(680, 417);
            mainMenuPanel.TabIndex = 1;
            // 
            // playButton
            // 
            playButton.Dock = DockStyle.Fill;
            playButton.Font = new Font("Segoe UI", 12F);
            playButton.Location = new Point(0, 0);
            playButton.Name = "playButton";
            playButton.Size = new Size(680, 417);
            playButton.TabIndex = 0;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += PlayClick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { timerStatus, timerProgressStatus, scoreStatus });
            statusStrip1.Location = new Point(0, 419);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(704, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // timerStatus
            // 
            timerStatus.Name = "timerStatus";
            timerStatus.Size = new Size(36, 17);
            timerStatus.Text = "Time:";
            // 
            // timerProgressStatus
            // 
            timerProgressStatus.Name = "timerProgressStatus";
            timerProgressStatus.Size = new Size(100, 16);
            // 
            // scoreStatus
            // 
            scoreStatus.Name = "scoreStatus";
            scoreStatus.Size = new Size(28, 17);
            scoreStatus.Text = "Text";
            // 
            // overPanel
            // 
            overPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            overPanel.Controls.Add(overButton);
            overPanel.Controls.Add(label1);
            overPanel.Location = new Point(15, 12);
            overPanel.Name = "overPanel";
            overPanel.Size = new Size(677, 404);
            overPanel.TabIndex = 3;
            overPanel.Visible = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(677, 348);
            label1.TabIndex = 0;
            label1.Text = "Game Over";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // overButton
            // 
            overButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            overButton.Location = new Point(3, 351);
            overButton.Name = "overButton";
            overButton.Size = new Size(674, 50);
            overButton.TabIndex = 4;
            overButton.Text = "OK";
            overButton.UseVisualStyleBackColor = true;
            overButton.Click += OKClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 441);
            Controls.Add(overPanel);
            Controls.Add(statusStrip1);
            Controls.Add(mainMenuPanel);
            Controls.Add(gridPanel);
            Name = "Form1";
            Text = "Form1";
            mainMenuPanel.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            overPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel gridPanel;
        private Panel mainMenuPanel;
        private Button playButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel timerStatus;
        private ToolStripProgressBar timerProgressStatus;
        private ToolStripStatusLabel scoreStatus;
        private Panel overPanel;
        private Label label1;
        private Button overButton;
    }
}
