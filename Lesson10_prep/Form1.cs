using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson10_prep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Showinfo();
            Sum(10.0, 20.0);
            Sum(15, 60);
        }

        [Conditional("DEBUG")]
        public void Showinfo()
        {
            MessageBox.Show("Приложение калькулятор v1.0");
        }


        [Obsolete("уставревший метод - используйте Sum(double, double)", true)]
        private int Sum(int a, int b)
        {
            return a + b;
        }

        private double Sum(double a, double b)
        {
            return a + b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Приложение калькулятор v1.0");



#if TRIAL
            MessageBox.Show("Купите продукт!");
            Random rnd = new Random();
            richTextBox3.Text = (rnd.Next(100, 10000)).ToString();
#else
//#error не дописал проверку на адекватность

            //todo дописать проверку адекватности

            int x = int.Parse(richTextBox1.Text);
            int y = int.Parse(richTextBox2.Text);

            
            richTextBox3.Text = (x + y).ToString();
#endif
        }
    }
}
