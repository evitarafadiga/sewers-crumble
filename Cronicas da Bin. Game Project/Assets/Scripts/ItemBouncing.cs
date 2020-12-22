using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBouncing : MonoBehaviour
{
    void Update ()
    {
        transform.Rotate (new Vector3 (0,18,0) * Time.deltaTime);

    }

}
