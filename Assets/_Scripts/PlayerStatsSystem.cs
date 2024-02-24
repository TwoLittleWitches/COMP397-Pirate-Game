using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatsSystem : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _player;
    [SerializeField] private int _playerHealth = 3;

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
                Debug.Log("Player notified of death. Decrease health.");
                ReducePlayerHealth();
                break;
            case PlayerEnums.Jump:
                Debug.Log("Player notified of jump. Increase score.");
                CalculateStamina();
                break;
            default:
                    break;
        }
        
    }

    private void ReducePlayerHealth()
    {
        _playerHealth -= 1;

        if (_playerHealth <= 0)
        {
            Debug.Log("Player Notified of death");
            SceneController.Instance.ChangeScene("GameOver");
        }
    }

    private void CalculateStamina()
    {
    
    }

    public void SaveGame()
    {
        SaveGameManager.Instance().SaveGame(_player.transform); 
    }

    
}
