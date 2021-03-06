using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;

public class PlayerRaycast : MonoBehaviour
{

    public float distanceToSee= 3f;
    RaycastHit hitObject;
    PlayerInput interact;
    private Dialogue_Manager dialogueManager;
    private ScriptableObject convoToFeed;
    public static PlayerRaycast _playerRaycast;
    public bool canInteract;
    public static InventoryManager inventoryManager;

    [SerializeField]
    private InventoryObject _inventory;


    public static PlayerRaycast raycastInstance
    {
        get
        {
            return _playerRaycast;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        canInteract = true;
        interact.Player.Interact.performed += _ => DetermineInteraction();
        dialogueManager = FindObjectOfType<Dialogue_Manager>();
        inventoryManager = InventoryManager.instance;
        _inventory = inventoryManager.inventory;
    }

    private void Awake()
    {
        if (_playerRaycast != null && _playerRaycast != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _playerRaycast = this;
        }

        interact = new PlayerInput();
    }

    private void OnEnable()
    {
        interact.Player.Interact.Enable();
    }

    private void OnDisable()
    {
        interact.Player.Interact.Disable();
    }

    public void DetermineInteraction()
    {
        if(Physics.Raycast(this.transform.position, this.transform.forward, out hitObject, distanceToSee))
        {           
            
            Debug.Log("Hit");


            if(hitObject.collider.tag == "Dialogue")
            {
                canInteract = false;
                //interact.Player.Disable();
                dialogueManager.Start_Dialogue(hitObject.collider.GetComponent<SO_Holder>().heldSO);
            }


            if (hitObject.collider.GetComponent<Item>())
            {
                Debug.Log("I am valid");
                var item = hitObject.collider.GetComponent<Item>().heldItem;

                //_inventory.AddItem(hitObject.collider.GetComponent<Item>().heldItem, 1);

                _inventory.AddItem(item, 1);
                Destroy(hitObject.collider.gameObject);
            }



        } else
        {
            Debug.Log("Ooh, I miss");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);
        if(canInteract == true)
        {
            interact.Player.Enable();
        }

        if(canInteract == false)
        {
            interact.Player.Disable();
        }

        if(canInteract == true)
        {
            interact.Player.Enable();
        }

    }

}
