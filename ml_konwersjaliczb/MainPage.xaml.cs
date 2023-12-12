namespace ml_konwersjaliczb
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            int ss1 = int.Parse(s1.Text);
            int ss2 = int.Parse(s2.Text);
            string numm = s3.Text;
            string result = ConvertNumericSystem(numm, ss1, ss2);
            DisplayAlert("Sukces", $"Liczba {numm} w zmienionym systemie to {result}", "OK");
        }

        static string ConvertNumericSystem(string num, int s1, int s2)
        {
            int decimalNum = ConvertToDecimal(num, s1);

            string result = ConvertFromDecimal(decimalNum, s2);

            return result;
        }

        static int ConvertToDecimal(string num, int sourceSystem)
        {
            int decimalNum = 0;
            int power = 0;

            for (int i = num.Length - 1; i >= 0; i--)
            {
                int digit = GetDecimalValue(num[i]);
                decimalNum += digit * (int)Math.Pow(sourceSystem, power);
                power++;
            }

            return decimalNum;
        }

        static int GetDecimalValue(char digit)
        {
            if (char.IsDigit(digit))
            {
                return digit - '0';
            }
            else
            {
                return char.ToUpper(digit) - 'A' + 10;
            }
        }

        static string ConvertFromDecimal(int decimalNum, int targetSystem)
        {
            string result = "";
            while (decimalNum > 0)
            {
                int remainder = decimalNum % targetSystem;
                char digit = (char)(remainder < 10 ? remainder + '0' : remainder - 10 + 'A');
                result = digit + result;
                decimalNum /= targetSystem;
            }

            return result;
        }

    }
}