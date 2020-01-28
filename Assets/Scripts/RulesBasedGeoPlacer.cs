using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesBasedGeoPlacer : MonoBehaviour
{
    public GameObject thing;

    public Vector3 position;
    public Vector3 scale = Vector3.one;
    public Vector3 rotation;
    void Start()
    {
        
    }

    void Update()
    {
        thing.transform.position = position;
        thing.transform.localScale = scale;
        thing.transform.eulerAngles = rotation;
    }
}
