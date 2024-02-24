using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [Header ("Get Trigger From")]
    [SerializeField] private GameObject treasure;
    private BoxCollider treasureCollider;
    [Header("Get Audio From")]
    [SerializeField] private GameObject sound;
    private static AudioSource playSound;
    private void Awake()
    {
        treasureCollider = treasure.GetComponent<BoxCollider>();
        playSound = sound.GetComponent<AudioSource>();
    }
    public void TreasureInteraction(GameObject treasureObject)
    {
        playSound.Play();
        treasureObject.gameObject.SetActive(false);
    }
}
