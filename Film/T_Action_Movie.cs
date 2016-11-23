using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Film
{
    class T_Action_Movie : T_Full_Movie //todo
    {
        protected string f_category;
        protected string f_operator;
        protected string f_composer;
        protected string f_artist1;
        protected string f_artist2;
        protected string f_artist3;
        //todo get artist
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
            Category = "null";
            Operator = "null";
            Composer = "null";
            f_artist1 = "null";
            f_artist2 = "null";
            f_artist3 = "null";

        }
        public override void Read_File(int number, string name_file)
        {
            string slovo;
            //todo excepiton
            using (StreamReader input = new StreamReader(@"D:\inputA.txt"))
            {
                int n = 0;
                name_file = @"D:\input.txt";
                while(true)
                {
                    // Читаем строку из файла во временную переменную.
                    slovo = input.ReadLine();
                    // Если достигнут конец файла, прерываем считывание.
                    if(slovo == null) break;
                    n++;
                    //if ((n%10 >= 1) && (n%10 <= 8)) base.Read_File(n,name_file);
                    //switch(n%10)
                    //{
                    //    case 9:
                    //        {
                    //            Category = slovo;
                    //            break;
                    //        }
                    //    case 0:
                    //        {
                    //            Operator = slovo;
                    //            break;
                    //        }
                    //    case 1:
                    //        {
                    //            Composer = slovo;
                    //            break;
                    //        }
                    //    case 2:
                    //        {
                    //            f_artist1 = slovo;
                    //            break;
                    //        }
                    //    case 3:
                    //        {
                    //            f_artist2 = slovo;
                    //            break;
                    //        }
                    //    case 4:
                    //        {
                    //            f_artist3 = slovo;
                    //            break;
                    //        }
                    //}
                }
            }
        }
    }
}
