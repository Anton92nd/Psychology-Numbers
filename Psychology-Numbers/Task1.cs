using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Psychology_Numbers
{
	public partial class Task1 : Form
	{
		private static ColoredNumber[] order = Enumerable.Range(1, 25)
			.Select(x => new ColoredNumber(x, Color.Red)).ToArray();

		private int position = 0;

		public static Stopwatch Clock;

		private void ClickHandler(object sender, EventArgs eventArgs)
		{
			if (position == 0 && Clock == null)
			{
				Clock = new Stopwatch();
				Clock.Start();
			}
			var button = (Button) sender;
			Console.WriteLine(button.Text + " " + button.ForeColor);
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
				Console.WriteLine("Success!");
			}
			if (position == order.Length)
			{
				Clock.Stop();
				Close();
			}
		}

		public Task1()
		{
			InitializeComponent();
			for (var i = 0; i < 49; i++)
			{
				var button = (Button)tableLayoutPanel1.Controls[i];
				button.Click += ClickHandler;
			}
		}

		private void Task1_Load(object sender, EventArgs e)
		{

		}
	}
}
