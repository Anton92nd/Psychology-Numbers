using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Psychology_Numbers
{
    public partial class MainForm : Form
    {

        public static Stopwatch Clock = new Stopwatch();

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

Ваше задание на втором этапе - находить все числа,
написанные черным цветом, в порядке убывания(24 -> 1).",
			
			@"Второй этап успешно пройден

Третий этап.

Вам будет представлена таблица 7х7,
случайным образом заполненная числами.

Ваше задание на третьем этапе - найти все
числа в порядке 1-красная, 24-черная, 2-крассная,
23-черная, ..., 24-красная, 1-черная, 25-крассная."
	    };
		#endregion

        public MainForm()
        {
            InitializeComponent();
        }

        // other properties mainButton and label1 in InitializeComponent
        private void MainForm_Load(object sender, EventArgs e)
        {
            label1.Text = @"Здравствуйте." + '\n' +
                          "Вам предлагается пройти тестирование на тему \"\"" + '\n' +
                          "\n\nРаботу выполнили:\n    Перевощиков Павел\n    Чаплыгин Антон\n    Чухарев Александр";
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
            mainButton.Click += Go_1Click;
        }
        private void Go_1Click(object sender, EventArgs e)
        {
	        mainButton.Click -= Go_1Click;
	        var t = new Task1();
	        t.Owner = this;
			t.Show();
            mainButton.Click += Go_2Click;
			mainButton.Text = @"Запустить второй этап";
			label1.Text = _texts[1];
        }
	    private void Go_2Click(object sender, EventArgs e)
	    {
			mainButton.Click -= Go_2Click;
			Console.WriteLine(Clock.Elapsed);
			var t = new Task2();
		    t.Owner = this;
			t.Show();
		    mainButton.Click += Go_3Click;
			mainButton.Text = @"Запустить третий этап";
			label1.Text = _texts[2];
	    }

	    private double _firstAndSecondSeconds;

		private void Go_3Click(object sender, EventArgs e)
		{
			_firstAndSecondSeconds = Clock.Elapsed.TotalSeconds;
			Console.WriteLine(Clock.Elapsed);
			Clock.Reset();
			mainButton.Click -= Go_3Click;
			var t = new Task3();
			t.FormClosed += Show3Results;
			t.Owner = this;
			t.Show();
			mainButton.Click += Go_4Click;
			mainButton.Text = @"Запустить последний этап";

		}

		private void Show3Results(object sender, FormClosedEventArgs e)
		{
			label1.Text = string.Format("Результат после трёх испытаний: {0:0.000} секунд",
				Clock.Elapsed.TotalSeconds - _firstAndSecondSeconds);
			Clock.Reset();
		}

		private void Go_4Click(object sender, EventArgs e)
		{
			mainButton.Click -= Go_3Click;
			Clock.Reset();
			var t = new Task4();
			t.FormClosed += Show4Results;
			t.Owner = this;
			t.Show();
			mainButton.Hide();
		}

	    private void Show4Results(object sender, FormClosedEventArgs e)
	    {
			label1.Text = string.Format("Результат после 4го испытания испытаний: {0:0.000} секунд",
				Clock.Elapsed.TotalSeconds - _firstAndSecondSeconds);
			Clock.Reset();
	    }
    }
}
