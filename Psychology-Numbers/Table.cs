using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Psychology_Numbers
{
	public class Table : TableLayoutPanel
	{

		public Table()
		{
			Location = new Point(45, 25);
			ColumnCount = 7;
			for (var i = 0; i < 7; i++)
			{
				ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.3F));
			}
			Name = "tableLayoutPanel1";
			RowCount = 7;
			for (var i = 0; i < 7; i++)
			{
				RowStyles.Add(new RowStyle(SizeType.Percent, 14.3F));
			}
			Size = new Size(300, 300);
			InitButtons();
		}

		private ColoredNumber[] numbers;

		private void InitButtons()
		{
			var rand = new Random(DateTime.Now.Millisecond);
			numbers = Enumerable.Range(1, 25)
				.Select(n => new ColoredNumber(n, Color.Red))
				.Concat(
					Enumerable.Range(1, 24)
					.Select(n => new ColoredNumber(n, Color.Black))
				)
				.OrderBy(x => rand.Next())
				.ToArray();
			for (var i = 0; i < 49; i++)
			{
				var button = new Button
				{
					Text = numbers[i].Number.ToString(CultureInfo.InvariantCulture),
					FlatStyle = FlatStyle.Standard,
					ForeColor = numbers[i].Color
				};
				Controls.Add(button, i / 7, i % 7);
			}
		}
	}
}
