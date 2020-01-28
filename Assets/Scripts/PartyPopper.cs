using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyPopper : MonoBehaviour
{
    public int ParticleCount = 25;

    public float Lifetime = 2f;

    public GameObject PartyPopperParticlePrefab;
    
    private float LifeSoFar;
    private bool Popped;

    private List<GameObject> PartyParticles = new List<GameObject>();
    
    public void Pop()
    {
        LifeSoFar = 0;
        for (int i = 0; i < ParticleCount; i++)
        {
            PartyParticles.Add(GameObject.Instantiate(PartyPopperParticlePrefab, transform, false));
        }
        Popped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Popped == false)
        {
            return;
        }

        LifeSoFar += Time.deltaTime;
        if (LifeSoFar >= Lifetime)
        {
            foreach (GameObject PartyParticle in PartyParticles)
            {
                Destroy(PartyParticle);
            }
            PartyParticles.Clear();
            Popped = false;
        }
    }
}
