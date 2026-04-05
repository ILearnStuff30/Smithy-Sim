using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class metalScript : MonoBehaviour
{
    public float heat = 0;
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
