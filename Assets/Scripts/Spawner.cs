using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabs;
    public float spawnrate = 1f;
    public float MinHeight = -1f;
    public float MaxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(spawn), spawnrate, spawnrate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(spawn));
    }

    private void spawn()
    {
        GameObject pipes = Instantiate(prefabs, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up *Random.Range(MinHeight, MaxHeight);  
    
    }

}
