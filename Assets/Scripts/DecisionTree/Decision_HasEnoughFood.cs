
public class Decision_HasEnoughFood : Decision
{
    //needs reference to script with village's food levels

    public override bool TestValue()
    {
        //testing if village's food value is above a certain value
        //if village has enough food, return true, else return false



        return false;
    }

    public override DecisionTreeNode GetBranch()
    {
        if (TestValue()) { return trueNode; }
        else { return falseNode; }
    }
}
