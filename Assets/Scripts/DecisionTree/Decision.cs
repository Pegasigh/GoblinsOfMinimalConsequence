
public abstract class Decision : DecisionTreeNode
{
    public DecisionTreeNode trueNode;
    public DecisionTreeNode falseNode;

    public override DecisionTreeNode MakeDecision()
    {
        DecisionTreeNode branch = GetBranch();
        return branch;
    }

    public abstract bool TestValue();
    public abstract DecisionTreeNode GetBranch();

}
