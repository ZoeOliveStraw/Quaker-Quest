using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyrSounds : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] AudioClip[] footsteps;
    [SerializeField] AudioClip[] jumps;
    [SerializeField] AudioClip[] flaps;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void StepSound()
    {
        _source.PlayOneShot(GetRandomClip(footsteps),0.3f);
    }

    private void FlapSound()
    {
        _source.PlayOneShot(GetRandomClip(flaps));
    }

    public void JumpSound()
    {
        _source.PlayOneShot(GetRandomClip(jumps));
    }

    private AudioClip GetRandomClip(AudioClip[] clipArray)
    {
        return clipArray[Random.Range(0,clipArray.Length)];
    }
}
