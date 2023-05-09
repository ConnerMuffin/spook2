using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpObjects : MonoBehaviour
{
	public Transform playerView;
	RaycastHit hit;
	public GameObject grabHand;
	public GameObject sleepTime;
	public GameObject defaultCrossHair;
	public LayerMask inter;
	public LayerMask bed;
    public Transform pickUpSlot;
    public bool holdingItem;
    private Transform heldItem;
    public bool canChangeDay;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Drop"))
        {
            heldItem.GetComponent<Rigidbody>().isKinematic = false;
            heldItem.GetComponent<Rigidbody>().useGravity = true;
            heldItem.parent = null;
            heldItem = null;
            holdingItem = false;
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, inter))
        {
        	grabHand.SetActive(true);	      	
        }
        else
        {
        	grabHand.SetActive(false);
        }
        if(grabHand.activeSelf && Input.GetButtonDown("Interact") && !holdingItem)
        {
            heldItem = hit.collider.transform;
        	heldItem.transform.SetParent(pickUpSlot);
            heldItem.transform.position = pickUpSlot.transform.position;
            heldItem.transform.rotation = pickUpSlot.transform.rotation;
            heldItem.GetComponent<Rigidbody>().isKinematic = true;
            heldItem.GetComponent<Rigidbody>().useGravity = false;
            holdingItem = true;
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, bed))
        {
        	sleepTime.SetActive(true);	      	
        }
        else
        {
        	sleepTime.SetActive(false);
        }
        
        if(sleepTime.activeSelf && Input.GetButtonDown("Interact"))
        {
        	canChangeDay = true;
        }

    }
}
