using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class Text_Wobbly : MonoBehaviour
{
    public TMP_Text textComponent;

    public float wavespeed;
    public float waveheight;
    public float wavewidth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.ForceMeshUpdate();
        var texInfo = textComponent.textInfo;

        for (int i = 0; i < texInfo.characterCount; i++)
        {
            var charInfo = texInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = texInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; ++j)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] =
                    orig + new Vector3(0, Mathf.Sin(Time.time * wavespeed + orig.x * wavewidth) * waveheight, 0);
                
            }
        }

        for (int i = 0; i < texInfo.meshInfo.Length; i++)
        {
            var meshInfo = texInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComponent.UpdateGeometry(meshInfo.mesh,i);
            
        }
    }
}
