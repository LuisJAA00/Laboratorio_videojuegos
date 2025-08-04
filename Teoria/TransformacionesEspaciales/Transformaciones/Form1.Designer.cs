namespace Transformaciones
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.angleRight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.messagesLabel = new System.Windows.Forms.Label();
            this.squareButton = new System.Windows.Forms.Button();
            this.triangleButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.angleLeft = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bigButton = new System.Windows.Forms.Button();
            this.smallButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.recButt = new System.Windows.Forms.Button();
            this.repButt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox.Location = new System.Drawing.Point(115, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(564, 363);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxClickM);
            // 
            // angleRight
            // 
            this.angleRight.Location = new System.Drawing.Point(506, 401);
            this.angleRight.Name = "angleRight";
            this.angleRight.Size = new System.Drawing.Size(75, 23);
            this.angleRight.TabIndex = 4;
            this.angleRight.Text = "Right";
            this.angleRight.UseVisualStyleBackColor = true;
            this.angleRight.Click += new System.EventHandler(this.angleRight_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(486, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Click a figure to control it";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(638, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Messages";
            // 
            // messagesLabel
            // 
            this.messagesLabel.AutoSize = true;
            this.messagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagesLabel.ForeColor = System.Drawing.Color.Red;
            this.messagesLabel.Location = new System.Drawing.Point(638, 402);
            this.messagesLabel.Name = "messagesLabel";
            this.messagesLabel.Size = new System.Drawing.Size(70, 18);
            this.messagesLabel.TabIndex = 11;
            this.messagesLabel.Text = "Nominal";
            // 
            // squareButton
            // 
            this.squareButton.Location = new System.Drawing.Point(12, 288);
            this.squareButton.Name = "squareButton";
            this.squareButton.Size = new System.Drawing.Size(93, 29);
            this.squareButton.TabIndex = 12;
            this.squareButton.Text = "Create Square";
            this.squareButton.UseVisualStyleBackColor = true;
            this.squareButton.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // triangleButton
            // 
            this.triangleButton.Location = new System.Drawing.Point(12, 323);
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(93, 29);
            this.triangleButton.TabIndex = 13;
            this.triangleButton.Text = "Create triangle";
            this.triangleButton.UseVisualStyleBackColor = true;
            this.triangleButton.Click += new System.EventHandler(this.triangleButton_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(206, 379);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(75, 23);
            this.upButton.TabIndex = 14;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(206, 415);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(75, 23);
            this.downButton.TabIndex = 15;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(287, 398);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(75, 23);
            this.rightButton.TabIndex = 16;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(125, 398);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(75, 23);
            this.leftButton.TabIndex = 17;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // angleLeft
            // 
            this.angleLeft.Location = new System.Drawing.Point(430, 402);
            this.angleLeft.Name = "angleLeft";
            this.angleLeft.Size = new System.Drawing.Size(70, 23);
            this.angleLeft.TabIndex = 18;
            this.angleLeft.Text = "Left";
            this.angleLeft.UseVisualStyleBackColor = true;
            this.angleLeft.Click += new System.EventHandler(this.angleLeft_Click);
            // 
            // bigButton
            // 
            this.bigButton.Location = new System.Drawing.Point(708, 202);
            this.bigButton.Name = "bigButton";
            this.bigButton.Size = new System.Drawing.Size(75, 23);
            this.bigButton.TabIndex = 19;
            this.bigButton.Text = "+";
            this.bigButton.UseVisualStyleBackColor = true;
            this.bigButton.Click += new System.EventHandler(this.bigButton_Click);
            // 
            // smallButton
            // 
            this.smallButton.Location = new System.Drawing.Point(708, 231);
            this.smallButton.Name = "smallButton";
            this.smallButton.Size = new System.Drawing.Size(75, 23);
            this.smallButton.TabIndex = 20;
            this.smallButton.Text = "-";
            this.smallButton.UseVisualStyleBackColor = true;
            this.smallButton.Click += new System.EventHandler(this.smallButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(730, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Size";
            // 
            // recButt
            // 
            this.recButt.Location = new System.Drawing.Point(12, 124);
            this.recButt.Name = "recButt";
            this.recButt.Size = new System.Drawing.Size(75, 23);
            this.recButt.TabIndex = 22;
            this.recButt.Text = "Rec";
            this.recButt.UseVisualStyleBackColor = true;
            this.recButt.Click += new System.EventHandler(this.recButt_Click);
            // 
            // repButt
            // 
            this.repButt.Location = new System.Drawing.Point(12, 163);
            this.repButt.Name = "repButt";
            this.repButt.Size = new System.Drawing.Size(75, 23);
            this.repButt.TabIndex = 24;
            this.repButt.Text = "Reproduce";
            this.repButt.UseVisualStyleBackColor = true;
            this.repButt.Click += new System.EventHandler(this.repButt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.repButt);
            this.Controls.Add(this.recButt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.smallButton);
            this.Controls.Add(this.bigButton);
            this.Controls.Add(this.angleLeft);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.triangleButton);
            this.Controls.Add(this.squareButton);
            this.Controls.Add(this.messagesLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.angleRight);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button angleRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label messagesLabel;
        private System.Windows.Forms.Button squareButton;
        private System.Windows.Forms.Button triangleButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button angleLeft;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button bigButton;
        private System.Windows.Forms.Button smallButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button recButt;
        private System.Windows.Forms.Button repButt;
    }
}

