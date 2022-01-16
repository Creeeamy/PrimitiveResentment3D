using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static PlayerInput playerInput;
    public static PlayerRaycast playerRaycast;


    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private PlayerInput playerControls;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }


        playerControls = new PlayerInput();
        playerRaycast = PlayerRaycast.raycastInstance;
        //playerInput = GetComponent<PlayerInput>();
    }




    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }


    //I want to fucking change the action map


        public void SwitchMapToDialogue()
    {
        playerControls.Player.Disable();
        playerControls.Dialogue.Enable();
    }

    public void SwitchMapToPlayer()
    {
        playerControls.Dialogue.Disable();
        playerControls.Player.Enable();
    }


    public Dialogue_Manager dm;
    private void Start()
    {
        dm = Dialogue_Manager.dmInstance;
        playerControls.Dialogue.NextText.performed += _ => CycleText();
    }

    void CycleText()
    {
        dm.Next();
    }

}
