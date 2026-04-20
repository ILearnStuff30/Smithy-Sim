using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForgeScript : MonoBehaviour
{
    public float rateOfHeatChange;

    private metalScript metalScript;

    GameObject materialGameobject;

    private void Awake()
    {
        metalScript = materialGameobject.GetComponent<metalScript>();
    }

    public void Update()
    {
        if(this.gameObject.GetComponentInChildren<metalScript>() != null)
        {
            Debug.Log("Heating up");
            metalScript.heat += rateOfHeatChange + Time.deltaTime;
        }
    }
}
