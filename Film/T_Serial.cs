using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Film
{
    class T_Serial : T_Abs_Film //todo
    {
        protected int f_num_series;
        protected int f_num_seasons;
        protected string f_operator;//todo same name
        public int Num_series
        {
            get
            {
                return f_num_series;
            }
            set
            {
                f_num_series = value;
            }
        }
        public int Num_Seasons
        {
            get
            {
                return f_num_seasons;
            }
            set
            {
                f_num_seasons = value;
            }
        }
        public string Operator
        {
            get
            {
                return f_operator;
            }
            set
            {
                f_operator = value;
            }
        }
        public T_Serial() : base()
        {
            Num_series = 1;
            Num_Seasons = 1;
            Operator = "null";
        }
        public override void Read_File(int number, string name_file)
        {
            using (StreamReader input = new StreamReader((@"G:\inputS.txt"),System.Text.Encoding.Default)) //todo_path
            {
                int n = 0;
                string stroka;
                name_file = @"G:\inputS.txt"; //todo_path
                while (true)
                {
                    // Читаем строку из файла во временную переменную.
                    stroka = input.ReadLine();
                    // Если достигнут конец файла, прерываем считывание.
                    if (stroka == null) break;
                    n++;
                    if (n % 3 == 1) base.Read_File(n, name_file);
                    if (n % 3 == 2)
                    {
                        Num_series = int.Parse(stroka.Substring(0, stroka.IndexOf(' ')));
                        stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                        Num_Seasons = int.Parse(stroka.Substring(0, stroka.IndexOf(' ')));
                        stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                        Operator = stroka;
                    }
                }
            }
        }
    }
}
