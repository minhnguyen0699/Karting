using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TankShooting : MonoBehaviour
{
    
    public GameObject m_Shell;
    public Transform m_FireTransform;
    public float m_MinLaunchForce = 99999f;
    public float m_MaxLaunchForce = 50f;
    public float m_MaxChargeTime = 0.75f;
    public int bulletsAmount = 10;
    [SerializeField]
    private GameObject textObject;
    private TextMeshProUGUI bulletsText;
    private float m_CurrentLaunchForce;
    private float m_ChargeSpeed;
    

    private void OnEnable()
    {
       
    }


    private void Start()
    {

        bulletsText = textObject.GetComponent<TextMeshProUGUI>();
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }


    private void Update()
    {
        // Track the current state of the fire button and make decisions based on the current launch force.

         if (Input.GetKeyDown(KeyCode.Space) && bulletsAmount >= 1)
        {

            
            m_CurrentLaunchForce = m_MinLaunchForce;
            Fire();
            bulletsAmount--;
        }
        bulletsText.SetText(bulletsAmount.ToString());
    }


    private void Fire()
    {
        // Instantiate and launch the shell.

       
        GameObject shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) ;
        Vector3 velo = GetComponent<Rigidbody>().velocity; // car

        shellInstance.GetComponent<Rigidbody>().velocity = (m_CurrentLaunchForce+ velo.magnitude ) *   (m_FireTransform.forward   + new Vector3(0,0, Random.Range(-0.1f, 0.1f)) );
        
        
        m_CurrentLaunchForce = m_MinLaunchForce;

        Destroy(shellInstance, 3.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AddBullet"))
        {
            bulletsAmount += 10;
            
            Destroy(other.gameObject);
        }
    
    }
}