using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveToJson : MonoBehaviour
{

    [SerializeField] private InputData inputData = new InputData();
    public TMP_InputField answerInput;
    public TMP_InputField keyInput; 

    private void Start()
    {
        //if (this.GetComponent<TMP_InputField>().isActiveAndEnabled) {
        //    textInput = this.GetComponent<TMP_InputField>();
        //}
    }

    public void StoreText() {
        string data = JsonUtility.ToJson(inputData);
        System.IO.File.WriteAllText(Application.dataPath + "/Resources" + "/InputTextData.json", data);
    }

    public void AddAnswerfromField() {
        inputData.answer = answerInput.text;
    }

    public void AddKeyfromField() {
        inputData.key = keyInput.text; 
    }
}
[System.Serializable]
public class InputData {
    public string question;
    public string answer;
    public string key;
}
