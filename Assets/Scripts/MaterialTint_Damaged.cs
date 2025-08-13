using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTint_Damaged : MonoBehaviour
{
    private Material material;
    private Color materialTintColor;
    private float tintFadeSpeed;

    void Start()
    {
        // initiates the variables 
        // puts the material of the enemy to the SetMaterial Method
        materialTintColor = new Color(1, 0, 0, 0f);
        material = gameObject.GetComponent<SpriteRenderer>().material;
        SetMaterial(material);
        tintFadeSpeed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        if(materialTintColor.a > 0)
        {
            materialTintColor.a = Mathf.Clamp01(materialTintColor.a - tintFadeSpeed * Time.deltaTime);
            material.SetColor("_Tint", materialTintColor);
        }
    }


    private void SetMaterial(Material material) 
    {
        this.material = material;
    }

    public void SetTintColor(Color color)
    {
        materialTintColor = color;
        material.SetColor("_Tint", materialTintColor);
    }

    public void SetTintFadeSpeed(float tintFadeSpeed)
    {
        this.tintFadeSpeed = tintFadeSpeed;
    }
        
}
