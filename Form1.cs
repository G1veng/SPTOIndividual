using System;
using System.Diagnostics;
using System.Text;

namespace SPTOIndividual
{
    public partial class Form1 : Form
    {
        private List<Command> commands = new List<Command>();
        private List<string> execCommands = new List<string>();
        private bool isPressKeys = false;
        private double _eps = 0.1;

        public Form1()
        {
            InitializeComponent();

            leftBorder.Text = "1";
            rightBorder.Text = "10";
            stepStart.Text = "0.000005";
            stepEnd.Text = "0.5";
            coefficients.Text = "1 2 3 4";
            stepOfStep.Text = "0.01";
        }

        private void startTest_Click(object sender, EventArgs e)
        {
            commands.Clear();
            var fileName = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds.ToString();
            var oracleFileName = $"oracle{fileName}.bat";
            var resultFileName = $"result{fileName}.txt";
            var filePath = $"{fileName}.bat";

            var start = Double.Parse(stepStart.Text);
            var end = Double.Parse(stepEnd.Text);
            var h = Double.Parse(stepOfStep.Text);
            var repeatAmounts = Math.Ceiling((end - start) / h);

            using (FileStream fs = File.Create(filePath))
                for (var j = 1; j <= 3; j++)
                    for (var i = 0; i < repeatAmounts; i++)
                    {
                        var curDegree = Math.Round(start + (i * h), 6);

                        var command = $"{leftBorder.Text.Replace('.', ',')} {rightBorder.Text.Replace('.', ',')} {curDegree.ToString().Replace('.', ',')} {j} {coefficients.Text}";

                        execCommands.Add(command);
                        commands.Add(new Command()
                        {
                            Coefficients = coefficients.Text.Split(' ').Select(v => Double.Parse(v)).ToList(),
                            LeftBorder = leftBorder.Text,
                            RightBorder = rightBorder.Text,
                            Eps = curDegree.ToString(),
                            Method = j
                        });

                        byte[] commandInfo = new UTF8Encoding(true).GetBytes($"Integral3x {command} >> result.txt{Environment.NewLine}");
                        fs.Write(commandInfo, 0, commandInfo.Length);
                    }

            var index = 0;

            using (FileStream rfs = File.Create(resultFileName))
                using (FileStream fs = File.Create(oracleFileName))
                    foreach (var command in commands)
                    {
                        var s = ProcessErrors(command);
                        if (s == String.Empty)
                        {
                            s = Calculate(command.Method, Double.Parse(command.LeftBorder), Double.Parse(command.Eps), Double.Parse(command.RightBorder), command.Coefficients).ToString();
                        }

                        byte[] commandInfo = new UTF8Encoding(true).GetBytes($"S = {s}{Environment.NewLine}");
                        fs.Write(commandInfo, 0, commandInfo.Length);

                        var proc = new Process()
                        {
                            StartInfo = new ProcessStartInfo()
                            {
                                FileName = "Integral3x",
                                Arguments = execCommands[index],
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                CreateNoWindow = true,
                                StandardOutputEncoding = Encoding.UTF8
                            }
                        };

                        proc.Start();

                        var result = proc.StandardOutput.ReadLine();
                        byte[] resultInfo = new byte[0];

                        if (Double.TryParse(result!.Split(' ').ToList().Last(), out var r) && Double.TryParse(s, out var sRes))
                        {
                            resultInfo = new UTF8Encoding(true).GetBytes($"initial data - {execCommands[index]}, result - {r + _eps > sRes && r - _eps < sRes}{Environment.NewLine}");
                        }
                        else
                        {
                            resultInfo = new UTF8Encoding(true).GetBytes($"initial data - {execCommands[index]}, result - {s == result}{Environment.NewLine}");
                        }
                        
                        rfs.Write(resultInfo, 0, resultInfo.Length);
                        
                        index++;
                    }
        }

        private double Calculate(int method, double a, double h, double b, List<double> coeffs)
        {
            double x = 0, S = 0, N = 0;

            switch (method)
            {
                case 1:
                    x = a + h;
                    while (x < b)
                    {
                        S = S + 4 * F(x, coeffs);
                        x += h;
                        if (x >= b) break;
                        S = S + 2 * F (x, coeffs);
                        x += h;
                    }
                    S = (h / 3) * (S + F(a, coeffs) + F(b, coeffs));
                    break;
                case 2:
                    N = Math.Floor((b - 1) / h);
                    S = (F(b, coeffs) - F(a, coeffs)) / 2;
                    x = a + h;
                    for (int i = 1; i < N; i++)
                    {
                        S += F(x, coeffs);
                        x = x + h;
                    }
                    S = S * h;
                    break;
                case 3:
                    Random rnd = new Random(0);
                    N = Math.Floor((b - a) / h);
                    for (int i = 0; i < N; i++)
                    {
                        S += F(a + (rnd.Next(0, 1) * (b - a)), coeffs);
                        S = S / N * (b - a);
                    }
                    break;
            }

            return S;
        }

        private double F(double x, List<double> arr)
        {
            double FS = 0;
            for (int i = 0; i < arr.Count; i++)
                FS += arr[i] * Math.Pow(x, i);

            return FS;
        }
        
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void coefficientsBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private string ProcessErrors(Command command)
        {
            if (!Double.TryParse(command.LeftBorder, out var a))
            {
                return "Левая граница диапазона не является числом!";
            }
            if (!Double.TryParse(command.RightBorder, out var b))
            {
                return "Прававя граница диапазона не является числом!";
            }
            if (a >= b)
            {
                return "Левая граница диапазона должна быть < правой границы диапазона!";
            }
            var h = 0.0;
            if (Double.TryParse(command.Eps, out var dH))
            {
                h = dH;
            }
            if (h < 0.000001 || h > 0.5)
            {
                return "Шаг интегрирования должен быть в пределах [0.000001;0.5]";
            }
            if (command.Method <= 0 || command.Method > 3)
            {
                return "Четвертый параметр определяет метод интегрирования и должен быть в пределах [1;3]";
            }

            return String.Empty;
        }
    }
}