using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private delegate void DelegateUpdateText(string message, int i);

        private void OnUpdateText(string message, int i)
        {
            this.textBox1.Text += (message + i + Environment.NewLine);
        }

        private void Work()
        {
            string message = "test ";
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);

                this.textBox1.Invoke(new DelegateUpdateText(OnUpdateText), new object[] { message, i });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            //Taskクラスの引数にActionを指定して生成する
            Task task = new Task(Work);

            //Taskを開始する
            task.Start();
            
            /*
            //これでもOK
            Task task = Task.Run(() => {
                string message = "test ";
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);

                    this.textBox1.Invoke(new DelegateUpdateText(OnUpdateText), new object[] { message, i });
                }
            });
            */
        }
    }
}
