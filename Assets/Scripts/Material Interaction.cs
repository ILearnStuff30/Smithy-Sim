using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Build.Content;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Declare the scripts for the workstations to access their "materialGameobject" variable
    public ForgeScript forgeScript;
    public AnvilScript anvilScript;
    public WorkbenchScript workbenchScript;
    public GameObject materialContainer;

    private bool hasMaterial, disablePickup = false;
    public bool interactable = true;

    public GameManager gameManager;

    //public void giveWorkstationMaterial(GameObject materialGameObjectForOverlay, GameObject workstationMaterialContainer)
    //{
    //    Debug.Log(workstationMaterialContainer.gameObject.name);
    //    if (workstationMaterialContainer = null)
    //    {
    //        Debug.Log("Dropped off");
    //        workstationMaterialContainer = cloneGameOjbect(materialGameObjectForOverlay);
    //        hasMaterial = false;
    //    } else
    //    {
    //        Debug.Log("Picked up");
    //        materialGameObjectForOverlay = cloneGameOjbect(workstationMaterialContainer);
    //        workstationMaterialContainer = null;
    //        hasMaterial = true;
    //    }
    //}

    // if the player is in range of a colldier
    private void OnTriggerStay(Collider collider)
    {

        // if the tag of whatever we interacted with is the material, is interactable and pickup hasnt been disabled
        if (collider.tag == "material" && Input.GetKey(KeyCode.E) && !disablePickup && interactable) 
        {
            gameManager.changeMetalHolder(this.gameObject, Vector3.zero, -Vector3.forward); // This is wrong!!
            
            Debug.Log("Metal given to player");
        }

        // if the tag of whatever we interacted with is the forge
        if (collider.tag == "forge" && Input.GetKey(KeyCode.E) /*&& interactable*/) 
        {
            gameManager.changeMetalHolder(collider.gameObject, collider.transform.position, new Vector3(collider.transform.rotation.x, collider.transform.rotation.y, collider.transform.rotation.z));
            interactable = false;

            Debug.Log("Metal given to forge");
        }

        // if the tag of whatever we interacted with is the anvil
        if (collider.tag == "anvil" && Input.GetKey(KeyCode.E) && interactable) 
        {
            //giveWorkstationMaterial(materialContainer, anvilScript.materialGameobject);
            interactable = false;
        }

        // if the forge has a material and is interacted with
        //if (collider.tag == "anvil" && Input.GetMouseButtonDown(1) && forgeScript.materialGameobject != null && interactable)
        //{
        //    interactable = false;
        //}

        // if the tag of whatever we interacted with is the workbench
        if (collider.tag == "workbench" && Input.GetKey(KeyCode.E) && interactable) 
        {
            //giveWorkstationMaterial(materialContainer, workbenchScript.materialGameobject);
            interactable = false;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            interactable = true;
        }
    }

    public void Update()
    {

        if (materialContainer != null)
        {
            // If the player has the metal, make it appear in the overlay
            materialContainer.transform.SetParent(transform, false);
            materialContainer.transform.position = Vector3.zero;
        }

    }
}
