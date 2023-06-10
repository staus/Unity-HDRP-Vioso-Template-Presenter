using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Image360 : MonoBehaviour
{

    [Range(-10f, 10f)]
    public float rotationSpeed = 5f;

    public enum RotationAxis { X, Y, Z }
    public RotationAxis rotationAxis = RotationAxis.Y;

    void Update()
    {
        Vector3 axis = Vector3.zero;

        switch (rotationAxis)
        {
            case RotationAxis.X:
                axis = Vector3.right;
                break;
            case RotationAxis.Y:
                axis = Vector3.up;
                break;
            case RotationAxis.Z:
                axis = Vector3.forward;
                break;
        }

        transform.Rotate(-axis * rotationSpeed * Time.deltaTime);
    }
}