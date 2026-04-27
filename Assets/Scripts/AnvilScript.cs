using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilScript : MonoBehaviour
{
    public GameManager gameManager;

    public void hammerMaterial()
    {
        // Function to change the shape of the material
        GetComponentInChildren<metalScript>().stress += 5f;
    }
}
