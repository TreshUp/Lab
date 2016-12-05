using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Form1 main = this.Owner as Form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TextBox[] tb = new TextBox[2];//todo nomera
            for (int i = 0; i < tb.Length; i++)
            {
                tb[i] = new System.Windows.Forms.TextBox();
                tb[i].Location = new System.Drawing.Point(150, i * (23+5));
                tb[i].Name = "textBox" + i.ToString();
                tb[i].Size = new System.Drawing.Size(75, 23);
                tb[i].TabIndex = i;
                Controls.Add(tb[i]);
            }
        }
        public string Rtext()
        {
            return textBox1.Text;
        }
    }
}
