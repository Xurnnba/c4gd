using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearAfterAWhile : MonoBehaviour
{
    public GameObject theText;


    private void Awake()
    {
        StartCoroutine(DeactivateText());
    }

    IEnumerator DeactivateText()
    {
        yield return new WaitForSeconds(4);
        theText.SetActive(false);
    }
}
