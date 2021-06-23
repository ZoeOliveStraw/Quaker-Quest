using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroy : MonoBehaviour
{
    private ParticleSystem _myParticle;

    private void Start() 
    {
        _myParticle = GetComponent<ParticleSystem>();
    }

    private void FixedUpdate() 
    {
        if(_myParticle && !_myParticle.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
