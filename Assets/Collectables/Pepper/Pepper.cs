using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepper : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] int pointValue;
    [SerializeField] GameObject getParticle;

    private void FixedUpdate() 
    {
        transform.Rotate(0f,rotationSpeed * Time.deltaTime,0f);
    }

    private void OnTriggerEnter(Collider col) 
    {
        if(col.gameObject.CompareTag("Player"))
        {
            PepperGet();
        }
    }

    private void PepperGet()
    {
        Instantiate(getParticle,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
