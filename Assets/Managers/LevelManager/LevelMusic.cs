using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] private AudioClip levelMusic;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = levelMusic;
        _source.Play();
    }

    
}
