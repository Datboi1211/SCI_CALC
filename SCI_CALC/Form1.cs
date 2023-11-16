using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI_CALC
{
    public partial class Form1 : Form
    {
        double enterFirstValue, enterSecondValue;
        String op, pt;
        public Form1()
        {
            InitializeComponent();
        }

        private void EnterNumbers(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (txtResult.Text == "0")
                txtResult.Text = "";
            {
                if (num.Text == ".")
                {
                    if (!txtResult.Text.Contains("."))
                        txtResult.Text = txtResult.Text + num.Text;
                }
                else
                {
                    txtResult.Text = txtResult.Text + num.Text;
                }
            }
        }

        private void numberOp(object sender, EventArgs e)
        {
            Button num = (Button)sender;

            enterFirstValue = Convert.ToDouble(txtResult.Text);
            op = num.Text;
            txtResult.Text = "";

        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            enterSecondValue = Convert.ToDouble(txtResult.Text);

            switch (op)
            {
                case "+":
                    txtResult.Text = (enterFirstValue + enterSecondValue).ToString();
                    break;

                case "-":
                    txtResult.Text = (enterFirstValue - enterSecondValue).ToString();
                    break;

                case "x":
                    txtResult.Text = (enterFirstValue * enterSecondValue).ToString();
                    break;

                case "÷":
                    txtResult.Text = (enterFirstValue / enterSecondValue).ToString();
                    break;

                case "%":
                    txtResult.Text = (enterFirstValue % enterSecondValue).ToString();
                    break;

                case "eˣ":
                    double i = Convert.ToDouble(txtResult.Text);
                    double j;
                    j = enterSecondValue;
                    txtResult.Text = Math.Exp(i * Math.Log(j * 4)).ToString();
                    break;

                case "xʸ":
                    double baseNumber = enterFirstValue;
                    double exponent = Convert.ToDouble(txtResult.Text);

                    double result = Math.Pow(baseNumber, exponent);
                    txtResult.Text = result.ToString();
                    break;

                case "⌈x⌉":
                    double ceil = Convert.ToDouble(txtResult.Text);
                    ceil = Math.Ceiling(ceil);
                    txtResult.Text = Convert.ToString(ceil);
                    break;

                case "⌊x⌋":
                    double floor = Convert.ToDouble(txtResult.Text);
                    floor = Math.Floor(floor);
                    txtResult.Text = Convert.ToString(floor);
                    break;

                case "nPr":
                    double num1 = enterFirstValue;
                    double num2 = enterSecondValue;

                    if (num1 >= num2 && num1 >= 0 && num2 >= 0 && num1 == Math.Floor(num1) && num2 == Math.Floor(num2))
                    {
                        double perm = CalculateFactorial((int)num1) / CalculateFactorial((int)(num1 - num2));
                        txtResult.Text = perm.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Error: Invalid input for permutation.");
                    }
                    break;

                case "nCr":
                    num1 = enterFirstValue;
                    num2 = enterSecondValue;

                    if (num1 >= num2 && num1 >= 0 && num2 >= 0 && num1 == Math.Floor(num1) && num2 == Math.Floor(num2))
                    {
                        double comb = CalculateFactorial((int)num1) / (CalculateFactorial((int)num2) * CalculateFactorial((int)(num1 - num2)));
                        txtResult.Text = comb.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Error: Invalid input for combination.");
                    }
                    break;


                default:
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";

            String f, s;

            f = Convert.ToString(enterFirstValue);
            s = Convert.ToString(enterSecondValue);

            f = "";
            s = "";
        }

        private void btnBS_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Length > 0)
            {
                txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1, 1);
            }

            if (txtResult.Text == "")
            {
                txtResult.Text = "0";
            }
        }

        private void btnPM_Click(object sender, EventArgs e)
        {
            double q = Convert.ToDouble(txtResult.Text);
            txtResult.Text = Convert.ToString(-1 * q);
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 330;
            txtResult.Width = 278;
        }

        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 625;
            txtResult.Width = 574;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exitCal;

            exitCal = MessageBox.Show("Exiting the calculator. Farewell Cosmic Traveller!");
            Application.Exit();
            
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            double baseNumber = enterFirstValue;
            double exponent = Convert.ToDouble(txtResult.Text);

            double result = Math.Pow(baseNumber, exponent);
            txtResult.Text = Convert.ToString(result);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            double logg = Convert.ToDouble(txtResult.Text);
            logg = Math.Log10(logg);
            txtResult.Text = Convert.ToString(logg);
        }

        private void btnLn_Click(object sender, EventArgs e)
        {
            double lnn = Convert.ToDouble(txtResult.Text);
            lnn = Math.Log(lnn);
            txtResult.Text = Convert.ToString(lnn);
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double sq = Convert.ToDouble(txtResult.Text);
            sq = Math.Sqrt(sq);
            txtResult.Text = Convert.ToString(sq);
        }

        private void btnCbrt_Click(object sender, EventArgs e)
        {
            double cb = Convert.ToDouble(txtResult.Text);
            cb = Math.Pow(cb, 1.0 / 3);
            txtResult.Text = Convert.ToString(cb);
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            double s = Convert.ToDouble(txtResult.Text);
            s = Math.Sin(s);
            txtResult.Text = Convert.ToString(s);
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            double sinh = Convert.ToDouble(txtResult.Text);
            sinh = Math.Sinh(sinh);
            txtResult.Text = Convert.ToString(sinh);
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            double c = Convert.ToDouble(txtResult.Text);
            c = Math.Cos(c);
            txtResult.Text = Convert.ToString(c);
        }

        private void btnCsc_Click(object sender, EventArgs e)
        {
            double cosh = Convert.ToDouble(txtResult.Text);
            cosh = Math.Cosh(cosh);
            txtResult.Text = Convert.ToString(cosh);
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            double tan = Convert.ToDouble(txtResult.Text);
            tan = Math.Cosh(tan);
            txtResult.Text = Convert.ToString(tan);
        }

        private void btnCot_Click(object sender, EventArgs e)
        {
            double tanh = Convert.ToDouble(txtResult.Text);
            tanh = Math.Cosh(tanh);
            txtResult.Text = Convert.ToString(tanh);
        }

        private void btnFactorial_Click(object sender, EventArgs e)
        {
            double enterFirstValue = Convert.ToDouble(txtResult.Text);

            if (enterFirstValue < 0 || enterFirstValue != Math.Floor(enterFirstValue))
            {
                MessageBox.Show("Factorial is defined for non-negative integers only.");
            }
            else
            {
                double result = CalculateFactorial((int)enterFirstValue);
                txtResult.Text = result.ToString();
            }
        }

        private double CalculateFactorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            return n * CalculateFactorial(n - 1);
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            txtResult.Text = "3.14159";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Original size = 816
            this.Width = 330; 
            txtResult.Width = 278;
        }
    }
}
