﻿using System;
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
        TextBox[] tb; 
        TextBox[] cb; 
        TextBox[] sb; 
        public event Action Changed;
        string[] Activefields = new string[14];

        string[] Cartoonfields = new string[10];

        string[] Serialfields = new string[9];

        string[] fieldsA;
        string[] fieldsC;
        string[] fieldsS;
        public Form1()
        {
            InitializeComponent();

        }
        IList<T_Action_Movie> elementsActive = new List<T_Action_Movie>();
        IList<T_Cartoon> elementsCartoon = new List<T_Cartoon>();
        IList<T_Serial> elementsSerial = new List<T_Serial>();
        private void Form1_Load(object sender, EventArgs e)
        {
            QsortBox.Items.Add("Name");
            QsortBox.Items.Add("Year");
            QsortBox.Items.Add("Time");
            QsortBox.Items.Add("Num_Seasons");
            QsortBox.Items.Add("Num_Series");
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
            tb = new TextBox[2*elementsActive.Count];
            cb = new TextBox[2*elementsCartoon.Count];
            sb = new TextBox[2*elementsSerial.Count];
            for (int i = 0; i < elementsActive.Count; i++)
            {
                BoxInit(tb, i,10);
            }
            for (int i = 0; i < elementsCartoon.Count; i++)
            {
                BoxInit(cb, i,150);
            }
            for (int i = 0; i < elementsSerial.Count; i++)
            {
                BoxInit(sb, i,300);
            }
        }
        public void BoxInit(TextBox[] t, int number,int pos)
        {
            t[number] = new System.Windows.Forms.TextBox();
            t[number].Location = new System.Drawing.Point(pos, number * (23));
            t[number].Name = "textBox" + number.ToString();
            t[number].Size = new System.Drawing.Size(80, 30);
            t[number].TabIndex = number;
            Controls.Add(t[number]);
        }
        private void Show_Active_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < elementsActive.Count; i++)
            {
            tb[i].Text = elementsActive[i].Name;
            }
        }
        private void ShowCartoons_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < elementsCartoon.Count; i++)
            {
                cb[i].Text = elementsCartoon[i].Name;
            }
        }
        private void ClearAll(ref TextBox[] t)
        {
            if (t==tb)
            {
                for (int i = 0; i < elementsActive.Count; i++)
                {
                    t[i].Text = "";
                }
            }
            if (t == cb)
            {
                for (int i = 0; i < elementsCartoon.Count; i++)
                {
                    t[i].Text = "";
                }
            }
            if (t == sb)
            {
                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    t[i].Text = "";
                }
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
            for (int i = 0; i < elementsSerial.Count; i++)
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
                if ((tb[1].Text) != "" && (tb[2].Text) != "" && ((tb[6].Text) == "0" || (tb[6].Text) == "1") && ((tb[7].Text) == "0" || (tb[7].Text) == "1"))
                {
                    elementsActive.Add(objA);
                    BoxInit(tb, elementsActive.Count - 1, 10);
                }
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
                if ((cb[1].Text) != "" && (cb[2].Text) != "" && ((cb[6].Text) == "0" || (cb[6].Text) == "1") && ((cb[7].Text) == "0" || (cb[7].Text) == "1"))
                {
                    elementsCartoon.Add(objC);
                    BoxInit(cb, elementsCartoon.Count - 1, 150);
                }
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
                if ((sb[1].Text) != "" && (sb[2].Text) != "" && (sb[6].Text) != "" && (sb[7].Text) != "")
                {
                    elementsSerial.Add(objS);
                    BoxInit(sb, elementsSerial.Count - 1, 300);
                }
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
                    fieldsA[i] = elementsActive[i].Name;
                }
                Qsort(fieldsA, 0, fieldsA.Length - 1);
                for (int i = 0; i < fieldsA.Length; i++)
                {
                    tb[i].Text = fieldsA[i];
                }
                for (int i = 0; i < elementsCartoon.Count; i++)
                {
                    fieldsC[i] = elementsCartoon[i].Name;
                }
                Qsort(fieldsC, 0, fieldsC.Length - 1);
                for (int i = 0; i < fieldsC.Length; i++)
                {
                    cb[i].Text = fieldsC[i];
                }

                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Name;
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
                }
                Qsort(fieldsA, 0, fieldsA.Length - 1);
                for (int i = 0; i < fieldsA.Length; i++)
                {
                    tb[i].Text = fieldsA[i];
                }

                for (int i = 0; i < elementsCartoon.Count; i++)
                {
                    fieldsC[i] = elementsCartoon[i].Year.ToString();
                }
                Qsort(fieldsC, 0, fieldsC.Length - 1);
                for (int i = 0; i < fieldsC.Length; i++)
                {
                    cb[i].Text = fieldsC[i];
                }

                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Year.ToString();
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
                }
                Qsort(fieldsS, 0, fieldsA.Length - 1);
                for (int i = 0; i < fieldsA.Length; i++)
                {
                    tb[i].Text = fieldsS[i];
                }

                for (int i = 0; i < elementsCartoon.Count; i++)
                {
                    fieldsC[i] = elementsCartoon[i].Time.ToString();
                }
                Qsort(fieldsC, 0, fieldsC.Length - 1);
                for (int i = 0; i < fieldsC.Length; i++)
                {
                    cb[i].Text = fieldsC[i];
                }

                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Time.ToString();
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
