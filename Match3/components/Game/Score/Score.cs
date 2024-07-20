using System.Windows.Controls;

namespace Match3;
public class Score
{
    private readonly ContentControl content;
    public Score(ContentControl content)
    {
        this.content = content;
        this.Value = 0;
    }
    private int score;
    public int Value { get => score;
        set
        {
            if (value == 0)
            {
                MaxValue = score>MaxValue?score:MaxValue;
            }
            score = value;
            content.Content = ToString();
        }
    }
    public int MaxValue { get; private set; }
    public override string ToString()
        => $"{Value} / {MaxValue}";
}
