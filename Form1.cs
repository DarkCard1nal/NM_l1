using System;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;

namespace l1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void swap(ref double a, ref double b)
		{
			double tmp = a;
			a = b;
			b = tmp;
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
			double detA, parsedValue, tmp;
			double[,] a = new double[3, 3];
			double[] b = new double[3];

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
						label1.Text = "Коренів не знайдено!\nПеревірте введення!";
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
					label1.Text = "Коренів не знайдено!\nПеревірте введення!";
					return;
				}
			}

			//Обчислення детермінанту матриці a
			detA = det3(a);
			if (detA == 0)
			{
				label1.Text = "Коренів не знайдено!\nДетермінант матриці 3х3 є 0!";
				return;
			}

			//Міняємо 0, 0 комірку (міняємо ряди місцями) якщо вона є 0, щоб не ділити на 0
			if (a[0, 0] == 0)
			{
				if (a[2, 0] == 0) //Міняємо 0 та 1 ряди
				{
					i = 1;
				}
				else //Міняємо 0 та 2 ряди
				{
					i = 2;
				}

				for (j = 0; j < 3; j++) 
				{
					swap(ref a[0, j], ref a[i, j]);
				}
			}

			//Розв'язок СЛАР 3 методом Гаусса.
			for (i = 0; i < 3; i++)
			{
				//Крок 1 Ділимо i рядок на a[i, i]
				tmp = a[i, i];
				for (j = 0; j < 3; j++)
				{
					a[i, j] /= tmp;
				}
				b[i] /= tmp;

				//Крок 2 та 3 Від x рядка віднімаємо i рядок, помножений на a[x, i]
				for (x = 0; x < 3; x++)
				{
					if (x == i) continue;

					tmp = a[x, i];
					for (j = 0; j < 3; j++)
					{
						a[x, j] -= a[i, j] * tmp;
					}
					b[x] -= b[i] * tmp;
				}
			}

			label1.Text = "x₁ = " + Convert.ToString(Math.Round(b[0], 8)) +
				"\nx₂ = " + Convert.ToString(Math.Round(b[1], 8)) +
				"\nx₃ = " + Convert.ToString(Math.Round(b[2], 8));
		}
	}
}
