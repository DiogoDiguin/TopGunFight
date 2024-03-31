using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateElice : MonoBehaviour
{

    [SerializeField] private float speedRotate = 10f;
    void Update()
    {
        transform.Rotate(0,speedRotate,0 *Time.deltaTime);
    }
}
