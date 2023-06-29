using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAGManager : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public ParticleSystem explosionParticle;
    [Header("Materials")]
    public Material Black;
    public Material Orange;
    public Material Purple;
    public Material Blue;
    public Material White;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    private void Update()
    {
        
    }


    public void TAG()
    {
        if (meshRenderer.material = Black)
        {

        }
        if (meshRenderer.material = White)
        {

        }
        if (meshRenderer.material = Orange)
        {

        }
        if (meshRenderer.material = Blue)
        {

        }
        if (meshRenderer.material = Purple)
        {

        }
    }
}
