using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quenchBucketScript : MonoBehaviour
{
    public void Update()
    {
        if (this.gameObject.GetComponentInChildren<metalScript>() != null)
        {
            GetComponentInChildren<metalScript>().quench();
        }
    }
}
