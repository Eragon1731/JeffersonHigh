using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class LightingAppear : MonoBehaviour
{
    public TextMeshPro description;

    public string lightning;

    public GameObject Light;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (description.text.Contains(lightning))
        {
            Light.SetActive(true);
        }
    }
}
