using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnObject : MonoBehaviour
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale = Vector3.one;
    public float currentTime;
    int rotateX = 0;
    int rotateY = 0;

    void Start()
    {
        
    }

    void Update()
    {
        currentTime = Time.time;
        rotateX += 2;
        rotateY += 5;
        
        Vector3 jiggle = new Vector3(
            position.x = Mathf.Sin(currentTime*10)*5,
            position.y = Mathf.Sin(currentTime)*8, 
            position.z = Mathf.Cos(currentTime*10)*5   );
        this.transform.position = jiggle;
        this.transform.Rotate(rotateX, rotateY, 0);
    }
}
