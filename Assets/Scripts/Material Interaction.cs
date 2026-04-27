using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor.Build.Content;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameManager gameManager;
    public AnvilScript anvilScript;

    // Stores what tags that the user will interact with as workstations
    private string[] workstationTags = { "forge", "anvil", "workbench" };

    // Function to give or take back the metal using collider data, given it matches one of the workstation tags
    public void giveWorkstationMaterial(Collider collider)
    {
        // If the player currently has the metal
        if (gameManager.objectContainingMetal == this.gameObject)
        {

            // Function to tell GameManager who has the metal gameobject.
            gameManager.changeMetalHolder(collider.gameObject, collider.transform.position, new Vector3(collider.transform.rotation.x, collider.transform.rotation.y, collider.transform.rotation.z));
        }

        // If the workstation has the material
        // FindGameObjectWithTag returns an array, but were only ever expecting 1 result, hence the array reference
        else if (gameManager.objectContainingMetal == GameObject.FindGameObjectsWithTag(collider.tag)[0])
        {

            // Function to tell GameManager who has the metal gameobject.
            gameManager.changeMetalHolder(this.gameObject, Vector3.zero, -Vector3.forward);

        }
    }

    // if the player is in range of a colldier
    private void OnTriggerStay(Collider collider)
    {

        // if the tag of whatever we interacted with is the material
        if (collider.tag == "material" && Input.GetKeyDown(KeyCode.E)) 
        {
            gameManager.changeMetalHolder(this.gameObject, Vector3.zero, -Vector3.forward); // This is inaccurate!
        }

        if (collider.tag == "anvil" && Input.GetMouseButtonDown(0))
        {
            anvilScript.hammerMaterial();
        }

        // if the tag of whatever we interacted with is a workstation
        if (workstationTags.Contains<String>(collider.tag) && Input.GetKeyDown(KeyCode.E))
        {
            giveWorkstationMaterial(collider);
        }
    }
}
