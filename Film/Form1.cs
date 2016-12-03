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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //IList<T_Abs_Film> elements = new List<T_Abs_Film>();
        IList<T_Action_Movie> elementsActive = new List<T_Action_Movie>();
        IList<T_Cartoon> elementsCartoon = new List<T_Cartoon>();
        private void Form1_Load(object sender, EventArgs e)
        {
           for(int i=1;i<5;i+=3) //todo nomer
            {
                T_Action_Movie objA = new T_Action_Movie();
                T_Cartoon objC = new T_Cartoon(); 
                objA.Read_File(i, "out");
                elementsActive.Add(objA);
                objC.Read_File(i, "out");
                elementsCartoon.Add(objC);
            }
        }
        TextBox[] tb = new TextBox[2]; //todo nomer
        private void Show_Active_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tb.Length; i++)
            {
                tb[i] = new System.Windows.Forms.TextBox();
                tb[i].Location = new System.Drawing.Point(10, i * (23+10));
                tb[i].Name = "textBox" + i.ToString();
                tb[i].Size = new System.Drawing.Size(75, 23);
                tb[i].TabIndex = i;
                tb[i].Text = elementsActive[i].Name;
                Controls.Add(tb[i]);
            }
        }

        private void ShowCartoons_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tb.Length; i++)
            {
                tb[i] = new System.Windows.Forms.TextBox();
                tb[i].Location = new System.Drawing.Point(200, i * (23 + 10));
                tb[i].Name = "textBox" + i.ToString();
                tb[i].Size = new System.Drawing.Size(75, 23);
                tb[i].TabIndex = i;
                tb[i].Text = elementsCartoon[i].Name;
                Controls.Add(tb[i]);
            }
        }
    }
}
