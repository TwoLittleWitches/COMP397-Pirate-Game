using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class AudioData
{
    public string audioName;
    public AudioClip audioClip;
}

public class AudioManager : MonoBehaviour, IObserver
{
[SerializeField] private Subject _player;
[SerializeField] private List<AudioData> _audios = new List<AudioData>();
[SerializeField] private AudioSource _sfxSource;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Subject>();
    }

    void OnEnable()
    {
        _player.AddObserver(this);
    }

    void OnDisable()
    {
        _player.RemoveObserver(this);
    }

    public void OnNotify(PlayerEnums playerEnums)
    {
        switch (playerEnums)
        {
            case PlayerEnums.Died:
                PlayAudioClip("Died");
                break;
            case PlayerEnums.Jump:
                PlayAudioClip("Jump");
                break;
            case PlayerEnums.Run:
                PlayAudioClip("Run");
                break;
            default:
                break;
        
        }
    }

    private void PlayAudioClip(string audioName)
    {
        var clip = _audios.Find(audio => audio.audioName == audioName).audioClip;
        _sfxSource.PlayOneShot(clip);
        
    }

    public void OnNotify()
    {
        throw new System.NotImplementedException();
    }
}