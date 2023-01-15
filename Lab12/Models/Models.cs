namespace Lab12.Models {
    public class CalcModel {
        public int num1 { get; set; }
        public int num2 { get; set; }
        public string operation { get; set; }

        public string Calculate() {
            return operation switch {
                "+" => $"{num1} + {num2} = {num1 + num2}",
                "-" => $"{num1} - {num2} = {num1 - num2}",
                "*" => $"{num1} * {num2} = {num1 * num2}",
                "/" when num2 != 0 => $"{num1} / {num2} = {(float)num1 / num2}",
                "/" when num2 == 0 => "Error - деление на ноль!",
                _ => "Error - Неверная операция"
            };
        }

        public string CalculateResult() {
            return operation switch {
                "+" => $"{num1 + num2}",
                "-" => $"{num1 - num2}",
                "*" => $"{num1 * num2}",
                "/" when num2 != 0 => $"{(float)num1 / num2}",
                "/" when num2 == 0 => "Error - деление на ноль!",
                _ => "Error - Неверная операция"
            };
        }
    }
}