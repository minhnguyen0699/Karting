using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitTeleport : MonoBehaviour
{
    ParticleSystem effect;
    public Teleportation teleport;
   

    void Awake()
    {
        
        effect = GetComponent<ParticleSystem>();
        teleport = GameObject.Find("Portal").GetComponent<Teleportation>();
    }

    void Update()
    {
        PlayEffects();
    }
    void PlayEffects()
    {
        if (teleport.isTeleported)
        {
            
            effect.Play();
            teleport.isTeleported = false;
            
        }
    }
}
