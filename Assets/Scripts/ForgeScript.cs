using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForgeScript : MonoBehaviour
{
    public float rateOfHeatChange;

    public float forgeTime;

    private metalScript metalScript;


    public void Update()
    {
        metalScript = this.gameObject.GetComponentInChildren<metalScript>();
        if (this.gameObject.GetComponentInChildren<metalScript>() != null)
        {
            Debug.Log("Heating up");
            forgeTime += Time.deltaTime;

            metalScript.heat = Mathf.Pow(Mathf.Exp(1), forgeTime / 15);
            if (metalScript.heat > 50)
            {
                metalScript.stress += Mathf.Pow(Mathf.Exp(1), (metalScript.heat - 70) / 13) * Time.deltaTime;
            }

            Debug.Log("The metal's heat is "+ metalScript.heat);
            // Forging temperature for steel is 1230 degrees celcius
        }


    }
}
