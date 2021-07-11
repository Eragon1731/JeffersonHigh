using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFormatManager : MonoBehaviour
{
    public TextMeshPro[] children;
    public GameObject[] images;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void disableEmptyText() {

        foreach (TextMeshPro child in children) {
            if (child.text == "" || child.text == null)
            {
                child.enabled = false;
            }
            else {
                child.enabled = true; 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
