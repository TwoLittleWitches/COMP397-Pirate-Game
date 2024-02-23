using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : Subject
{
    #region Private Fields
    PlayerControl _inputs;
    Vector2 _move;
    Camera _camera;
    Vector3 _camForward, _camRight;
    #endregion

    #region Serialized Fields

    [Header("Character Controller")]
    [SerializeField] CharacterController _controller;

    [Header("Movement")]
    [SerializeField] float _speed;
    [SerializeField] float _gravity = -30.0f;
    [SerializeField] float _jumpHeight = 3.0f;
    [SerializeField] Vector3 _velocity;

    [Header("Ground Detection")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundRadius = 0.5f;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] bool _isGrounded;

    [Header("Respawn Transform")]
    [SerializeField] Transform _respawn;
    #endregion

    void Awake()
    {
        _camera = Camera.main;
        _controller = GetComponent<CharacterController>();

        // from InputSettings/PlayerControl api
        _inputs = new PlayerControl();
        //_inputs.Player.Move.performed += context => DebugMessage(context);
        _inputs.Player.Move.performed += context => _move = context.ReadValue<Vector2>();
        _inputs.Player.Move.canceled += context => _move = Vector2.zero;
        _inputs.Player.Jump.performed += context => Jump();
    }

    void OnEnable()
    {
        _inputs.Enable();
    }

    void OnDisable() => _inputs.Disable();

    void FixedUpdate()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundMask);
        if (_isGrounded && _velocity.y < 0.0f)
        {
            _velocity.y = -2.0f;

        }

        _camForward = _camera.transform.forward;
        _camRight = _camera.transform.right;
        _camForward.y = 0.0f;
        _camRight.y = 0.0f;
        _camForward.Normalize();
        _camRight.Normalize();

        Vector3 movement = (_camRight * _move.x + _camForward * _move.y) * _speed * Time.fixedDeltaTime;
        if(!_controller.enabled) return; // if controller is not enabled, return (stop movement
        _controller.Move(movement);
        _velocity.y += _gravity * Time.fixedDeltaTime;
        _controller.Move(_velocity * Time.fixedDeltaTime);
    } 

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundRadius);
    }

    void Jump()
    {
        if(_isGrounded)
        {
            Debug.Log("Jumping");  
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
            NotifyObservers(PlayerEnums.Jump);
        } else { 
            Debug.Log("Not Grounded");
        }
    }

    void DebugMessage(InputAction.CallbackContext context)
    {
        Debug.Log($"Moved Performed {context.ReadValue<Vector2>().x}, {context.ReadValue<Vector2>().y}");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Colliding with {other.tag}");
        if(other.CompareTag("DeathZone"))
        {
            // stop any movement from controller in order to move/transform, then enable controller again
            _controller.enabled = false;
            //transform.position = new Vector3(0.0f, 1.0f, 0.0f); //_respawnTransform.position & player start point
            transform.position = _respawn.position;
            _controller.enabled = true;

            NotifyObservers(PlayerEnums.Died);
            
        }
    }


   

}



/* using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : Subject
{
    PlayerControl _inputs;
    Vector2 _move;

    [Header("Character Controller")]
    [SerializeField] CharacterController _controller;

    [Header("Movement")]
    [SerializeField] float _speed;
    [SerializeField] float _gravity = -30.0f;
    [SerializeField] float _jumpHeight = 3.0f;
    [SerializeField] Vector3 _velocity;

    [Header("Ground Detection")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundRadius = 0;
    [SerializeField] LayerMask _groundMasks;
    [SerializeField] bool _isGrounded;

    [Header("Respawn Transform")]
    [SerializeField] Transform _respawn;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _inputs = new PlayerControl();
        _inputs.Player.Move.performed += context => _move = context.ReadValue<Vector2>();
        _inputs.Player.Move.canceled += context => _move = Vector2.zero;
        _inputs.Player.Jump.performed += context => Jump();
        _inputs.Player.Pause.performed += context => TogglePause();
    }
    void OnEnable()
    {
        _inputs.Enable();
    }

    void OnDisable() => _inputs.Disable();

    void FixedUpdate()
    {
        // Stops running if game is currently paused 
        if (Time.timeScale == 0)
            return;

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundMasks);
        if (_isGrounded && _velocity.y < 0.0f)
        {
            _velocity.y = -2.0f;
        }
        Vector3 movement = new Vector3(_move.x, 0.0f, _move.y) * _speed * Time.fixedDeltaTime;
        _controller.Move(movement);
        _velocity.y += _gravity * Time.fixedDeltaTime;
        _controller.Move(_velocity * Time.fixedDeltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundRadius);
    }

    void Jump()
    {
        if (_isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
        }
    }

    void DebugMessage(InputAction.CallbackContext context)
    {
        Debug.Log($"Move Performed {context.ReadValue<Vector2>().x}, {context.ReadValue<Vector2>().y}");
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Colliding with {other.tag}");
        if (other.CompareTag("deathZone"))
        {
            //MainMenu.GameOver();
            _controller.enabled = false;
            transform.position = _respawn.position;
            _controller.enabled = true;
            //NotifyObservers();
        }
        if (other.CompareTag("Treasure")) Treasure.DestroyItem(other.gameObject);
    }

    void TogglePause()
    {
    if (Time.timeScale == 0) {
        Debug.Log($"Game resumed.");
        Time.timeScale = 1; // Resume 
    } else {
        Debug.Log($"Game paused.");
        Time.timeScale = 0; // Pause 
    }
  }
}
*/