using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawn : MonoBehaviour
{
    public GameObject key;
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
       key.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(!box.activeSelf)
        {
            key.SetActive(true);
        }
    }
}
