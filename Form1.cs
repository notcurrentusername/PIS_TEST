using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L4VP
{
    public partial class Form1 : Form
    {
        GenericLIFO<int> stInt = new GenericLIFO<int>();
        GenericLIFO<char> stChar = new GenericLIFO<char>();
        GenericLIFO<double> stDouble = new GenericLIFO<double>();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            string hoursText = textBox1.Text;
            string minutesText = textBox4.Text;
            string secondsText = textBox5.Text;
            Stack<ListItem<TimeSpan>> stack = new Stack<ListItem<TimeSpan>>();

            // Преобразовываем значения в тип TimeSpan
            TimeSpan time = new TimeSpan(int.Parse(hoursText), int.Parse(minutesText), int.Parse(secondsText));
            ListItem<TimeSpan> newItem = new ListItem<TimeSpan>(time);

            // Добавляем новый элемент в стек
            stack.Push(newItem);
            textBox3.Text = time;
            if (radioButton1.Checked)
            {
                int el = Convert.ToInt32(textBox1.Text);
                stInt.Push(el);
                textBox3.Text = stInt.Length.ToString();
            }
            else if (radioButton2.Checked)
            {
                double el = Convert.ToDouble(textBox1.Text);
                stDouble.Push(el);
                textBox3.Text = stDouble.Length.ToString();
            }
            else if (radioButton3.Checked) 
            {
                char el = textBox1.Text[0];
                stChar.Push(el);
                textBox3.Text = stChar.Length.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                
                int numel = Convert.ToInt32(numericUpDown1.Value);
                int len = stInt.Length;

                if (numel <= len && numel > 0)
                {
                    int el = stInt.Get(numel);

                    textBox2.Text = el.ToString();
                }
                else MessageBox.Show("Элемента с таким номером нет", "error");
            } else if (radioButton2.Checked)
            {
                int numel = Convert.ToInt32(numericUpDown1.Value);
                int len = stDouble.Length;

                if (numel <= len && numel >0)
                {
                    double el = stDouble.Get(numel);

                    textBox2.Text = el.ToString();
                }
                else MessageBox.Show("Элемента с таким номером нет", "error");
            } else if (radioButton3.Checked)
            {
                int numel = Convert.ToInt32(numericUpDown1.Value);
                int len = stChar.Length;

                if (numel <= len && numel > 0)
                {
                    char el = stChar.Get(numel);

                    textBox2.Text = el.ToString();
                }
                else MessageBox.Show("Элемента с таким номером нет", "error");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <0)
            {
                numericUpDown1.Value = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                stInt.Pop();
                textBox3.Text = stInt.Length.ToString();
            }
            else if (radioButton2.Checked)
            {
                stDouble.Pop();
                textBox3.Text = stDouble.Length.ToString();
            }
            else if (radioButton3.Checked)
            {
                stChar.Pop();
                textBox3.Text = stChar.Length.ToString();
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            if (radioButton1.Checked)
            {
                textBox3.Text = stInt.Length.ToString();
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            if (radioButton2.Checked)
            {
                textBox3.Text = stDouble.Length.ToString();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            if (radioButton3.Checked)
            {

                textBox3.Text = stChar.Length.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (radioButton1.Checked)
            {
                
                for (int i = 0; i < stInt.Length; i++)
                    listBox1.Items.Insert(i, stInt.Get(i + 1).ToString());
            }
            else if (radioButton2.Checked)
            {
                
                for (int i = 0; i < stDouble.Length; i++)
                    listBox1.Items.Insert(i, stDouble.Get(i + 1).ToString());
            }
            else if (radioButton3.Checked) 
            {
                
                for (int i = 0; i < stChar.Length; i++)
                    listBox1.Items.Insert(i, stChar.Get(i + 1).ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string helpstr = "";

                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if ((textBox1.Text[i] >= '0') && (textBox1.Text[i] <= '9') /*|| textBox1.Text[i] == ','*/)
                    {
                        helpstr += textBox1.Text[i];
                    }
                }
                textBox1.Text = helpstr;
            } else if (radioButton2.Checked)
            {
                string helpstr = "";

                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if ((textBox1.Text[i] >= '0') && (textBox1.Text[i] <= '9') || textBox1.Text[i] == ',')
                    {
                        helpstr += textBox1.Text[i];
                    }
                }
                textBox1.Text = helpstr;
            } else if (radioButton3.Checked)
            {
                if (textBox1.Text.Length > 1)
                {
                    textBox1.Text = textBox1.Text[textBox1.Text.Length - 1].ToString();
                }
            }
        }
    }
}
