using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public float m_MinLaunchForce = 15f;
    public float m_MaxLaunchForce = 30f;
    public float m_MaxChargeTime = 0.75f;


   
    private float m_CurrentLaunchForce;
    private float m_ChargeSpeed;
    

    private void OnEnable()
    {
       
    }


    private void Start()
    {
        

        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }


    private void Update()
    {
        // Track the current state of the fire button and make decisions based on the current launch force.
        


        

         if (Input.GetKeyDown(KeyCode.Space))
        {

            
            m_CurrentLaunchForce = m_MinLaunchForce;
            Fire();
            

        }

        else if (Input.GetKeyDown(KeyCode.Space) )
        {
            Fire();
        }
    }


    private void Fire()
    {
        // Instantiate and launch the shell.


        Rigidbody shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward; ;


        m_CurrentLaunchForce = m_MinLaunchForce;

        
    }
}