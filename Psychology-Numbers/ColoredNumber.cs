using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychology_Numbers
{
	public class ColoredNumber
	{
		public int Number { get; private set; }
		public Color Color { get; private set; }

		public ColoredNumber(int number, Color color)
		{
			Number = number;
			Color = color;
		}

		public bool Equals(ColoredNumber otherNumber)
		{
			return Number == otherNumber.Number && Color == otherNumber.Color;
		}
	}
}
