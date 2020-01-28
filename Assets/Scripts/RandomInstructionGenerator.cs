using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInstructionGenerator : MonoBehaviour
{
    public bool rebuild;

    public int roseMin = 0;
    public int roseMax = 4;

    public string[] paperColor;
    public string[] roseType;
    public string[] leafType;
    public string[] extraShape;
    public string[] extraColor;

    void Start()
    {

    }

    void Update()
    {
        if (rebuild)
        {
            float redNumber = Random.Range(roseMin, roseMax);
            float blueNumber = Random.Range(roseMin, roseMax);

            string pColor = paperColor[Random.Range(0, paperColor.Length)];
            string rType = roseType[Random.Range(0, roseType.Length)];
            string lType = leafType[Random.Range(0, leafType.Length)];
            string eShape = extraShape[Random.Range(0, extraShape.Length)];
            string eColor = extraColor[Random.Range(0, extraColor.Length)];

            //---Rules---//
            string output = "\nChoose a " + pColor + " piece of paper. \nDraw " + redNumber + " " + rType + " red rose(s).";

            rType = roseType[Random.Range(0, roseType.Length)];

            output += "\nDraw " + blueNumber + " " + rType + " blue rose(s).";

            if (redNumber > blueNumber)
            {
                output += "\nDraw " + Random.Range(1, 7) + " " + lType + " leaves, one of them on a corner.";
            }

            else
            {
                output += "\nDraw " + Random.Range(2, 7) + " pointy leaves.";
            }

            output += "\nDraw " + Random.Range(2,10) + " " + eColor + " " + eShape + ".";

            Debug.Log(output);
            rebuild = false;
        }
    }
}