

using UnityEngine.Analytics;

public abstract class Action : DecisionTreeNode
{
    public override DecisionTreeNode MakeDecision()
    {
        return this;
    }

    public abstract void PerformAction();

    // Eat, Sleep, Socialize, Dance, Play Game, Fish, Kill

}
