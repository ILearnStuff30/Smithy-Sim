using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class AnvilScript : MonoBehaviour
{
    public GameManager gameManager;

    public MMF_Player anvilFeedback;

    private metalScript metalScript;

    public void hammerMaterial()
    {
        Debug.Log("Hammered");

        metalScript = GetComponentInChildren<metalScript>();

        anvilFeedback?.PlayFeedbacks();
        // Math to change the stress of the material depending on how hot the weapon is (never changing this by a negative)
        metalScript.stress += Mathf.Max(((0.5f * metalScript.heat) - 12.5f), 0f);
        metalScript.completion += 10f;

        // Function to change the shape of the material

    }
}
