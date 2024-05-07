using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject targetObject;
    private Vector3 distance;
    private Vector3 targetPosition;

    private void Start()
    {
        distance= new Vector3(0,-5f,5f);
    }
    private void Update()
    {
        targetPosition = targetObject.transform.position - distance;

    }
    private void FixedUpdate()
    {
        this.transform.position = targetPosition;

    }
}
