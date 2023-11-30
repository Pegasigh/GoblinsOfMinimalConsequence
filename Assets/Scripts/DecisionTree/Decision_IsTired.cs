
public class Decision_IsTired : Decision
{
    private GoblinNeeds goblinInfo;
    private float tiredThreshold;

    public Decision_IsTired(GoblinNeeds goblinInfo_, float tiredThreshold_)
    {
        goblinInfo = goblinInfo_;
        tiredThreshold = tiredThreshold_;
    }

    public override bool TestValue()
    {
        if(goblinInfo.energy < tiredThreshold) //goblin is tired
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
