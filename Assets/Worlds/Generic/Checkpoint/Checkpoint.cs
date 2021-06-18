using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private PlayerSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerSpawner>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            spawner.SetCheckpoint(transform);
        }
    }
}
