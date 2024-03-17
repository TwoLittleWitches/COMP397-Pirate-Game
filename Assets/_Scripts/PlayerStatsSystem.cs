using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsSystem : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _player;
    [SerializeField] private int _playerHealth = 100;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private TextMeshProUGUI _healthText;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Subject>();
        _healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
        _healthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<TextMeshProUGUI>();
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
        _playerHealth -= 10;
        _healthBar.value = _playerHealth;
        _healthText.text = _playerHealth.ToString() + "%";

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

    public void LoadGame()
    {
        PlayerData data = SaveGameManager.Instance().LoadGame();
        if (data != null)
        {
            Debug.Log("Game data loaded");
            _player.transform.position = JsonUtility.FromJson<Vector3>(data.position);
        }
    }
}
