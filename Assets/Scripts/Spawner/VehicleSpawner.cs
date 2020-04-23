using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject[] vehicles;

    public float timer = 1;
    private void Start()
    {
        timer = UnityEngine.Random.Range(0, 0.3f);
        StartCoroutine(spawner());
    }

    public IEnumerator spawner()
    {
        yield return new WaitForSeconds(timer);
        GameObject vehicleObj = vehicles[UnityEngine.Random.Range(0, vehicles.Length)];
        Instantiate(vehicleObj, transform.position, vehicleObj.transform.rotation);
        timer = UnityEngine.Random.Range(3f, 5f);
        StartCoroutine(spawner());
    }
}
