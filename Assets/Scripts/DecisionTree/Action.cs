
using System.Collections;
using UnityEngine.Analytics;

public abstract class Action : DecisionTreeNode
{
    public override DecisionTreeNode MakeDecision()
    {
        return this;
    }

    public abstract IEnumerator PerformAction();
}
