using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 spawnPosPlayer = new Vector3(17.7f, 15.0f, 14.0f);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 5)
        {
            transform.position = spawnPosPlayer;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}