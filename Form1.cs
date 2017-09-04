using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
LIST OF OPERATION
 * + --> 1
 * - --> 2
 * * --> 3
 * / --> 4
 * x^y --> 5
 * x^2 --> 6
 * sqrt --> 7
 * 1/x --> 8
 * % --> 9
 * n! --> 10
 * x^3 --> 11
 * sin --> 12
 * cos --> 13
 * tan --> 14
 * ln --> 15
 * log10 --> 16
 * exp --> 17
 * asin --> 18
 * acos --> 19
 * atan --> 20
 * NULL --> 0
*/
namespace Calculator_CS
{
    public partial class Form1 : Form
    {
        bool call_operation = false;
        bool res_is_empty = true;
        bool op_is_empty = true;
        short op = 0;
        bool is_grad = true;

        double operand;
        double result;

        bool memory_is_empty = true;
        double memory;

        bool isMouseDown;
        private Point dragStartPoint = new Point(); 

        public Form1()
        {
            InitializeComponent();
        }

        void unary_operation(string a, short b)
        {
            operand = Convert.ToDouble(maintext.Text);
            secondtext.Text = a;
            if (res_is_empty)
            {
                result = operand;
                res_is_empty = false;
                op_is_empty = true;
                listBoxOp.Items.Add(Convert.ToString(result));
            }
            else
            {
                if (!op_is_empty)
                {
                    solution();
                    op_is_empty = true;
                }
            }
            op = b;
            solution();
            call_operation = true;
        }

        void binary_operation(string a, short b)
        {
            operand = Convert.ToDouble(maintext.Text);
            secondtext.Text = a;
            if (res_is_empty)
            {
                result = operand;
                res_is_empty = false;
                op_is_empty = true;
                listBoxOp.Items.Add(Convert.ToString(result));
            }
            else
            {
                if (!op_is_empty)
                {
                    solution();
                    op_is_empty = true;
                }
            }
            op = b;
            call_operation = true;
        }

        void solution()
        { 
            switch (op)
            {
                case 1: 
                    result += operand;
                    listBoxOp.Items.Add("+ " + Convert.ToString(operand));
                    break;
                case 2: 
                    result -= operand;
                    listBoxOp.Items.Add("- " + Convert.ToString(operand));
                    break;
                case 3: 
                    result *= operand;
                    listBoxOp.Items.Add("* " + Convert.ToString(operand));
                    break;
                case 4:
                    listBoxOp.Items.Add("/ " + Convert.ToString(operand));
                    if (operand == 0) MessageBox.Show("Ділення на нуль неможливе!","Помилка");
                    else result /= operand; 
                    break;
                case 5:
                    result = Math.Pow(result, operand);
                    listBoxOp.Items.Add("^ " + Convert.ToString(operand));
                    break;
                case 6:
                    listBoxOp.Items.Add(Convert.ToString(result) + "^2");
                    result *= result;
                    break;
                case 7:
                    if (result >= 0)
                    {
                        listBoxOp.Items.Add("sqrt(" + Convert.ToString(result) + ")");
                        result = Math.Sqrt(result);
                    }
                    else MessageBox.Show("Кореня від від'ємного числа не існує!", "Помилка");
                    break;
                case 8:
                    if (result != 0)
                    {
                        listBoxOp.Items.Add("1/" + Convert.ToString(result));
                        result = 1/result;
                    }
                    else MessageBox.Show("Ділення на нуль неможливе!", "Помилка");
                    break;
                case 9:
                    listBoxOp.Items.Add(Convert.ToString(operand)+ "% (" + Convert.ToString(result) + ")");
                    operand /= 100;
                    result *= operand;
                    break;
                case 10:
                    listBoxOp.Items.Add(Convert.ToString(result) + "!");
                    if (result >= 0)
                    {
                        if (result == 0 || result == 1) result = 1;
                        else
                        {
                            int i, res = 1;
                            for (i = 1; i <= result; i++)
                            {
                                res *= i;
                            }
                            result = res;
                        }
                    }
                    else MessageBox.Show("Факторіалу від від'ємного числа не існує!", "Помилка");
                    break;
                case 11:
                    listBoxOp.Items.Add(Convert.ToString(result) + "^3");
                    result *= result * result;
                    break;
                case 12:
                    listBoxOp.Items.Add("sin(" + Convert.ToString(result) + ")");
                    if (is_grad)
                    {
                        result = Math.PI / 180 * result;
                        result = Math.Sin(result);
                    }
                    else result = Math.Sin(result);
                    break;
                case 13:
                    listBoxOp.Items.Add("cos(" + Convert.ToString(result) + ")");
                    if (is_grad)
                    {
                        result = Math.PI / 180 * result;
                        result = Math.Cos(result);
                    }
                    else result = Math.Cos(result);
                    break;
                case 14:
                    listBoxOp.Items.Add("tan(" + Convert.ToString(result) + ")");
                    if (is_grad)
                    {
                        result = Math.PI / 180 * result;
                        result = Math.Tan(result);
                    }
                    else result = Math.Tan(result);
                    break;
                case 15:
                    listBoxOp.Items.Add("ln(" + Convert.ToString(result) + ")");
                    result = Math.Log(result, Math.E);
                    break;
                case 16:
                    listBoxOp.Items.Add("ln(" + Convert.ToString(result) + ")");
                    result = Math.Log(result, 10);
                    break;
                case 17:
                    listBoxOp.Items.Add("e^" + Convert.ToString(result));
                    result = Math.Pow(Math.E, result);
                    break;
                case 18:
                    listBoxOp.Items.Add("asin(" + Convert.ToString(result) + ")");
                    if (is_grad)
                    {
                        result = Math.PI / 180 * result;
                        result = Math.Asin(result);
                    }
                    else result = Math.Asin(result);
                    break;
                case 19:
                    listBoxOp.Items.Add("acos(" + Convert.ToString(result) + ")");
                    if (is_grad)
                    {
                        result = Math.PI / 180 * result;
                        result = Math.Acos(result);
                    }
                    else result = Math.Acos(result);
                    break;
                case 20:
                    listBoxOp.Items.Add("atan(" + Convert.ToString(result) + ")");
                    if (is_grad)
                    {
                        result = Math.PI / 180 * result;
                        result = Math.Atan(result);
                    }
                    else result = Math.Atan(result);
                    break;
            }
            maintext.Text = Convert.ToString(result);
            listBoxOp.SetSelected(listBoxOp.Items.Count - 1, true);
        }

        void button_press(string a)
        {
            op_is_empty = false;
            if (call_operation == true)
            {
                call_operation = false;
                maintext.Text = a;
            }
            else
            {
                if (maintext.Text == "0") maintext.Text = a;
                else maintext.Text += a;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_press("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button_press("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button_press("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button_press("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button_press("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button_press("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button_press("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button_press("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button_press("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            button_press("0");
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            if (call_operation == true)
            {
                call_operation = false;
                maintext.Text = "0,";
            }
            else
            {
                if (maintext.Text == "0") maintext.Text = "0,";
                else maintext.Text += ",";
            }
        }

        private void button_cleanall_Click(object sender, EventArgs e)
        {
            call_operation = false;
            res_is_empty = true;
            op_is_empty = true;
            operand = 0;
            result = 0;
            secondtext.Text = "";
            maintext.Text = "0";
            listBoxOp.Items.Clear();
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            maintext.Text = "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
		    {
			    isMouseDown = true;
                dragStartPoint = new Point(e.X + (Width - ClientSize.Width) / 2, e.Y - (Width - ClientSize.Width) / 2);
		    }    
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown) 
		    {
                Point location = PointToScreen(new Point(e.X, e.Y));
                Location = new Point(location.X - dragStartPoint.X, location.Y - dragStartPoint.Y - (Height - ClientSize.Height));
		    }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
	        {
		        isMouseDown = false;
	        }
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            binary_operation("+", 1);
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            binary_operation("-", 2);
        }

        private void button_equalop_Click(object sender, EventArgs e)
        {
            operand = Convert.ToDouble(maintext.Text);
            secondtext.Text = "=";
            if (res_is_empty)
            {
                result = operand;
                res_is_empty = false;
                op_is_empty = true;
                listBoxOp.Items.Add(Convert.ToString(result));
            }
            else
            {
                if (!op_is_empty)
                {
                    solution();
                    op_is_empty = true;
                }
            }
            call_operation = true;
            listBoxOp.Items.Add("————————————————————");
            listBoxOp.Items.Add(Convert.ToString(result) + "\n");
            listBoxOp.SetSelected(listBoxOp.Items.Count - 1, true);
        }

        private void button_mul_Click(object sender, EventArgs e)
        {
            binary_operation("*", 3);
        }

        private void button_div_Click(object sender, EventArgs e)
        {
            binary_operation("/", 4);
        }

        private void button_xy_Click(object sender, EventArgs e)
        {
            binary_operation("^", 5);
        }

        private void button_MS_Click(object sender, EventArgs e)
        {
            memory_is_empty = false;
            mem_text.Text = "M";
            memory = Convert.ToDouble(maintext.Text);
        }

        private void button_MC_Click(object sender, EventArgs e)
        {
            memory_is_empty = true;
            mem_text.Text = "";
        }

        private void button_MR_Click(object sender, EventArgs e)
        {
            if (!memory_is_empty) maintext.Text = Convert.ToString(memory);
            op_is_empty = false;
            if (call_operation == true) call_operation = false;
        }

        private void button_plus_or_minus_Click(object sender, EventArgs e)
        {
            string a = "-";
            if(maintext.Text != "0")
            {
                if (maintext.Text[0] != '-')
                {
                    a += maintext.Text;
                    maintext.Text = a;
                }
                else 
                {
                    string str = "";
                    for (int i = 1; i < maintext.Text.Length; i++)
                    {
                        str += maintext.Text[i];
                    }
                    maintext.Text = str;
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string str = "";
            if (maintext.Text.Length == 1) maintext.Text = "0";
            else
            {
                for (int i = 0; i < maintext.Text.Length - 1; i++)
                {
                    str += maintext.Text[i];
                }
                maintext.Text = str;
            }
        }

        private void button_x2_Click(object sender, EventArgs e)
        {
            unary_operation("^2", 6);
        }

        private void button_sqrt_Click(object sender, EventArgs e)
        {
            unary_operation("sqrt", 7);
        }

        private void button_1x_Click(object sender, EventArgs e)
        {
            unary_operation("1/х", 8);
        }

        private void button_proc_Click(object sender, EventArgs e)
        {
            binary_operation("%", 9);
        }

        private void button_factorial_Click(object sender, EventArgs e)
        {
            unary_operation("n!", 10);
        }

        private void button_x3_Click(object sender, EventArgs e)
        {
            unary_operation("^3", 11);
        }

        private void button_Pi_Click(object sender, EventArgs e)
        {
            op_is_empty = false;
            maintext.Text = Convert.ToString(Math.PI);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            is_grad = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            is_grad = false;
        }

        private void button_sin_Click(object sender, EventArgs e)
        {
            unary_operation("sin", 12);
        }

        private void button_cos_Click(object sender, EventArgs e)
        {
            unary_operation("cos", 13);
        }

        private void button_tan_Click(object sender, EventArgs e)
        {
            unary_operation("tan", 14);
        }

        private void button_ln_Click(object sender, EventArgs e)
        {
            unary_operation("ln", 15);
        }

        private void button_log_Click(object sender, EventArgs e)
        {
            unary_operation("log", 16);
        }

        private void button_exp_Click(object sender, EventArgs e)
        {
            unary_operation("Exp", 17);
        }

        private void button_e_Click(object sender, EventArgs e)
        {
            op_is_empty = false;
            maintext.Text = Convert.ToString(Math.E);
        }

        private void button_asin_Click(object sender, EventArgs e)
        {
            unary_operation("asin", 18);
        }

        private void button_acos_Click(object sender, EventArgs e)
        {
            unary_operation("acos", 19);
        }

        private void button_atan_Click(object sender, EventArgs e)
        {
            unary_operation("atan", 20);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.D1: button1_Click(sender, e); break;
                case Keys.D2: button2_Click(sender, e); break;
                case Keys.D3: button3_Click(sender, e); break;
                case Keys.D4: button4_Click(sender, e); break;
                case Keys.D5: button5_Click(sender, e); break;
                case Keys.D6: button6_Click(sender, e); break;
                case Keys.D7: button7_Click(sender, e); break;
                case Keys.D8: button8_Click(sender, e); break;
                case Keys.D9: button9_Click(sender, e); break;
                case Keys.D0: button0_Click(sender, e); break;

                case Keys.NumPad1: button1_Click(sender, e); break;
                case Keys.NumPad2: button2_Click(sender, e); break;
                case Keys.NumPad3: button3_Click(sender, e); break;
                case Keys.NumPad4: button4_Click(sender, e); break;
                case Keys.NumPad5: button5_Click(sender, e); break;
                case Keys.NumPad6: button6_Click(sender, e); break;
                case Keys.NumPad7: button7_Click(sender, e); break;
                case Keys.NumPad8: button8_Click(sender, e); break;
                case Keys.NumPad9: button9_Click(sender, e); break;
                case Keys.NumPad0: button0_Click(sender, e); break;

                case Keys.Add: button_plus_Click(sender, e); break;
                case Keys.OemMinus: button_minus_Click(sender, e); break;
                case Keys.Subtract: button_minus_Click(sender, e); break;                            
                case Keys.Multiply: button_mul_Click(sender, e); break;
                case Keys.Divide: button_div_Click(sender, e); break;
                case Keys.Enter: button_equalop_Click(sender, e); break;
                case Keys.Delete: button_delete_Click(sender, e); break;

                case Keys.S: button_sin_Click(sender, e); break;
                case Keys.C: button_cos_Click(sender, e); break;
                case Keys.T: button_tan_Click(sender, e); break;
                case Keys.F: button_factorial_Click(sender, e); break;
                case Keys.L: button_ln_Click(sender, e); break;
                case Keys.P: button_xy_Click(sender, e); break;
                case Keys.E: button_exp_Click(sender, e); break;
                case Keys.Q: button_sqrt_Click(sender, e); break;

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 1, 1, Width-2, Height-2);
        }

    }
}
