using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [Header ("Get Trigger From")]
    [SerializeField] private GameObject treasure;
    private static BoxCollider treasureCollider;
    [Header("Get Audio From")]
    [SerializeField] private GameObject getSound;
    private static AudioSource playSound;
    private void Awake()
    {
        treasureCollider = treasure.GetComponent<BoxCollider>();
        playSound = getSound.GetComponent<AudioSource>();
    }
    public static void DestroyItem(GameObject currentObject)
    {
        playSound.Play();
        treasureCollider.gameObject.SetActive(false);
    }
}
