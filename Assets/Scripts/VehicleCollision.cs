using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Vehicle")
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene(0);
        }
    }
}
