using System.Windows;

namespace pwmTableGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly string typePrefix = "uint16_t";
        private static readonly string tableName = "arcTable";
        private static readonly string defaultMax = "8000";
        private static readonly string defaultCnt = "255";

        public MainWindow()
        {
            InitializeComponent();

            uiTextBoxMaximum.Text = defaultMax;
            uiTextBoxCount.Text = defaultCnt;
        }

        private void ClickGenerate(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(uiTextBoxMaximum.Text, out int max) != true)
            {
                uiTextBoxResult.Text = "Ошибка! Не удалось распознать Максимум.";
                return;
            }

            if (max < 2)
            {
                uiTextBoxResult.Text = "Ошибка! Некорректное значение Максимума.";
                return;
            }

            if (int.TryParse(uiTextBoxCount.Text, out int cnt) != true)
            {
                uiTextBoxResult.Text = "Ошибка! Не удалось распознать Количество.";
                return;
            }

            if (max < 4)
            {
                uiTextBoxResult.Text = "Ошибка! Некорректное значение Количества.";
                return;
            }
            
            int[] values = (uiRadioBtnLog.IsChecked == true) ?
                ValueTableCalculator.GetLogarithmicTable(max, cnt) : ValueTableCalculator.GetLinearTable(max, cnt);

            uiTextBoxResult.Text = OutputTextGenerator.GetOutputText($"{typePrefix} {tableName}", values);
        }
    }
}
