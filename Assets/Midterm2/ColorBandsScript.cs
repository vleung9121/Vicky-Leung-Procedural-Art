using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Art
{
    public class ColorBandsScript : ArtMakerTemplate
    {
        public int maxLines = 50;
        public int minLines = 25;
        int points = 30;
        float radius = 7;
        public GameObject GOLine;
        public GameObject cubeObj;

        public override void MakeArt()
        {
            ColorBands();
        }

        public void ColorBands()
        {
            int rQuadrant = Random.Range(1, 3);
            switch (rQuadrant)
            {
                case 1:
                    CreateRings(180, 0, 0, 0, 0, "noLim");
                    break;
                case 2:
                    CreateRings(180, 180, 5, 0, 0, "negXLim");
                    break;
            }

            int botQuadrant = Random.Range(1, 7);
            switch (botQuadrant)
            {
                case 1:
                    CreateRings(90, 0, -5, -5, 1, "posYLim");
                    break;
                case 2:
                    CreateRings(90, 270, -5, 0, 1, "noLim");
                    break;
                case 3:
                    CreateRings(90, 180, 0, 0, 1, "noLim");
                    break;
                case 4:
                    CreateRings(90, 90, 0, -5, 1, "posYLim");
                    break;
                case 5:
                    CreateLines(true, -1);
                    break;
                case 6:
                    CreateLines(false, -1);
                    break;
            }

            int topQuadrant = Random.Range(1, 7);
            switch (topQuadrant)
            {
                case 1:
                    CreateRings(90, 0, -5, 0, 1.5f, "noLim");
                    break;
                case 2:
                    CreateRings(90, 270, -5, 5, 1.5f, "noLim");
                    break;
                case 3:
                    CreateRings(90, 180, 0, 5, 1.5f, "noLim");
                    break;
                case 4:
                    CreateRings(90, 90, 0, 0, 1.5f, "noLim");
                    break;
                case 5:
                    CreateLines(true, 1);
                    break;
                case 6:
                    CreateLines(false, 1);
                    break;
            }
        }

        public void CreateRings(float angle, float angleStart, float h, float k, float z, string limit)
        {
            float x;
            float y;

            int numLines = Random.Range(minLines, maxLines);

            for (int i = 0; i < numLines; i++)
            {
                GameObject newLine = Instantiate(GOLine);
                newLine.transform.parent = root.transform;
                LineRenderer line = newLine.GetComponent<LineRenderer>();

                Color randColor = new Color(Random.value, Random.value, Random.value);
                line.endColor =randColor;
                line.startColor = randColor;

                line.endWidth = radius / numLines;
                line.startWidth = radius / numLines;
                line.positionCount = (points + 1);
                line.useWorldSpace = true;

                float angleAmt = angle;

                for (int j = 0; j < (points + 1); j++)
                {
                    x = h + Mathf.Sin(Mathf.Deg2Rad * (angleAmt - angleStart)) * (radius - (radius / numLines) * i);
                    y = k + Mathf.Cos(Mathf.Deg2Rad * (angleAmt - angleStart)) * (radius - (radius / numLines) * i);

                    angleAmt -= (angle / points);

                    if (limit == "posYLim" && y >= 0.1)
                    {
                        y = -0.05f;
                    }
                    if (limit == "negXLim" && x<= -0.1)
                    {
                        x = 0.05f;
                    }

                    line.SetPosition(j, new Vector3(x, y, z));
                }
            }
        }

        public void CreateLines(bool vertical, int ySign)
        {
            int numLines = Random.Range(minLines, maxLines);
            float lineScale = 5f / numLines;
            for (int i = 0; i < numLines; i++)
            {
                GameObject newLine = Instantiate(cubeObj);
                Color randColor = new Color(Random.value, Random.value, Random.value);
                newLine.GetComponent<MeshRenderer>().material.color = randColor;
                newLine.GetComponent<MeshRenderer>().material.SetFloat("_Glossiness", 0f);
                newLine.transform.parent = root.transform;

                if (vertical == true)
                {
                    float x = -lineScale * i;
                    newLine.transform.position = new Vector3(x, (2.45f * ySign), 0);
                    newLine.transform.localScale = new Vector3(lineScale, 5f, 1);
                }
                else
                {
                    float y = lineScale * ySign * i;
                    newLine.transform.position = new Vector3(-2.45f, y, 0);
                    newLine.transform.localScale = new Vector3(5f, lineScale, 1);
                }
            }
        }
    }
}
