using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class metalScript : MonoBehaviour
{

    // Measured in degrees celcius. Room temperature is 20-22 degrees Celcius.
    public float heat = 21;
    public float stress = 0;

    public void changeHeat(int heatChange)
    {
        heat += heatChange;
    }
    public void changeStress(int stressChange)
    {
        stress += stressChange;
    }
}
