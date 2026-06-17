using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRender;
    public float animationspeed = 1f;
    private void Awake()
    {
        meshRender =  GetComponent <MeshRenderer>() ;
    }

    private void Update()
    {
        meshRender.material.mainTextureOffset += new Vector2(animationspeed * Time.deltaTime, 0);       
    }
}
