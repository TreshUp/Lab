namespace Film
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Show_Active = new System.Windows.Forms.Button();
            this.ShowCartoons = new System.Windows.Forms.Button();
            this.Sort_Films = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Show_Active
            // 
            this.Show_Active.Location = new System.Drawing.Point(519, 2);
            this.Show_Active.Name = "Show_Active";
            this.Show_Active.Size = new System.Drawing.Size(75, 23);
            this.Show_Active.TabIndex = 0;
            this.Show_Active.Text = "Films";
            this.Show_Active.UseVisualStyleBackColor = true;
            this.Show_Active.Click += new System.EventHandler(this.Show_Active_Click);
            // 
            // ShowCartoons
            // 
            this.ShowCartoons.Location = new System.Drawing.Point(519, 31);
            this.ShowCartoons.Name = "ShowCartoons";
            this.ShowCartoons.Size = new System.Drawing.Size(75, 23);
            this.ShowCartoons.TabIndex = 1;
            this.ShowCartoons.Text = "Cartoons";
            this.ShowCartoons.UseVisualStyleBackColor = true;
            this.ShowCartoons.Click += new System.EventHandler(this.ShowCartoons_Click);
            // 
            // Sort_Films
            // 
            this.Sort_Films.Location = new System.Drawing.Point(519, 111);
            this.Sort_Films.Name = "Sort_Films";
            this.Sort_Films.Size = new System.Drawing.Size(75, 23);
            this.Sort_Films.TabIndex = 2;
            this.Sort_Films.Text = "Sort films";
            this.Sort_Films.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(606, 386);
            this.Controls.Add(this.Sort_Films);
            this.Controls.Add(this.ShowCartoons);
            this.Controls.Add(this.Show_Active);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "My_form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Show_Active;
        private System.Windows.Forms.Button ShowCartoons;
        private System.Windows.Forms.Button Sort_Films;

    }
}

