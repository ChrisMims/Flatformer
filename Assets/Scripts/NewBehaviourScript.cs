using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class NewBehaviourScript : CalculateDamage
{
    public virtual void Testing(string str)
    {
        Debug.Log(str);
        var i = 10;
        Debug.Log("I'm just testing stuff!" + i);
    }
    public virtual void Testing2()
    {
        string str = "hi";
        Debug.Log("Testing2()");
        Testing(str);
    }
    public virtual void TestingDebug()
    {
        Debug.Log("Hello!");
    }
}
public class BlahTest : NewBehaviourScript
{
    public string str;


    [Button("Static")]
    public static void Testing()
    {
        Debug.Log("Changed");
    }
    [Button("Override")]
    public override void Testing(string str)
    {
        base.Testing(str);
    }
    [Button("Override and changed body")]
    public override void Testing2()
    {
        Debug.Log("changed this, too..");
    }
}
public class BlahhhhhTeeest : NewBehaviourScript
{
    string str = "hi...";
    [Button("dd")]
    public override void Testing2()
    {

        Debug.Log("Testing3()");
        base.TestingDebug();
    }
}