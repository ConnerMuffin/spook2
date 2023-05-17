using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockDoor : MonoBehaviour
{
    public Transform playerView;
    RaycastHit hit;
    public GameObject unlockHand;
    public GameObject defaultCrossHair;
    public LayerMask door;
    bool holdingKey;
    public pickUpObjects PickUpObjects;
    public Transform key;


    // Update is called once per frame
    void Update()
    {
         if(PickUpObjects.heldItem == key)
        {
            holdingKey = true;
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, door) && holdingKey)
        {
        	unlockHand.SetActive(true);	      	
        }
        else
        {
        	unlockHand.SetActive(false);
        }
        if(unlockHand.activeSelf && Input.GetButtonDown("Interact") && holdingKey)
        {
            hit.collider.gameObject.SetActive(false);
        }
    }
}
