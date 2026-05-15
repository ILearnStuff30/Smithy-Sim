using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class FeelMaterial : MonoBehaviour
{
    public MMF_Player materialFeedback;

    public bool isInterpolating;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isInterpolating)
        {
            materialFeedback.Revert();
            //materialFeedback?.PauseFeedbacks();
        }
        else
        {
            materialFeedback.Revert();
            //materialFeedback?.ResumeFeedbacks();
        }
    }
}
