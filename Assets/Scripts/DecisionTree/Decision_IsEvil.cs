
public class Decision_IsEvil : Decision
{
    private GoblinNeeds goblinInfo;

    public Decision_IsEvil(GoblinNeeds goblinInfo_)
    {
        goblinInfo = goblinInfo_;
    }

    public override bool TestValue()
    {
        if(goblinInfo.personality == personalities.EVIL) //goblin is evil
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
