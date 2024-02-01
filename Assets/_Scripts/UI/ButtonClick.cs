using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    private static AudioSource buttonClickEffect;
    private void Awake()
    {
        buttonClickEffect = GetComponent<AudioSource>();
    }
    public static void playButtonSound()
    {
        Debug.Log("Button Pushed");
        buttonClickEffect.Play();
    }
}
