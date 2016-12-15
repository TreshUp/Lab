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
        TextBox[] tb;
        TextBox[] cb; //textbox массивы, необходимые отображения полей классов;
        TextBox[] sb; 
        string[] Activefields = new string[14];

        string[] Cartoonfields = new string[10]; //string массивы для записи и чтения полей классов;

        string[] Serialfields = new string[9];

        string[] fieldsA;
        string[] fieldsC;//string массивы, необходимые для  сортировки некоторых полей классов в возрастающем порядке;
        string[] fieldsS;
        public Form1()
        {
            InitializeComponent();

        }
        IList<T_Action_Movie> elementsActive = new List<T_Action_Movie>();
        IList<T_Cartoon> elementsCartoon = new List<T_Cartoon>();           //строго типизированные списки объектов;
        IList<T_Serial> elementsSerial = new List<T_Serial>();

        private void Form1_Load(object sender, EventArgs e)//событие, которое происходит при каждой загрузке формы;
        {
            QsortBox.Items.Add("Name");
            QsortBox.Items.Add("Year");
            QsortBox.Items.Add("Time");         //добавление пунктов Name, Year, Time, Num_Seasons, Num_Series в элемент управления QsortBox
            QsortBox.Items.Add("Num_Seasons");
            QsortBox.Items.Add("Num_Series");
            for(int i=1;i<3*n+1;i+=3)
            {
                T_Action_Movie objA = new T_Action_Movie();//создание объекта класса T_Action_Movie
                T_Cartoon objC = new T_Cartoon();//создание объекта класса T_Cartoon
                objA.Read_File(i, "out");//считывание информации из файла
                elementsActive.Add(objA);//добавление нового объекта в коллекцию
                objC.Read_File(i, "out");
                elementsCartoon.Add(objC);
            }
            for (int i=1;i<2*n+1;i+=2)
            {
                T_Serial objS = new T_Serial();//создание объекта класса T_Serial
                objS.Read_File(i, "out");//считывание информации из файла
                elementsSerial.Add(objS);//добавление нового объекта в коллекцию
            }
            tb = new TextBox[2*elementsActive.Count];
            cb = new TextBox[2*elementsCartoon.Count];
            sb = new TextBox[2*elementsSerial.Count];
            for (int i = 0; i < elementsActive.Count; i++)
            {
                BoxInit(tb, i,10);//метод, который создает и отображает textbox на главной форме;
            }
            for (int i = 0; i < elementsCartoon.Count; i++)
            {
                BoxInit(cb, i, 150);//метод, который создает и отображает textbox на главной форме;
            }
            for (int i = 0; i < elementsSerial.Count; i++)
            {
                BoxInit(sb, i, 300);//метод, который создает и отображает textbox на главной форме;
            }
        }
        public void BoxInit(TextBox[] t, int number, int pos)//метод, который создает и отображает textbox на главной форме;
        {
            t[number] = new System.Windows.Forms.TextBox();
            t[number].Location = new System.Drawing.Point(pos, number * (23)); //расположение textbox на главной форме
            t[number].Name = "textBox" + number.ToString();//имя textbox
            t[number].Size = new System.Drawing.Size(100, 30);//размер textbox
            t[number].TabIndex = number;
            Controls.Add(t[number]);//добавление нового элемента управления
        }
        private void Show_Active_Click(object sender, EventArgs e)//событие, которое выводит название всех фильмов на главную форму. Активируется при нажатии на кнопку «Films»;
        {
            for (int i = 0; i < elementsActive.Count; i++)
            {
            tb[i].Text = elementsActive[i].Name;//вывод названий объектов в textbox
            }
        }
        private void ShowCartoons_Click(object sender, EventArgs e)//событие, которое выводит название всех мультфильмов на главную форму. Активируется при нажатии на кнопку «Cartoons»;
        {
            for (int i = 0; i < elementsCartoon.Count; i++)
            {
                cb[i].Text = elementsCartoon[i].Name;//вывод названий объектов в textbox
            }
        }
        private void ClearAll(ref TextBox[] t)//метод очистки textbox–ов;
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
        private void Clear_Click(object sender, EventArgs e)//событие очистки все textbox-ов на главной форме. Активируется при нажатии на кнопку «Clear»;
        {
            ClearAll(ref tb);
            ClearAll(ref cb);
            ClearAll(ref sb);
            Poisk.Text = "";
        }

        private void Sort_year_Click(object sender, EventArgs e)//обытие, которое выводит на форму, все объекты, удовлетворяющие некоторому условию (год создания). Активируется при нажатии на кнопку «Choose year»;
        {
            ArgumentException r = new ArgumentException("Nothing to choose.");//проверка на ""
            ClearAll(ref tb);
            ClearAll(ref cb);
            ClearAll(ref sb);
            try
            {
                for (int i = 0; i < elementsActive.Count; i++)
                {
                    if (elementsActive[i].Sort_year(int.Parse(Poisk.Text)) == true)
                    {
                        tb[i].Text = elementsActive[i].Name;//если объект подходит под условие, выводим его имя
                    }

                }
                for (int i = 0; i < elementsCartoon.Count; i++)
                {
                    if (elementsCartoon[i].Sort_year(int.Parse(Poisk.Text)) == true)
                    {
                        cb[i].Text = elementsCartoon[i].Name;//если объект подходит под условие, выводим его имя
                    }
                }
                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    if (elementsSerial[i].Sort_year(int.Parse(Poisk.Text)) == true)
                    {
                        sb[i].Text = elementsSerial[i].Name;//если объект подходит под условие, выводим его имя
                    }
                }
            }
            catch { MessageBox.Show(r.Message); }
        }

        private void Sort_cat_Click(object sender, EventArgs e)//событие, которое выводит на форму, все объекты, удовлетворяющие некоторому условию (жанр). Активируется при нажатии на кнопку «Choose cat»;
        {
            ClearAll(ref tb);
            ClearAll(ref cb);
            ClearAll(ref sb);
            for (int i = 0; i < elementsActive.Count; i++)
            {
                if (elementsActive[i].Sort_Cat(Poisk.Text) == true)
                {
                    tb[i].Text = elementsActive[i].Name;//если объект подходит под условие, выводим его имя
                }
            }
            for (int i = 0; i < elementsCartoon.Count; i++)
            {
                if (elementsCartoon[i].Sort_Cat(Poisk.Text) == true)
                {
                    cb[i].Text = elementsCartoon[i].Name;//если объект подходит под условие, выводим его имя
                }
            }
        }

        private void Show_Info_Click(object sender, EventArgs e)//событие, которое выводит всю информацию о данном объекте. Активируется при нажатии на кнопку «Show info»;
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
                        tb[j].Text = Activefields[j];//если объект подходит под условие, выводим всю информацию о нем
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
                        cb[j].Text = Cartoonfields[j];//если объект подходит под условие, выводим всю информацию о нем
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
                        sb[j].Text = Serialfields[j];//если объект подходит под условие, выводим всю информацию о нем
                    }
                }
            }
        }

        private void Serial_Click(object sender, EventArgs e)//событие, которое выводит название всех сериалов на главную форму. Активируется при нажатии на кнопку «Serial»;
        {
            for (int i = 0; i < elementsSerial.Count; i++)
            {
                sb[i].Text = elementsSerial[i].Name;//вывод названий объектов в textbox
            }
        }

        private void Enter_obj_SelectionChangeCommitted(object sender, EventArgs e)//событие, которое добавляет в коллекцию новый объект;
        {
            bool flag=false;//"флаг" для проверки на совпадение имен
            Poisk.Text = "";
            if (Enter_obj.SelectedItem == "Action Movie")
            {
                ClearAll(ref cb);
                ClearAll(ref sb);
                for (int j=0;j<Activefields.Length;j++)
                {
                    Activefields[j] = tb[j].Text;
                }
                for (int j=0;j<elementsActive.Count;j++)
                {
                    if (String.Compare(elementsActive[j].Name, Activefields[0], new CultureInfo(""), CompareOptions.IgnoreCase) == 0)//проверка на совпание имен
                    {
                        flag=true;
                    }

                }
                if (flag != true)
                {
                    try
                    {
                        T_Action_Movie objA = new T_Action_Movie(ref Activefields); //создание и добавление нового объекта в коллекцию
                        elementsActive.Add(objA);
                        BoxInit(tb, elementsActive.Count - 1, 10);                  //создание нового textbox
                    }
                    catch (FormatException r) { MessageBox.Show(r.Message);  }//проверка на несовпадение типов данных
                    catch (ArgumentException s) { MessageBox.Show(s.Message); }//проверка на некорректные значения данныъ
                }
                else MessageBox.Show("Same data.");//если найден объект с таким же именем, уведомляем пользователя
            }
            if (Enter_obj.SelectedItem == "Cartoon")
            {
                flag = false;
                ClearAll(ref tb);
                ClearAll(ref sb);
                for (int j = 0; j < Cartoonfields.Length; j++)
                {
                    Cartoonfields[j] = cb[j].Text;
                }
                for (int j = 0; j < elementsCartoon.Count; j++)
                {
                    if (String.Compare(elementsCartoon[j].Name, Cartoonfields[0], new CultureInfo(""), CompareOptions.IgnoreCase) == 0)
                    {
                        flag = true;
                    }

                }
                if (flag != true)
                {
                    try
                    {
                        T_Cartoon objC = new T_Cartoon(ref Cartoonfields);
                        elementsCartoon.Add(objC);
                        BoxInit(cb, elementsCartoon.Count - 1, 150);
                    }
                    catch (FormatException r) { MessageBox.Show(r.Message); }
                    catch (ArgumentException s) { MessageBox.Show(s.Message); }
                }
                else MessageBox.Show("Same data.");
            }
            if (Enter_obj.SelectedItem == "Serial")
            {
                flag = false;
                ClearAll(ref cb);
                ClearAll(ref tb);
                for (int j = 0; j < Serialfields.Length; j++)
                {
                    Serialfields[j] = sb[j].Text;
                }
                for (int j = 0; j < elementsSerial.Count; j++)
                {
                    if (String.Compare(elementsSerial[j].Name, Serialfields[0], new CultureInfo(""), CompareOptions.IgnoreCase) == 0)
                    {
                        flag = true;
                    }

                }
                if (flag != true)
                {
                    try
                    {
                        T_Serial objS = new T_Serial(ref Serialfields);
                        elementsSerial.Add(objS);
                        BoxInit(sb, elementsSerial.Count - 1, 300);
                    }
                    catch (FormatException r) { MessageBox.Show(r.Message); }
                    catch (ArgumentException s) { MessageBox.Show(s.Message); }
                }
                else MessageBox.Show("Same data.");
            }
        }
        public void Qsort(string[] fields, int l, int r, bool flag)//метод, реализующий алгоритм «быстрой» сортировки;
        {
            string temp;
            string x = fields[l + (r - l) / 2];
            int i = l;
            int j = r;
            while (i <= j)
            {
                if (flag == false)
                {
                    while (String.Compare(fields[i], x, new CultureInfo(""), CompareOptions.IgnoreCase) < 0) i++;
                    while (String.Compare(fields[j], x, new CultureInfo(""), CompareOptions.IgnoreCase) > 0) j--; //сортировка объектов по возрастанию
                }
                else
                {
                    while (int.Parse(fields[i]) < int.Parse(x)) i++;
                    while (int.Parse(fields[j]) > int.Parse(x)) j--;
                }
                if (i <= j)
                {
                    temp = fields[i];
                    fields[i] = fields[j];
                    fields[j] = temp;
                    i++;
                    j--;
                }
            }
            if (flag == false)
            {
                if (i < r)
                    Qsort(fields, i, r,false);
            }
            else
            {
                if (i < r)
                    Qsort(fields, i, r, true);
            }
            if (flag == false)
            {
                if (l < j)
                    Qsort(fields, l, j,false);
            }
            else
            {
                if (l < j)
                    Qsort(fields, l, j, true);
            }
        }

        private void Qsort_Click(object sender, EventArgs e)//событие, которое выводит в возрастающем порядке определенный поля класса.
        {
            fieldsA = new string[elementsActive.Count];
            fieldsC = new string[elementsCartoon.Count];
            fieldsS = new string[elementsSerial.Count];
            ClearAll(ref tb);
            ClearAll(ref cb);
            ClearAll(ref sb);
            if (QsortBox.Text == "Name") //сортировка поля f_name
            {
                for (int i = 0; i < elementsActive.Count; i++)
                {
                    fieldsA[i] = elementsActive[i].Name;
                }
                Qsort(fieldsA, 0, fieldsA.Length - 1,false);
                for (int i = 0; i < fieldsA.Length; i++)
                {
                    tb[i].Text = fieldsA[i];
                }
                for (int i = 0; i < elementsCartoon.Count; i++)
                {
                    fieldsC[i] = elementsCartoon[i].Name;
                }
                Qsort(fieldsC, 0, fieldsC.Length - 1,false);
                for (int i = 0; i < fieldsC.Length; i++)
                {
                    cb[i].Text = fieldsC[i];
                }

                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Name;
                }
                Qsort(fieldsS, 0, fieldsS.Length - 1, false);
                for (int i = 0; i < fieldsS.Length; i++)
                {
                    sb[i].Text = fieldsS[i];
                }
            }
            if (QsortBox.Text == "Year")//сортировка поля f_year
            {
                for (int i = 0; i < elementsActive.Count; i++)
                {
                    fieldsA[i] = elementsActive[i].Year.ToString();
                }
                Qsort(fieldsA, 0, fieldsA.Length - 1,true);
                for (int i = 0; i < fieldsA.Length; i++)
                {
                    tb[i].Text = fieldsA[i];
                }

                for (int i = 0; i < elementsCartoon.Count; i++)
                {
                    fieldsC[i] = elementsCartoon[i].Year.ToString();
                }
                Qsort(fieldsC, 0, fieldsC.Length - 1,true);
                for (int i = 0; i < fieldsC.Length; i++)
                {
                    cb[i].Text = fieldsC[i];
                }

                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Year.ToString();
                }
                Qsort(fieldsS, 0, fieldsS.Length - 1,true);
                for (int i = 0; i < fieldsS.Length; i++)
                {
                    sb[i].Text = fieldsS[i];
                }
            }
            if (QsortBox.Text == "Time")//сортировка поля f_time
            {
                for (int i = 0; i < elementsActive.Count; i++)
                {
                    fieldsA[i] = elementsActive[i].Time.ToString();
                }
                Qsort(fieldsA, 0, fieldsA.Length - 1,true);
                for (int i = 0; i < fieldsA.Length; i++)
                {
                    tb[i].Text = fieldsA[i];
                }
                for (int i = 0; i < elementsCartoon.Count; i++)
                {
                    fieldsC[i] = elementsCartoon[i].Time.ToString();
                }
                Qsort(fieldsC, 0, fieldsC.Length - 1,true);
                for (int i = 0; i < fieldsC.Length; i++)
                {
                    cb[i].Text = fieldsC[i];
                }

                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Time.ToString();
                }
                Qsort(fieldsS, 0, fieldsS.Length - 1,true);
                for (int i = 0; i < fieldsS.Length; i++)
                {
                    sb[i].Text = fieldsS[i];
                }
            }
            if (QsortBox.Text == "Num_Seasons")//сортировка поля f_num_seasons
            {
                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Num_Seasons.ToString();
                }
                Qsort(fieldsS, 0, fieldsS.Length - 1, true);
                for (int i = 0; i < fieldsS.Length; i++)
                {
                    sb[i].Text = fieldsS[i];
                }
            }
            if (QsortBox.Text == "Num_Series")//сортировка поля f_num_series
            {
                for (int i = 0; i < elementsSerial.Count; i++)
                {
                    fieldsS[i] = elementsSerial[i].Num_series.ToString();
                }
                Qsort(fieldsS, 0, fieldsS.Length - 1, true);
                for (int i = 0; i < fieldsS.Length; i++)
                {
                    sb[i].Text = fieldsS[i];
                }
            }
        }

    }
}
