using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootParticleScript : MonoBehaviour
{
    [SerializeField] ParticleSystem BackParticle;
    [SerializeField] ParticleSystem FootParticle;

    int asd;

    private void FixedUpdate()
    {
        asd++;
        if (Input.GetKeyDown(KeyCode.E))
        {
            asd = 0;
            BackParticle.Play();
        }
        if (FootParticle.time >= 30)
        {
            Destroy(this.gameObject);
        }
    }
}
