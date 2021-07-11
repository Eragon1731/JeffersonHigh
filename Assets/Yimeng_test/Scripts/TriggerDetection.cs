using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerDetection : MonoBehaviour
{
    public GameObject TriggerObj;
    public TMP_FontAsset FontAssetTriggerEntered;
    public Material FontMaterialTriggerEntered;
    //public TMP_Text Triggertext;

    private TextMeshPro m_Text;
    // Start is called before the first frame update
    void Start()
    {
        m_Text = gameObject.GetComponent<TextMeshPro>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.name == TriggerObj.name)
        {
            Debug.Log(2);
            m_Text.font = FontAssetTriggerEntered;
            m_Text.fontSharedMaterial = FontMaterialTriggerEntered;

        }
    }
}
