using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private Vector3 spawnMinCoords;

    [SerializeField] private Vector3 spawnMaxCoords;

    [SerializeField] private float startDelay;

    [SerializeField] private float spawnRate;

    [SerializeField] private float minTossForce;

    [SerializeField] private float maxTossForce;

    [SerializeField] private float minTorqueForce;

    [SerializeField] private float maxTorqueForce;

    [SerializeField] private List<GameObject> items = new List<GameObject>();

    [SerializeField] private ObjectPool pool;

    void Start()
    {
        InvokeRepeating("SpawnRandomItem", startDelay, spawnRate); // Redo with coroutine
    }

    private void SpawnRandomItem()
    {
        var rndItem = pool.GetNewItem();
        rndItem.SetActive(true);
        Vector3 spawnPosition = new Vector3(Random.Range(spawnMinCoords.x, spawnMaxCoords.x),
                Random.Range(spawnMinCoords.y, spawnMaxCoords.y), 
                Random.Range(spawnMinCoords.z, spawnMaxCoords.z));

        float tossForce = Random.Range(minTossForce, maxTossForce);
        float torqueForce = Random.Range(minTorqueForce, maxTorqueForce);


        rndItem.GetComponent<MeshRenderer>().material.color = Color.white;
        rndItem.transform.position = spawnPosition;

        rndItem.GetComponent<Rigidbody>().velocity = Vector3.zero;

        rndItem.GetComponent<Rigidbody>().AddForce(Vector3.up * tossForce);
        rndItem.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(0, 10f), Random.Range(0, 10f), Random.Range(0, 10f)) * torqueForce);
    }

   
}
