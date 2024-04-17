using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColors : MonoBehaviour
{
    Renderer _getRenderer;
    public Renderer _borderRenderer;
    int currentWorld;
    public Material[] materials;
    public Material[] borderMaterials;

    // Start is called before the first frame update
    void Start()
    {
        
        _getRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentWorld = ChangeWeapon.currentWeapon;
        SetMaterial();

        /*if (currentWorld == 0)
        {
            _getRenderer.materials[1].SetColor("_ColorDim", Color.red);
        }
        
        if (currentWorld == 1)
        {
            _getRenderer.materials[1].SetColor("_ColorDim", Color.magenta);
        }
        
        if(currentWorld == 2) 
        {
            _getRenderer.materials[1].SetColor("_ColorDim", Color.blue);
        
        
        }*/
        
    }

    void SetMaterial()
    {
        var materialsCopy = _getRenderer.materials;
        materialsCopy[1] = materials[currentWorld];
        _getRenderer.materials = materialsCopy;

        _borderRenderer.sharedMaterial = borderMaterials[currentWorld];
    }
}
