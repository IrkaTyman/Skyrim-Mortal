
namespace Skyrim_Mortal
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            labelPlayer = new Label();
            imageList1 = new ImageList(components);
            labelEnemy = new Label();
            pictureBox1 = new PictureBox();
            HPPlayerBar = new ProgressBar();
            pictureBox2 = new PictureBox();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // labelPlayer
            // 
            labelPlayer.AutoSize = true;
            labelPlayer.BackColor = Color.MidnightBlue;
            labelPlayer.FlatStyle = FlatStyle.Popup;
            labelPlayer.Font = new Font("Microsoft YaHei", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelPlayer.ForeColor = Color.LightSkyBlue;
            labelPlayer.Location = new Point(307, 83);
            labelPlayer.Margin = new Padding(4, 0, 4, 0);
            labelPlayer.Name = "labelPlayer";
            labelPlayer.Size = new Size(85, 19);
            labelPlayer.TabIndex = 3;
            labelPlayer.Text = "labelPlayer";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // labelEnemy
            // 
            labelEnemy.AutoSize = true;
            labelEnemy.BackColor = Color.MidnightBlue;
            labelEnemy.Font = new Font("Microsoft YaHei", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelEnemy.ForeColor = Color.LightSkyBlue;
            labelEnemy.Location = new Point(1184, 105);
            labelEnemy.Margin = new Padding(4, 0, 4, 0);
            labelEnemy.Name = "labelEnemy";
            labelEnemy.RightToLeft = RightToLeft.No;
            labelEnemy.Size = new Size(89, 19);
            labelEnemy.TabIndex = 5;
            labelEnemy.Text = "labelEnemy";
            labelEnemy.TextAlign = ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.bar;
            pictureBox1.ImageLocation = "D:\\Ilyxa\\УЧЕБА\\Прога\\GAME\\GameForULearnCourse\\Arena\\Arena\\Arena\\Sprites\\HpBarHero.png";
            pictureBox1.Location = new Point(13, 27);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(425, 23);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // HPPlayerBar
            // 
            HPPlayerBar.BackColor = Color.FloralWhite;
            HPPlayerBar.ForeColor = SystemColors.MenuText;
            HPPlayerBar.Location = new Point(39, 28);
            HPPlayerBar.Margin = new Padding(4, 3, 4, 3);
            HPPlayerBar.Name = "HPPlayerBar";
            HPPlayerBar.RightToLeft = RightToLeft.Yes;
            HPPlayerBar.Size = new Size(371, 22);
            HPPlayerBar.TabIndex = 0;
            HPPlayerBar.Value = 100;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.bar;
            pictureBox2.ImageLocation = "D:\\Ilyxa\\УЧЕБА\\Прога\\GAME\\GameForULearnCourse\\Arena\\Arena\\Arena\\Sprites\\HpBarHero.png";
            pictureBox2.Location = new Point(790, 27);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(425, 23);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.FloralWhite;
            progressBar1.ForeColor = SystemColors.MenuText;
            progressBar1.Location = new Point(817, 28);
            progressBar1.Margin = new Padding(4, 3, 4, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.RightToLeft = RightToLeft.Yes;
            progressBar1.Size = new Size(371, 22);
            progressBar1.TabIndex = 8;
            progressBar1.Value = 100;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 667);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox2);
            Controls.Add(labelEnemy);
            Controls.Add(labelPlayer);
            Controls.Add(HPPlayerBar);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximumSize = new Size(1255, 706);
            MinimumSize = new Size(1255, 706);
            Name = "Form1";
            Text = "Form1";
            Paint += OnPaint;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar HPPlayerBar;
        private System.Windows.Forms.ProgressBar HPEnemyBar;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label labelEnemy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private ProgressBar progressBar1;
    }
}

