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
        TextBox[] tb = new TextBox[4]; //todo nomer
        TextBox[] cb = new TextBox[4];
        TextBox[] sb = new TextBox[4];
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
            }
            for (int i=0;i<cb.Length;i++)
            {
                cb[i] = new System.Windows.Forms.TextBox();
                cb[i].Location = new System.Drawing.Point(150, i * (23 + 10));
                cb[i].Name = "textBox" + i.ToString();
                cb[i].Size = new System.Drawing.Size(80, 30);
                cb[i].TabIndex = i;
                //cb[i].Click += new System.EventHandler(this.textBox_ClickC);
                Controls.Add(cb[i]);
            }
            for (int i=0;i<sb.Length;i++)
            {
                sb[i] = new System.Windows.Forms.TextBox();
                sb[i].Location = new System.Drawing.Point(300, i * (23 + 10));
                sb[i].Name = "textBox" + i.ToString();
                sb[i].Size = new System.Drawing.Size(80, 30);
                sb[i].TabIndex = i;
                //cb[i].Click += new System.EventHandler(this.textBox_ClickC);
                Controls.Add(sb[i]);
            }

        }
        IList<T_Action_Movie> elementsActive = new List<T_Action_Movie>();
        IList<T_Cartoon> elementsCartoon = new List<T_Cartoon>();
        IList<T_Serial> elementsSerial = new List<T_Serial>();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            for(int i=1;i<13;i+=3) //todo nomer
            {
                T_Action_Movie objA = new T_Action_Movie();
                T_Cartoon objC = new T_Cartoon();
                objA.Read_File(i, "out");
                elementsActive.Add(objA);
                objC.Read_File(i, "out");
                elementsCartoon.Add(objC);
            }
            for (int i=1;i<9;i+=2)
            {
                T_Serial objS = new T_Serial();
                objS.Read_File(i, "out");
                elementsSerial.Add(objS);
            }
        }
        private void Show_Active_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tb.Length; i++)
            {
            tb[i].Text = elementsActive[i].Name;
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
                cb[i].Text = elementsCartoon[i].Name;
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
            ClearAll(ref sb);
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
            for (int i = 0; i < elementsSerial.Count; i++)
            {
                if (elementsSerial[i].Sort_year(int.Parse(Poisk.Text)) == true)
                {
                    sb[i].Text = elementsSerial[i].Name;
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
            ClearAll(ref sb);
            for (int i=0;i<tb.Length;i++)
            {
                //todo enum;
            }
        }

        private void Serial_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                sb[i].Text = elementsSerial[i].Name;
            }
        }
    }
}
