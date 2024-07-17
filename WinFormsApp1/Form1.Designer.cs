using CultivationGame;

namespace WinFormsApp1
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
            label1 = new Label();
            Cultivate = new Button();
            Breakthrough = new Button();
            progressBar1 = new ProgressBar();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 40F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(176, 9);
            label1.Name = "label1";
            label1.Size = new Size(439, 72);
            label1.TabIndex = 0;
            label1.Text = "Cultivation Game";
            // 
            // Cultivate
            // 
            Cultivate.BackColor = Color.Transparent;
            Cultivate.FlatStyle = FlatStyle.Flat;
            Cultivate.ForeColor = Color.Transparent;
            Cultivate.Image = Properties.Resources.cultivation_button_d;
            Cultivate.Location = new Point(108, 244);
            Cultivate.Name = "Cultivate";
            Cultivate.Size = new Size(96, 96);
            Cultivate.TabIndex = 1;
            Cultivate.UseVisualStyleBackColor = false;
            Cultivate.Click += Cultivate_Click;
            Cultivate.MouseEnter += Cultivate_MouseEnter;
            Cultivate.MouseLeave += Cultivate_MouseLeave;
            // 
            // Breakthrough
            // 
            Breakthrough.Location = new Point(448, 264);
            Breakthrough.Name = "Breakthrough";
            Breakthrough.Size = new Size(207, 76);
            Breakthrough.TabIndex = 2;
            Breakthrough.Text = "Breakthrough";
            Breakthrough.UseVisualStyleBackColor = true;
            Breakthrough.Click += Breakthrough_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 415);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(776, 23);
            progressBar1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(353, 388);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 4;
            label2.Text = "label2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(progressBar1);
            Controls.Add(Breakthrough);
            Controls.Add(Cultivate);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Cultivate;
        private Button Breakthrough;
        private ProgressBar progressBar1;
        private Label label2;
    }
}