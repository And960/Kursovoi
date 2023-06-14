using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovoi
{
    public struct Lex
    {
        public string Lexema;
        public string Type;
        public Lex(string L, string Type)
        {
            this.Lexema = L;
            this.Type = Type;
        }
    }

    public class Lexic
    {
        List<Lex> strokes = new List<Lex>();
        public List<Lex> lexes { get { return strokes; } }
        private static readonly Regex TokenRegex = new Regex(@"\s*(=>|[A-Za-z_][A-Za-z_0-9]*|\d+|\S)");
        public readonly List<Token> Lexemes = new List<Token>();
        private static readonly HashSet<string> Keywords = new HashSet<string>
        {
        "main", "int", "while" , "{","}"
        };

        public void Analysis(string input)
        {
            string buff = string.Empty;
            foreach (Match match in TokenRegex.Matches(input))
            {
                var token = match.Value.Trim();
                if (token == "")
                    continue;

                if (Keywords.Contains(token))
                {
                    strokes.Add(new Lex(token, "идентификатор"));
                    buff = token;
                }
                else if (Regex.IsMatch(token, @"^\d+$"))
                    strokes.Add(new Lex(token, "литерал"));

                else if (Regex.IsMatch(token, @"^[A-Za-z_][A-Za-z_0-9]*$"))
                {
                    int length = token.Length;
                    if (length > 8)
                        throw new Exception("Длина идентификатора превышает 8 символов.");
                    strokes.Add(new Lex(token, "идентификатор"));
                }

                else if (Regex.IsMatch(token, @"^[+*/=><,;:()](\s|\z)"))
                    strokes.Add(new Lex(token, "разделитель"));
                else
                    throw new Exception("Подмножество поддерживает только буквы латинского алфавита.");
            }
        }
    }
}
