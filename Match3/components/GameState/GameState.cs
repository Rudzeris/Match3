using System.Windows.Controls;

namespace Match3;

public abstract class GameState
{
    public GameState? nextState { get; set; }

    protected Panel panel;
    public GameState(Panel panel)
    {
        this.panel = panel;
    }
    public abstract void Start();
    public abstract void Update();
    public abstract void Stop();
    public static void NextState(ref GameState state)
    {
        if (state.nextState is null)
            return;
        state.Stop();
        state = state.nextState;
        state.Start();
    }
}
