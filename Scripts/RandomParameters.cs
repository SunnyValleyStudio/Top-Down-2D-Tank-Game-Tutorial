using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomParameters : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var radius = 5;
        Vector3 randomPositionInsideSphere = Random.insideUnitSphere* radius;
        Vector2 randomPositionInsiedCircle = Random.insideUnitCircle* radius;
        Vector3 randomPositionOnSphereSurfce = Random.onUnitSphere * radius;

        Quaternion randomRotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
