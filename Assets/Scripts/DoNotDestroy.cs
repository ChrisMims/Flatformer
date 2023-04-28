using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    [HideInInspector]
    public string objectID;
    private void Awake()
    {
        objectID = name + transform.position.ToString() + transform.eulerAngles.ToString();
    }
    void Start()
    {
        var doNotDestroys = Object.FindObjectsOfType<DoNotDestroy>();
        for (int i = 0; i < doNotDestroys.Length; i++)
        {
            if (doNotDestroys[i] != this)
            {
                if(doNotDestroys[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
