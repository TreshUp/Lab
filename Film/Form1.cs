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
            for (int i = 0; i < tb.Length; i++)
            {
                tb[i] = new System.Windows.Forms.TextBox();
                tb[i].Location = new System.Drawing.Point(10, i * (23 + 10));
                tb[i].Name = "textBox" + i.ToString();
                tb[i].Size = new System.Drawing.Size(80, 30);
                tb[i].TabIndex = i;
                //tb[i].Click += new System.EventHandler(this.textBox_ClickA);
                Controls.Add(tb[i]);
                cb[i] = new System.Windows.Forms.TextBox();
                cb[i].Location = new System.Drawing.Point(200, i * (23 + 10));
                cb[i].Name = "textBox" + i.ToString();
                cb[i].Size = new System.Drawing.Size(80, 30);
                cb[i].TabIndex = i;
                //cb[i].Click += new System.EventHandler(this.textBox_ClickC);
                Controls.Add(cb[i]);
            }
        }

        //IList<T_Abs_Film> elements = new List<T_Abs_Film>();
        IList<T_Action_Movie> elementsActive = new List<T_Action_Movie>();
        IList<T_Cartoon> elementsCartoon = new List<T_Cartoon>();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            for(int i=1;i<7;i+=3) //todo nomer
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
        TextBox[] cb = new TextBox[2];
        private void Show_Active_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tb.Length; i++)
            {
            //    tb[i] = new System.Windows.Forms.TextBox();
            //    tb[i].Location = new System.Drawing.Point(10, i * (23+10));
            //    tb[i].Name = "textBox" + i.ToString();
            //    tb[i].Size = new System.Drawing.Size(80, 30);
            //    tb[i].TabIndex = i;
            tb[i].Text = elementsActive[i].Name;
            //    tb[i].Click += new System.EventHandler(this.textBox_Click);
            //    Controls.Add(tb[i]);
            }
        }
        //private void textBox_ClickA(object sender, EventArgs e) //todo view
        //{
        //    //for (int i = 0; i < tb.Length;i++)
        //    //{
        //    //    if (tb.Tex)
        //    //}
        //        this.ClearAll(ref tb);

        //}
        //private void textBox_ClickC(object sender, EventArgs e) //todo view
        //{
        //    this.ClearAll(ref cb);

        //}
        private void ShowCartoons_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cb.Length; i++)
            {
                //cb[i] = new System.Windows.Forms.TextBox();
                //cb[i].Location = new System.Drawing.Point(200, i * (23 + 10));
                //cb[i].Name = "textBox" + i.ToString();
                //cb[i].Size = new System.Drawing.Size(80, 30);
                //cb[i].TabIndex = i;
                cb[i].Text = elementsCartoon[i].Name;
                //cb[i].Click += new System.EventHandler(this.textBox_Click);
                //Controls.Add(cb[i]);
            }
        }
        private void ClearAll(ref TextBox[] t)
        {
            for (int i = 0; i < t.Length; i++)
            {
                t[i].Text = "";
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            ClearAll(ref tb);
            ClearAll(ref cb);
            Poisk.Text = "";
        }

        private void Sort_year_Click(object sender, EventArgs e)
        {
            //todo except
            for (int i = 0; i < elementsActive.Count; i++)
            {
                if (elementsActive[i].Sort_year(int.Parse(Poisk.Text))==true)
                {
                    tb[i].Text = elementsActive[i].Name;
                }
            }
            for (int i = 0; i < elementsCartoon.Count; i++)
            {
                if (elementsCartoon[i].Sort_year(int.Parse(Poisk.Text)) == true)
                {
                    cb[i].Text = elementsCartoon[i].Name;
                }
            }
        }

        private void Sort_cat_Click(object sender, EventArgs e)
        {
            //todo except
            for (int i = 0; i < elementsActive.Count; i++)
            {
                if (elementsActive[i].Sort_Cat(Poisk.Text) == true)
                {
                    tb[i].Text = elementsActive[i].Name;
                }
            }
            for (int i = 0; i < elementsCartoon.Count; i++)
            {
                if (elementsCartoon[i].Sort_Cat(Poisk.Text) == true)
                {
                    cb[i].Text = elementsCartoon[i].Name;
                }
            }
        }

        private void Show_Info_Click(object sender, EventArgs e)
        {
            ClearAll(ref tb);
            ClearAll(ref cb);
            for (int i=0;i<tb.Length;i++)
            {
                //todo enum;
            }
        }
    }
}
