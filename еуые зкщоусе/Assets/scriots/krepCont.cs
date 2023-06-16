using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class krepCont : MonoBehaviour
{
    void Start()
    {
        if (DataHolder.StartScore<=1)
        {
            DataHolder.listK.Add(transform.position);
        }
    }
}
