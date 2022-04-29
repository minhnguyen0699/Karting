/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitParticlesOnKartBounce : MonoBehaviour
{

#if UNITY_TEMPLATE_KART

    ParticleSystem p;

    private void Awake() {
        p = GetComponent<ParticleSystem>();
        var kart = GetComponentInParent<KartGame.KartSystems.KartBounce>();

        //TODO:
        //should remove this once the template is fixed.
        //need to clamp capsule size as kart's collider is too big for Bounce to work in the default template.
        var capsule = kart.GetComponent<CapsuleCollider>();
        capsule.height = Mathf.Clamp(capsule.height, 0, 1f);

        kart.OnKartCollision.AddListener(KartCollision_OnExecute);
    }

    void KartCollision_OnExecute() {
        p.Play();
    }


#endif

}
*/



using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(ParticleSystem))]
public class EmitParticlesOnKartBounce : MonoBehaviour
{
    ParticleSystem effect;
    KartBounce vehicleBounce;

    void Awake()
    {
        effect = GetComponent<ParticleSystem>();
        vehicleBounce = GetComponentInParent<KartBounce>();

        Assert.IsNotNull(vehicleBounce, "This particle should be a child of a VehicleBounce!");
    }

    void Update()
    {
        if (vehicleBounce.BounceFlag)
        {
            effect.Play();
        }
    }
}