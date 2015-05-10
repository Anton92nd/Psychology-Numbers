using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Psychology_Numbers
{
	public partial class Task1 : Form
	{
		private static ColoredNumber[] order = Enumerable.Range(1, 25)
			.Select(x => new ColoredNumber(x, Color.Red)).ToArray();

		private int position = 0;

		private void ClickHandler(object sender, EventArgs eventArgs)
		{
            var clock = MainForm.Clock;
			if (position == 0 && !clock.IsRunning)
			{
				clock.Start();
			}
			var button = (Button) sender;
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
		        label1.Text = position == 0 ? "First is RED 1": "Incorrect.\nLast correct click was: "
					+ order[position - 1];
		    }
			if (position != order.Length) return;
			MainForm.SmthWork = 0;
			clock.Stop();
			Close();
		}

		public Task1()
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

		private void Task1_Load(object sender, EventArgs e)
		{

		}
	}
}
