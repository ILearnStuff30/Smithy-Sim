using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject metal, objectContainingMetal;

    // Function to handle changing the parent of the metal depending on if a workstation has it or the user has it, and change its position and rotation
    public void changeMetalHolder(GameObject metalHolder, Vector3 relativePosition, Quaternion relativeRotation)
    {
        objectContainingMetal = metalHolder;
        metal.transform.parent = metalHolder.transform;

        if (metalHolder.tag == "forge")
        {
            metal.transform.position = new Vector3 (0, 0.53f, 0);
        } else if (metalHolder.tag == "anvil")
        {
            metal.transform.position = new Vector3(0f, 0f, 0f);
        } else
        {
            metal.transform.position = new Vector3(0f, 0f, 0f);
        }

        metal.transform.rotation = relativeRotation;

        Debug.Log(metal.transform.position);
    }

    private void Start()
    {
        // Start with making this the parent of the gameobject
        objectContainingMetal.transform.parent = this.transform;
    }

}
