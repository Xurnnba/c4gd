using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMap : MonoBehaviour
{
    public GameObject Map;
    public GameObject tip;
    private void OnCollisionEnter(Collision collision)
    {
        Map.SetActive(true);
        tip.SetActive(true);
        StartCoroutine(UnShowMap());
    }


    IEnumerator UnShowMap()
    {
        yield return new WaitForSeconds(3);
        Map.SetActive(false);
        tip.SetActive(false);
    }
}
