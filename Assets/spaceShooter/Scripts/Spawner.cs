using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 3f);
    }
    void Spawn()
    {
        Vector3 position = new Vector3(0f, 0f, 0f);
        position.y = Random.Range(4.7f, 5f);
        position.x = Random.Range(-3.25f, 3.61f);
        Instantiate(prefab, position, Quaternion.identity);
    }
}
