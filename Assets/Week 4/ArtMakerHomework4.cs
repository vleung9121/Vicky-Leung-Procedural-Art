using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Art
{
    public class ArtMakerHomework4 : ArtMakerTemplate
    {
        public int min = 4;
        public int max = 8;
        public int minIterations = 3;
        public int maxIterations = 12;
        public GameObject[] objects;
        public GameObject parentObj;

        public override void MakeArt()
        {
            int amt = Random.Range(min, max);
            int iterations = Random.Range(minIterations, maxIterations);
            for (int i = 0; i < amt; i++)
            {
                //for each random shape, set transforms
                float tx = Random.Range(0f, 5f);
                float ty = Random.Range(0f, 5f);
                float rx = Random.Range(0f, 360f);
                float ry = Random.Range(0f, 360f);
                float rz = Random.Range(0f, 360f);
                float s = Random.Range(0.25f, 1f);
                Color shapeColor = Random.ColorHSV();
                int objectRange = Random.Range(0, objects.Length);

                for (int j = 1; j < iterations + 1; j++)
                {
                    //to make one for every iteration
                    GameObject shape = Instantiate(objects[objectRange]);
                    GameObject newParent = Instantiate(parentObj);
                    shape.transform.parent = newParent.transform;

                    shape.transform.position = new Vector3(tx, ty, 0f);
                    shape.transform.Rotate(rx, ry, rz);
                    shape.transform.localScale = new Vector3(s, s, s);
                    shape.GetComponent<MeshRenderer>().material.color = shapeColor;
                    shape.GetComponent<MeshRenderer>().material.SetFloat("_Glossiness", 0f);

                    float newRotate = (j * 360 / iterations);
                    newParent.transform.Rotate(0, 0, newRotate);
                    newParent.transform.parent = root.transform;
                }
            }
        }
    }
}