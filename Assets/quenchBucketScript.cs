using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quenchBucketScript : MonoBehaviour
{
    private metalScript metalScript;

    public void Update()
    {
        metalScript = this.gameObject.GetComponentInChildren<metalScript>();
        if (this.gameObject.GetComponentInChildren<metalScript>() != null && !metalScript.quenched)
        {
            Debug.Log("Quench");
            GetComponentInChildren<metalScript>().quench();
        }
    }
}
