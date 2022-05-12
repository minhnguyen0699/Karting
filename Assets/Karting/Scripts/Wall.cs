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
    public GameObject smExplosion;
    public GameObject bgExplosion;

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
            
            GameObject smallExplosion = Instantiate(smExplosion, collision.transform.position, collision.transform.rotation);
            
            smallExplosion.GetComponent<ParticleSystem>().Play();
            Destroy(smallExplosion, 1.0f);
            wallHeallth -= 1;
            if (wallHeallth < 1)
            {
                GameObject bigExplosion = Instantiate(bgExplosion, collision.transform.position, collision.transform.rotation);
                bigExplosion.GetComponent<ParticleSystem>().Play();
               
                for (int i = 0; i < bricksRb.Length; i++)
                {
                    bricksRb[i].isKinematic = false;
                    bricksRb[i].AddExplosionForce(explosionForce, collision.transform.position, explosionRad);
                    
                }
                Destroy(bigExplosion, 1.0f);
                Destroy(gameObject, 5.0f);
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            Destroy(collision.gameObject);
        }
    }


}
