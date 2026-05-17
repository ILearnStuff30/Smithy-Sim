using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class metalScript : MonoBehaviour
{

    // Measured in degrees celcius. Room temperature is 20-22 degrees Celcius.
    public float heat, stress, completion, delayCount = 0;
    public float rateOfColourChange;

    public bool quenched = false;

    public Color[] colorTargets;
    public Color heatChangeColor;

    private MeshFilter myMeshFilter;
    public Mesh[] completionMeshes;

    public Material metalMaterial;

    public AudioSource myAudioSource;
    public AudioClip breakingClip;

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

        if (completion >= 0f && completion < 10f) {
            myMeshFilter.mesh = completionMeshes[0];
        }
        else if (completion >= 10f && completion < 20f) {
            myMeshFilter.mesh = completionMeshes[1];
        }
        else if (completion >= 20f && completion < 30f) {
            myMeshFilter.mesh = completionMeshes[2];
        }
        else if (completion >= 30f && completion < 40f) {
            myMeshFilter.mesh = completionMeshes[3];
        }
        else if (completion >= 40f && completion < 50f) {
            myMeshFilter.mesh = completionMeshes[4];
        }
        else if (completion >= 50f && completion < 60f) {
            myMeshFilter.mesh = completionMeshes[5];
        }
        else if (completion >= 60f && completion < 70f) {
            myMeshFilter.mesh = completionMeshes[6];
        }
        else if (completion >= 70f && completion < 80f) {
            myMeshFilter.mesh = completionMeshes[7];
        }
        else if (completion >= 80f && completion < 100f)
        {
            myMeshFilter.mesh = completionMeshes[8];
        }
        else if (completion >= 100f) {
            myMeshFilter.mesh = completionMeshes[9];
        }
        else {
            Debug.Log("Error in calculating teperature colour");
        }
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
        myMeshFilter = GetComponent<MeshFilter>();
    }
    private void Update()
    {
        // change the colour of the material
        metalMaterial.color = heatChangeColor;

        // destroy the material if it is too stressed
        if (stress > 100f)
        {
            myAudioSource.PlayOneShot(breakingClip);
            while (delayCount < 2f)
            {
                delayCount += Time.deltaTime;
            }
            delayCount = 0;
            Destroy(this.gameObject);
        }

        // passively decrease the temperature
        if (heat > 0 && !quenched)
        {
            changeHeat(-0.5f * Time.deltaTime);
        }
    }
}
