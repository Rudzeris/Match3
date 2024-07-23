using System.Windows.Controls;

namespace Match3;
public struct Score
{
    public event EventHandler UpdateScore;
    private int score;
    public int Value
    {
        get => score;
        set
        {
            score = value;
            if (score > MaxValue)
                MaxValue = score;

            UpdateScore?.Invoke(this, EventArgs.Empty);
        }
    }
    public int MaxValue { get; private set; }
    public override string ToString()
        => $"{Value} / {MaxValue}";
}
