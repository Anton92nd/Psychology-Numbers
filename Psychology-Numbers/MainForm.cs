using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Psychology_Numbers
{
    public partial class MainForm : Form
    {

        public static Stopwatch Clock = new Stopwatch();
	    public static int SmthWork = 0;

		#region
		private readonly string[] _texts =
	    {
		    @"Вам предстоит пройти 4 этапа.

Первый этап.
Вам будет представлена таблица 7х7,
случайным образом заполненная числами.

Ваше задание на первом этапе - находить все числа,
написанные красным цветом, в порядке возрастания.",

		    @"Первый этап успешно пройден

Второй этап.

Вам будет представлена таблица 7х7,
случайным образом заполненная числами.

Ваше задание на первом этапе - находить все числа,
написанные черным цветом, в порядке убывания(24 -> 1)."
	    };
		#endregion

        public MainForm()
        {
            InitializeComponent();
        }

        // other properties mainButton and label1 in InitializeComponent
        private void MainForm_Load(object sender, EventArgs e)
        {
            label1.Text = @"Доброго времени суток." + '\n' +
                          @"Наша дружная команда в лице Медведя," + '\n' +
                          @"Камня и Фуха предлагает вам поройти данное тестирование.";
            mainButton.Text = @"Готовы?";
            mainButton.BackColor = Color.SkyBlue;
            mainButton.Click += MainButtonClick;
        }
        private void MainButtonClick(object sender, EventArgs e)
        {
			mainButton.Click -= MainButtonClick;
            label1.Text = _texts[0];
            mainButton.BackColor = Color.MediumSeaGreen;
            mainButton.Text = @"Запустить первый этап";
            mainButton.Click += Go_Click;
        }

        private void Go_Click(object sender, EventArgs e)
        {
	        mainButton.Click -= Go_Click;
	        SmthWork = 1;
	        var t = new Task1();
			t.Show();
            mainButton.Click += Go_2Click;
			mainButton.Text = @"Запустить второй этап";
			label1.Text = _texts[1];
        }
	    private void Go_2Click(object sender, EventArgs e)
	    {
			mainButton.Click -= Go_2Click;
			Console.WriteLine(Clock.Elapsed);
			if (SmthWork == 1) return;
			var t = new Task2();
			t.Show();
	    }
    }
}
