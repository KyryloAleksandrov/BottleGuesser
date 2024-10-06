using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;
    [SerializeField] Transform checkerRayPosition;
    [SerializeField] LayerMask movableBottleLayerMask; 
    private Color bottleColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(Color color)
    {
        bottleColor = color;
        mesh.material.color = bottleColor;
    }

    public Color GetColor()
    {
        return bottleColor;
    }

    public bool CheckColor()
    {
        if(Physics.Raycast(checkerRayPosition.position, Vector3.up, out RaycastHit hit, movableBottleLayerMask))
        {
            if(hit.transform.TryGetComponent<MovableBottle>(out MovableBottle movableBottle))
            {
                if(this.GetColor() == movableBottle.GetColor())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }
}
