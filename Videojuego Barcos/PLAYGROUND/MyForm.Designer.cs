namespace PLAYGROUND
{
    partial class MyForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PNL_MAIN = new System.Windows.Forms.Panel();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PNL_BOTTOM = new System.Windows.Forms.Panel();
            this.plat2HpLabel = new System.Windows.Forms.Label();
            this.HP2 = new System.Windows.Forms.Label();
            this.plat1HPLabel = new System.Windows.Forms.Label();
            this.HP1 = new System.Windows.Forms.Label();
            this.LBL_STATUS = new System.Windows.Forms.Label();
            this.PNL_HEADER = new System.Windows.Forms.Panel();
            this.planeStatus2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.planeStatus1 = new System.Windows.Forms.Label();
            this.Plane1 = new System.Windows.Forms.Label();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.PNL_MAIN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.PNL_BOTTOM.SuspendLayout();
            this.PNL_HEADER.SuspendLayout();
            this.SuspendLayout();
            // 
            // PNL_MAIN
            // 
            this.PNL_MAIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PNL_MAIN.Controls.Add(this.PCT_CANVAS);
            this.PNL_MAIN.Controls.Add(this.panel2);
            this.PNL_MAIN.Controls.Add(this.panel1);
            this.PNL_MAIN.Controls.Add(this.PNL_BOTTOM);
            this.PNL_MAIN.Controls.Add(this.LBL_STATUS);
            this.PNL_MAIN.Controls.Add(this.PNL_HEADER);
            this.PNL_MAIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_MAIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PNL_MAIN.ForeColor = System.Drawing.Color.Silver;
            this.PNL_MAIN.Location = new System.Drawing.Point(0, 0);
            this.PNL_MAIN.Margin = new System.Windows.Forms.Padding(6);
            this.PNL_MAIN.Name = "PNL_MAIN";
            this.PNL_MAIN.Size = new System.Drawing.Size(2740, 1325);
            this.PNL_MAIN.TabIndex = 0;
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.PCT_CANVAS.BackgroundImage = global::PLAYGROUND.Resource1.Background;
            this.PCT_CANVAS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCT_CANVAS.Location = new System.Drawing.Point(400, 192);
            this.PCT_CANVAS.Margin = new System.Windows.Forms.Padding(6);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1940, 897);
            this.PCT_CANVAS.TabIndex = 6;
            this.PCT_CANVAS.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(2340, 192);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 897);
            this.panel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 192);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 897);
            this.panel1.TabIndex = 4;
            // 
            // PNL_BOTTOM
            // 
            this.PNL_BOTTOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PNL_BOTTOM.Controls.Add(this.plat2HpLabel);
            this.PNL_BOTTOM.Controls.Add(this.HP2);
            this.PNL_BOTTOM.Controls.Add(this.plat1HPLabel);
            this.PNL_BOTTOM.Controls.Add(this.HP1);
            this.PNL_BOTTOM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PNL_BOTTOM.Location = new System.Drawing.Point(0, 1089);
            this.PNL_BOTTOM.Margin = new System.Windows.Forms.Padding(6);
            this.PNL_BOTTOM.Name = "PNL_BOTTOM";
            this.PNL_BOTTOM.Size = new System.Drawing.Size(2740, 192);
            this.PNL_BOTTOM.TabIndex = 3;
            // 
            // plat2HpLabel
            // 
            this.plat2HpLabel.AutoSize = true;
            this.plat2HpLabel.Location = new System.Drawing.Point(2396, 38);
            this.plat2HpLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.plat2HpLabel.Name = "plat2HpLabel";
            this.plat2HpLabel.Size = new System.Drawing.Size(94, 44);
            this.plat2HpLabel.TabIndex = 3;
            this.plat2HpLabel.Text = ".-.xd";
            // 
            // HP2
            // 
            this.HP2.AutoSize = true;
            this.HP2.Location = new System.Drawing.Point(2128, 38);
            this.HP2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.HP2.Name = "HP2";
            this.HP2.Size = new System.Drawing.Size(267, 44);
            this.HP2.TabIndex = 2;
            this.HP2.Text = "Platform 2 HP:";
            // 
            // plat1HPLabel
            // 
            this.plat1HPLabel.AutoSize = true;
            this.plat1HPLabel.Location = new System.Drawing.Point(488, 38);
            this.plat1HPLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.plat1HPLabel.Name = "plat1HPLabel";
            this.plat1HPLabel.Size = new System.Drawing.Size(59, 44);
            this.plat1HPLabel.TabIndex = 1;
            this.plat1HPLabel.Text = "xd";
            // 
            // HP1
            // 
            this.HP1.AutoSize = true;
            this.HP1.Location = new System.Drawing.Point(220, 38);
            this.HP1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.HP1.Name = "HP1";
            this.HP1.Size = new System.Drawing.Size(267, 44);
            this.HP1.TabIndex = 0;
            this.HP1.Text = "Platform 1 HP:";
            // 
            // LBL_STATUS
            // 
            this.LBL_STATUS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LBL_STATUS.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_STATUS.Location = new System.Drawing.Point(0, 1281);
            this.LBL_STATUS.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LBL_STATUS.Name = "LBL_STATUS";
            this.LBL_STATUS.Size = new System.Drawing.Size(2740, 44);
            this.LBL_STATUS.TabIndex = 2;
            this.LBL_STATUS.Text = "WELCOME !!!";
            // 
            // PNL_HEADER
            // 
            this.PNL_HEADER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PNL_HEADER.Controls.Add(this.planeStatus2);
            this.PNL_HEADER.Controls.Add(this.label1);
            this.PNL_HEADER.Controls.Add(this.planeStatus1);
            this.PNL_HEADER.Controls.Add(this.Plane1);
            this.PNL_HEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNL_HEADER.Location = new System.Drawing.Point(0, 0);
            this.PNL_HEADER.Margin = new System.Windows.Forms.Padding(6);
            this.PNL_HEADER.Name = "PNL_HEADER";
            this.PNL_HEADER.Size = new System.Drawing.Size(2740, 192);
            this.PNL_HEADER.TabIndex = 0;
            this.PNL_HEADER.Paint += new System.Windows.Forms.PaintEventHandler(this.PNL_HEADER_Paint);
            // 
            // planeStatus2
            // 
            this.planeStatus2.AutoSize = true;
            this.planeStatus2.Location = new System.Drawing.Point(2164, 108);
            this.planeStatus2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.planeStatus2.Name = "planeStatus2";
            this.planeStatus2.Size = new System.Drawing.Size(0, 44);
            this.planeStatus2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1922, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 44);
            this.label1.TabIndex = 9;
            // 
            // planeStatus1
            // 
            this.planeStatus1.AutoSize = true;
            this.planeStatus1.Location = new System.Drawing.Point(646, 108);
            this.planeStatus1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.planeStatus1.Name = "planeStatus1";
            this.planeStatus1.Size = new System.Drawing.Size(0, 44);
            this.planeStatus1.TabIndex = 8;
            // 
            // Plane1
            // 
            this.Plane1.AutoSize = true;
            this.Plane1.Location = new System.Drawing.Point(404, 108);
            this.Plane1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Plane1.Name = "Plane1";
            this.Plane1.Size = new System.Drawing.Size(0, 44);
            this.Plane1.TabIndex = 7;
            // 
            // TIMER
            // 
            this.TIMER.Enabled = true;
            this.TIMER.Interval = 10;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2740, 1325);
            this.Controls.Add(this.PNL_MAIN);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MyForm";
            this.Text = "PLAYGROUND || VERLETS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MyForm_Load);
            this.SizeChanged += new System.EventHandler(this.MyForm_SizeChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            this.PNL_MAIN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.PNL_BOTTOM.ResumeLayout(false);
            this.PNL_BOTTOM.PerformLayout();
            this.PNL_HEADER.ResumeLayout(false);
            this.PNL_HEADER.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNL_MAIN;
        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PNL_BOTTOM;
        private System.Windows.Forms.Label LBL_STATUS;
        private System.Windows.Forms.Panel PNL_HEADER;
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.Label plat1HPLabel;
        private System.Windows.Forms.Label HP1;
        private System.Windows.Forms.Label plat2HpLabel;
        private System.Windows.Forms.Label HP2;
        private System.Windows.Forms.Label planeStatus1;
        private System.Windows.Forms.Label Plane1;
        private System.Windows.Forms.Label planeStatus2;
        private System.Windows.Forms.Label label1;
    }
}

