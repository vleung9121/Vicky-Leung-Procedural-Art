using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Art
{
    public class week5test : ArtMakerTemplate
    {
        public GameObject[] gridObjects;
        public int amount = 10;

        public override void MakeArt()
        {
            for (int i = 0; i < amount; i++)
            {
                for (int j = 0; j < amount; j++)
                {
                    GameObject thing = Instantiate(gridObjects[0]);
                    thing.transform.position = new Vector3(i, j, 0);
                    float scale = Random.value;
                    thing.transform.localScale = new Vector3(scale, scale, scale);
                    thing.transform.parent = root.transform;
                }
            }
        }
    }
}