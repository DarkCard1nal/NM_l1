using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace l1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//Повертає детермінант матриці 3х3 методом трикутників.
		private double det3(double[,] a)
		{
			return (a[0, 0] * a[1, 1] * a[2, 2] +
					a[0, 1] * a[1, 2] * a[2, 0] +
					a[0, 2] * a[1, 0] * a[2, 1] -
					a[0, 2] * a[1, 1] * a[2, 0] -
					a[0, 0] * a[1, 2] * a[2, 1] -
					a[0, 1] * a[1, 0] * a[2, 2]);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			TextBox[] textBoxArray = new TextBox[12];
			textBoxArray[0] = textBox1;
			textBoxArray[1] = textBox2;
			textBoxArray[2] = textBox3;
			textBoxArray[3] = textBox4;
			textBoxArray[4] = textBox5;
			textBoxArray[5] = textBox6;
			textBoxArray[6] = textBox7;
			textBoxArray[7] = textBox8;
			textBoxArray[8] = textBox9;
			textBoxArray[9] = textBox10;
			textBoxArray[10] = textBox11;
			textBoxArray[11] = textBox12;

			int i, j, x;
			double detA, parsedValue;
			double[,] a = new double[3, 3];
			double[] b = new double[3];
			double[] res = new double[3];
			bool[] zero = new bool[6];

			//Отримання значень з textBoxArray.
			for (i = 0, x = 0; i < 3; i++)
			{
				for (j = 0; j < 3; j++, x++)
				{
					if (Double.TryParse(textBoxArray[x].Text, out parsedValue))
					{
						a[i, j] = parsedValue;
					}
					else
					{
						label1.Text = "Коренів не знайдено!";
						return;
					}
				}
			}
			
			for (i = 0; i < 3; i++)
			{
				if (Double.TryParse(textBoxArray[i + 9].Text, out parsedValue))
				{
					b[i] = parsedValue;
				}
				else
				{
					label1.Text = "Коренів не знайдено! Перевірте введення!";
					return;
				}
			}

			//Обчислення детермінанту матриці a
			detA = det3(a);
			if (detA == 0)
			{
				label1.Text = "Коренів не знайдено! Детермінант матриці 3х3 є 0!";
			}

			//


			//Розв'язок СЛАР 3 методом Гаусса.








			label1.Text = "x₁ = " + Convert.ToString(Math.Round(res[0], 4)) +
				"\nx₂ = " + Convert.ToString(Math.Round(res[1], 4)) +
				"\nx₃ = " + Convert.ToString(Math.Round(res[2], 4));
		}
	}
}
