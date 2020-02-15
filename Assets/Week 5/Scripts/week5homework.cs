using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Art
{
    public class week5homework : ArtMakerTemplate
    {
        public GameObject[] objects;
        public GameObject lineObj;
        public int maxLines = 41;
        public bool colorLines = true;

        public override void MakeArt()
        {
            int objectRange = Random.Range(0, objects.Length);
            GameObject colliderObj = Instantiate(objects[objectRange]);
            colliderObj.transform.parent = root.transform;

            Color lineColor = new Color(0, 0, 0);
            if (colorLines == true)
            {
                lineColor = Random.ColorHSV();
            }

            int amt = Random.Range(7, maxLines+1);
            if (amt % 2 == 0)
            {
                amt -= 1;
            }

			for (int i = 0; i < amt; i++)
			{
                float yScale = 2f / (amt * 2f - 1);
                float yPosRange = 2 + (2 * yScale);
                float raycastYPos = yPosRange / amt;
                Vector3 lposition = new Vector3(0, raycastYPos * i, 0);
                Vector3 rposition = new Vector3(2, raycastYPos * i, 0);

                if (Physics.Raycast(lposition, transform.TransformDirection(Vector3.right), out RaycastHit hitLeft, 5))
                {
                    GameObject line = Instantiate(lineObj, lposition, Quaternion.identity);
                    line.transform.localScale = new Vector3(hitLeft.distance * 2, yScale, 1);
                    line.GetComponent<MeshRenderer>().material.color = lineColor;
                    line.GetComponent<MeshRenderer>().material.SetFloat("_Glossiness", 0f);
                    line.transform.parent = root.transform;
                }
                else
                {
                    GameObject line = Instantiate(lineObj, new Vector3(1, raycastYPos * i, 0), Quaternion.identity);
                    line.transform.localScale = new Vector3(4, yScale, 1);
                    line.GetComponent<MeshRenderer>().material.color = lineColor;
                    line.GetComponent<MeshRenderer>().material.SetFloat("_Glossiness", 0f);
                    line.transform.parent = root.transform;
                }
                if (Physics.Raycast(rposition, transform.TransformDirection(Vector3.left), out RaycastHit hitRight, 5))
                {
                    GameObject line = Instantiate(lineObj, rposition, Quaternion.identity);
                    line.transform.localScale = new Vector3(hitRight.distance * 2, yScale, 1);
                    line.GetComponent<MeshRenderer>().material.color = lineColor;
                    line.GetComponent<MeshRenderer>().material.SetFloat("_Glossiness", 0f);
                    line.transform.parent = root.transform;
                }

            }
        }
    }
}