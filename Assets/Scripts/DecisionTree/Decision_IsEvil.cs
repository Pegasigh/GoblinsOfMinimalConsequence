
public class Decision_IsEvil : Decision
{
    //needs reference to goblin's personalities script

    public override bool TestValue()
    {
        //testing if goblin is evil
        //if goblin is evil, return true, else return false



        return false;
    }

    public override DecisionTreeNode GetBranch()
    {
        if (TestValue()) { return trueNode; }
        else { return falseNode; }
    }
}
