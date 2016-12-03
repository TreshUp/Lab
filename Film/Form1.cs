using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Film
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IList<T_Abs_Film> elements = new List<T_Abs_Film>();
        private void Form1_Load(object sender, EventArgs e)
        {
            //T_Action_Movie my_test = new T_Action_Movie();
            //T_Action_Movie my_ch = new T_Action_Movie();
            T_Cartoon my_test = new T_Cartoon();
            T_Cartoon my_ch = new T_Cartoon();
            my_test.Read_File(1, "input");
            textBox1.Text = my_test.Name;
            textBox2.Text = my_test.Year.ToString();
            textBox3.Text = my_test.Time.ToString();
            textBox4.Text = my_test.Director;
            textBox6.Text = my_test.Scenarist;
            textBox5.Text = my_test.Producer;
            textBox7.Text = my_test.Audio.ToString();
            textBox8.Text = my_test.Color.ToString();
            textBox9.Text = my_test.Category;
            textBox21.Text = my_test.Painter;
            //textBox10.Text = my_test.Painter;

            my_ch.Read_File(4, "input");
            textBox11.Text = my_ch.Name;
            textBox12.Text = my_ch.Year.ToString();
            textBox13.Text = my_ch.Time.ToString();
            textBox14.Text = my_ch.Director;
            textBox16.Text = my_ch.Scenarist;
            textBox15.Text = my_ch.Producer;
            textBox17.Text = my_ch.Audio.ToString();
            textBox18.Text = my_ch.Color.ToString();
            textBox19.Text = my_ch.Category;
            textBox20.Text = my_ch.Painter;

            //textBox12.Text = my_test.Arist1;
            //textBox10.Text = my_test.Operator;
            //textBox11.Text = my_test.Composer;
            //textBox13.Text = my_test.Arist2;
            //textBox14.Text = my_test.Arist3;
        }
    }
}
