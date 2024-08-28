namespace PracticeProblems
{
    public class BalancedBracketsProblem : IBaseProblem
    {
        private string s = "(])";
        public BalancedBracketsProblem()
        {
        }

        public override void Solve()
        {
            Console.WriteLine(IsBalancedBracketSolution() ? "Balanced" : "Not Balanced");
        }

        public bool IsBalancedBracketSolution()
        {
            var stack = new Stack<char>();

            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    stack.Push(s[i]);
                }
                else if(stack.Count == 0)
                {
                    return false;
                }
                else
                {
                    if (s[i] == ')' && stack.First() == '(')
                    {
                        stack.Pop();
                    }
                    else if (s[i] == ']' && stack.First() == '[')
                    {
                        stack.Pop();
                    }
                    else if (s[i] == '}' && stack.First() == '{')
                    {
                        stack.Pop();
                    }
                    else
                        return false;
                }

            }

            if (stack.Count == 0)
            {
                return true;
            }

            return false;
        }

        //here I misunderstood the problem, I though we also had to respect the mathematical rules (i.e. shouldn't open {} inside ()
        public bool IsBalancedBracketSadSolution()
        {
            bool isBalanced = true;
            int round = 0;
            int square = 0;
            int bracket = 0;
            int bracketDegree = 0;

            for (int i = 0; i< s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        if((bracketDegree != 0 && bracketDegree <=3) || (bracketDegree == 0 && round == 0))
                        {
                            round++;
                            bracketDegree = 1;
                        }
                        else
                        {
                            isBalanced = false;
                        }
                        break;

                    case '[':
                        if(bracketDegree == 0 || bracketDegree == 3)
                        {
                            square++;
                            bracketDegree = 2;
                        }
                        else
                        {
                            isBalanced = false;
                        }
                        break;

                    case '{':
                        if (bracketDegree == 0)
                        {
                            bracket++;
                            bracketDegree = 3;
                        }
                        else
                        {
                            isBalanced = false;
                        }
                        break;

                    case ')':
                        if (bracketDegree == 1 && round == 1)
                        {
                            round--;
                            if (square == 0 && bracket == 0)
                                bracketDegree = 0;
                            else if (square == 1)
                                bracketDegree = 2;
                            else if(bracket == 1 && square == 0)
                                bracketDegree = 3;
                        }
                        else
                        {
                            isBalanced = false;
                        }
                        break;

                    case ']':
                        if ((bracketDegree == 2 && square == 1) || bracketDegree == 1 && round == 0)
                        {
                            square--;
                            if (round == 0 && bracket == 0)
                                bracketDegree = 0;
                            else if (bracket == 1)
                                bracketDegree = 3;
                        }
                        else
                        {
                            isBalanced = false;
                        }
                        break;

                    case '}':
                        if ((bracketDegree == 3 && bracket == 1) ||(( bracketDegree == 2 && square == 0) && (bracketDegree == 1 && round == 0) ))
                        {
                            bracket--;
                            if (round == 0 && square == 0)
                                bracketDegree = 0;
                        }
                        else
                        {
                            isBalanced = false;
                        }
                        break;
                }

            }

            return isBalanced;
        }
    }
}
