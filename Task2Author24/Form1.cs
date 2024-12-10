using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2Author24
{
    public partial class Form1 : Form
    {

      

        public Form1()
        {
            InitializeComponent();
        }


        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int n = 7; // длина кода
            int d = 4; // минимальное расстояние
            List<string> codeWords = GenerateCodeWords(n, d);

            // Выводим результаты
            textBoxOutput.Clear();
            foreach (var word in codeWords)
            {
                textBoxOutput.AppendText(word + "\n");
            }
        }

        private List<string> GenerateCodeWords(int n, int d)
        {
            List<string> codeWords = new List<string>();
            int totalWords = (int)Math.Pow(2, n);

            for (int i = 0; i < totalWords; i++)
            {
                string binaryString = Convert.ToString(i, 2).PadLeft(n, '0');
                if (IsValidCodeWord(binaryString, codeWords, d))
                {
                    codeWords.Add(binaryString);
                }
            }

            return codeWords;
        }

        private bool IsValidCodeWord(string newWord, List<string> existingWords, int d)
        {
            foreach (var word in existingWords)
            {
                if (HammingDistance(newWord, word) < d)
                {
                    return false;
                }
            }
            return true;
        }

        private int HammingDistance(string str1, string str2)
        {
            int distance = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    distance++;
                }
            }
            return distance;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
