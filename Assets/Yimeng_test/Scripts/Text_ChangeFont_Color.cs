using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Text_ChangeFont_Color : MonoBehaviour
{
    private TMP_Text BaseText;

    public TMP_FontAsset FontAssetNormal;
    public TMP_FontAsset FontAssetMouseover;

    public Material FontMaterialNormal;
    public Material FontMaterialMouseover;
    
    public GameObject TriggerObj;
    public TMP_FontAsset FontAssetTriggerEntered;
    public Material FontMaterialTriggerEntered;

    private bool inTrigger = false;
    // Start is called before the first frame update

    private void Awake()
    {
        BaseText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        
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
            BaseText.font = FontAssetTriggerEntered;
            BaseText.fontSharedMaterial = FontMaterialTriggerEntered;
            inTrigger = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        BaseText.font = FontAssetNormal; 
        BaseText.fontSharedMaterial = FontMaterialNormal;
        inTrigger = false;
    }
    
    private void OnMouseOver()
    {
        //Debug.Log(1);
         if (inTrigger == false)
         {
            BaseText.font = FontAssetMouseover;
            BaseText.fontSharedMaterial = FontMaterialMouseover;
         }
       
    }

    private void OnMouseExit()
    {
        if (inTrigger == false)
        {
            BaseText.font = FontAssetNormal; 
            BaseText.fontSharedMaterial = FontMaterialNormal;
        }
        
    }
}
