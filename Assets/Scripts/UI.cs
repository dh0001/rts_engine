using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject camera;
    public UnitManager selected;


    void Start(){

    }


    void OnMouseDown(){
        
    }

    void Update(){
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePosition = Input.mousePosition;
        }
    }
}
