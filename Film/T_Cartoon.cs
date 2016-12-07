using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Film
{
    class T_Cartoon: T_Movie//todo
    {
        //todo
        protected string f_painter;
        public T_Cartoon() :base()
        {
            Painter = "null";
        }
        public T_Cartoon(ref string[] c_obj) : base(ref c_obj)
        {
            Painter = c_obj[9];
        }
        public string Painter
        {
            get
            {
                return f_painter;
            }
            set
            {
                f_painter = value;
            }
        }
        public override void Read_File(int number, string name_file)
        {
            string stroka;
            //todo excepiton
            using (StreamReader input = new StreamReader((@"D:\inputC.txt"),System.Text.Encoding.Default)) //to_path
            {
                int n = 0;
                name_file = @"D:\inputC.txt"; //to_path
                while (true)
                {
                    // Читаем строку из файла во временную переменную.
                    stroka = input.ReadLine();
                    // Если достигнут конец файла, прерываем считывание.
                    if (stroka == null) break;
                    n++;
                    if (n == number+2)
                    {
                        base.Read_File(number+1, name_file);
                        {
                            Painter = stroka;
                            if (Painter.IndexOf("_") != -1) Painter = Painter.Replace("_", " ");
                        }
                    }
                }
            }
        }
        public override void Show_All_Info(ref string[] fields)
        {
            base.Show_All_Info(ref fields);
            fields[14] = this.Painter;
        }
    }
}
