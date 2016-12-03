using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Film
{
    class T_Action_Movie : T_Movie //todo
    {
        //protected string f_category;
        protected string f_operator;
        protected string f_composer;
        protected string f_artist1;
        protected string f_artist2;
        protected string f_artist3;
        //todo get artist
        public string Arist1
        {
            get
            {
                return f_artist1;
            }
            set
            {
                f_artist1 = value;
            }
        }
        public string Arist2
        {
            get
            {
                return f_artist2;
            }
            set
            {
                f_artist1 = value;
            }
        }
        public string Arist3
        {
            get
            {
                return f_artist3;
            }
            set
            {
                f_artist1 = value;
            }
        }
        //public string Category
        //{
        //    get
        //    {
        //        return f_category;
        //    }
        //    set
        //    {
        //        f_category = value;
        //    }
        //}
        public string Operator
        {
            get
            {
                return f_operator;
            }
            set
            {
                f_operator=value;
            }
        }
        public string Composer
        {
            get
            {
                return f_composer;
            }
            set
            {
                f_composer = value;
            }
        }
        public T_Action_Movie() : base()
        {
            //Category = "null";
            Operator = "null";
            Composer = "null";
            f_artist1 = "null";
            f_artist2 = "null";
            f_artist3 = "null";

        }
        public override void Read_File(int number, string name_file)
        {
            string stroka;
            //todo excepiton
            using (StreamReader input = new StreamReader((@"H:\inputA.txt"),System.Text.Encoding.Default)) //to_path
            {
                int n = 0;
                name_file = @"H:\inputA.txt"; //to_path
                while(true)
                {
                    // Читаем строку из файла во временную переменную.
                    stroka = input.ReadLine();
                    // Если достигнут конец файла, прерываем считывание.
                    if(stroka == null) break;
                    n++;
                    if (n == (number+2))
                    {
                        /*if (n % 3 == 1)*/ base.Read_File(number+1, name_file);
                        /*if (n % 3 == 2) base.Read_File(n, name_file);*/
                        //if (n % 3 == 0)
                        ///{
                            //Category = stroka.Substring(0, stroka.IndexOf(' '));
                            //stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                            Operator = stroka.Substring(0, stroka.IndexOf(' '));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                            Composer = stroka.Substring(0, stroka.IndexOf(' '));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                            f_artist1 = stroka.Substring(0, stroka.IndexOf(' '));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);
                            f_artist2 = stroka.Substring(0, stroka.IndexOf(' '));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);
                            f_artist3 = stroka;
                        //}
                    }
                    //break;
                }
            }
        }
    }
}
