using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private float step;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        step += 0.004f*(1.0f * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + step);
    }
}
