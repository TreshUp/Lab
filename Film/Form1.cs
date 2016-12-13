using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Film
{
    public partial class Form1 : Form
    {
        static int n = 18;
        TextBox[] tb = new TextBox[n]; //todo nomer
        TextBox[] cb = new TextBox[n];
        TextBox[] sb = new TextBox[n];
        
        string[] Activefields = new string[]
            {
                "0","1","2","3","4","5","6","7","8","9","10","11","12","13"
            };
        string[] Cartoonfields = new string[]
            {
                "0","1","2","3","4","5","6","7","8","9"
            };
        string[] Serialfields = new string[]
            {
                "0","1","2","3","4","5","6","7","8"
            };
        string[] fieldsA; //= new string[]
        //    {
        //        //"0","1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17"
        //    };
        ////IList<string> fields = new List<string>();
        string[] fieldsC;
        string[] fieldsS;
        public Form1()
        {
            InitializeComponent();
            QsortBox.Items.Add("Name");
            QsortBox.Items.Add("Year");
            QsortBox.Items.Add("Time");
            QsortBox.Items.Add("Num_Seasons");
            QsortBox.Items.Add("Num_Series");
            for (int i = 0; i < tb.Length; i++)
            {
                tb[i] = new System.Windows.Forms.TextBox();
                tb[i].Location = new System.Drawing.Point(10, i * (23 + 10));
                tb[i].Name = "textBox" + i.ToString();
                tb[i].Size = new System.Drawing.Size(80, 30);
                tb[i].TabIndex = i;
                Controls.Add(tb[i]);
            }
            for (int i=0;i<cb.Length;i++)
            {
                cb[i] = new System.Windows.Forms.TextBox();
                cb[i].Location = new System.Drawing.Point(150, i * (23 + 10));
                cb[i].Name = "textBox" + i.ToString();
                cb[i].Size = new System.Drawing.Size(80, 30);
                cb[i].TabIndex = i;
                Controls.Add(cb[i]);
            }
            for (int i=0;i<sb.Length;i++)
            {
                sb[i] = new System.Windows.Forms.TextBox();
                sb[i].Location = new System.Drawing.Point(300, i * (23 + 10));
                sb[i].Name = "textBox" + i.ToString();
                sb[i].Size = new System.Drawing.Size(80, 30);
                sb[i].TabIndex = i;
                Controls.Add(sb[i]);
            }

        }
        IList<T_Action_Movie> elementsActive = new List<T_Action_Movie>();
        IList<T_Cartoon> elementsCartoon = new List<T_Cartoon>();
        IList<T_Serial> elementsSerial = new List<T_Serial>();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            for(int i=1;i<3*n+1;i+=3) //todo nomer
            {
                T_Action_Movie objA = new T_Action_Movie();
                T_Cartoon objC = new T_Cartoon();
                objA.Read_File(i, "out");
                elementsActive.Add(objA);
                objC.Read_File(i, "out");
                elementsCartoon.Add(objC);
            }
            for (int i=1;i<2*n+1;i+=2)
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

        private void Sort_year_Click(object sender, EventArgs e)//todo ssylka
        {
            ArgumentException r = new ArgumentException("Nothing to choose.");
            ClearAll(ref tb);
            ClearAll(ref cb);
            ClearAll(ref sb);
            try
            {
                for (int i = 0; i < elementsActive.Count; i++)
                {
                    if (elementsActive[i].Sort_year(int.Parse(Poisk.Text)) == true)
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
            catch { MessageBox.Show(r.Message); }
        }

        private void Sort_cat_Click(object sender, EventArgs e)//todo ssylka
        {
            ClearAll(ref tb);
            ClearAll(ref cb);
            ClearAll(ref sb);
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

        private void Show_Info_Click(object sender, EventArgs e) //todo ssylka;
        {
            ClearAll(ref tb);
            ClearAll(ref cb);
            ClearAll(ref sb);
            for (int i=0;i<elementsActive.Count;i++)
            {
                if (String.Compare(elementsActive[i].Name, Poisk.Text, new CultureInfo(""), CompareOptions.IgnoreCase) == 0)
                {
                    elementsActive[i].Show_All_Info(ref Activefields);
                    for (int j=0;j<Activefields.Length;j++)
                    {
                        tb[j].Text = Activefields[j];
                    }
                }
            }

            for (int i = 0; i < elementsCartoon.Count; i++)
            {
                if (String.Compare(elementsCartoon[i].Name, Poisk.Text, new CultureInfo(""), CompareOptions.IgnoreCase) == 0)
                {
                    elementsCartoon[i].Show_All_Info(ref Cartoonfields);
                    for (int j = 0; j < Cartoonfields.Length; j++)
                    {
                        cb[j].Text = Cartoonfields[j];
                    }
                }
            }

            for (int i = 0; i < elementsSerial.Count; i++)
            {
                if (String.Compare(elementsSerial[i].Name, Poisk.Text, new CultureInfo(""), CompareOptions.IgnoreCase) == 0)
                {
                    elementsSerial[i].Show_All_Info(ref Serialfields);
                    for (int j = 0; j < Serialfields.Length; j++)
                    {
                        sb[j].Text = Serialfields[j];
                    }
                }
            }
        }

        private void Serial_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                sb[i].Text = elementsSerial[i].Name;
            }
        }

        private void Enter_obj_SelectionChangeCommitted(object sender, EventArgs e) //todo ssylka
        {
            Poisk.Text = "";
            if (Enter_obj.SelectedItem == "Action Movie")
            {
                ClearAll(ref cb);
                ClearAll(ref sb);
                for (int j=0;j<Activefields.Length;j++)
                {
                    Activefields[j] = tb[j].Text;
                }
                T_Action_Movie objA = new T_Action_Movie(ref Activefields);
                elementsActive.Add(objA);
            }
            if (Enter_obj.SelectedItem == "Cartoon")
            {
                ClearAll(ref tb);
                ClearAll(ref sb);
                for (int j = 0; j < Cartoonfields.Length; j++)
                {
                    Cartoonfields[j] = cb[j].Text;
                }
                T_Cartoon objC = new T_Cartoon(ref Cartoonfields);
                elementsCartoon.Add(objC);
            }
            if (Enter_obj.SelectedItem == "Serial")
            {
                ClearAll(ref cb);
                ClearAll(ref tb);
                for (int j = 0; j < Serialfields.Length; j++)
                {
                    Serialfields[j] = sb[j].Text;
                }
                T_Serial objS = new T_Serial(ref Serialfields);
                elementsSerial.Add(objS);
            }
        }
        public void Qsort(string[] fields, int l, int r)
        {
            string temp;
            string x = fields[l + (r - l) / 2];
            int i = l;
            int j = r;
            while (i <= j)
            {
                while (String.Compare(fields[i], x, new CultureInfo(""), CompareOptions.IgnoreCase) > 0) i++;
                while (String.Compare(fields[j], x, new CultureInfo(""), CompareOptions.IgnoreCase) < 0) j--;
                if (i <= j)
                {
                    temp = fields[i];
                    fields[i] = fields[j];
                    fields[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < r)
                Qsort(fields, i, r);

            if (l < j)
                Qsort(fields, l, j);
        }

        private void Qsort_Click(object sender, EventArgs e)
        {
            fieldsA = new string[elementsActive.Count];
            fieldsC = new string[elementsCartoon.Count];
            fieldsS = new string[elementsSerial.Count];
            ClearAll(ref tb);
            ClearAll(ref cb);
            ClearAll(ref sb);
            if (QsortBox.Text == "Name")
            {
                for (int i = 0; i < elementsActive.Count; i++)
                {
                    fieldsA[i] = elementsActive[i].Name.ToString();
                    //fields.Add(elementsActive[i].Name);
                }
                Qsort(fieldsA, 0, fieldsA.Length - 1);
                for (int i = 0; i < fieldsA.Length; i++)
                {
                    tb[i].Text = fieldsA[i];
                }
                for (int i = 0; i < elementsCartoon.Count; i++)
                {
                    fieldsC[i] = elementsCartoon[i].Name.ToString();
                    //fields.Add(elementsCartoon[i].Name);
                }
                Qsort(fieldsC, 0, fieldsC.Length - 1);
                for (int i = 0; i < fieldsC.Length; i++)
                {
                    cb[i].Text = fieldsC[i];
                }

                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Name.ToString();
                    //fields.Add(elementsSerial[i].Name);
                }
                Qsort(fieldsS, 0, fieldsS.Length - 1);
                for (int i = 0; i < fieldsS.Length; i++)
                {
                    sb[i].Text = fieldsS[i];
                }
            }
            if (QsortBox.Text == "Year")
            {
                for (int i = 0; i < elementsActive.Count; i++)
                {
                    fieldsA[i] = elementsActive[i].Year.ToString();
                    //fields.Add(elementsActive[i].Year.ToString());
                }
                Qsort(fieldsA, 0, fieldsA.Length - 1);
                for (int i = 0; i < fieldsA.Length; i++)
                {
                    tb[i].Text = fieldsA[i];
                }

                for (int i = 0; i < elementsCartoon.Count; i++)
                {
                    fieldsC[i] = elementsCartoon[i].Year.ToString();
                    //fields.Add(elementsCartoon[i].Year.ToString());
                }
                Qsort(fieldsC, 0, fieldsC.Length - 1);
                for (int i = 0; i < fieldsC.Length; i++)
                {
                    cb[i].Text = fieldsC[i];
                }

                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Year.ToString();
                    //fields.Add(elementsSerial[i].Year.ToString());
                }
                Qsort(fieldsS, 0, fieldsS.Length - 1);
                for (int i = 0; i < fieldsS.Length; i++)
                {
                    sb[i].Text = fieldsS[i];
                }
            }
            if (QsortBox.Text == "Time")
            {
                for (int i = 0; i < elementsActive.Count; i++)
                {
                    fieldsA[i] = elementsActive[i].Time.ToString();
                    //fields.Add(elementsActive[i].Time.ToString());
                }
                Qsort(fieldsS, 0, fieldsA.Length - 1);
                for (int i = 0; i < fieldsA.Length; i++)
                {
                    tb[i].Text = fieldsS[i];
                }

                for (int i = 0; i < elementsCartoon.Count; i++)
                {
                    fieldsC[i] = elementsCartoon[i].Time.ToString();
                    //fields.Add(elementsCartoon[i].Time.ToString());
                }
                Qsort(fieldsC, 0, fieldsC.Length - 1);
                for (int i = 0; i < fieldsC.Length; i++)
                {
                    cb[i].Text = fieldsC[i];
                }

                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Time.ToString();
                    //fields.Add(elementsSerial[i].Time.ToString());
                }
                Qsort(fieldsS, 0, fieldsS.Length - 1);
                for (int i = 0; i < fieldsS.Length; i++)
                {
                    sb[i].Text = fieldsS[i];
                }
            }
            if (QsortBox.Text == "Num_Seasons")
            {
                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Num_Seasons.ToString();
                    //fields.Add(elementsSerial[i].Num_Seasons.ToString());
                }
                Qsort(fieldsS, 0, fieldsS.Length - 1);
                for (int i = 0; i < fieldsS.Length; i++)
                {
                    sb[i].Text = fieldsS[i];
                }
            }
            if (QsortBox.Text == "Num_Series")
            {
                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Num_series.ToString();
                    //fields.Add(elementsSerial[i].Num_series.ToString());
                }
                Qsort(fieldsS, 0, fieldsS.Length - 1);
                for (int i = 0; i < fieldsS.Length; i++)
                {
                    sb[i].Text = fieldsS[i];
                }
            }
        }

    }
}
