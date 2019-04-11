using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    List<UnitManager> units;
    public Text text;
    int buttonPressedCount = 0;

    // initialize
    private void Start()
    {
        // create units, will be passed a list of units to create, somehow
        List<string> passed = new List<string>();
        passed.Add("axe");

        units = new List<UnitManager>();

        foreach (var p in passed)
        {
            units.Add(new UnitManager(p));
        }


        // start game loop
        StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        // 
        while (true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 mousePosition = Input.mousePosition;
                buttonPressedCount++;
                text.text = buttonPressedCount.ToString();

            }
            yield return null;
        }
        
    }
}