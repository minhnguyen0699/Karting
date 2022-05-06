using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    private int wallHeallth = 4;
    private Rigidbody[] bricksRb;
    public float explosionForce = 1000.0f;
    public float explosionRad = 3.0f;

    Vector3 hit;
    void Start()
    {
       bricksRb = gameObject.GetComponentsInChildren<Rigidbody>();
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Shell"))
        {
            Debug.Log("shelled");
            Destroy(collision.gameObject);
            wallHeallth -= 1;
            Debug.Log(wallHeallth);

            if (wallHeallth < 1)
            {
                for (int i = 0; i < bricksRb.Length; i++)
                {
                    bricksRb[i].isKinematic = false;
                    bricksRb[i].AddExplosionForce(explosionForce, collision.transform.position, explosionRad);

                }

                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
