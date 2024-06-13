using System.CodeDom;

namespace Match3.components
{
    internal struct State
    {
        internal int Score { get; private set; } = 0;
        internal void Increment(int x) { Score+=x; }
        private State(int score) => Score = score;
        
    }
}
