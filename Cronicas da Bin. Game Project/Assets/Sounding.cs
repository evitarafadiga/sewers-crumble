using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounding : MonoBehaviour
{
    int oincIndex;
    public static readonly string[] oincs = {"Oinc1, Oinc2, Oinc3, Oinc4, Oinc5, Oinc6, Oinc7, Oinc8, Oinc9, Oinc10, Oinc11, Oinc12, Oinc13, Oinc14"};
    void Oinc () {

        for (int i = 0 ; i < 1 ; i++) {
            oincIndex = Random.Range(0,oincs.Length);
            FindObjectOfType<AudioManager>().Play(oincs[oincIndex]);
        }   
    }

    void Yay () {
        FindObjectOfType<AudioManager>().Play("Yay");
    }
}
