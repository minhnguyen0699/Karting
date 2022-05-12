using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollForward : MonoBehaviour
{
    private Rigidbody ballRb;
    [SerializeField]
    private GameObject kart; Vector3 heading;
    public GameObject smExplosion;
    public GameObject bgExplosion;
    Vector3 moveDirectionPush;
    int ballHealth=3;// Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        heading = (kart.transform.position - transform.position).normalized;
        ballRb.AddForce(2000 * heading);
    }
    private void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.CompareTag("Player")) {
            Vector3 lookDirection = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(lookDirection * 10000);
           
        }
        if (collision.gameObject.CompareTag("Shell"))
        {
            transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
            ballHealth --;
            GameObject smallExplosion = Instantiate(smExplosion, collision.transform.position, collision.transform.rotation);

            smallExplosion.GetComponent<ParticleSystem>().Play();
            Destroy(smallExplosion, 1.0f);
            if (ballHealth < 1)
            {
                GameObject bigExplosion = Instantiate(bgExplosion, collision.transform.position, collision.transform.rotation);
                bigExplosion.GetComponent<ParticleSystem>().Play();
                Destroy(bigExplosion, 1.0f);
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }


    }
    
}
