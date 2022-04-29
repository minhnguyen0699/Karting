using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidDir : MonoBehaviour
{
    public GameObject explosionParticel;
    public GameObject smokeParticel;
    public GameObject blastParticel;
    public LayerMask m_PlayerMask;
    private float step;
    private float m_ExplosionRadius = 200.0f;
    private float m_ExplosionForce = 200.0f;
    public bool isDestoyed;
    public Rigidbody playerRb;
   
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameObject.Find("KART").GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        step += 0.5f * (Random.Range(0.1f,1.0f) * Time.deltaTime);

        transform.position = new Vector3(transform.position.x - step, transform.position.y - step, transform.position.z);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("destroy"))
        {
            GameObject explosion = Instantiate(explosionParticel, transform.position, transform.rotation);
            GameObject smoke = Instantiate(smokeParticel, transform.position, transform.rotation);
            GameObject blast = Instantiate(blastParticel, transform.position, transform.rotation);
            explosion.GetComponent<ParticleSystem>().Play();
            smoke.GetComponent<ParticleSystem>().Play();
            blast.GetComponent<ParticleSystem>().Play();
            if (collision.gameObject.CompareTag("Player"))
            {
                playerRb.AddForce(transform.position * 100, ForceMode.Impulse);
            }
                /* Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_PlayerMask);
                 for (int i = 0; i < colliders.Length; i++)
                 {
                     Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
                     if (!targetRigidbody)
                         continue;

                     targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
                     Debug.Log(targetRigidbody);

                 }*/
                Destroy(gameObject);
            Destroy(smoke, 1.5f);
            Destroy(blast, 1.5f);
            Destroy(explosion, 1.5f);
        }
    }
  
    }
