using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject2 : MonoBehaviour
{
    public float distance = 10;

    private float startPosX;

    private float startPosY;
    private bool isBeingHeld = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (isBeingHeld == true)
        {
            Vector3 MousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            transform.localPosition = new Vector3(objPosition.x-startPosX,objPosition.y-startPosY,objPosition.z);
        }
        
    }
    
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 MousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);

            startPosX = objPosition.x - transform.position.x;
            startPosY = objPosition.y - transform.position.y;
            

            isBeingHeld = true;
            
        }
        
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
