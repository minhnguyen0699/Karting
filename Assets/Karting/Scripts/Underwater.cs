using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Underwater : MonoBehaviour
{
    private GameObject volume;
    private GameObject volume1;

    // Use this for initialization
    void Start()
    {
        volume = GameObject.Find("Volume");
        volume1 = volume.transform.Find("PostProcessVolume").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter(Collider other)
    {
        volume1.SetActive(true);
    }
   
}

