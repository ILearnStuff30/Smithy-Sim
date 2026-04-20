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

    private string[] workstationTags = { "forge", "anvil", "workbench" };

    public void giveWorkstationMaterial(Collider collider)
    {
        if (gameManager.objectContainingMetal == this.gameObject)
        {

            gameManager.changeMetalHolder(collider.gameObject, collider.transform.position, new Vector3(collider.transform.rotation.x, collider.transform.rotation.y, collider.transform.rotation.z));

            Debug.Log("Metal given to |" + collider.tag + "| from player");

        }
        else if (gameManager.objectContainingMetal == GameObject.FindGameObjectsWithTag(collider.tag)[0])
        // FindGameObjectWithTag returns an array, but were only ever expecting 1 result
        {

            gameManager.changeMetalHolder(this.gameObject, Vector3.zero, -Vector3.forward);

            Debug.Log("Metal given to player from |" + collider.tag + "|");

        }
    }

    // if the player is in range of a colldier
    private void OnTriggerStay(Collider collider)
    {

        // if the tag of whatever we interacted with is the material
        if (collider.tag == "material" && Input.GetKeyDown(KeyCode.E)) 
        {
            gameManager.changeMetalHolder(this.gameObject, Vector3.zero, -Vector3.forward); // This is wrong!!
            
            Debug.Log("Metal given to player from world");
        }

        if (workstationTags.Contains<String>(collider.tag))
        {
            giveWorkstationMaterial(collider);
        }
    }
}
