using System;
using System.Collections.Generic;

namespace Lab13.Models {
    public class QuizModel {
        private string[] operations = {"+", "-"};
        private int num1 { get; set; }
        private int num2 { get; set; }
        public string question;
        private int answer;
        public List<string> results { get; set; } = new List<string>();
        public string operation { get; set; }

        public int questionCount = 0;
        public int correctAnswerCount = 0;
        
        public void generateQuestion() {
            Random rand = new Random();

            num1 = rand.Next(0, 201);
            num2 = rand.Next(0,201);

            operation = operations[rand.Next(0,2)];

            switch(operation) {
                case "+":
                    answer = num1 + num2;
                    break;
                case "-":
                    answer = num1 - num2;
                    break;
            };

            question = $"{num1} {operation} {num2} = ";
        }

        public void GetResult(int answer) {
            questionCount++;
            if(answer == this.answer) {
                correctAnswerCount++;
            }
            results.Add($"{question} {answer}");
        }
    }
}