
public class Decision_IsHungry : Decision
{
    private GoblinNeeds goblinInfo;
    private float hungerThreshold;

    public Decision_IsHungry(GoblinNeeds goblinInfo_, float hungerThreshold_)
    {
        goblinInfo = goblinInfo_;
        hungerThreshold = hungerThreshold_;
    }

    public override bool TestValue()
    {
        if (goblinInfo.hunger < hungerThreshold) //goblin is hungry
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
