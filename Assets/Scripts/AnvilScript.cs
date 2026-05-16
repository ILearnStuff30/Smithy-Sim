using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilScript : MonoBehaviour
{
    public GameManager gameManager;

    private metalScript metalScript;

    public void hammerMaterial()
    {
        Debug.Log("Hammered");

        metalScript = GetComponentInChildren<metalScript>();

        // Math to change the stress of the material depending on how hot the weapon is (never changing this by a negative)
        metalScript.stress += Mathf.Max(((0.5f * metalScript.heat) - 12.5f), 0f);
        metalScript.completion += 10f;

        // Function to change the shape of the material

    }
}
