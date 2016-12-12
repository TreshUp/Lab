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
        string[] fields = new string[]
            {
                "0","1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17"
            };
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
            ArgumentException r = new ArgumentException("Nothing to choose");
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
        private void QSortYear_Click(object sender, EventArgs e)
        {
            ClearAll(ref tb);
            ClearAll(ref cb);
            ClearAll(ref sb);

            for (int i = 0; i < elementsActive.Count; i++)
            {
              fields[i]= elementsActive[i].Year.ToString();
            }
            Qsort(fields, 0, fields.Length - 1);
            for (int i = 0; i < fields.Length; i++)
            {
                tb[i].Text = fields[i];
            }

            for (int i = 0; i < elementsCartoon.Count; i++)
            {
                fields[i] = elementsCartoon[i].Year.ToString();
            }
            Qsort(fields, 0, fields.Length - 1);
            for (int i = 0; i < fields.Length; i++)
            {
                cb[i].Text = fields[i];
            }

            for (int i = 0; i < elementsSerial.Count; i++)
            {
                fields[i] = elementsSerial[i].Year.ToString();
            }
            Qsort(fields, 0, fields.Length - 1);
            for (int i = 0; i < fields.Length; i++)
            {
                sb[i].Text = fields[i];
            }
        }

        private void QsortName_Click(object sender, EventArgs e)
        {
            ClearAll(ref tb);
            ClearAll(ref cb);
            ClearAll(ref sb);

            for (int i = 0; i < elementsActive.Count; i++)
            {
                fields[i] = elementsActive[i].Name.ToString();
            }
            Qsort(fields, 0, fields.Length - 1);
            for (int i = 0; i < fields.Length; i++)
            {
                tb[i].Text = fields[i];
            }

            for (int i = 0; i < elementsCartoon.Count; i++)
            {
                fields[i] = elementsCartoon[i].Name.ToString();
            }
            Qsort(fields, 0, fields.Length - 1);
            for (int i = 0; i < fields.Length; i++)
            {
                cb[i].Text = fields[i];
            }

            for (int i = 0; i < elementsSerial.Count; i++)
            {
                fields[i] = elementsSerial[i].Name.ToString();
            }
            Qsort(fields, 0, fields.Length - 1);
            for (int i = 0; i < fields.Length; i++)
            {
                sb[i].Text = fields[i];
            }
        }

    }
}
