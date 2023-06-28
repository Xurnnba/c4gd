using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOver : MonoBehaviour
{



    private void OnTriggerEnter(Collider collision)
    {
        PopOutMessage.pO.ShowMessage();
    }
}
