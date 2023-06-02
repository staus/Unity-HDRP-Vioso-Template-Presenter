using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Image360 : MonoBehaviour
{
    public Texture2D texture360;

    [Range(-10f, 10f)]
    public float rotationSpeed = 5f;

    public enum RotationAxis { X, Y, Z }
    public RotationAxis rotationAxis = RotationAxis.Y;

    string materialPath = "Assets/AVProVideo/Demos/Common/Demo-360.mat";

    void OnValidate()
    {
        AssignTextureToMaterial();
    }

    void Start()
    {
        AssignTextureToMaterial();
    }

    void AssignTextureToMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material sourceMaterial = AssetDatabase.LoadAssetAtPath<Material>(materialPath);
        Material material = new Material(sourceMaterial);
        if (!texture360) {
            material.SetTexture("_MainTex", null);
        }
        else {
            material.SetTexture("_MainTex", texture360);
        }
        renderer.material = material;
    }

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