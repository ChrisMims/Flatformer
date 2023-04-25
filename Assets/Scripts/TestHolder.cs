using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TestHolder : MonoBehaviour
{
    public NewBehaviourScript newBehaviourScript;
    public BlahhhhhTeeest blahhhhhTeeest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    public void Test()
    {
        newBehaviourScript.Testing("hi");
        newBehaviourScript.TestingDebug();
        blahhhhhTeeest.TestingDebug();
        blahhhhhTeeest.Testing2();
    }
}
