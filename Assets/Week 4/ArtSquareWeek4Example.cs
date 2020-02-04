using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script randomly selects items from an array
 * and scatters them randomly
 * It parents the items to the root object
 * so that they will be destroyed when 'rebuild' is true
 */

namespace Art
{
    public class ArtSquareWeek4Example : ArtMakerTemplate
    {
        public GameObject[] objects;
        public int amount = 10;

        public override void MakeArt()
        {
            /*int amt = Random.Range(2, amount);
            for (int i = 0; i < amt; i++)
            {
                GameObject g = Instantiate(objects[Random.Range(0, objects.Length)]);
                g.transform.parent = root.transform;
                g.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
                float s = Random.value * .25f;
                g.transform.localScale = new Vector3(s, s, s);
                g.transform.position = Random.insideUnitSphere*.5f;
            }*/
            int amt = Random.Range(2, amount);
            for (int i = 0; i < amt; i++)
            {
                if (i % 2 == 0)
                {
                    GameObject g = Instantiate(objects[0]);
                    g.transform.parent = root.transform;
                    float s = Random.value * 0.25f;
                    g.transform.localScale = new Vector3(s, s, s);
                    g.transform.position = Random.insideUnitSphere*0.5f;
                }
                if (i % 3 == 0)
                {
                    GameObject t = Instantiate(objects[2]);
                    t.transform.parent = root.transform;
                    float tr = Random.Range(0, 360);
                    t.transform.rotation = Quaternion.Euler(tr, tr, tr);
                    float ts = Random.value * 0.25f;
                    t.transform.localScale = new Vector3(ts, ts, ts);
                    t.transform.position = Random.insideUnitSphere * 0.5f;
                }
                else
                {
                    GameObject g = Instantiate(objects[1]);
                    g.transform.parent = root.transform;
                    g.transform.position = Random.insideUnitSphere * 0.75f;
                    float r = Random.Range(0, 360);
                    g.transform.rotation = Quaternion.Euler(r, 0, r);
                    float s = Random.value * 0.25f;
                    g.transform.localScale = new Vector3(s, s, s);
                }
            }
        }
    }
}