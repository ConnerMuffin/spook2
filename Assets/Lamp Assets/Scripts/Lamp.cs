using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

    public GameObject LampLight;
    public GameObject DomeOff;
    public GameObject DomeOn;

    bool TurnOn;

    public LayerMask lamp;
    RaycastHit hit;
    public Transform playerView;
    
    

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        

        if (Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, lamp) && Input.GetButtonDown("Interact"))
        {
            TurnOn = !TurnOn;
        }
        if (TurnOn== true)
        {
            LampLight.SetActive(true);
            DomeOff.SetActive(false);
            DomeOn.SetActive(true);

        }
        if (TurnOn == false)
        {
            LampLight.SetActive(false);
            DomeOff.SetActive(true);
            DomeOn.SetActive(false);

        }
    }
}
