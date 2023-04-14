using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextDay : MonoBehaviour
{
    pickUpObjects PickUpObjects;
    public int dayChange = 1;

    void Update()
    {
        if(PickUpObjects.canChangeDay == true)
        {
            Debug.Log("NewDay");
        }
    }
}
