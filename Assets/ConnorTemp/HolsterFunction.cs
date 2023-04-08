using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolsterFunction : MonoBehaviour
{
    //Add this function to grab class
    //
    /*
    [SerializeField] GameObject holster = GameObject.FindWithTag("Holster");


    private void HolsterWeapon() {
        //var holster = GameObject.FindWithTag("Holster");

        float distanceToHolster = Vector3.Distance(objectInHand.transform.position, holster.transform.position);

        if (distanceToHolster < .25f) {
            objectInHand.transform.rotation = holster.transform.GetChild(0).transform.rotation;
            objectInHand.transform.position = holster.transform.GetChild(0).transform.position;
        
            objectInHand.GetComponent<Rigidbody>().isKinematic = true;
            objectInHand.transform.parent = holster.transform;
        }
    }
    */
}
