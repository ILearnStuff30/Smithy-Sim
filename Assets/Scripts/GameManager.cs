using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject metal, objectContainingMetal;

    // Function to handle changing the parent of the metal depending on if a workstation has it or the user has it, and change its position and rotation
    public void changeMetalHolder(GameObject metalHolder, Vector3 relativePosition, Vector3 relativeRotation)
    {
        objectContainingMetal = metalHolder;
        metal.transform.parent = metalHolder.transform;
        metal.transform.position = relativePosition;
        metal.transform.position = relativeRotation;
    }

    private void Start()
    {
        // Start with making this the parent of the gameobject
        objectContainingMetal.transform.parent = this.transform;
    }

}
