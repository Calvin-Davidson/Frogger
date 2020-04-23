using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public float followSpeed;
    public GameObject PlayerObj;
    void Update()
    {
        float dir = PlayerObj.transform.position.z - transform.position.z;

        this.transform.position = transform.position + new Vector3(0, 0, (dir-6) * Time.deltaTime * followSpeed);
    }
}
