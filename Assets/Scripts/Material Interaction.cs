using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public ForgeScript forgeScript;
    public AnvilScript anvilScript;
    public WorkbenchScript workbenchScript;
    public GameObject originalMaterialGameObject, materialGameObjectForOverlay;
    // Declare the script for the forge to access it's "hasMaterial" variable

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
        if (collider.tag == "material" && Input.GetKeyDown("E")) // if the tag of whatever we interacted with is the material
        {
            materialGameObjectForOverlay = cloneGameOjbect(collider.gameObject);
            hasMaterial = true;
        }

        if (collider.tag == "forge" && Input.GetKeyDown ("E")) // if the tag of whatever we interacted with is the forge
        {
            giveWorkstationMaterial(materialGameObjectForOverlay, forgeScript.materialGameobject);
        }

        if (collider.tag == "anvil" && Input.GetKeyDown ("E")) // if the tag of whatever we interacted with is the forge
        {
            giveWorkstationMaterial(materialGameObjectForOverlay, anvilScript.materialGameobject);
        }

        if (collider.tag == "workbench" && Input.GetKeyDown ("E")) // if the tag of whatever we interacted with is the forge
        {
            giveWorkstationMaterial(materialGameObjectForOverlay, workbenchScript.materialGameobject);
        }
    }
}
