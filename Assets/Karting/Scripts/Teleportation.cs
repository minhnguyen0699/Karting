using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    private GameObject arrival;
    private GameObject volume;
    private GameObject volume1;
    private GameObject volume2;
    private Rigidbody playeRb;
    public bool isTeleported;
    
    // Start is called before the first frame update
    void Start()
    {
        arrival = GameObject.Find("ArivalPos");
        playeRb = GameObject.Find("KART").GetComponent<Rigidbody>();
        volume = GameObject.Find("volume");
        volume1 = volume.transform.Find("PostProcessVolume").gameObject;
        volume2 = volume.transform.Find("PostProcessVolume2").gameObject;
        isTeleported = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        isTeleported = true;
        playeRb.transform.position = arrival.transform.position;
        playeRb.transform.rotation = Quaternion.Euler(playeRb.transform.rotation.x, 0, playeRb.transform.rotation.z);
        volume1.SetActive(false);
        volume2.SetActive(true);

        /* if (isTeleported)*/
        /* {
             isTeleported = false;
             Debug.Log("2:" + isTeleported);
         }*/
    }
}
