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
    	public bool canChangeDay;
    
    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, inter))
        {
        	grabHand.SetActive(true);	      	
        }
        else
        {
        	grabHand.SetActive(false);
        }
        if(grabHand.activeSelf && Input.GetButtonDown("Interact"))
        {
        	hit.transform.SetParent(transform);
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
