using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMoving : MonoBehaviour
{
    public float cadistance = 10;
    public float FurthestDistance = 3;

    private Vector3 formalPosition;
    private float startX;
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        formalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,cadistance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);

        startX =objPosition.x - transform.position.x;
        startY = objPosition.y - transform.position.y;

        float MouseDistance = Vector3.Distance(objPosition, formalPosition);
        
        Vector3 dirctionbase = new Vector3(startX,startY,cadistance);

        float x = MouseDistance/FurthestDistance*3;

        Vector3 direction = Vector3.Normalize(dirctionbase);

        // if (MouseDistance < FurthestDistance)
        // {
        //     transform.localPosition = new Vector3(direction.x*x,direction.y*x,0);
        //     Debug.Log(3);
        // }
        //
        // else if (MouseDistance >= FurthestDistance)
        // {
        //     transform.localPosition = new Vector3(direction.x * FurthestDistance, direction.y * FurthestDistance, 0);
        //     Debug.Log(2);
        //     Debug.Log(direction);
        // }

        transform.localPosition = new Vector3(direction.x * FurthestDistance, direction.y * FurthestDistance, 0);
        
    }
}
