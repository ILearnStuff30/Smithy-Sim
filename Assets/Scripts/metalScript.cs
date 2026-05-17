using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class metalScript : MonoBehaviour
{

    // Measured in degrees celcius. Room temperature is 20-22 degrees Celcius.
    public float heat, stress, completion = 0;
    public float heatColorFactor, rateOfColourChange;

    public bool quenched = false;

    public Color[] colorTargets;
    public Color heatChangeColor;

    public Material metalMaterial;


    public void changeHeat(float heatChange)
    { 
        heat += heatChange;

        // Changes the colour of the gameobject depending on the temperature value
        if (heat >= 0f && heat < 10f) {
            heatChangeColor = Color.Lerp(heatChangeColor, colorTargets[0], rateOfColourChange * Time.deltaTime);
        } else if (heat >= 10f && heat < 20f) {
            heatChangeColor = Color.Lerp(heatChangeColor, colorTargets[1], rateOfColourChange * Time.deltaTime);
        } else if (heat >= 20f && heat < 30f) {
            heatChangeColor = Color.Lerp(heatChangeColor, colorTargets[2], rateOfColourChange * Time.deltaTime);
        } else if (heat >= 30f && heat < 40f) {
            heatChangeColor = Color.Lerp(heatChangeColor, colorTargets[3], rateOfColourChange * Time.deltaTime);
        } else if (heat >= 40f && heat < 50f) {
            heatChangeColor = Color.Lerp(heatChangeColor, colorTargets[4], rateOfColourChange * Time.deltaTime);
        } else if (heat >= 50f && heat < 60f) {
            heatChangeColor = Color.Lerp(heatChangeColor, colorTargets[5], rateOfColourChange * Time.deltaTime);
        } else if (heat >= 60f && heat < 70f) {
            heatChangeColor = Color.Lerp(heatChangeColor, colorTargets[6], rateOfColourChange * Time.deltaTime);
        } else if (heat >= 70f && heat < 80f) {
            heatChangeColor = Color.Lerp(heatChangeColor, colorTargets[7], rateOfColourChange * Time.deltaTime);
        } else if (heat >= 80f && heat < 90f) {
            heatChangeColor = Color.Lerp(heatChangeColor, colorTargets[8], rateOfColourChange * Time.deltaTime);
        } else if (heat >= 90f) {
            heatChangeColor = Color.Lerp(heatChangeColor, colorTargets[9], rateOfColourChange * Time.deltaTime);
        } else {
            Debug.Log("Error in calculating teperature colour");
        }
        metalMaterial.color = heatChangeColor;
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

    private void Start()
    {
        heatChangeColor = colorTargets[0];
        
    }
    private void Update()
    {
        // change the colour of the material
        metalMaterial.color = heatChangeColor;

        // destroy the material if it is too stressed
        if (stress > 100f)
        {
            Destroy(this.gameObject);
        }

        // passively decrease the temperature
        if (heat > 0 && !quenched)
        {
            changeHeat(-0.5f * Time.deltaTime);
        }
    }
}
