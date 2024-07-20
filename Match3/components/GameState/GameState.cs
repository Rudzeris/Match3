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
    public GameState NextState()
    {
        if (nextState is null)
            return this;

        InfoForNextState();
        StateUpdate();

        return nextState;
    }
    protected virtual void InfoForNextState() { }
    private void StateUpdate()
    {
        Stop();
        nextState?.Start();
    }
}
