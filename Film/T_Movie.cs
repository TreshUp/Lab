using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Film
{
    class T_Movie :  T_Abs_Film //todo protected
    {
        protected int f_audio; // "1" - have sound "0" - no sound
        protected int f_color; // "1" - colored "0" - black and white
        protected string f_category;
        public int Audio
        {
            get
            {
                return f_audio;
            }
            set
            {
                f_audio = value;
            }
        }
        public int Color //todo exceptions
        {
            get
            {
                return f_color;
            }
            set
            {
                f_color=value;
            }
        }
        public string Category
        {
            get
            {
                return f_category;
            }
            set
            {
                f_category = value;
            }
        }
        public T_Movie() : base()
        {
            Audio = 1;
            Color = 1;
            Category = "null";
        }
        public override void Read_File(int number, string name_file)
        {
            string stroka;
            int n = 0;
            using (StreamReader input = new StreamReader((name_file),System.Text.Encoding.Default))
            {
                while(true)
                {
                    // Читаем строку из файла во временную переменную.
                    stroka = input.ReadLine();
                    // Если достигнут конец файла, прерываем считывание.
                    if(stroka == null) break;
                    n++;
                    if (n==number)
                    {
                       // if (n % 3 == 2)
                        //{
                            Audio = int.Parse(stroka.Substring(0, stroka.IndexOf(' ')));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                            Color = int.Parse(stroka.Substring(0, stroka.IndexOf(' ')));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                            Category = stroka;
                            
                        //}
                        /*if (n % 3 == 1)*/ { base.Read_File(number-1, name_file); }
                    }
                }
            }
        }
    }
}
