using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class AnvilScript : MonoBehaviour
{
    public MMF_Player anvilFeedback;

    private metalScript metalScript;

    public void hammerMaterial()
    {
        Debug.Log(this.gameObject.name);

        if (metalScript != null)
        {
            anvilFeedback?.PlayFeedbacks();
            Debug.Log("Hammered");
            // Math to change the stress of the material depending on how hot the weapon is (never changing this by a negative)
            metalScript.stress += Mathf.Max(((0.5f * metalScript.heat) - 12.5f), 0f);
            if (metalScript.heat > 20f)
            {
                // Math to change the completion based on the temperature of the material
                metalScript.completion += (metalScript.heat - 20) / 4f;
            }

            // Function to change the shape of the material
        }
    }

    private void Update()
    {
        metalScript = this.gameObject.GetComponentInChildren<metalScript>();
    }
}
