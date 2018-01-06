using _2NFA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NFA
{
    public class State
    {
        int stateID;
        public State(int stateID, State parent)
        {
            this.Parent = parent;
            this.stateID = stateID;
            nextStates = new List<State>();
        }
        public List<State> nextStates;

        public int StateNumber { get { return stateID; } }

        public State Parent { get; private set; }

        public void AddTransitions(State nextState)
        {
            nextStates.Add(nextState);
        }

        private void Traverse(State state)
        {
            if (state == null)
                return;

            this.Traverse(state.Parent);
            Console.Write(state.stateID + "->");
        }

        public void Traverse()
        {
            Traverse(Parent);
            Console.Write(stateID);
            Console.WriteLine();
        }
    }
}
