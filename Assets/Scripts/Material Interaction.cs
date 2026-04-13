using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Declare the scripts for the workstations to access their "materialGameobject" variable
    public ForgeScript forgeScript;
    public AnvilScript anvilScript;
    public WorkbenchScript workbenchScript;
    public GameObject materialContainer;

    private bool hasMaterial, pickedUp = false;


    private GameObject cloneGameOjbect(GameObject target)
    {
        GameObject returnGameObject = Instantiate(target);
        Destroy(target);
        return gameObject;
    }

    public void giveWorkstationMaterial(GameObject materialGameObjectForOverlay, GameObject workstationMaterialContainer)
    {

        if (workstationMaterialContainer = null)
        {
            Debug.Log("Dropped off");
            workstationMaterialContainer = cloneGameOjbect(materialGameObjectForOverlay);
            hasMaterial = false;
        } else
        {
            Debug.Log("Picked up");
            materialGameObjectForOverlay = cloneGameOjbect(workstationMaterialContainer);
            workstationMaterialContainer = null;
            hasMaterial = true;
        }
    }

    // if the player is in range of a colldier
    private void OnTriggerStay(Collider collider)
    {
        // if the tag of whatever we interacted with is the material
        if (collider.tag == "material" && Input.GetKey(KeyCode.E) && !pickedUp) 
        {
            materialContainer = collider.gameObject;
            pickedUp = true;
            hasMaterial = true;
        }

        // if the tag of whatever we interacted with is the forge
        if (collider.tag == "forge" && Input.GetKey(KeyCode.E)) 
        {
            giveWorkstationMaterial(materialContainer, forgeScript.materialGameobject);
        }

        // if the tag of whatever we interacted with is the anvil
        if (collider.tag == "anvil" && Input.GetKey(KeyCode.E)) 
        {
            giveWorkstationMaterial(materialContainer, anvilScript.materialGameobject);
        }

        // if the forge has a material and is interacted with
        if (collider.tag == "anvil" && Input.GetMouseButtonDown(1) && forgeScript.materialGameobject != null)
        {

        }

        // if the tag of whatever we interacted with is the workbench
        if (collider.tag == "workbench" && Input.GetKeyDown ("E")) 
        {
            giveWorkstationMaterial(materialContainer, workbenchScript.materialGameobject);
        }
    }

    public void Update()
    {

        if (materialContainer != null)
        {
            // If the player has the metal, make it appear in the overlay
            materialContainer.transform.SetParent(transform, false);
        }

    }
}
