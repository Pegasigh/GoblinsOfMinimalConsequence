
public class Decision_NeedsSocial : Decision
{
    private GoblinNeeds goblinInfo;
    private float socialThreshold;

    public Decision_NeedsSocial(GoblinNeeds goblinInfo_, float socialThreshold_)
    {
        goblinInfo = goblinInfo_;
        socialThreshold = socialThreshold_;
    }

    public override bool TestValue()
    {
        if(goblinInfo.social < socialThreshold) //goblin needs social
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
