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
    public GameObject howUnlock;
    public GameObject howBreak;
    public GameObject leaveTrigger;


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
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, door))
        {
        	unlockHand.SetActive(true);	      	
        }
        else
        {
        	unlockHand.SetActive(false);
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, door) && Input.GetButtonDown("Interact") && holdingKey)
        {
            hit.collider.gameObject.SetActive(false);
            leaveTrigger.SetActive(true);
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, door) && Input.GetButtonDown("Interact") && !holdingKey)
        {
            howUnlock.SetActive(true);
            Invoke(nameof(fade), 3);
        }
        //Hammer Break Code
        if (PickUpObjects.heldItem == hammer)
        {
            holdingHammer = true;
        }
        else
        {
            holdingHammer = false;
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, breakable))
        {
        	breakHand.SetActive(true);	      	
        }
        else
        {
        	breakHand.SetActive(false);
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, breakable) && Input.GetButtonDown("Interact") && holdingHammer)
        {
            hit.collider.gameObject.SetActive(false);
        }
        if (Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, breakable) && Input.GetButtonDown("Interact") && !holdingHammer)
        {
            howBreak.SetActive(true);
            Invoke(nameof(fade2), 3);
        }
    }
    private void fade()
    {
        howUnlock.SetActive(false);
    }
    private void fade2()
    {
        howBreak.SetActive(false);
    }
}
