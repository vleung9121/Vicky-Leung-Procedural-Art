using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Art
{
    public class week5homework : ArtMakerTemplate
    {
        public GameObject[] objects;
        public GameObject lineObj;
        public int maxLines = 49;
        public bool colorLines = true;
        public bool equalLineScale = true;
        GameObject colliderObj;

        public override void MakeArt()
        {
            //SolLewitt();
            Invoke("SolLewitt", .1f);
        }

        public void SolLewitt()
        {
            int objectRange = Random.Range(0, objects.Length);
            colliderObj = Instantiate(objects[objectRange]);
            colliderObj.transform.parent = root.transform;

            Color lineColor = new Color(0, 0, 0);
            if (colorLines == true)
            {
                float rVal = Random.value;
                float gVal = Random.value;
                float bVal = Random.value;
                lineColor = new Color(rVal, gVal, bVal);
            }

            int amt = Random.Range(9, maxLines + 1);
            if (amt % 2 == 0)
            {
                amt -= 1;
            }

			for (int i = 0; i < amt; i++)
			{
                float rayScale = 2f / ((amt - 1f) * 2f);
                float rayPosRange = 2 + (2 * rayScale);
                float rayPos = (rayPosRange / amt);
                if (equalLineScale == false)
                {
                    rayScale *= 1.3f;
                }
                Vector3 leftPosition = new Vector3(0, rayPos * i, 0);
                Vector3 rightPosition = new Vector3(2, rayPos * i, 0);
                Vector3 upPosition = new Vector3(rayPos * i, 2, 0);
                Vector3 downPosition = new Vector3(rayPos * i, 0, 0);

                if (Physics.Raycast(leftPosition, transform.TransformDirection(Vector3.right), out RaycastHit hitLeft, 5))
                {
                    LineMaker(leftPosition, new Vector3(hitLeft.distance * 2, rayScale, 1), lineColor);
                }

                else
                {
                    LineMaker(new Vector3(1, rayPos * i, 0), new Vector3(4, rayScale, 1), lineColor);
                }

                if (Physics.Raycast(rightPosition, transform.TransformDirection(Vector3.left), out RaycastHit hitRight, 5))
                {
                    LineMaker(rightPosition, new Vector3(hitRight.distance * 2, rayScale, 1), lineColor);
                }

                if (Physics.Raycast(upPosition, transform.TransformDirection(Vector3.down), out RaycastHit hitUp, 5))
                {
                    LineMaker(new Vector3(rayPos * i, (1 - hitUp.distance)/2 + 1, 0), new Vector3(rayScale, 1 - hitUp.distance, 1), lineColor);
                }

                if (Physics.Raycast(downPosition, transform.TransformDirection(Vector3.up), out RaycastHit hitDown, 5))
                {
                    LineMaker(new Vector3(rayPos * i, 1 - (1 - hitDown.distance)/2, 0), new Vector3(rayScale, 1 - hitDown.distance, 1), lineColor);
                }
            }
        }
        void LineMaker(Vector3 linePos, Vector3 lineScale, Color lineRGB)
        {
            GameObject line = Instantiate(lineObj, linePos, Quaternion.identity);
            line.transform.localScale = lineScale;
            line.GetComponent<MeshRenderer>().material.color = lineRGB;
            line.GetComponent<MeshRenderer>().material.SetFloat("_Glossiness", 0f);
            line.transform.parent = root.transform;
        }
    }
}