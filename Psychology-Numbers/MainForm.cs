using System;
using System.Drawing;
using System.Windows.Forms;

namespace Psychology_Numbers
{
    public partial class MainForm : Form
    {
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
            label1.Text = @"Вам предстоит пройти 4 этапа.";
            mainButton.BackColor = Color.MediumSeaGreen;
            mainButton.Text = @"Начали!";
            mainButton.Click += Go_Click;
        }

        private void Go_Click(object sender, EventArgs e)
        {
            Console.Write(@"green button presed!");
        }

	}
}
