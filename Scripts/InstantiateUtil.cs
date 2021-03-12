using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtil : MonoBehaviour
{
    public GameObject objectToinstantiate;

    public void InstantiateObject()
    {
        Instantiate(objectToinstantiate);
    }
}
