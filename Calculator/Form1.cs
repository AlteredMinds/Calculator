using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public List<double> inputs = new List<double>();
        public List<string> operatons = new List<string>();
        public double result;
        public double input;
        public double left;
        public double right;
        public string prevop;
        public int step = 0;
        public double total;
        public bool firstInput = true;
        public bool answered = false;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        public void doMath()
        {
            for (var i = 0; i < operatons.Count; i++)
            {
                if (firstInput)
                {
                    left = inputs[step];
                    firstInput = false;
                    step++;
                }
                else
                    left = total;

                right = inputs[step];
                if (operatons[i] == "+")
                {
                    result = left + right;
                    total = result;
                }
                if (operatons[i] == "-")
                {
                    result = left - right;
                    total = result;
                }
                if (operatons[i] == "*")
                {
                    result = left * right;
                    total = result;
                }
                if (operatons[i] == "/")
                {
                    result = left / right;
                    total = result;
                }
                step++;
            }
            updateDisplay(total.ToString());
            operatons.Clear();
            inputs.Clear();
            firstInput = true;
            step = 0;
            answered = true;
        }

        public void updateDisplay(string num, bool goback = false, bool clear = false, bool add_decimal = false, bool switchplace = false)
        {
            if (clear)
            {
                display.Text = "";
                display2.Text = "";
            }
            else if (goback)
                display.Text = display.Text.Remove(display.Text.Length - 1, 1);
            else if (add_decimal)
                display.Text = display.Text + ".";
            else if (switchplace)
            {
                double reverse = double.Parse(display.Text) * -1;
                display.Text = reverse.ToString();
            }
            else if (display.Text.Length <= 33)
                display.Text += num;
            scaleUI();
        }

        public void scaleUI()
        {
            int strLength2 = display2.Text.Length;
            if (strLength2 > 35)
            {
                Font Font = new Font("Microsoft Sans Serif", 8);
                display2.Font = Font;
            }
            else if (strLength2 > 25)
            {
                Font Font = new Font("Microsoft Sans Serif", 12);
                display2.Font = Font;
            }
            else if (strLength2 > 15)
            {
                Font Font = new Font("Microsoft Sans Serif", 18);
                display2.Font = Font;
            }
            else
            {
                Font Font = new Font("Microsoft Sans Serif", 24);
                display2.Font = Font;
            }

            int strLength = display.Text.Length;
            if (strLength > 20)
            {
                Font Font = new Font("Microsoft Sans Serif", 12);
                display.Font = Font;
            }
            else if (strLength > 16)
            {
                Font Font = new Font("Microsoft Sans Serif", 20);
                display.Font = Font;
            }
            else if (strLength > 13)
            {
                Font Font = new Font("Microsoft Sans Serif", 20);
                display.Font = Font;
            }
            else if (strLength > 8)
            {
                Font Font = new Font("Microsoft Sans Serif", 30);
                display.Font = Font;
            }
            else
            {
                Font Font = new Font("Microsoft Sans Serif", 48);
                display.Font = Font;
            }
        }

        private void button00_Click(object sender, EventArgs e)
        {
            input = 0;
            updateDisplay(input.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            input = 1;
            updateDisplay(input.ToString());
        }

        private void button02_Click(object sender, EventArgs e)
        {
            input = 2;
            updateDisplay(input.ToString());
        }

        private void button03_Click(object sender, EventArgs e)
        {
            input = 3;
            updateDisplay(input.ToString());
        }

        private void button04_Click(object sender, EventArgs e)
        {
            input = 4;
            updateDisplay(input.ToString());
        }

        private void button05_Click(object sender, EventArgs e)
        {
            input = 5;
            updateDisplay(input.ToString());
        }

        private void button06_Click(object sender, EventArgs e)
        {
            input = 6;
            updateDisplay(input.ToString());
        }

        private void button07_Click(object sender, EventArgs e)
        {
            input = 7;
            updateDisplay(input.ToString());
        }

        private void button08_Click(object sender, EventArgs e)
        {
            input = 8;
            updateDisplay(input.ToString());
        }

        private void button09_Click(object sender, EventArgs e)
        {
            input = 9;
            updateDisplay(input.ToString());
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (display.Text != "")
            {
                updateDisplay(0.ToString(), true);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            firstInput = true;
            answered = false;
            updateDisplay(0.ToString(), false, true);
            inputs.Clear();
            operatons.Clear();
            result = 0;
            step = 0;
            total = 0;
        }

        private void button_dec_Click(object sender, EventArgs e)
        {
            if (display.Text != "")
            {
                updateDisplay(0.ToString(), false, false, true);
            }
        }

        private void button_neg_Click(object sender, EventArgs e)
        {
            if (display.Text != "")
            {
                updateDisplay(0.ToString(), false, false, false, true);
            }
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            if (display.Text != "")
            {
                inputs.Add(double.Parse(display.Text));
                operatons.Add("+");
                if (inputs.Count > 1)
                    display2.Text = display2.Text += prevop + display.Text;
                else if (answered)
                {
                    display2.Text = display2.Text;
                    answered = false;
                }
                else
                    display2.Text = display2.Text += "" + display.Text;
                display.Text = "";
                prevop = "+";
            }
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            if (display.Text != "" && !answered)
            {
                inputs.Add(double.Parse(display.Text));
                display2.Text = display2.Text += prevop + display.Text;
                display.Text = "";
                doMath();
            }
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            if (display.Text != "")
            {
                inputs.Add(double.Parse(display.Text));
                operatons.Add("-");
                if (inputs.Count > 1)
                    display2.Text = display2.Text += prevop + display.Text;
                else if (answered)
                {
                    display2.Text = display2.Text;
                    answered = false;
                }
                else
                    display2.Text = display2.Text += "" + display.Text;
                display.Text = "";
                prevop = "-";
            }
        }

        private void button_multi_Click(object sender, EventArgs e)
        {
            if (display.Text != "")
            {
                inputs.Add(double.Parse(display.Text));
                operatons.Add("*");
                if (inputs.Count > 1)
                    display2.Text = display2.Text += prevop + display.Text;
                else if (answered)
                {
                    display2.Text = display2.Text;
                    answered = false;
                }
                else
                    display2.Text = display2.Text += "" + display.Text;
                display.Text = "";
                prevop = "*";
            }
        }

        private void button_divide_Click(object sender, EventArgs e)
        {
            if (display.Text != "")
            {
                inputs.Add(double.Parse(display.Text));
                operatons.Add("/");
                if (inputs.Count > 1)
                    display2.Text = display2.Text += prevop + display.Text;
                else if (answered)
                {
                    display2.Text = display2.Text;
                    answered = false;
                }
                else
                    display2.Text = display2.Text += "" + display.Text;
                display.Text = "";
                prevop = "/";
            }
        }

        private void buttonSqr_Click(object sender, EventArgs e)
        {
            if (display.Text != "" && display.Text.Length <= 50)
            {
                double x = double.Parse(display.Text);
                double y = x * x;
                display2.Text = x.ToString() + "\u00b2";
                display.Text = y.ToString();
                scaleUI();
                answered = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    button00_Click(sender, e);
                    break;
                case Keys.D0:
                    button00_Click(sender, e);
                    break;
                case Keys.NumPad1:
                    button12_Click(sender, e);
                    break;
                case Keys.D1:
                    button12_Click(sender, e);
                    break;
                case Keys.NumPad2:
                    button02_Click(sender, e);
                    break;
                case Keys.D2:
                    button02_Click(sender, e);
                    break;
                case Keys.NumPad3:
                    button03_Click(sender, e);
                    break;
                case Keys.D3:
                    button03_Click(sender, e);
                    break;
                case Keys.NumPad4:
                    button04_Click(sender, e);
                    break;
                case Keys.D4:
                    button04_Click(sender, e);
                    break;
                case Keys.NumPad5:
                    button05_Click(sender, e);
                    break;
                case Keys.D5:
                    button05_Click(sender, e);
                    break;
                case Keys.NumPad6:
                    button06_Click(sender, e);
                    break;
                case Keys.D6:
                    button06_Click(sender, e);
                    break;
                case Keys.NumPad7:
                    button07_Click(sender, e);
                    break;
                case Keys.D7:
                    button07_Click(sender, e);
                    break;
                case Keys.NumPad8:
                    button08_Click(sender, e);
                    break;
                case Keys.D8:
                    button08_Click(sender, e);
                    break;
                case Keys.NumPad9:
                    button09_Click(sender, e);
                    break;
                case Keys.D9:
                    button09_Click(sender, e);
                    break;
                case Keys.Decimal:
                    button_dec_Click(sender, e);
                    break;
                case Keys.OemPeriod:
                    button_dec_Click(sender, e);
                    break;
                case Keys.Back:
                    back_Click(sender, e);
                    break;
                case Keys.Oemplus:
                    button_plus_Click(sender, e);
                    break;
                case Keys.Add:
                    button_plus_Click(sender, e);
                    break;
                case Keys.Subtract:
                    button_minus_Click(sender, e);
                    break;
                case Keys.OemMinus:
                    button_minus_Click(sender, e);
                    break;
                case Keys.Multiply:
                    button_multi_Click(sender, e);
                    break;
                case Keys.Divide:
                    button_divide_Click(sender, e);
                    break;
                case Keys.Delete:
                    button_clear_Click(sender, e);
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                inputs.Add(double.Parse(display.Text));
                display2.Text = display2.Text += prevop + display.Text;
                display.Text = "";
                doMath();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void helloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            MessageBox.Show("Created by AlteredMinds");
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
