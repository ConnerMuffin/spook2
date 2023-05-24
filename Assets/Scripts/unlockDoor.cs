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
    public Transform hammer;
    public GameObject breakHand;
    bool holdingHammer;
    public LayerMask breakable;


    // Update is called once per frame
    void Update()
    {
    //Key Unlock Code
         if(PickUpObjects.heldItem == key)
        {
            holdingKey = true;
        }
        else
        {
            holdingKey = false;
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
    //Hammer Break Code
        if(PickUpObjects.heldItem == hammer)
        {
            holdingHammer = true;
        }
        else
        {
            holdingHammer = false;
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, breakable) && holdingHammer)
        {
        	breakHand.SetActive(true);	      	
        }
        else
        {
        	breakHand.SetActive(false);
        }
        if(breakHand.activeSelf && Input.GetButtonDown("Interact") && holdingHammer)
        {
            hit.collider.gameObject.SetActive(false);
        }
    }
}
