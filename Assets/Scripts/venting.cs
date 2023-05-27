using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class venting : MonoBehaviour
{
    public LayerMask vent;
    public Transform teleLocIn;
    public Transform teleLocOut;
    public Transform playerView;
    RaycastHit hit;
    bool into = true;
    public GameObject ventHand;
    public GameObject unScrewHand;
    bool unScrewed = false;
    bool holdingScrewdriver;
    public pickUpObjects PickUpObjects;
    public Transform screwdriver;
    public LayerMask ventCover;
    
    // Update is called once per frame
    void Update()
    {
        
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, vent) && into && Input.GetButtonDown("Interact") && unScrewed)
        {
            Debug.Log("vented in");
            transform.position = teleLocIn.position;
            into = false;
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, vent) && !into && Input.GetButtonDown("Interact") && unScrewed)
        {
            Debug.Log("vented out");
            transform.position = teleLocOut.position;
            into = true;
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, vent) && unScrewed)
        {
            ventHand.SetActive(true);
        }
        else
        {
            ventHand.SetActive(false);
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, ventCover) && Input.GetButtonDown("Interact") && holdingScrewdriver)
        {
            hit.collider.gameObject.SetActive(false);
            unScrewed = true;
        }
        //Check if holding screwdriver
        if(PickUpObjects.heldItem == screwdriver)
        {
            holdingScrewdriver = true;
        }
        else
        {
            holdingScrewdriver = false;
        }
        //Turn Unscrew text on when look at unscrewed vent
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, ventCover) && !unScrewed && holdingScrewdriver)
        {
            unScrewHand.SetActive(true);
        }
        else
        {
            unScrewHand.SetActive(false);
        }
    }
}
