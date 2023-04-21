using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] clientPrefabs;
    [SerializeField] Transform clientsTransform;

    [SerializeField] float timeToSpawn = 10f;
    [SerializeField] float currentTime = 0;


    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > timeToSpawn)
        {
            SpawnClient();
            currentTime = 0f;
        }
    }

    public void SpawnClient()
    {
        int randomClient = Random.Range(0, 2);
        GameObject client = Instantiate(clientPrefabs[randomClient],clientsTransform);
    }
}
