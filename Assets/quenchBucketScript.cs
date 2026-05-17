using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class quenchBucketScript : MonoBehaviour
{
    private metalScript metalScript;

    public MMF_Player quenchFeedback;

    public void Update()
    {
        metalScript = this.gameObject.GetComponentInChildren<metalScript>();
        if (this.gameObject.GetComponentInChildren<metalScript>() != null && !metalScript.quenched)
        {
            Debug.Log("Quench");
            quenchFeedback?.PlayFeedbacks();
            GetComponentInChildren<metalScript>().quench();
        }
    }
}
