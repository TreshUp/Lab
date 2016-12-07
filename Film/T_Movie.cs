using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

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
        //функция считывания из файла
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
                            //считывание поля аудио
                            Audio = int.Parse(stroka.Substring(0, stroka.IndexOf(' ')));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);
                            //считывание поля цвет
                            Color = int.Parse(stroka.Substring(0, stroka.IndexOf(' ')));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);
                            //считывание жанра фильма
                            Category = stroka;
                            if (Category.IndexOf("_") != -1) Category = Category.Replace("_", " ");
                            //вызываем функция считывания из файла предка
                            base.Read_File(number-1, name_file);
                    }
                }
            }
        }
        //функция сортировки фильмов по жанру
        public bool Sort_Cat(string cat)
        {
            //string check="";
            ////проверка на " " в конце строки
            //if (this.Category.LastIndexOf(" ") == this.Category.Length - 1)
            //{
            //    check = this.Category.Substring(0, this.Category.IndexOf(' '));
            //}
            ////сравнения двух строк
            if (String.Compare(this.Category, cat, new CultureInfo(""), CompareOptions.IgnoreCase) == 0) return true;
            else return false;
        }
        public override void Show_All_Info (ref string[] fields)
        {
            base.Show_All_Info(ref fields);
            if (Audio == 1) fields[6] = "Со звуком";
            else fields[6] = "Без звука";
            if (Color == 1) fields[7] = "Цветной";
            else fields[7] = "Черно-белый";
            fields[8] = this.Category;
        }
    }
}
