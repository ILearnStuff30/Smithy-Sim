using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class metalScript : MonoBehaviour
{

    // Measured in degrees celcius. Room temperature is 20-22 degrees Celcius.
    public float heat = 21;

    public float stress = 0;

    public Color heatChangeColor;

    public Material metalMaterial;
    public void changeHeat(int heatChange)
    {
        heatChangeColor = Color.Lerp(metalMaterial.color, new Color(255f, 101f, 0f), Mathf.PingPong(0, heat));

        metalMaterial.color = heatChangeColor;
        heat += heatChange;
    }
    public void changeStress(int stressChange)
    {
        stress += stressChange;
    }

    private void Update()
    {
        if (stress > 100f)
        {
            Destroy(this.gameObject);
        }
    }
}
