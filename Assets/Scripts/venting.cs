using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class venting : MonoBehaviour
{
    public Transform player;
    public LayerMask vent;
    public Transform teleLocIn;
    public Transform teleLocOut;
    public Transform playerView;
    RaycastHit hit;
    bool into = true;
    
    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, vent) && into && Input.GetButtonDown("Interact"))
        {
            player.position = teleLocIn.position;
            into = false;
        }
        if(Physics.Raycast(playerView.position, playerView.forward, out hit, 2.1f, vent) && !into && Input.GetButtonDown("Interact"))
        {
            player.position = teleLocOut.position;
            into = true;
        }
    }
}
