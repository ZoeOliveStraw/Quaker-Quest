using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{
    [SerializeField] float worldRotation;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0f,worldRotation * Time.deltaTime,0f);
    }
}
