﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Film
{
    class T_Action_Movie : T_Movie //todo
    {
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
            Operator = "null";
            Composer = "null";
            Arist1 = "null";
            Arist2 = "null";
            Arist3 = "null";

        }
        public T_Action_Movie(ref string[] c_obj) : base(ref c_obj)
        {
            Operator = c_obj[9];
            Composer = c_obj[10];
            Arist1 = c_obj[11];
            Arist2 = c_obj[12];
            Arist3 = c_obj[13];
        }
        public override void Read_File(int number, string name_file)
        {
            string stroka;
            //todo excepiton
            using (StreamReader input = new StreamReader((@"D:\inputA.txt"),System.Text.Encoding.Default)) //to_path
            {
                int n = 0;
                name_file = @"D:\inputA.txt"; //to_path
                while(true)
                {
                    // Читаем строку из файла во временную переменную.
                    stroka = input.ReadLine();
                    // Если достигнут конец файла, прерываем считывание.
                    if(stroka == null) break;
                    n++;
                    if (n == (number+2))
                    {
                            base.Read_File(number+1, name_file);

                            //считывания поля оператор
                            Operator = stroka.Substring(0, stroka.IndexOf(' '));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);
                            if (Operator.IndexOf("_") != -1) Operator = Operator.Replace("_", " ");

                            //считвание поля композитор
                            Composer = stroka.Substring(0, stroka.IndexOf(' '));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);
                            if (Composer.IndexOf("_") != -1) Composer = Composer.Replace("_", " ");

                            //считывания полей актеры
                            f_artist1 = stroka.Substring(0, stroka.IndexOf(' '));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);
                            if (f_artist1.IndexOf("_") != -1) f_artist1 = f_artist1.Replace("_", " ");

                            f_artist2 = stroka.Substring(0, stroka.IndexOf(' '));
                            stroka = stroka.Remove(0, stroka.IndexOf(' ') + 1);

                            if (f_artist2.IndexOf("_") != -1) f_artist2 = f_artist2.Replace("_", " ");
                            f_artist3 = stroka;
                            if (f_artist3.IndexOf("_") != -1) f_artist3 = f_artist3.Replace("_", " ");
                    }
                }
            }
        }
        public override void Show_All_Info(ref string[] fields)
        {
            base.Show_All_Info(ref fields);
            fields[9] = this.Operator;
            fields[10] = this.Composer;
            fields[11] = this.Arist1;
            fields[12] = this.Arist2;
            fields[13] = this.Arist3;
        }
    }
}
