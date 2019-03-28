    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<UnitManager> units;

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
            yield return null;
        }
        
    }
}