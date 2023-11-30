
public class Decision_NeedsFun : Decision
{
    private GoblinNeeds goblinInfo;
    private float funThreshold;

    public Decision_NeedsFun(GoblinNeeds goblinInfo_, float funThreshold_)
    {
        goblinInfo = goblinInfo_;
        funThreshold = funThreshold_;
    }

    public override bool TestValue()
    {
        if(goblinInfo.fun < funThreshold) //goblin needs fun
        {
            return true;
        }
        return false;
    }

    public override DecisionTreeNode GetBranch()
    {
        if (TestValue()) { return trueNode; }
        else { return falseNode; }
    }
}
