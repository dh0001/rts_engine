using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachHealthBar : MonoBehaviour
{
    private GameObject attachedUnit;
    private Vector3 offset = new Vector3(0, 15, 0);

    // Start is called before the first frame update
    void Start()
    {
        attachedUnit = gameObject.transform.parent.parent.gameObject; // sphere should be parent of parent
    }

    // Update is called once per frame
    void Update()
    {
        // resets position of health slider every frame to follow the attached GameObject.
        gameObject.transform.position = Camera.main.WorldToScreenPoint(attachedUnit.transform.position) + offset;
    }
}
