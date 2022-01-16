using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DisableScript : MonoBehaviour
{
    //This exists to disable objects it is attached to when StopDialogue runs

    void suicide()
    {
        Destroy(gameObject);
    }


}
