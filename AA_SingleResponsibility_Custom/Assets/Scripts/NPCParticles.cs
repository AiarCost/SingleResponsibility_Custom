using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCParticles: MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<IHealth>().OnDied += HandleNPCDied;
    }

    private void HandleNPCDied()
    {
        var deathparticle = Instantiate(deathParticlePrefab, transform.position, transform.rotation);
        Destroy(deathparticle, 4f);
    }
}
