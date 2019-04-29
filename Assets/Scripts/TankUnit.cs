using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUnit : MonoBehaviour
{
    private GameObject reference;

    // Start is called before the first frame update
    void Start()
    {
        reference = this.gameObject;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
