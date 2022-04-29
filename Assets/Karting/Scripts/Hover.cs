using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float step;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 InitialPosition = transform.position;
        offset = transform.position.y + transform.localScale.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        step += 0.01f;
        if (step > 999999) { step = 1.0f; };

       
        transform.position = new Vector3( transform.position.x,Mathf.Sin(step) + offset,transform.position.z);
    }
}
