using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpObjects : MonoBehaviour
{
	public Transform playerView;
	RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 500f))	//after 500f put comma and add layer mask
        {
        	
        }
    }
}
