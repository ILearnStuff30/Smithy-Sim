using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject metal, objectContainingMetal;

    // Function to handle changing the parent of the metal depending on if a workstation has it or the user has it, and change its position and rotation
    public void changeMetalHolder(GameObject metalHolder)
    {
        Debug.Log("Metal Holder: " + metalHolder.tag);

        objectContainingMetal = metalHolder;
        metal.transform.parent = metalHolder.transform;

        if (metalHolder.tag == "forge") {
            metal.transform.localPosition = new Vector3(-0.2f, 1.165f, 0f);
            metal.transform.rotation = Quaternion.Euler(90f, 90f, 0f);

        } else if (metalHolder.tag == "Player") {
            metal.transform.localPosition = Vector3.forward;
            metal.transform.rotation = Quaternion.Euler(90f, 80f, -20f);

        } else if (metalHolder.tag == "anvil") {
            metal.transform.localPosition = new Vector3(0f, 0f, 0.65f);
            metal.transform.rotation = Quaternion.Euler(-90f, 0f, 90f);

        } else if (metalHolder.tag == "quench") {
            metal.transform.localPosition = new Vector3(0f, 0.44f, 0f);
            metal.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        // Disables the sphere collider to avoid bugs
        metal.GetComponent<SphereCollider>().enabled = false;

        Debug.Log(metal.transform.rotation);
    }

    private void Start()
    {
        // Start with making this the parent of the gameobject
        objectContainingMetal.transform.parent = this.transform;
    }

}
