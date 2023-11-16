using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //*************add display value******************
        private void display_value(string num)

        {

            result_display.Focus();
            if (result_display.Text == "0")
            {
                result_display.Text = "";
            }
            if (calc_display.Text.Contains("="))
            {
                result_display.Text = "";
                calc_display.Text = "";

            }
            result_display.Text += num;




        }

        // display value cancle one by one
        private void display_value_cancle()

        {
            string value = result_display.Text;

            if (value != "")
            {
                //remove last index
                value = value.Remove(value.Length - 1, 1);

                result_display.Text = value;
            }
            if (value == "")
            {
                result_display.Text = "0";
            }


        }

        // add calc display value
        public void calc_display_(string x)
        {

            string value = result_display.Text;

            if (value.StartsWith("."))
            {

                value = "0" + value;

            }


            if (x == "√")
            {
                value = x + "(" + value + ")";

            }
            else if (x == "10^")
            {
                value = x + value;

            }
            else
            {
                value = value + x;
            }
            calc_display.Text = value;
            result_display.Text = "0";


        }
         
        // create bool variable for pass condition
        bool condition = false;
        void calc_value_equal(string x)
        {

            string value = result_display.Text;
            string value1 = calc_display.Text;


            

            string fvalue = value1 + value + x;
            
            // result display = chack

            if (!value1.Contains("="))
            {
                calc_display.Text = fvalue;
                condition = false;
            }
            value1 = calc_display.Text;

            // condition for devided
            if (value1.Contains("÷"))
            {

                string operato = value1.Substring(0, value1.IndexOf("÷") + 1);


                // condition for multi click equal button
                if (condition)
                {
                    operato = value1.Substring(value1.IndexOf("÷"));

                    operato = operato.Replace("=", "");
                    value = result_display.Text;
                    calc_display.Text = value + operato + "=";

                }
                else
                {

                    calc_display.Text = operato + value + "=";
                    condition = true;
                }


                value1 = calc_display.Text;
                

                // get two value
                var vlue1 = double.Parse(value1.Substring(0, value1.IndexOf("÷")));
                var valuedo = value1.Substring(value1.IndexOf("÷") + 1);
                if (value1.Contains("="))
                {
                    valuedo = valuedo.Remove(valuedo.IndexOf("="));
                }
                double valuedoubl = Convert.ToDouble(valuedo);


                string calcula = Convert.ToString(vlue1 / valuedoubl);



                result_display.Text = calcula;

            }

            // condition for multipication
            else if (value1.Contains("×"))
            {


                string operato = value1.Substring(0, value1.IndexOf("×") + 1);
                // condition for multi click equal button

                if (condition)
                {
                    operato = value1.Substring(value1.IndexOf("×"));

                    operato = operato.Replace("=", "");
                    value = result_display.Text;
                    calc_display.Text = value + operato + "=";

                }
                else
                {

                    calc_display.Text = operato + value + "=";
                    condition = true;
                }


                value1 = calc_display.Text;

                // get two value
                var vlue1 = double.Parse(value1.Substring(0, value1.IndexOf("×")));
                var valuedo = value1.Substring(value1.IndexOf("×") + 1);
                if (value1.Contains("="))
                {
                    valuedo = valuedo.Remove(valuedo.IndexOf("="));
                }
                double valuedoubl = Convert.ToDouble(valuedo);


                string calcula = Convert.ToString(vlue1 * valuedoubl);



                result_display.Text = calcula;

            }
            // condition for plus
            else if (value1.Contains("+"))
            {
                string operato = value1.Substring(0, value1.IndexOf("+") + 1);
                // condition for multi click equal button

                if (condition)
                {
                    operato = value1.Substring(value1.IndexOf("+"));

                    operato = operato.Replace("=", "");
                    value = result_display.Text;
                    calc_display.Text = value + operato + "=";

                }
                else
                {

                    calc_display.Text = operato + value + "=";
                    condition = true;
                }


                value1 = calc_display.Text;

                // get two value
                var vlue1 = double.Parse(value1.Substring(0, value1.IndexOf("+")));
                var valuedo = value1.Substring(value1.IndexOf("+") + 1);
                if (value1.Contains("="))
                {
                    valuedo = valuedo.Remove(valuedo.IndexOf("="));
                }
                double valuedoubl = Convert.ToDouble(valuedo);


                string calcula = Convert.ToString(vlue1 + valuedoubl);



                result_display.Text = calcula;

            }
            // condition for minus
            else if (value1.Contains("-"))
            {
                string operato = value1.Substring(0, value1.IndexOf("-", 1) + 1);
                // condition for multi click equal button

                if (condition)
                {
                    operato = value1.Substring(value1.IndexOf("-", 1));

                    operato = operato.Replace("=", "");
                    value = result_display.Text;
                    calc_display.Text = value + operato + "=";

                }
                else
                {

                    calc_display.Text = operato + value + "=";
                    condition = true;
                }


                value1 = calc_display.Text;

                // ger two value
                var vlue1 = double.Parse(value1.Substring(0, value1.IndexOf("-", 1)));
                var valuedo = value1.Substring(value1.IndexOf("-", 1) + 1);
                if (value1.Contains("="))
                {
                    valuedo = valuedo.Remove(valuedo.IndexOf("="));
                }
                double valuedoubl = double.Parse(valuedo);


                string calcula = Convert.ToString(vlue1 - valuedoubl);



                result_display.Text = calcula;

            }

        }

        //Power function

        public void powercalck(double x, double y)
        {
            
            double powerclac = Math.Pow(x, y);

            result_display.Text = Convert.ToString(powerclac);
        }
        // squar function
        public void squar(double x)
        {
            double powerclac = Math.Pow(x, 2);

            result_display.Text = Convert.ToString(powerclac);
        }
        // root function
        public void rootfunction(double x)
        {
            result_display.Text = Convert.ToString(Math.Sqrt(x));
        }
        // add zero
        private void zeroadd()
        {
            if (result_display.Text.StartsWith("."))
            {

                result_display.Text = "0" + result_display.Text;
            }
        }

        // cup button event
        private void button_persent_Click(object sender, EventArgs e)
        {
            calc_display_("^");
        }

        private void button_ce_Click(object sender, EventArgs e)
        {
            result_display.Text = "0";
        }

        private void button_c_Click(object sender, EventArgs e)
        {
            result_display.Text = "0";
            calc_display.Text = "";
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            display_value_cancle();
        }

        private void button_1_devid_x_Click(object sender, EventArgs e)
        {

            calc_display_("10^");

            string value = calc_display.Text;


            calc_display.Text = value;

            result_display.Text = Convert.ToString(Math.Pow(10, Convert.ToDouble(value.Substring(value.IndexOf("^") + 1))));


        }

        private void button_x_2_Click(object sender, EventArgs e)
        {
            calc_display_("²");
            string cvalue = calc_display.Text;


            cvalue = cvalue.Replace("²", "");

            squar(Convert.ToDouble(cvalue));

        }

        private void button_2_root_x_Click(object sender, EventArgs e)
        {
            calc_display_("√");
            string cvalue = calc_display.Text;

            cvalue = cvalue.Remove(0, 2);

            cvalue = cvalue.Replace(")", "");

            rootfunction(double.Parse(cvalue));
        }

        private void button_devied_Click(object sender, EventArgs e)
        {
            calc_display_("÷");

        }

        private void button_7_Click(object sender, EventArgs e)
        {
            display_value("7");
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            display_value("8");
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            display_value("9");
        }

        private void button_multification_Click(object sender, EventArgs e)
        {
            calc_display_("×");
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            display_value("4");
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            display_value("5");
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            display_value("6");
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            calc_display_("-");

        }

        private void button_1_Click(object sender, EventArgs e)
        {
            display_value("1");

        }

        private void button_2_Click(object sender, EventArgs e)
        {
            display_value("2");
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            display_value("3");
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            calc_display_("+");

        }

        private void button_plus_devide_minus_Click(object sender, EventArgs e)
        {
            string value = result_display.Text;
            if (value.StartsWith("-"))
            {
                result_display.Text = value.Replace("-", "");
            }
            else
            {

                result_display.Text = "-" + value;
            }
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            display_value("0");

        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            display_value(".");

        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            string value1 = result_display.Text;
            string value2 = calc_display.Text;

            calc_value_equal("=");

            if (value2.Contains("^"))
            {
                powercalck(Convert.ToDouble(value2.Replace("^", "")), Convert.ToDouble(value1));

            }
            else if (value2.Contains("√"))
            {
                rootfunction(0.2);

            }
        }

        private void calc_display_Click(object sender, EventArgs e)
        {

        }

        private void result_display_Click(object sender, EventArgs e)
        {
            zeroadd();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bunifuTransition1.Show(tableLayoutPanel1);
        }
        private void clicked5(object sender, MouseEventArgs e)
        {

        }
        

        // keypress event
        private void keypress_event(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;

            
            switch (key)
            {
                case '0':
                    button_0.PerformClick();
                    break;
                case '1':
                    button_1.PerformClick();
                    break;
                case '2':
                    button_2.PerformClick();
                    break;
                case '3':
                    button_3.PerformClick();
                    break;
                case '4':
                    button_4.PerformClick();
                    break;
                case '5':
                    button_5.PerformClick();
                    break;
                case '6':
                    button_6.PerformClick();
                    break;
                case '7':
                    button_7.PerformClick();
                    break;
                case '8':
                    button_8.PerformClick();
                    break;
                case '9':
                    button_9.PerformClick();
                    break;
                case '':
                    button_cancel.PerformClick();
                    break;
                case '+':
                    button_plus.PerformClick();
                    break;
                case '-':
                    button_minus.PerformClick();
                    break;
                case '*':
                    button_multification.PerformClick();
                    break;
                case '/':
                    button_devied.PerformClick();
                    break;
               
            }
        }

       

        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_equal.PerformClick();
            }
        }
    }
}
