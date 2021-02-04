using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMachine : MonoBehaviour
{
   
    void Steam()
    {
        FindObjectOfType<AudioManager>().Play("Steam");
    }
}
