using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackTile : MonoBehaviour
{
    
    public float normalForwardSpeed = 1;
    [HideInInspector]
    public static BlackTile bT;
    // Start is called before the first frame update
    void Start()
    {
        bT = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float returnSpeed()
    {
        return normalForwardSpeed;
    }
}
