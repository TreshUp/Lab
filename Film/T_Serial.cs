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
        public int Num_Seasans
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
            Num_Seasans = 1;
            Operator = "null";
        }
        public override void Read_File(int number, string name_file)
        {
            using (StreamReader input = new StreamReader(@"D:\inputS.txt"))
            {
                int n = 0;
                string slovo;
                name_file = @"D:\inputS.txt";
                while (true)
                {
                    // Читаем строку из файла во временную переменную.
                    slovo = input.ReadLine();
                    // Если достигнут конец файла, прерываем считывание.
                    if (slovo == null) break;
                    n++;
                    if ((n % 10 >= 1) && (n % 10 <= 6)) base.Read_File(n, name_file);
                    switch (n % 10)
                    {
                        case 7:
                            {
                                Num_series = int.Parse(slovo);
                                break;
                            }
                        case 8:
                            {
                                Num_Seasans = int.Parse(slovo);
                                break;
                            }
                        case 9:
                            {
                                Operator = slovo;
                                break;
                            }
                    }
                }
            }
        }
    }
}
