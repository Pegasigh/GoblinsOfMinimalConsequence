
public class Decision_HasEnoughFood : Decision
{
    private FoodLevels villageInfo;
    private GoblinNeeds goblinInfo;
    private float hasFoodThreshold;
    private float hasFoodThreshold_productive;

    public Decision_HasEnoughFood(FoodLevels villageInfo_, GoblinNeeds goblinInfo_, float hasFoodThreshold_, float hasFoodThreshold_productive_)
    {
        villageInfo = villageInfo_;
        goblinInfo = goblinInfo_;
        hasFoodThreshold = hasFoodThreshold_;
        hasFoodThreshold_productive = hasFoodThreshold_productive_;
    }

    public override bool TestValue()
    {
        //goblin is productive
        if (goblinInfo.personality == personalities.PRODUCTIVE) 
        {
            if(villageInfo.GetFoodLevels() > hasFoodThreshold_productive) //has enough food
            {
                return true;
            }
            return false;
        }

        //goblin is not productive
        else if(villageInfo.GetFoodLevels() > hasFoodThreshold) //has enough food
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
