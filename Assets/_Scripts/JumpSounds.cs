using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] gruntClips;
    [SerializeField]
    private AudioClip[] landClips;

    private AudioSource jumpsoundAudioSource;

    private void Awake()
    {
        jumpsoundAudioSource = transform.Find("JumpsoundAudioSource").GetComponent<AudioSource>();
    }

    private void Grunt()
    {
        AudioClip clip = GetRandomClip(0);
        if (clip != null)
        {
            jumpsoundAudioSource.PlayOneShot(clip);
        }
    }

    private void Land()
    {
        AudioClip clip = GetRandomClip(1);
        if (clip != null)
        {
            jumpsoundAudioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetRandomClip(int clipType)
    {
        switch (clipType)
        {
            case 0:
                return gruntClips[Random.Range(0, gruntClips.Length)];
            case 1:
                return landClips[Random.Range(0, landClips.Length)];
            default:
                return null;
        }
    }
}