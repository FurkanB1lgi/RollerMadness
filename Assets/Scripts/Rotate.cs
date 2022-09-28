using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 angle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(angle, Space.World);
    }
}
