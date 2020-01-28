using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale = Vector3.one;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 jiggle = new Vector3(
            position.x, 
            position.y + Random.value, 
            position.z);
        this.transform.position = jiggle;
        this.transform.localEulerAngles = rotation;
        this.transform.localScale = scale;
    }
}
