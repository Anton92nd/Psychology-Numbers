using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Psychology_Numbers
{
	public partial class Task4 : Form
	{
		private static ColoredNumber[] order = Enumerable.Range(1, 49)
			.Select(x => (x % 2 == 0) ? new ColoredNumber((24 - x / 2 + 1), Color.Black) : new ColoredNumber((x / 2 + 1), Color.Red))
			.ToArray();

		private string[] sounds = Enumerable.Range(1, 25).Select(x => x.ToString()).ToArray();

		private int position = 0;
		private System.Threading.Timer timer;

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
					position < 2 ? new string[2] { "Первое число - 1 красное", "Второе число - 24 черное" }[position]
					: "Неверно.\nПопробуйте: "
					+ order[position];
			}
			if (position != order.Length) return;
			clock.Stop();
			Close();
		}
		public Task4()
		{
			InitializeComponent();
			label1.Text = "";
			var rand = new Random();
			timer = new System.Threading.Timer(PlaySound, rand, 0, 5000);
			for (var i = 0; i < 49; i++)
			{
				var button = (Button)tableLayoutPanel1.Controls[i];
				button.Click += ClickHandler;
				button.Height = 60;
			}
		}

		private void PlaySound(object state)
		{
			var rand = (Random) state;
			var sound = sounds[rand.Next()%sounds.Length] + ".wav";
			var player = new SoundPlayer(Path.Combine("sounds", sound));
			player.Play();
		}

		private void Task4_Load(object sender, EventArgs e)
		{
			Owner.Hide();
			MainForm.Clock.Start();
		}

		private void Task4_FormClosed(object sender, FormClosedEventArgs e)
		{
			Owner.Show();
			MainForm.Clock.Stop();
			timer.Dispose();
		}
	}
}
