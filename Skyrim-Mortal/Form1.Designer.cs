
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
            HPPlayer1Bar = new ProgressBar();
            pictureBox6 = new PictureBox();
            labelPlayer2 = new Label();
            HPPlayer2Bar = new ProgressBar();
            pictureBox7 = new PictureBox();
            winScreen = new PictureBox();
            repeatButton = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)winScreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repeatButton).BeginInit();
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
            // HPPlayer1Bar
            // 
            HPPlayer1Bar.BackColor = Color.FloralWhite;
            HPPlayer1Bar.ForeColor = SystemColors.MenuText;
            HPPlayer1Bar.Location = new Point(38, 14);
            HPPlayer1Bar.Margin = new Padding(4, 3, 4, 3);
            HPPlayer1Bar.Name = "HPPlayer1Bar";
            HPPlayer1Bar.RightToLeft = RightToLeft.Yes;
            HPPlayer1Bar.Size = new Size(370, 20);
            HPPlayer1Bar.TabIndex = 0;
            HPPlayer1Bar.Value = 100;
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
            // HPPlayer2Bar
            // 
            HPPlayer2Bar.BackColor = Color.FloralWhite;
            HPPlayer2Bar.ForeColor = SystemColors.MenuText;
            HPPlayer2Bar.Location = new Point(829, 16);
            HPPlayer2Bar.Margin = new Padding(4, 3, 4, 3);
            HPPlayer2Bar.Name = "HPPlayer2Bar";
            HPPlayer2Bar.RightToLeft = RightToLeft.Yes;
            HPPlayer2Bar.Size = new Size(370, 20);
            HPPlayer2Bar.TabIndex = 10;
            HPPlayer2Bar.Value = 100;
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
            // winScreen
            // 
            winScreen.Location = new Point(366, 168);
            winScreen.Name = "winScreen";
            winScreen.Size = new Size(518, 324);
            winScreen.TabIndex = 13;
            winScreen.TabStop = false;
            // 
            // repeatButton
            // 
            repeatButton.Image = (Image)resources.GetObject("repeatButton.Image");
            repeatButton.Location = new Point(545, 454);
            repeatButton.Name = "repeatButton";
            repeatButton.Size = new Size(166, 29);
            repeatButton.TabIndex = 14;
            repeatButton.TabStop = false;
            repeatButton.Click += repeatButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 667);
            Controls.Add(repeatButton);
            Controls.Add(winScreen);
            Controls.Add(labelPlayer2);
            Controls.Add(HPPlayer2Bar);
            Controls.Add(pictureBox7);
            Controls.Add(labelPlayer1);
            Controls.Add(HPPlayer1Bar);
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
            ((System.ComponentModel.ISupportInitialize)winScreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)repeatButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar HPPlayer1Bar;
        private System.Windows.Forms.ProgressBar HPPlayer2Var;
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
        private PictureBox winScreen;
        private PictureBox repeatButton;
        private ProgressBar HPPlayer2Bar;
    }
}

