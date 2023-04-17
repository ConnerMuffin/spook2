using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextDay : MonoBehaviour
{
    public pickUpObjects PickUpObjects;
    static int dayChange = 2;

    void Update()
    {
        if(PickUpObjects.canChangeDay == true)
        {
            SceneManager.LoadScene(dayChange);
            PickUpObjects.canChangeDay = false;
            dayChange += 1;
        }
    }
}
