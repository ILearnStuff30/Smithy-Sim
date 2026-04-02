using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeScript : MonoBehaviour
{
    public float rateOfHeatChange;

    public GameObject materialGameobject;
    public metalScript metalScript;

    private void Start()
    {
        metalScript = materialGameobject.GetComponent<metalScript>();
    }

    public void Update()
    {
        metalScript.heat += rateOfHeatChange + Time.deltaTime;
    }
}
