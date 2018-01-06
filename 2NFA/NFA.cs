using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NFA
{
    public class NFA
    {
        List<State> actualStates;

        public NFA()
        {
            actualStates = new List<State>() { new State(0, null) };
        }

        public void Automata(char inputValue)
        {            
            List<State> statesBeforeTransition = new List<State>(actualStates);
            actualStates.Clear();
            foreach (var actualState in statesBeforeTransition)
            {
                switch (actualState.StateNumber)
                {
                    case 0:
                        AddTransition(actualState, 0);
                        if (inputValue == '0')
                            AddTransition(actualState, 1);
                        if (inputValue == '1')
                            AddTransition(actualState, 2);
                        if (inputValue == '2')
                            AddTransition(actualState, 3);
                        if (inputValue == '3')
                            AddTransition(actualState, 4);
                        if (inputValue == '4')
                            AddTransition(actualState, 5);
                        if (inputValue == 'a')
                            AddTransition(actualState, 6);
                        if (inputValue == 'b')
                            AddTransition(actualState, 7);
                        if (inputValue == 'c')
                            AddTransition(actualState, 8);
                        if (inputValue == 'e')
                            AddTransition(actualState, 9);
                        if (inputValue == 'f')
                            AddTransition(actualState, 10);
                        break;
                    case 1:
                        if (inputValue == '0')
                            AddTransition(actualState, 11);
                        break;
                    case 2:
                        if (inputValue == '1')
                            AddTransition(actualState, 11);
                        break;
                    case 3:
                        if (inputValue == '2')
                            AddTransition(actualState, 11);
                        break;
                    case 4:
                        if (inputValue == '3')
                            AddTransition(actualState, 11);
                        break;
                    case 5:
                        if (inputValue == '4')
                            AddTransition(actualState, 11);
                        break;
                    case 6:
                        if (inputValue == 'a')
                            AddTransition(actualState, 12);
                        break;
                    case 7:
                        if (inputValue == 'b')
                            AddTransition(actualState, 12);
                        break;
                    case 8:
                        if (inputValue == 'c')
                            AddTransition(actualState, 12);
                        break;
                    case 9:
                        if (inputValue == 'e')
                            AddTransition(actualState, 12);
                        break;
                    case 10:
                        if (inputValue == 'f')
                            AddTransition(actualState, 12);
                        break;
                    case 11:
                        AddTransition(actualState, 11);
                        break;
                    case 12:
                        AddTransition(actualState, 12);
                        break;
                }                  
            }                       
        }

        public void GetPath()
        {
            int i = 1;
            foreach (var actualState in actualStates)
            {
                Console.WriteLine("Ścieżka nr " + i++);
                actualState.Traverse();

                if (actualState.StateNumber == 11)
                        Console.WriteLine("Wykryto ciąg powtarzających się cyfr.");
                if (actualState.StateNumber == 12)
                    Console.WriteLine("Wykryto ciąg powtarzających się liter.");
            }

            Console.WriteLine();
        }

        private void AddTransition(State actualState, int nextStateID)
        {
            var nextState = new State(nextStateID, actualState);
            actualState.AddTransitions(nextState);
            actualStates.Add(nextState);
        }
    }
}
