using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBottle : Bottle
{
    private bool isSet = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetIsSet()
    {
        return isSet;
    }
    public void SetIsSet(bool isSet)
    {
        this.isSet = isSet;
    }

    
}
