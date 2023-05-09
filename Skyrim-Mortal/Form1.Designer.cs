
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timer1 = new System.Windows.Forms.Timer(components);
            labelPlayer1 = new Label();
            imageList1 = new ImageList(components);
            HPPlayerBar = new ProgressBar();
            pictureBox6 = new PictureBox();
            labelPlayer2 = new Label();
            progressBar1 = new ProgressBar();
            pictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // labelPlayer1
            // 
            labelPlayer1.AutoSize = true;
            labelPlayer1.BackColor = Color.FromArgb(50, 50, 50);
            labelPlayer1.Font = new Font("MingLiU_HKSCS-ExtB", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayer1.ForeColor = Color.White;
            labelPlayer1.Location = new Point(57, 39);
            labelPlayer1.Margin = new Padding(4, 0, 4, 0);
            labelPlayer1.Name = "labelPlayer1";
            labelPlayer1.Size = new Size(95, 13);
            labelPlayer1.TabIndex = 3;
            labelPlayer1.Text = "labelPlayer";
            labelPlayer1.Click += labelPlayer_Click_1;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // HPPlayerBar
            // 
            HPPlayerBar.BackColor = Color.FloralWhite;
            HPPlayerBar.ForeColor = SystemColors.MenuText;
            HPPlayerBar.Location = new Point(38, 14);
            HPPlayerBar.Margin = new Padding(4, 3, 4, 3);
            HPPlayerBar.Name = "HPPlayerBar";
            HPPlayerBar.RightToLeft = RightToLeft.Yes;
            HPPlayerBar.Size = new Size(370, 20);
            HPPlayerBar.TabIndex = 0;
            HPPlayerBar.Value = 100;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(12, 12);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(424, 79);
            pictureBox6.TabIndex = 9;
            pictureBox6.TabStop = false;
            // 
            // labelPlayer2
            // 
            labelPlayer2.AutoSize = true;
            labelPlayer2.BackColor = Color.FromArgb(50, 50, 50);
            labelPlayer2.Font = new Font("MingLiU_HKSCS-ExtB", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayer2.ForeColor = Color.White;
            labelPlayer2.Location = new Point(1088, 42);
            labelPlayer2.Margin = new Padding(4, 0, 4, 0);
            labelPlayer2.Name = "labelPlayer2";
            labelPlayer2.Size = new Size(55, 13);
            labelPlayer2.TabIndex = 11;
            labelPlayer2.Text = "label1";
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.FloralWhite;
            progressBar1.ForeColor = SystemColors.MenuText;
            progressBar1.Location = new Point(829, 16);
            progressBar1.Margin = new Padding(4, 3, 4, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.RightToLeft = RightToLeft.Yes;
            progressBar1.Size = new Size(370, 20);
            progressBar1.TabIndex = 10;
            progressBar1.Value = 100;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(803, 14);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(424, 79);
            pictureBox7.TabIndex = 12;
            pictureBox7.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 667);
            Controls.Add(labelPlayer2);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox7);
            Controls.Add(labelPlayer1);
            Controls.Add(HPPlayerBar);
            Controls.Add(pictureBox6);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximumSize = new Size(1255, 706);
            MinimumSize = new Size(1255, 706);
            Name = "Form1";
            Text = "Form1";
            Paint += OnPaint;
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar HPPlayerBar;
        private System.Windows.Forms.ProgressBar HPEnemyBar;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private PictureBox pictureBox2;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private Label labelPlayer2;
        private ProgressBar progressBar1;
        private PictureBox pictureBox7;
    }
}

