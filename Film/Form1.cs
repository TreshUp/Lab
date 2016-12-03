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
        //IList<T_Abs_Film> elements = new List<T_Abs_Film>();
        IList<T_Action_Movie> elementsActive = new List<T_Action_Movie>();
        IList<T_Cartoon> elementsCartoon = new List<T_Cartoon>();
        private void Form1_Load(object sender, EventArgs e)
        {
           for(int i=1;i<5;i+=3) //todo nomer
            {
                T_Action_Movie objA = new T_Action_Movie();
                T_Cartoon objC = new T_Cartoon(); 
                objA.Read_File(i, "out");
                elementsActive.Add(objA);
                objC.Read_File(i, "out");
                elementsCartoon.Add(objC);
            }
        }

        private void Show_Active_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 3; i++)//todo nomer
            {
                TextBox Tb = new TextBox();
                Tb.Location = new Point(10, i * (Tb.Height + 10));
                Tb.Text = elementsActive[i-1].Name;
                this.Controls.Add(Tb);
            }
        }

        private void ShowCartoons_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 3; i++)//todo nomer
            {
                TextBox Tb = new TextBox();
                Tb.Location = new Point(200, i * (Tb.Height + 10));
                Tb.Text = elementsCartoon[i - 1].Name;
                this.Controls.Add(Tb);
            }
        }
    }
}
