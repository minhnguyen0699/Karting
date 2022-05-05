using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Underwater : MonoBehaviour
{
    private GameObject volumeParent;
    private GameObject volume;
    public Rigidbody playerRb;



    // Use this for initialization
    void Start()
    {
        volumeParent = GameObject.Find("Volume");
        volume = volumeParent.transform.Find("PostProcessVolume").gameObject;
        


    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter(Collider other)
    {
        volume.SetActive(true);
        playerRb.useGravity = false;
    }
    private void OnTriggerExit(Collider other)
    {
        volume.SetActive(false);
        playerRb.useGravity = true;
    }

}

