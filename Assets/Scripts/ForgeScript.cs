using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForgeScript : MonoBehaviour
{
    public float forgeTime;
    private metalScript metalScript;

    public void Update()
    {
        metalScript = this.gameObject.GetComponentInChildren<metalScript>();
        if (this.gameObject.GetComponentInChildren<metalScript>() != null)
        {
            forgeTime += Time.deltaTime;
            // Funciton to increase the metal's temperature faster over time
            metalScript.heat += (Mathf.Pow(Mathf.Exp(1), forgeTime / 15)) / 100;

            if (metalScript.heat > 50)
            {
                // Function to increase the metal's stress faster with more heat
                metalScript.stress += Mathf.Pow(Mathf.Exp(1), (metalScript.heat - 70) / 13) * Time.deltaTime;
            }

        } else
        {
            forgeTime = 0f;
        }
    }
}

// Forging temperature for steel is 1230 degrees celcius