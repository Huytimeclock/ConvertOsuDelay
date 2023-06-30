using System.Text;

namespace ConvertOsuDelay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            string delayText = textBox3.Text;
            float delayValue = float.Parse(delayText);
            string convertedText = ConvertText(inputText, delayValue); // Call the conversion function

            textBox2.Text = convertedText; // Display the converted text in textBox2
        }

        private string ConvertText(string input, float delay)
        {
            StringBuilder convertedText = new StringBuilder();

            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                if (values.Length >= 3)
                {
                    if (int.TryParse(values[2], out int thirdValue))
                    {
                        double convertedValue = (thirdValue + delay) / 1000.0;
                        string formattedValue = $"[{convertedValue:F3}]";
                        convertedText.AppendLine(formattedValue);
                    }
                }
            }

            return convertedText.ToString();
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
