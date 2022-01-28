using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{  
    [SerializeField]private GameObject prefab;
    [SerializeField]private float spawnRate = 1f;
    [SerializeField]private float minHeight = -1f;

    [SerializeField]private float maxHeight = 1f;

    //Doesn't work use onEnable, the pipes won't generate
    // private void onEnable(){
    //     Debug.Log("Enabled is calling");
    //      InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    // }

    private void Start(){
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    
    private void onDisable(){
         CancelInvoke(nameof(Spawn));
    }

    private void Spawn(){
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
