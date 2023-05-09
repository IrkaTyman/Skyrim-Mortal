
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
            HPPlayerBar = new ProgressBar();
            HPEnemyBar = new ProgressBar();
            labelPlayer = new Label();
            imageList1 = new ImageList(components);
            labelEnemy = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // HPPlayerBar
            // 
            HPPlayerBar.BackColor = Color.FloralWhite;
            HPPlayerBar.ForeColor = SystemColors.MenuText;
            HPPlayerBar.Location = new Point(133, 53);
            HPPlayerBar.Margin = new Padding(4, 3, 4, 3);
            HPPlayerBar.Name = "HPPlayerBar";
            HPPlayerBar.RightToLeft = RightToLeft.Yes;
            HPPlayerBar.Size = new Size(474, 25);
            HPPlayerBar.TabIndex = 0;
            HPPlayerBar.Value = 100;
            // 
            // HPEnemyBar
            // 
            HPEnemyBar.BackColor = SystemColors.MenuText;
            HPEnemyBar.ForeColor = SystemColors.MenuText;
            HPEnemyBar.Location = new Point(643, 53);
            HPEnemyBar.Margin = new Padding(4, 3, 4, 3);
            HPEnemyBar.Name = "HPEnemyBar";
            HPEnemyBar.RightToLeft = RightToLeft.Yes;
            HPEnemyBar.RightToLeftLayout = true;
            HPEnemyBar.Size = new Size(471, 25);
            HPEnemyBar.TabIndex = 1;
            HPEnemyBar.Value = 100;
            // 
            // labelPlayer
            // 
            labelPlayer.AutoSize = true;
            labelPlayer.BackColor = Color.MidnightBlue;
            labelPlayer.FlatStyle = FlatStyle.Popup;
            labelPlayer.Font = new Font("Microsoft YaHei", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelPlayer.ForeColor = Color.LightSkyBlue;
            labelPlayer.Location = new Point(166, 105);
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
            pictureBox1.ImageLocation = "D:\\Ilyxa\\УЧЕБА\\Прога\\GAME\\GameForULearnCourse\\Arena\\Arena\\Arena\\Sprites\\HpBarHero.png";
            pictureBox1.Location = new Point(10, 14);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(614, 123);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.ImageLocation = "D:\\Ilyxa\\УЧЕБА\\Прога\\GAME\\GameForULearnCourse\\Arena\\Arena\\Arena\\Sprites\\HpBarEnemy.png";
            pictureBox2.Location = new Point(626, 14);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(614, 123);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.ImageLocation = "D:\\Ilyxa\\УЧЕБА\\Прога\\GAME\\GameForULearnCourse\\Arena\\Arena\\Arena\\Sprites\\heroWinner.png";
            pictureBox3.Location = new Point(-6, 60);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(1547, 801);
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            pictureBox3.Visible = false;
            // 
            // pictureBox4
            // 
            pictureBox4.ImageLocation = "D:\\Ilyxa\\УЧЕБА\\Прога\\GAME\\GameForULearnCourse\\Arena\\Arena\\Arena\\Sprites\\satyrWinner.png";
            pictureBox4.Location = new Point(-18, 14);
            pictureBox4.Margin = new Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(1547, 847);
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            pictureBox4.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 667);
            Controls.Add(labelEnemy);
            Controls.Add(labelPlayer);
            Controls.Add(HPEnemyBar);
            Controls.Add(HPPlayerBar);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox4);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximumSize = new Size(1255, 706);
            MinimumSize = new Size(1255, 706);
            Name = "Form1";
            Text = "Form1";
            Paint += OnPaint;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
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
    }
}

