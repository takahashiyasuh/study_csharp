using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimersTimer
{
    public partial class Form1 : Form
    {
        private delegate void DelegateCountUp();

        private void CountUp()
        {
            num++;
            this.label1.Text = num.ToString();
        }

        System.Timers.Timer m_tim = null;

        int num = 0;

        public Form1()
        {
            InitializeComponent();

            m_tim = new System.Timers.Timer(1000);
            m_tim.Elapsed += M_tim_Elapsed;
        }

        private void M_tim_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.label1.Invoke(new DelegateCountUp(CountUp));

            /*
            this.label1.Invoke((MethodInvoker)delegate() {
                num++;
                this.label1.Text = num.ToString();
            });

            //ラムダ式をさらに進めるとこんな感じでも書ける
            this.label1.Invoke((MethodInvoker)(() => {
                num++;
                this.label1.Text = num.ToString();
            }));
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //開始
            m_tim.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //停止
            m_tim.Stop();
        }
    }
}
