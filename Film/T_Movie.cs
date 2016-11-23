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
        public T_Movie() : base()
        {
            Audio = 0;
            Color = 0;
        }
        public override void Read_File(int number, string name_file)
        {
            string slovo;
            int n = 0;
            using (StreamReader input = new StreamReader(name_file))
            {
                while(true)
                {
                    // Читаем строку из файла во временную переменную.
                    slovo = input.ReadLine();
                    // Если достигнут конец файла, прерываем считывание.
                    if(slovo == null) break;
                    n++;
                    if ((n%10 >= 1) && (n%10 <= 6)) base.Read_File(n,name_file);
                    switch(n%10)
                    {
                        case 7:
                            {
                                Audio=int.Parse(slovo);
                                break;
                            }
                        case 8:
                             {
                                 Color = int.Parse(slovo);
                                 break;
                             }
                    }
                }
            }
        }
    }
}
