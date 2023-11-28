using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

/* SOURCE: I USED CHATGPT TO HELP ME START WRITING THIS XML SECTION */
/* SOURCE: https://learn.microsoft.com/en-us/dotnet/api/system.xml.xmlnode.item?view=net-7.0#system-xml-xmlnode-item(system-string) */
/* SOURCE: https://learn.microsoft.com/en-us/dotnet/api/system.xml.xmldocument.documentelement?view=net-8.0 */


public class DecisionTree : MonoBehaviour
{
    private DecisionTreeNode firstNode = null;
    public TextAsset xmlFile;

    // Start is called before the first frame update
    void Start()
    {
        //load xml file
        XmlDocument xmlDoc = new XmlDocument();
        //xmlDoc.Load(xmlFile.text);
        xmlDoc.LoadXml(xmlFile.text);

        //start processing decision tree
        firstNode = ProcessDecision(xmlDoc.DocumentElement);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: look through decision tree, perform action

        //if firstNode is of type Decision, call its function "GetBranch"
        //"GetBranch" returns either another decision or an action
        //if it returns a decision, call its function "GetBranch"
        //keep going until GetBranch returns an action
        //call "PerformAction"

        //in other words: for as long as "GetBranch" returns a decision, keep calling "GetBranch"
    }

    DecisionTreeNode ProcessDecision(XmlNode node)
    {
        //look through children until a decision or action is found, create instance, return instance

        XmlNode currentNode = node;
        currentNode = node["Decision"]; //finds first child element of node with the name "Decision", returns null if no child named "Decision"
        if (currentNode == null)
        {
            currentNode = node["Action"]; //finds first child element of node with the name "Action"
        }

        if(currentNode != null)
        {
            if (currentNode.Name == "Decision")
            {
                Decision currentDecision = CreateDecisionInstance(currentNode.InnerText);

                //get true and false branches
                XmlNode trueNode = currentNode.SelectSingleNode("following-sibling::*[name()='True']");
                XmlNode falseNode = currentNode.SelectSingleNode("following-sibling::*[name()='False']");

                //process true and flase branches
                if (trueNode != null) { currentDecision.trueNode = ProcessDecision(trueNode); }
                if (falseNode != null) { currentDecision.falseNode = ProcessDecision(falseNode); }

                return currentDecision;
            }
            else if (currentNode.Name == "Action")
            {
                return CreateActionInstance(currentNode.InnerText);
            }
        }
        

        return null;
    }

    Decision CreateDecisionInstance(string type)
    {
        if (type == "IsHungry") return new Decision_IsHungry();
        if (type == "HasEnoughFood") return new Decision_HasEnoughFood();
        if (type == "IsTired") return new Decision_IsTired();
        if (type == "NeedsSocial") return new Decision_NeedsSocial();
        if (type == "NeedsFun") return new Decision_NeedsFun();
        if (type == "IsEvil") return new Decision_IsEvil();

        return null;
    }

    Action CreateActionInstance(string type)
    {
        if (type == "Eat") return new Action_Eat();
        if (type == "Sleep") return new Action_Sleep();
        if (type == "Socialize") return new Action_Socialize();
        if (type == "FunEvil") return new Action_FunEvil();
        if (type == "Fun") return new Action_Fun();
        if (type == "Fish") return new Action_Fish();

        return null;
    }
}
