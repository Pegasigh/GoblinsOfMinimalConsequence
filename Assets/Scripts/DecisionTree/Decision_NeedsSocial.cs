
public class Decision_NeedsSocial : Decision
{
    //needs reference to goblin's needs script

    public override bool TestValue()
    {
        //testing if goblin's social value is below a certain value
        //if goblin needs social, return true, else return false



        return false;
    }

    public override DecisionTreeNode GetBranch()
    {
        if (TestValue()) { return trueNode; }
        else { return falseNode; }
    }
}
