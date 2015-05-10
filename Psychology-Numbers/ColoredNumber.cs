using System.Drawing;

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

	    public override string ToString()
	    {
			return this.Color.Name + " " + Number;
	    }
	}
}
