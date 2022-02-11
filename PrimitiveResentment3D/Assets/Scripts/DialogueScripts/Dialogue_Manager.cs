using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{
    [Header("Blank Sound File")]
    public AudioClip Blankshot;

    [Header("Dialogue Variables")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    //public GameObject buttonBlocker;

        [Header("Name Variables")]
    public TextMeshProUGUI npcName;
    [SerializeField]
    private TextMeshProUGUI storedName;
    

    [Header("Portrait Variables")]
    public Image CharPortrait;
    public GameObject CharacterPortrait;
    [SerializeField]
    private Image storedImage;
    
    //    [Header("Deleting Variables")]
    //public bool delete;
    //public GameObject objectToDelete;
    //public GameObject linkedItem;

    [Header("EnableVariables")]
    public bool enable;
    public GameObject objectToEnable;
    public GameObject linkedEnableItem;

    private List<string> conversation;
    private int convoIndex;
    private List<string> npcNameText;
    private int nameIndex;
    private List<Sprite> portraitList;
    private int portraitIndex;
    private List<AudioClip> audioList;
    private int audioIndex;
    private AudioSource audioSource;

    private static Dialogue_Manager dm;
    public InputManager inputManager;
    public PlayerInput playerInput;
    public PlayerRaycast playerRaycast;

    void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        dialoguePanel.SetActive(false);
        inputManager = InputManager.Instance;
        playerRaycast = PlayerRaycast.raycastInstance;
        playerInput = new PlayerInput();

    }

    private void Awake()
    {
        if (dm != null && dm != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            dm = this;
        }
    }

    public static Dialogue_Manager dmInstance
    {
        get
        {
            return dm;
        }
    }


    //Sets portrait, NPC name, activates button blocker, and initiates conversation, is fed by Scriptable Objects
    public void Start_Dialogue(SO_Convo _convo)
    {
       

        //SetPortrait(_convo);
        
        conversation = new List<string>(_convo.myConversation);
        npcNameText = new List<string>(_convo.nameList);
        portraitList = new List<Sprite>(_convo.portraitList);
        audioList = new List<AudioClip>(_convo.audioList);
        dialoguePanel.SetActive(true);
        nameIndex = 0;
        convoIndex = 0;
        portraitIndex = 0;
        audioIndex = 0;
        ShowText();
        inputManager.SwitchMapToDialogue();
    }

    //Sets default image in dialogue box to a portrait
    //public void SetPortrait(SO_Convo _convo)
    //{
    //    //CharPortrait.GetComponent<Image>().sprite = _convo.portrait;

    //    CharPortrait = CharacterPortrait.GetComponent<Image>();
    //    CharPortrait.sprite = _convo.portrait;
    //}


    //Stops conversations, and reverts back to normal gameplay
    public void Stop_Dialogue()
    {
        playerRaycast.canInteract = true;
        inputManager.SwitchMapToPlayer();
        dialoguePanel.SetActive(false);
        
    }


    //Sets dialogue box text to display text. Called in startDialogue function.
    private void ShowText()
    {
        CharPortrait = CharacterPortrait.GetComponent<Image>();

        if(portraitList[portraitIndex] == null)
        {
            CharPortrait = storedImage;
        }
        else if(portraitList[portraitIndex] != null)
        {
            CharPortrait.sprite = portraitList[portraitIndex];
            storedImage = CharPortrait;
        }

        //npcName.text = npcNameText[nameIndex];

        if(npcNameText[nameIndex] == "")
        {
            npcName = storedName;
        } 
        else if(npcNameText[nameIndex] != "")
        {
            npcName.text = npcNameText[nameIndex];
            storedName = npcName;
        }

        //CharPortrait.sprite = portraitList[portraitIndex];

        dialogueText.text = conversation[convoIndex];

        if(audioList[audioIndex] == null)
        {
            audioSource.clip = Blankshot;
        }
        else if(audioList[audioIndex] != null)
        {
            audioSource.clip = audioList[audioIndex];
        }

        audioSource.clip = audioList[audioIndex];
        audioSource.Play();
    }


    //Advances dialogue. Only needed by dialogue box
    public void Next()
    {

        if (convoIndex < conversation.Count - 1)
        {
            nameIndex += 1;
            convoIndex += 1;
            portraitIndex += 1;
            audioIndex += 1;
            ShowText();
        }
        else
        {
            Stop_Dialogue();

        }
    }

}
