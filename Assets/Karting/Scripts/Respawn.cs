using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject spawnPos;
    void Start()
    {
        spawnPos = GameObject.Find("SpawnPos");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = spawnPos.transform.position;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().transform.rotation =Quaternion.Euler( Vector3.zero);
        }
    }
}