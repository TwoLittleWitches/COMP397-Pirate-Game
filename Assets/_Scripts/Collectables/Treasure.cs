using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    //[SerializeField] private int treasureCount;
    //public int TreasureCount { get { return treasureCount; } }

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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //treasureCount++;
            playSound.Play();
            treasure.SetActive(false);
            TreasureCalculation.AddTreasure();
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BoxCollider trigger = gameObject.GetComponent<BoxCollider>();
            trigger.enabled = false;
        }
    }

   /*public void TreasureInteraction(GameObject treasureObject)
    {
        playSound.Play();
        treasureObject.gameObject.SetActive(false);
    }*/
}


