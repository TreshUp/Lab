using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Film
{
    abstract public class T_Abs_Film //todo vidimost
    {
        protected string f_name;
        protected int f_time;
        protected int f_year;
        protected string f_director;
        protected string f_producer;
        protected string f_scenarist;
        //todo polya vidimosti
        public virtual string Name
        {
            get
            {
                return f_name;
            }
            set
            {
                f_name = value;
            }
        }
        public virtual int Time
        {
            get
            {
                return f_time;
            }
            set
            {
                f_time = value;
            }
        }
        public virtual int Year
        {
            get
            {
                return f_year;
            }
            set
            {
                f_year = value;
            }
        }
        public virtual string Director
        {
            get
            {
                return f_director;
            }
            set
            {
                f_director = value;
            }
        }
        public virtual string Producer
        {
            get
            {
                return f_producer;
            }
            set
            {
                f_producer = value;
            }
        }
        public virtual string Scenarist
        {
            get
            {
                return f_scenarist;
            }
            set
            {
                f_scenarist = value;
            }
        }
        public T_Abs_Film()
        {
            Name = "new_film";
            Time = 1;
            Year = 1000;
            Director = "null";
            Producer = "null";
            Scenarist = "null";
        }
        public virtual void Read_File(int number,string name_file)
        {
            using (StreamReader input = new StreamReader((name_file),System.Text.Encoding.Default))
            {
                string stroka;
                int n = 0;
                while (true)
                {
                    // Читаем строку из файла во временную переменную.
                    stroka = input.ReadLine();
                    // Если достигнут конец файла, прерываем считывание.
                    if (stroka == null) break;
                    n++;
                    if (n==number)
                    {
                        Name = stroka.Substring(0, stroka.IndexOf(' '));
                        stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                        Year = int.Parse(stroka.Substring(0, stroka.IndexOf(' ')));
                        stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                        Time = int.Parse(stroka.Substring(0, stroka.IndexOf(' ')));
                        stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                        Director = stroka.Substring(0, stroka.IndexOf(' '));
                        stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                        Producer = stroka.Substring(0, stroka.IndexOf(' '));
                        stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                        Scenarist = stroka;
                    }
                }
            }
        }
        public bool Sort_year(int year)
        {
            if (this.Year == year) return true;
            else return false;
        }
    }
}
