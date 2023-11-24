
public class Decision_NeedsFun : Decision
{
    //needs reference to goblin's needs script

    public override bool TestValue()
    {
        //testing if goblin's fun value is below a certain value
        //if goblin needs fun, return true, else return false



        return false;
    }

    public override DecisionTreeNode GetBranch()
    {
        if (TestValue()) { return trueNode; }
        else { return falseNode; }
    }
}
