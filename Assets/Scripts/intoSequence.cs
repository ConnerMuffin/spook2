using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intoSequence : MonoBehaviour
{
    public GameObject Line1;
    public GameObject Line2;
    public GameObject Line3;
    public GameObject Line4;

    private void Awake()
    {
        Invoke(nameof(sayLine1), 3);
    }
    private void sayLine1()
    {
        Line1.SetActive(true);
        Invoke(nameof(removeLine1), 3);
    }
    private void removeLine1()
    {
        Line1.SetActive(false);
        sayLine2();
    }
    private void sayLine2()
    {
        Line2.SetActive(true);
        Invoke(nameof(removeLine2), 3);
    }
    private void removeLine2()
    {
        Line2.SetActive(false);
        sayLine3();
    }
    private void sayLine3()
    {
        Line3.SetActive(true);
        Invoke(nameof(removeLine3), 7);
    }
    private void removeLine3()
    {
        Line3.SetActive(false);
        sayLine4();
    }
    private void sayLine4()
    {
        Line4.SetActive(true);
        Invoke(nameof(removeLine4), 4);
    }
    private void removeLine4()
    {
        Line4.SetActive(false);
        Invoke(nameof(startGame), 2);
    }
    private void startGame()
    {
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            SceneManager.LoadScene(1);
        }    
    }
}
