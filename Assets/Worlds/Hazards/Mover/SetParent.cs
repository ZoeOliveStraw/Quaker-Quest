using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    private void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision col) 
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(null);
        }
    }
}
