using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpObjects : MonoBehaviour
{
	public Transform playerView;
	RaycastHit hit;
	public GameObject grabHand;
	public GameObject defaultCrossHair;
	public LayerMask inter;
    public bool canChangeDay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 1.5f, inter))	//after 500f put comma and add layer mask
        {
        	grabHand.SetActive(true);	      	
        }
        else
        {
        	grabHand.SetActive(false);
        }
        if(grabHand.activeSelf && Input.GetButtonDown("Fire1"))
        {
            canChangeDay = true;
        }
    }
}
