﻿namespace Film
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
            this.Sort_year = new System.Windows.Forms.Button();
            this.Poisk = new System.Windows.Forms.TextBox();
            this.Clear = new System.Windows.Forms.Button();
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
            // Sort_year
            // 
            this.Sort_year.Location = new System.Drawing.Point(519, 111);
            this.Sort_year.Name = "Sort_year";
            this.Sort_year.Size = new System.Drawing.Size(75, 23);
            this.Sort_year.TabIndex = 2;
            this.Sort_year.Text = "Sort year";
            this.Sort_year.UseVisualStyleBackColor = true;
            this.Sort_year.Click += new System.EventHandler(this.Sort_year_Click);
            // 
            // Poisk
            // 
            this.Poisk.Location = new System.Drawing.Point(394, 113);
            this.Poisk.Name = "Poisk";
            this.Poisk.Size = new System.Drawing.Size(100, 20);
            this.Poisk.TabIndex = 3;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(519, 82);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 4;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(606, 386);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Poisk);
            this.Controls.Add(this.Sort_year);
            this.Controls.Add(this.ShowCartoons);
            this.Controls.Add(this.Show_Active);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "My_form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Show_Active;
        private System.Windows.Forms.Button ShowCartoons;
        private System.Windows.Forms.Button Sort_year;
        private System.Windows.Forms.TextBox Poisk;
        private System.Windows.Forms.Button Clear;

    }
}

