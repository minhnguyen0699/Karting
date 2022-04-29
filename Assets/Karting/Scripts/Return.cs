using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    private GameObject destination;
    private Rigidbody playeRb;
    public Teleportation teleport;
    private GameObject volume;
    private GameObject volume1;
    private GameObject volume2;
    // Start is called before the first frame update
    void Start()
    {
        destination = GameObject.Find("ReturnPos");
        playeRb = GameObject.Find("KART").GetComponent<Rigidbody>();
        teleport = GameObject.Find("Portal").GetComponent<Teleportation>();
        volume = GameObject.Find("volume");
        volume1 = volume.transform.Find("PostProcessVolume").gameObject;
        volume2 = volume.transform.Find("PostProcessVolume2").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        volume1.SetActive(true);
        volume2.SetActive(false);
        teleport.isTeleported = true;
        playeRb.transform.position = destination.transform.position;
        playeRb.transform.rotation = Quaternion.Euler(playeRb.transform.rotation.x, playeRb.transform.rotation.y, playeRb.transform.rotation.z);
    }
}
