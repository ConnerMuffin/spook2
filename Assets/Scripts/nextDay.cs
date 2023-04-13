using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextDay : MonoBehaviour
{
    // Update is called once per frame
    public void newDay(int dayChange)
    {
        SceneManager.LoadScene (dayChange);
    }
}
