using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopOutMessage : MonoBehaviour
{
    

    public TextMeshProUGUI text;
    public static PopOutMessage pO;
    public void ShowMessage()
    {
        text.gameObject.SetActive(true);
        //StartCoroutine("CloseMessage",2);
        StartCoroutine(CloseMessageCountDown());
    }

    IEnumerator CloseMessageCountDown()
    {
        yield return new WaitForSeconds(7);
        text.gameObject.SetActive(false);
    }
}
