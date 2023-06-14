using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoi
{
    class lr
    {
        List<Token> tokens = new List<Token>();
        Stack<Token> lexemStack = new Stack<Token>();
        Stack<int> stateStack = new Stack<int>();
        int nextLex = 0;
        int state = 0;
        bool isEnd = false;

        public lr(List<Token> tokens)
        {
            this.tokens = tokens;
        }

        private Token GetLexeme(int nextLex)
        {
            return tokens[nextLex];
        }
        private void Shift()
        {
            if (nextLex == tokens.Count)
                throw new Exception("Список лексем пуст, но анализ не был завершён.");
            if ((lexemStack.Count > 0) && (tokens[nextLex].Type == lexemStack.Peek().Type))
                throw new Exception($"После {ConvertLex(lexemStack.Peek().Type)} не может следовать {ConvertLex(GetLexeme(nextLex).Type)}.");
            lexemStack.Push(GetLexeme(nextLex));
            nextLex++;
        }
        private void GoToState(int state)
        {
            stateStack.Push(state);
            this.state = state;
        }

        private void Reduce(int num, string neterm)
        {
            for (int i = 0; i < num; i++)
            {
                lexemStack.Pop();
                stateStack.Pop();
            }
            state = stateStack.Peek();
            Token k = new Token(TokenType.NETERM);
            k.Value = neterm;
            lexemStack.Push(k);
        }
        public void Start()
        {
            stateStack.Push(0);
            while (isEnd != true)
                switch (state)
                {
                    case 0:
                        State0();
                        break;
                    case 1:
                        State1();
                        break;
                    case 2:
                        State2();
                        break;
                    case 3:
                        State3();
                        break;
                    case 4:
                        State4();
                        break;
                    case 5:
                        State5();
                        break;
                    case 6:
                        State6();
                        break;
                    case 7:
                        State7();
                        break;
                    case 8:
                        State8();
                        break;
                    case 9:
                        State9();
                        break;
                    case 10:
                        State10();
                        break;
                    case 11:
                        State11();
                        break;
                    case 12:
                        State12();
                        break;
                    case 13:
                        State13();
                        break;
                    case 14:
                        State14();
                        break;
                    case 15:
                        State15();
                        break;
                    case 16:
                        State16();
                        break;
                    case 17:
                        State17();
                        break;
                    case 18:
                        State18();
                        break;
                    case 19:
                        State19();
                        break;
                    case 20:
                        State20();
                        break;
                    case 21:
                        State21();
                        break;
                    case 22:
                        State22();
                        break;
                    case 23:
                        State23();
                        break;
                    case 24:
                        State24();
                        break;
                    case 25:
                        State25();
                        break;
                    case 26:
                        State26();
                        break;
                    case 27:
                        State27();
                        break;
                    case 28:
                        State28();
                        break;
                    case 29:
                        State29();
                        break;
                    case 30:
                        State30();
                        break;
                    case 31:
                        State31();
                        break;
                    case 32:
                        State32();
                        break;
                    case 33:
                        State33();
                        break;
                    case 34:
                        State34();
                        break;
                    case 35:
                        State35();
                        break;
                    case 36:
                        State36();
                        break;
                    case 37:
                        State37();
                        break;
                    case 38:
                        State38();
                        break;
                    case 39:
                        State39();
                        break;
                    case 40:
                        State40();
                        break;
                    case 41:
                        State41();
                        break;
                    case 42:
                        State42();
                        break;
                    case 43:
                        State43();
                        break;
                    case 44:
                        State44();
                        break;
                    case 45:
                        State45();
                        break;
                    case 46:
                        State46();
                        break;
                    case 47:
                        State47();
                        break;
                    case 48:
                        State48();
                        break;
                    case 49:
                        State49();
                        break;
                    case 50:
                        State50();
                        break;
                    case 51:
                        State51();
                        break;
                    case 53:
                        State53();
                        break;
                    case 54:
                        State54();
                        break;
                    case 55:
                        State55();
                        break;
                }
        }
        private void State55()
        {
            if (lexemStack.Peek().Type == TokenType.NETERM && lexemStack.Peek().Value == "<Операнд>")
                Reduce(3, "<арифм>");
            else
                Error("<Операнд>");
        }
        private void State54()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<азнак>":
                            Shift();
                            break;
                        case "<Операнд>":
                            GoToState(55);
                            break;
                        default:
                            Error("<Операнд> или <азнак>");
                            break;
                    }
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(36);
                    break;
                case TokenType.LITERAL:
                    GoToState(37);
                    break;
                default:
                    Error("<Операнд>, <Знак>, id, или lit");
                    break;
            }
        }
        private void State53()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Операнд>":
                            switch (GetLexeme(nextLex).Type)
                            {
                                case TokenType.PAR:
                                    Reduce(1, "<арифм>");
                                    break;
                                case TokenType.PLUS://проверить
                                    Shift();
                                    break;
                                default:
                                    Error("<Операнд>");
                                    break;
                            }
                            break;
                        case "<азнак>":
                            GoToState(54);
                            break;
                        default:
                            Error("<Операнд> или <Знак>");
                            break;
                    }
                    break;
                case TokenType.PLUS:
                    GoToState(43);
                    break;
                case TokenType.MINUS:
                    GoToState(44);
                    break;
                case TokenType.MULTIPLY:
                    GoToState(43);
                    break;
                case TokenType.DIVIDE:
                    GoToState(46);
                    break;
                default:
                    Error("<Операнд>, <Знак>, +, -, * или /");
                    break;
            }
        }
        private void State51()
        {
            if (lexemStack.Peek().Type == TokenType.EQUAL)
                Reduce(1, "<Знак>");
            else
                Error("=");
        }

        private void State50()
        {
            if (lexemStack.Peek().Type == TokenType.LESS)
                Reduce(1, "<Знак>");
            else
                Error("<");
        }

        private void State49()
        {
            if (lexemStack.Peek().Type == TokenType.MORE)
                Reduce(1, "<Знак>");
            else
                Error(">");
        }

        private void State48()
        {
            if (lexemStack.Peek().Type == TokenType.NETERM && lexemStack.Peek().Value == "<Операнд>")
                Reduce(3, "<Логик>");
            else
                Error("<Операнд>");
        }

        private void State47()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Знак>":
                            Shift();
                            break;
                        case "<Операнд>":
                            GoToState(48);
                            break;
                        default:
                            Error("<Операнд> или <Знак>");
                            break;
                    }
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(36);
                    break;
                case TokenType.LITERAL:
                    GoToState(37);
                    break;
                default:
                    Error("<Операнд>, <Знак>, id, или lit");
                    break;
            }
        }

        private void State46()
        {
            if (lexemStack.Peek().Type == TokenType.DIVIDE)
                Reduce(1, "<азнак>");
            else
                Error("/");
        }

        private void State45()
        {
            if (lexemStack.Peek().Type == TokenType.MULTIPLY)
                Reduce(1, "<азнак>");
            else
                Error("*");
        }

        private void State44()
        {
            if (lexemStack.Peek().Type == TokenType.MINUS)
                Reduce(1, "<азнак>");
            else
                Error("-");
        }

        private void State43()
        {
            if (lexemStack.Peek().Type == TokenType.PLUS)
                Reduce(1, "<азнак>");
            else
                Error("+");
        }

        private void State42()
        {
            if (lexemStack.Peek().Type == TokenType.NETERM && lexemStack.Peek().Value == "<арифм>")
                Reduce(4, "<Присвоен>");
            else
                Error("<арифм>");
        }

        private void State41()
        {
            
        }

        private void State40()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<арифм>":
                            GoToState(42);
                            break;
                        case "<Операнд>":
                            GoToState(53);
                            break;
                        default:
                            Error("<арифм> или <Операнд>");
                            break;
                    }
                    break;
                case TokenType.EQUAL:
                    Shift();
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(36);
                    break;
                case TokenType.LITERAL:
                    GoToState(37);
                    break;
                
                default:
                    Error("получить =, идентификатор, ариф, операнд или литерал");
                    break;
            }
        }

        private void State39()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.IDENTIFIER:
                    Shift();
                    break;
                case TokenType.EQUAL:
                    GoToState(40);
                    break;
                default:
                    Error("индетификатор или =");
                    break;
            }
        }

        private void State38()
        {
            if (lexemStack.Peek().Type == TokenType.RCURLY)
                Reduce(3, "<Блок операт>");
            else
                Error("}");
        }

        private void State37()
        {
            if (lexemStack.Peek().Type == TokenType.LITERAL)
                Reduce(1, "<Операнд>");
            else
                Error("lit");
        }

        private void State36()
        {
            if (lexemStack.Peek().Type == TokenType.IDENTIFIER)
                Reduce(1, "<Операнд>");
            else
                Error("id");
        }

        private void State35()
        {
            if (lexemStack.Peek().Type == TokenType.NETERM && lexemStack.Peek().Value == "<Оператор>")
                Reduce(1, "<Блок операт>");
            else
                Error("<оператор>");
        }
        private void State34()
        {
            throw new NotImplementedException();
        }
        private void State33()
        {
            throw new NotImplementedException();
        }
        private void State32()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Список операт>":
                            Shift();
                            break;
                        default:
                            Error("<Список операт>");
                            break;
                    }
                    break;
                case TokenType.RCURLY:
                    GoToState(38);
                    break;
                default:
                    Error("<Список операт>  или }");
                    break;
            }
        }
        private void State31()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Список операт>":
                            GoToState(32);
                            break;
                        case "<Оператор>":
                            GoToState(7);
                            break;
                        case "<Объявлен>":
                            GoToState(8);
                            break;
                        case "<Цикл>":
                            GoToState(9);
                            break;
                        case "<Присвоен>":
                            GoToState(10);
                            break;
                        case "<тип2>":
                            GoToState(11);
                                break;
                        case "<тип>":
                            GoToState(13);
                            break;
                        default:
                            Error("<Список операт>, <Оператор>, <Объявлен>, <Цикл>,  <Присвоен>, <Тип>, <Тип2>");
                            break;
                    }
                    break;
                case TokenType.LCURLY:
                    if (GetLexeme(nextLex).Type == TokenType.PAR)
                    {
                        Reduce(0, "<тип>");
                        break;
                    }
                    if (GetLexeme(nextLex).Type == TokenType.IDENTIFIER)
                    {
                        Shift();
                        break;
                    }
                    else
                    {
                        Error("; или ,");
                        break;
                    }
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(13);
                    break;
                case TokenType.INT:
                    GoToState(14);
                    break;
                case TokenType.DOUBLE:
                    GoToState(15);
                    break;
                case TokenType.FLOAT:
                    GoToState(16);
                    break;
                case TokenType.WHILE:
                    GoToState(12);
                    break;
                default:
                    Error("<Список операт>, <Оператор>, <Объявлен>, <Цикл>,  <Присвоен>, <Тип>, <Тип2>, Int, Double, Float, While");
                    break;
            }
        }

        private void State30()
        {
            if (lexemStack.Peek().Type == TokenType.NETERM && lexemStack.Peek().Value == "<Блок операт>")
                Reduce(5, "<Цикл>");
            else
                Error("<Блок операт>");
        }

        private void State29()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Блок операт>":
                            GoToState(30);
                            break;
                        case "<Оператор>":
                            GoToState(35);
                            break;
                        case "<Объявлен>":
                            GoToState(8);
                            break;
                        case "<Цикл>":
                            GoToState(9);
                            break;
                        case "<Присвоен>":
                            GoToState(10);
                            break;
                        case "<тип2>":
                            GoToState(11);
                            break;
                        case "<тип>":
                            GoToState(13);
                            break;
                        default:
                            Error("<Блок операт>, <Оператор>, <Объявлен>, <Цикл>,  <Присвоен>, <Тип>, <Тип2>");
                            break;
                    }
                    break;
                case TokenType.RPAR:
                    if (GetLexeme(nextLex).Type == TokenType.PAR)
                    {
                        Reduce(0, "<тип>");
                        break;
                    }
                    if (GetLexeme(nextLex).Type == TokenType.LCURLY)
                    {
                        Shift();
                        break;
                    }
                    else
                    {
                        Error("; или ,");
                        break;
                    }
                    break;
                case TokenType.LCURLY:
                    GoToState(31);
                    break;
                case TokenType.INT:
                    GoToState(14);
                    break;
                case TokenType.DOUBLE:
                    GoToState(15);
                    break;
                case TokenType.FLOAT:
                    GoToState(16);
                    break;
                case TokenType.WHILE:
                    GoToState(12);
                    break;
                default:
                    Error("<Список операт>, <Оператор>, <Объявлен>, <Цикл>,  <Присвоен>, <Тип>, <Тип2>, Int, Double, Float, While или )");
                    break;
            }
        }

        private void State28()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Операнд>":
                            Shift();
                            break;
                        case "<Знак>":
                            GoToState(47);
                            break;
                        default:
                            Error("<Операнд> или <Знак>");
                            break;
                    }
                    break;
                case TokenType.MORE:
                    GoToState(49);
                    break;
                case TokenType.LESS:
                    GoToState(50);
                    break;
                case TokenType.EQUAL:
                    GoToState(51);
                    break;
                default:
                    Error("<Операнд>, <Знак>, <, >, или =)");
                    break;
            }
        }
        private void State27()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Логик>":
                            Shift();
                            break;
                        default:
                            Error("<Логик>");
                            break;
                    }
                    break;
                case TokenType.RPAR:
                    GoToState(29);
                    break;
                default:
                    Error("<Логик> или )");
                    break;
            }
        }
        private void State26()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Логик>":
                            GoToState(27);
                            break;
                        case "<Операнд>":
                            GoToState(28);
                            break;
                        default:
                            Error("<Логик> или <Операнд>");
                            break;
                    }
                    break;
                case TokenType.LPAR:
                    Shift();
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(36);
                    break;
                case TokenType.LITERAL:
                    GoToState(37);
                    break;
                default:
                    Error("получить (, id, lit");
                    break;
            }
        }

        private void State25()
        {
            if (lexemStack.Peek().Type == TokenType.NETERM && lexemStack.Peek().Value == "<Список>")
                Reduce(3, "<Список>");
            else
                Error("<Список>");
        }

        private void State24()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Список>":
                            GoToState(25);
                            break;
                        default:
                            Error("<Список>");
                            break;
                    }
                    break;
                case TokenType.COMMA:
                    Shift();
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(22);
                    break;
                default:
                    Error("получить <Список>,id или ,");
                    break;
            }
        }

        private void State23()
        {
            if (lexemStack.Peek().Type == TokenType.PAR)
                Reduce(2, "<Оператор>");
            else
                Error("}");
        }

        private void State22()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.IDENTIFIER:

                    if (GetLexeme(nextLex).Type == TokenType.PAR)
                    {
                        Reduce(1, "<Список>");
                        break;
                    }
                    if (GetLexeme(nextLex).Type == TokenType.COMMA)
                    {
                        Shift();
                        break;
                    }
                    else
                    {
                        Error("; или ,");
                        break;
                    }
                case TokenType.COMMA:
                    GoToState(24);
                    break;
                default:
                    Error("Индетификатор или ,");
                    break;
            }
        }

        private void State21()
        {
            if (lexemStack.Peek().Type == TokenType.NETERM && lexemStack.Peek().Value == "<Оператор>")
                Reduce(1, "<Список оператор>");
            else
                Error("<Оператор>");
        }

        private void State20()
        {
            if (lexemStack.Peek().Type == TokenType.NETERM && lexemStack.Peek().Value == "<Список>")
                Reduce(2, "<Объявлен>");
            else
                Error("<Список>");
        }

        private void State19()
        {
            switch (lexemStack.Peek().Type)
            {
               case TokenType.IDENTIFIER:     
                        Reduce(2, "<Объявлен>");
                        break;
               default:
                    Error("получить идентификатор");
               break;
            }
        }

        private void State18()
        {
            if (lexemStack.Peek().Type == TokenType.NETERM && lexemStack.Peek().Value == "<Список операт>")
                Reduce(2, "<Список операт>");
            else
                Error("<Список операт>");
        }

        private void State17()
        {
            if (lexemStack.Peek().Type == TokenType.RCURLY)
                Reduce(6, "<Програм>");
            else
                Error("}");
        }

        private void State16()
        {
            if (lexemStack.Peek().Type == TokenType.FLOAT)
                Reduce(1, "<тип2>");
            else
                Error("float");
        }

        private void State15()
        {
            if (lexemStack.Peek().Type == TokenType.DOUBLE)
                Reduce(1, "<тип2>");
            else
                Error("double");
        }

        private void State14()
        {
            if (lexemStack.Peek().Type == TokenType.INT)
                Reduce(1, "<тип2>");
            else
                Error("int");
        }

        private void State13()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<тип>":
                            Shift();
                            break;
                        default:
                            Error("<тип>");
                            break;
                    }
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(39);
                    break;
                default:
                    Error("получить идентификатор или тип");
                    break;
            }
        }

        private void State12()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.WHILE:
                    Shift();
                    break;
                case TokenType.LPAR:
                    GoToState(26);
                    break;
                default:
                    Error("получить While или (");
                    break;
            }
        }

        private void State11()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<тип2>":
                            switch (GetLexeme(nextLex).Type)
                            {
                                //Нужно смотреть
                                case TokenType.IDENTIFIER:
                                    Shift();
                                    break;
                                case TokenType.INT:
                                    Reduce(1, "<тип>");
                                    break;
                                default:
                                    Error("тип2");
                                    break;
                            }
                            break;
                        case "<Список>":
                            GoToState(20);
                            break;
                        default:
                            Error("<тип2>, <Список>");
                            break;
                    }
                    break;
                case TokenType.IDENTIFIER://смотреть
                    if (GetLexeme(nextLex).Type == TokenType.PAR)
                    {
                        GoToState(19);
                        break;
                    }
                    if (GetLexeme(nextLex).Type == TokenType.COMMA)
                    {
                        GoToState(22);
                        break;
                    }
                    else
                    {
                        Error("; или ,");
                        break;
                    }
                    break;
                default:
                    Error("<тип2>, <Список> или индетификатор");
                    break;
            }
        }

        private void State10()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {

                        case "<Присвоен>":
                                Shift();
                                break;
                        default:
                            Error("<Присвоен>");
                            break;
                    }
                    break;
                case TokenType.PAR:
                    GoToState(23);
                    break;
                default:
                    Error("<Присвоен> или }");
                    break;
            }
        }

        private void State9()
        {
            if (lexemStack.Peek().Type == TokenType.NETERM && lexemStack.Peek().Value == "<Цикл>")
                Reduce(1, "<Оператор>");
            else
                Error("<Цикл>");
        }

        private void State8()
        {
            if (lexemStack.Peek().Type == TokenType.NETERM && lexemStack.Peek().Value == "<Объявлен>")
                Reduce(1, "<Оператор>");
            else
                Error("<Объявлен>");
        }

        private void State7()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Оператор>":
                            //if (nextLex == tokens.Count)
                            //{
                            //    Reduce(1, "<Список операт>");
                            //    break;
                            //}
                            switch (GetLexeme(nextLex).Type)
                            {
                                case TokenType.INT:
                                    Shift();
                                    break;
                                case TokenType.FLOAT:
                                    Shift();
                                    break;
                                case TokenType.DOUBLE:
                                    Shift();
                                    break;
                                case TokenType.WHILE:
                                    Shift();
                                    break;
                                case TokenType.IDENTIFIER:
                                    Reduce(0, "<тип>");
                                    break;
                                case TokenType.RCURLY:
                                    Reduce(1, "<Список операт>");
                                    break;
                                case TokenType.PAR://проверить
                                    Shift();
                                    break;
                                //case TokenType.PLUS://проверить
                                //    Shift();
                                //    break;
                                default:
                                    Error("While, int, float, double, id или {");
                                    break;
                            }
                            break;

                        case "<Список операт>":
                            GoToState(18);
                            break;
                        case "<Объявлен>":
                            GoToState(8);
                            break;
                        case "<Цикл>":
                            GoToState(9);
                            break;
                        case "<Присвоен>":
                            GoToState(10);
                            break;
                        case "<тип2>":
                            GoToState(11);
                            break;
                        case "<тип>":
                            GoToState(13);
                            break;
                        default:
                            Error("<Оператор>,<Объявлен>,<Цикл>,<Присвоен>,<тип2>,<тип> или <Список операт>");
                            break;
                    }
                    break;
                case TokenType.LCURLY:
                    Reduce(1, "<Список операт>");
                    break;
                case TokenType.PAR://проверить
                    Shift();
                    break;
                case TokenType.IDENTIFIER://проверить
                    GoToState(13);
                    break;
                case TokenType.PLUS://проверить
                    GoToState(40);
                    break;
                case TokenType.WHILE:
                    GoToState(12);
                    break;
                case TokenType.INT:
                    GoToState(14);
                    break;
                case TokenType.DOUBLE:
                    GoToState(15);
                    break;
                case TokenType.FLOAT:
                    GoToState(16);
                    break;
                default:
                    Error("<Оператор>, int, float, double, while, id");
                    break;
            }
        }

        private void State6()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        
                        case "<Список операт>":    
                            if (GetLexeme(nextLex).Type == TokenType.RCURLY)
                            {
                                Shift();
                                break;
                            }
                            else
                            {
                                Error("<Список операт>");
                                break;
                            }
                        default:
                            Error("<Список операт>");
                            break;
                    }
                    break;
                case TokenType.RCURLY:
                    GoToState(17);
                    break;
                default:
                    Error("получить <Список операт> или }");
                    break;
            }
        }

        private void State5()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Список операт>":
                            GoToState(6);
                            break;
                        case "<Оператор>":
                            GoToState(7);
                            break;
                        case "<Объявлен>":
                            GoToState(8);
                            break;
                        case "<Цикл>":
                            GoToState(9);
                            break;
                        case "<Присвоен>":
                            GoToState(10);
                            break;
                        case "<тип2>":
                            GoToState(11);
                            break;
                        case "<тип>":
                            GoToState(13);
                            break;
                        default:
                            Error("<Список операт>, <Оператор>, <Объявлен>, <Цикл>, <Присвоен>, <Тип2> или <тип>");
                            break;
                    }
                    break;
                case TokenType.LCURLY:
                    switch (GetLexeme(nextLex).Type)
                    {
                        case TokenType.INT:
                            Shift();
                            break;
                        case TokenType.FLOAT:
                            Shift();
                            break;
                        case TokenType.DOUBLE:
                            Shift();
                            break;
                        case TokenType.IDENTIFIER:
                            Reduce(0, "тип");
                            break;
                        case TokenType.WHILE:
                            Shift();
                            break;
                        default:
                            Error("Int, Float, Double, id, While");
                            break;
                    }
                    break;
                case TokenType.WHILE:
                    GoToState(12);
                    break;
                case TokenType.INT:
                    GoToState(14);
                    break;
                case TokenType.DOUBLE:
                    GoToState(15);
                    break;
                case TokenType.FLOAT:
                    GoToState(16);
                    break;
                default:
                    Error("While, Int, Double, Float или {");
                    break;
            }
        }

        private void State4()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.RPAR:
                    Shift();
                    break;
                case TokenType.LCURLY:
                    GoToState(5);
                    break;
                default:
                    Error("{ или )");
                    break;
            }
        }

        private void State3()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.LPAR:
                    Shift();
                    break;
                case TokenType.RPAR:
                    GoToState(4);
                    break;
                default:
                    Error("( или )");
                    break;
            }
        }

        private void State2()
        {
            switch (lexemStack.Peek().Type)
            {
                case TokenType.MAIN:
                    Shift();
                    break;
                case TokenType.LPAR:
                    GoToState(3);
                    break;
                default:
                    Error("(");
                    break;
            }
        }
        private void State1()
        {
           
        }
        private void State0()
        {
            if (lexemStack.Count == 0)
                Shift();
            switch (lexemStack.Peek().Type)
            {
                case TokenType.NETERM:
                    switch (lexemStack.Peek().Value)
                    {
                        case "<Програм>":
                            if (nextLex == tokens.Count)
                                isEnd = true;
                            break;
                        default:
                            Error("<програм>");
                            break;
                    }
                    break;
                case TokenType.MAIN:
                    GoToState(2);
                    break;
                default:
                    Error("Main");
                    break;
            }
        }
        private void Error(string ojid)
        {
            if (lexemStack.Peek().Type == TokenType.NETERM)
                throw new Exception($"Ожидалось {ojid}, но было получено {lexemStack.Peek().Value}. Состояние:{state}");
            else
                throw new Exception($"Ожидалось {ojid}, но было получено {ConvertLex(lexemStack.Peek().Type)}. Состояние:{state}");
        }

        public static string ConvertLex(TokenType type)
        {
            string s = "";
            switch (type)
            {
                case TokenType.IDENTIFIER:
                    s = "идентификатор";
                    break;
                case TokenType.LITERAL:
                    s = "литерал";
                    break;
                case TokenType.PLUS:
                    s = "+";
                    break;
                case TokenType.MINUS:
                    s = "-";
                    break;
                case TokenType.MULTIPLY:
                    s = "*";
                    break;
                case TokenType.DIVIDE:
                    s = "/";
                    break;
                case TokenType.EQUAL:
                    s = "=";
                    break;
                case TokenType.MORE:
                    s = ">";
                    break;
                case TokenType.LESS:
                    s = "<";
                    break;
                case TokenType.COMMA:
                    s = ",";
                    break;
                case TokenType.LPAR:
                    s = "(";
                    break;
                case TokenType.RPAR:
                    s = ")";
                    break;
                case TokenType.INT:
                    s = "int";
                    break;
                case TokenType.DOUBLE:
                    s = "double";
                    break;
                case TokenType.FLOAT:
                    s = "float";
                    break;
                case TokenType.MAIN:
                    s = "main";
                    break;
                case TokenType.WHILE:
                    s = "while";
                    break;
                case TokenType.RCURLY:
                    s = "}";
                    break;
                case TokenType.LCURLY:
                    s = "{";
                    break;
                default:
                    break;
            }
            return s;
        }
    }
}
