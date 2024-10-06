using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBottle : Bottle
{
    [SerializeField] private MeshRenderer selectedVisualMesh;
    private bool isSet = false;
    // Start is called before the first frame update
    void Start()
    {
        HideSelected();
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

    public void ShowSelected()
    {
        selectedVisualMesh.enabled = true;
    }

    public void HideSelected()
    {
        selectedVisualMesh.enabled = false;
    }
    
}
