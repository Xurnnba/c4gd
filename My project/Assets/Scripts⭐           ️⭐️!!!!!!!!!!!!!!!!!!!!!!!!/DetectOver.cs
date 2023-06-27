using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOver : MonoBehaviour
{



    private void OnCollisionEnter(Collision collision)
    {
        PopOutMessage.pO.ShowMessage();
    }
}
