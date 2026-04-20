using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject metal, objectContainingMetal;

    public void changeMetalHolder(GameObject metalHolder, Vector3 relativePosition, Vector3 relativeRotation)
    {
        objectContainingMetal = metalHolder;
        metal.transform.parent = metalHolder.transform;
        metal.transform.position = relativePosition;
        metal.transform.position = relativeRotation;
    }

    private void Start()
    {
        objectContainingMetal.transform.parent = this.transform;
    }

}
