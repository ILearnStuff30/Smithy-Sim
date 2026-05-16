using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameManager gameManager;
    public AnvilScript anvilScript;

    // Stores what tags that the user will interact with as workstations
    private string[] workstationTags = { "forge", "anvil", "workbench" };
    public ArrayList collisionTags = new ArrayList();

    // Function to give or take back the metal using collider data, given it matches one of the workstation tags
    public void giveWorkstationMaterial(GameObject targetWorkstation)
    {
        // If the player currently has the metal
        if (gameManager.objectContainingMetal == this.gameObject)
        {
            // Function to tell GameManager who has the metal gameobject.
            gameManager.changeMetalHolder(targetWorkstation, targetWorkstation.transform.position, targetWorkstation.transform.rotation);
        }

        // If the workstation has the material
        // FindGameObjectWithTag returns an array, but were only ever expecting 1 result, hence the array reference
        else if (gameManager.objectContainingMetal == GameObject.FindGameObjectsWithTag(targetWorkstation.tag)[0])
        {
            // Function to tell GameManager who has the metal gameobject.
            gameManager.changeMetalHolder(this.gameObject, Vector3.zero, targetWorkstation.transform.rotation);
        }
    }

    private void Update()
    {

        // Responsible for stopping repeatid true results more than one loop
        bool expectInput = true;

        if (Input.GetKeyDown(KeyCode.E) && expectInput == true)
        {
            // Disallows repeats of this loop until GetKeyUp has been triggered
            expectInput = false;

            // For every tag in collisionTags, check the tag to see if it is a tag associated with a workstation or the material.
            foreach (string tag in collisionTags)
            {
                if (workstationTags.Contains<String>(tag))
                {
                    giveWorkstationMaterial(GameObject.FindGameObjectsWithTag(tag)[0]);
                } else if (tag == "material")
                {
                    gameManager.changeMetalHolder(this.gameObject, Vector3.zero, transform.rotation);
                    collisionTags.Remove("material");
                }
            }
        }
        if (Input.GetMouseButtonDown(0) && expectInput == true)
        {
            foreach (string tag in collisionTags)
            {
                if (tag == "anvil")
                {
                    anvilScript.hammerMaterial();
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            expectInput = true;
        }
    }

    // if the player enters a collider, add the tag of the collider to an ArrayList (unless it is untagged)
    private void OnTriggerStay(Collider collider)
    {
        // Adds the tag of the collider to the ArrayList if it is not "Untagged"
        if (collider.tag != "Untagged")
        {
            // Ensures we aren't adding duplicates to the arraylist
            if (!collisionTags.Contains(collider.tag))
            {
                collisionTags.Add(collider.tag);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        // Remove the tag of the collider to the ArrayList if it is not "Untagged"
        if (collider.tag != "Untagged")
        {
            collisionTags.Remove(collider.tag);
        }
    }
}