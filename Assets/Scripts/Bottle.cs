using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;
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
}
