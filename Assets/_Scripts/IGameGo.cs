public interface IGameGo
{
    bool IsStarted();
    public bool GoalTapStarted
    {
        get;
        set;
    }

    public bool IsDead
    {
        get;
        set;
    }
}
