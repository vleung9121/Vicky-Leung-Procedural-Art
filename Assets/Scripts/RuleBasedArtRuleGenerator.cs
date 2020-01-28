using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleBasedArtRuleGenerator : MonoBehaviour
{
    public string Greeting = "Hello World";
    public string[] Greetings;
    public int HowMany = 10;
    public float weight = 0.5f;
    public bool Heavy = false;
    public bool refresh;

    void Start()
    {
        print(Greeting + " " + HowMany + " " + weight + " " + Heavy);

        if (Heavy == true)
            print("I'm heavy");
    }

    void Update()
    {
        if (refresh)
        {
            int index = Random.Range(0, Greetings.Length);
            string thisGreeting = Greetings[index];
            print(thisGreeting + " " + HowMany + " " + weight + " " + Heavy);

            refresh = false;
        }
    }
}
