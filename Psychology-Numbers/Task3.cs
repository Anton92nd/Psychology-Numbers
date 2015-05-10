using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Psychology_Numbers
{
	public partial class Task3 : Form
	{
		private static ColoredNumber[] order = Enumerable.Range(1, 49)
			.Select(x => (x%2 == 0) ? new ColoredNumber((24 - x/2 + 1), Color.Black) : new ColoredNumber((x/2 + 1), Color.Red))
			.ToArray();

		private int position = 0;

		private void ClickHandler(object sender, EventArgs eventArgs)
		{
			var clock = MainForm.Clock;
			var button = (Button)sender;
			Console.WriteLine(button.Text + @" " + button.ForeColor);
			var number = new ColoredNumber(int.Parse(button.Text), button.ForeColor);
			if (number.Equals(order[position]))
			{
				var oldColor = button.BackColor;
				button.BackColor = Color.GreenYellow;
				button.Refresh();
				Thread.Sleep(500);
				button.BackColor = oldColor;
				button.Refresh();
				position++;
				Console.WriteLine(@"Success!");

				label1.Text = "";
			}
			else
			{
				label1.Text = 
					position < 2 ? new string[2]{"First is Red 1", "Secon click must be 24 Black"}[position]
					: "Incorrect.\nTry: " 
					+ order[position];
			}
			if (position != order.Length) return;
			clock.Stop();
			Close();
		}
		public Task3()
		{
			InitializeComponent();
			label1.Text = "";
			for (var i = 0; i < 49; i++)
			{
				var button = (Button)tableLayoutPanel1.Controls[i];
				button.Click += ClickHandler;
				button.Height = 60;
			}
		}

		private void Task3_Load(object sender, EventArgs e)
		{
			Owner.Hide();
			MainForm.Clock.Start();
		}

		private void Task3_FormClosed(object sender, FormClosedEventArgs e)
		{
			Owner.Show();
			MainForm.Clock.Stop();
		}
	}
}
