using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject goTarget;
    public float maxDegreesPerSecond;
    private Quaternion qTo;

    void Start()
    {
        qTo = goTarget.transform.localRotation;
    }

    void Update()
    {
        Vector3 v3T = goTarget.transform.position - transform.position;
        v3T.z = -transform.position.z;
        qTo = Quaternion.LookRotation(v3T, Vector3.up);
        qTo.y = 0;
        qTo.x = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, qTo, maxDegreesPerSecond * Time.deltaTime);
    }
}