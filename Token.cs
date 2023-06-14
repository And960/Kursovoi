using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoi
{
    public enum TokenType
    {
        INT, DOUBLE, FLOAT, MAIN, WHILE, RCURLY, LCURLY,
        PLUS, MINUS, MULTIPLY, DIVIDE,
        OR, EQUAL, MORE, LESS, COMMA, LPAR, RPAR,PAR,
        IDENTIFIER, LITERAL, NETERM, AND
    }
    public class Token
    {


        public TokenType Type;
        public string Value;
        public Token(TokenType type)
        {
            Type = type;
 
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}", Type, Value);

        }
        static TokenType[] Delimiters = new TokenType[]
        {
            TokenType.PLUS, TokenType.MINUS, TokenType.MULTIPLY,
            TokenType.DIVIDE,TokenType.EQUAL, TokenType.MORE,
            TokenType.LESS, TokenType.COMMA, TokenType.LPAR, TokenType.RPAR, TokenType.PAR
        };
        public static bool IsDelimiter(Token token)
        {
            return Delimiters.Contains(token.Type);
        }
        public static Dictionary<string, TokenType> SpecialWords = new Dictionary<string, TokenType>() {
            {"int", TokenType.INT},
            {"double", TokenType.DOUBLE},
            {"float", TokenType.FLOAT},
            {"main", TokenType.MAIN},
            {"while", TokenType.WHILE},
            {"{", TokenType.LCURLY},
            {"}", TokenType.RCURLY}

        };
        public static bool IsSpecialWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }
            return (SpecialWords.ContainsKey(word));
        }
        public static Dictionary<char, TokenType> SpecialSymbols = new Dictionary<char, TokenType>()
        {
            {'+', TokenType.PLUS},
            {'-', TokenType.MINUS},
            {'*', TokenType.MULTIPLY},
            {'/', TokenType.DIVIDE},
            {'=', TokenType.EQUAL},
            {'>', TokenType.MORE},
            {'<', TokenType.LESS},
            {',', TokenType.COMMA},
            {'(', TokenType.LPAR},
            {')', TokenType.RPAR},
            {';', TokenType.PAR},

        };
        public static bool IsSpecialSymbol(char ch)
        {
            return SpecialSymbols.ContainsKey(ch);
        }
    }
}
