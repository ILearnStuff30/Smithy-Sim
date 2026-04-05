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
    public GameObject originalMaterialGameObject, materialGameObjectForOverlay;

    private bool hasMaterial = false;


    private GameObject cloneGameOjbect(GameObject target)
    {
        GameObject returnGameObject = Instantiate(target);
        Destroy(target);
        return gameObject;
    }

    private void giveWorkstationMaterial(GameObject materialGameObjectForOverlay, GameObject workstationMaterialContainer)
    {

        if (workstationMaterialContainer = null)
        {
            workstationMaterialContainer = cloneGameOjbect(materialGameObjectForOverlay);
            hasMaterial = false;
        } else
        {
            materialGameObjectForOverlay = cloneGameOjbect(workstationMaterialContainer);
            workstationMaterialContainer = null;
            hasMaterial = true;
        }
    }

    // if the player is in range of a colldier
    private void OnTriggerStay(Collider collider)
    {
        // if the tag of whatever we interacted with is the material
        if (collider.tag == "material" && Input.GetKeyDown("E")) 
        {
            materialGameObjectForOverlay = cloneGameOjbect(collider.gameObject);
            hasMaterial = true;
        }

        // if the tag of whatever we interacted with is the forge
        if (collider.tag == "forge" && Input.GetKeyDown ("E")) 
        {
            giveWorkstationMaterial(materialGameObjectForOverlay, forgeScript.materialGameobject);
        }

        // if the tag of whatever we interacted with is the anvil
        if (collider.tag == "anvil" && Input.GetKeyDown ("E")) 
        {
            giveWorkstationMaterial(materialGameObjectForOverlay, anvilScript.materialGameobject);
        }

        // if the forge has a material and is interacted with
        if (collider.tag == "anvil" && Input.GetMouseButtonDown(1) && forgeScript.materialGameobject != null)
        {

        }

        // if the tag of whatever we interacted with is the workbench
        if (collider.tag == "workbench" && Input.GetKeyDown ("E")) 
        {
            giveWorkstationMaterial(materialGameObjectForOverlay, workbenchScript.materialGameobject);
        }
    }
}
