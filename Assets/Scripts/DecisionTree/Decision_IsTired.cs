
public class Decision_IsTired : Decision
{
    //needs reference to goblin's needs script

    public override bool TestValue()
    {
        //testing if goblin's energy value is below a certain value
        //if goblin is tired, return true, else return false



        return false;
    }

    public override DecisionTreeNode GetBranch()
    {
        if (TestValue()) { return trueNode; }
        else { return falseNode; }
    }
}
