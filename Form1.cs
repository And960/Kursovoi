using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovoi
{
    public partial class Razrabotka : Form
    {
        public Razrabotka()
        {
            InitializeComponent();
        }
        List<Token> tokens = new List<Token>();
        private void Load_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Файлы csv (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DataLoad.Clear();
                dataLex.Rows.Clear();
                LoadTxtFile(dialog.FileName);
            }
            textBox1.Clear();
            textBox1.Text = ("Файл успешно загружен");
        }

        private void LoadTxtFile(string fileName)
        {
            DataLoad.Text = File.ReadAllText(fileName, Encoding.Default);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataLex.Rows.Clear();
            try
            {
                //textBox1.Clear();
                if (DataLoad.Text == "")
                {
                    //textBox1.Clear();
                    textBox1.Text = "Загрузите файл или напишите код программы вручную!";
                    DataLoad.Clear();
                    dataLex.Rows.Clear();
                    return;
                }
                //dataLex.Rows.Clear();
                Lexic tp = new Lexic();
                tp.Analysis(@DataLoad.Text);

                foreach (Lex a in tp.lexes)
                {
                    dataLex.Rows.Add();
                    dataLex["Column1", dataLex.Rows.Count - 1].Value = a.Lexema;
                    dataLex["Column2", dataLex.Rows.Count - 1].Value = a.Type;

                }
                //textBox1.Clear();
                textBox1.Text = ("Лексический разбор выполнен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                MessageBox.Show($"Error! {ex.Message}");
                //textBox1.Clear();
                textBox1.Text = ($"Есть ошибочки! { ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            try
            {
                if (DataLoad.Text == "")
                {
                    textBox1.Clear();
                    textBox1.Text = "Загрузите файл или напишите код программы вручную!";
                    return;
                }
                if (dataLex.Rows.Count == 0)
                {
                    textBox1.Clear();
                    textBox1.Text = "Вы не выполнили лексический анализ";
                    return;
                }
                tokens.Clear();
                ListTokenov();
                lr lrgram = new lr(tokens);
                lrgram.Start();

                MessageBox.Show("Разбор завершён!");
                textBox1.Clear();
                textBox1.Text = "Вы успешно написали программу!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                MessageBox.Show($"Error! {ex.Message}");
                textBox1.Clear();
                textBox1.Text = ($"Есть ошибочки! { ex.Message}");
            }
        }

        private void ListTokenov()
        {
            Lexic s = new Lexic();
            s.Analysis(@DataLoad.Text);
            for (int i = 0; i < s.lexes.Count; i++)
            {
                string currentLexem = s.lexes[i].Lexema;
                if (s.lexes[i].Type == "идентификатор")
                {
                    if (Token.IsSpecialWord(s.lexes[i].Lexema))
                    {
                        Token token = new Token(Token.SpecialWords[s.lexes[i].Lexema]);
                        tokens.Add(token);
                    }
                    else
                    {
                        Token token = new Token(TokenType.IDENTIFIER);
                        token.Value = currentLexem;
                        tokens.Add(token);
                    }
                }
                else if (s.lexes[i].Type == "литерал")
                {
                    Token token = new Token(TokenType.LITERAL);
                    token.Value = currentLexem;
                    tokens.Add(token);
                }
                else
                {
                    if (i == s.lexes.Count - 1)
                    {
                        if (Token.IsSpecialSymbol(Convert.ToChar(s.lexes[i].Lexema)))
                        {
                            Token token = new Token(Token.SpecialSymbols[Convert.ToChar(s.lexes[i].Lexema)]);
                            tokens.Add(token);
                        }
                    }
                    else
                    {
                        if (Token.IsSpecialSymbol(Convert.ToChar(s.lexes[i].Lexema)))
                        {

                            Token token = new Token(Token.SpecialSymbols[Convert.ToChar(s.lexes[i].Lexema)]);
                            tokens.Add(token);

                        }
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
