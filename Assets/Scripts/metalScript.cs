using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class metalScript : MonoBehaviour
{

    // Measured in degrees celcius. Room temperature is 20-22 degrees Celcius.
    public float heat, stress, completion = 0;
    public float heatColorFactor;

    public bool quenched = false;

    public Color heatChangeColor;
    public Color[] colorTargets;

    public Material metalMaterial;


    public void changeHeat(float heatChange)
    { 
        heat += heatChange;

        if (heat >= 0f && heat < 25f)
        {
            // Lerp current colour to lowest colour
        } else if (heat >= 25f && heat < 50f)
        {

        } else if (heat >= 50f && heat < 75f)
        {

        } else if (heat >= 50f && heat < 100f)
        {

        } else
        {
            Debug.Log("Error in calculating teperature colour");
        }
    }
    public void changeStress(float stressChange)
    {
        stress += stressChange;
    }
    public void changeCompletion(float completionChange)
    {
        completion += completionChange;
    }
    public void quench()
    {
        quenched = true;
        stress += 25f; // The amount of stress that is caused from quenching
        heat = 0f;
    }

    private void Update()
    {
        if (stress > 100f)
        {
            Destroy(this.gameObject);
        }

        if (heat > 0 && !quenched)
        {
            changeHeat(-0.5f * Time.deltaTime);
        }
    }
}
