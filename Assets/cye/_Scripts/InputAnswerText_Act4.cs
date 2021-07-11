using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using System;using static System.Random;
public class InputAnswerText_Act4 : MonoBehaviour
{
    protected TMP_InputField inputField;
    public Text_RevealWordwithSound storyblock;
    public TMP_Text messageField;
    public TMP_Text optionField;
    public TMP_Text descriptionField; 
    public string wronganswers_path;

    public ParseJson scene_data;
    public BGMManager bgm_manager;
    public AudioSource sfx_source; 
    public Text_RevealWordwithSound settingsblock;
    private int scene_counter = -1;

    private List<string> scene_answers;
    private List<string> scene_titlekeys;
    private List<string> audio_paths;
    private List<string> image_names;

    //ACT4 - wrong answer outputs for safe
    private List<string> content;    private List<int> story_indices;
    private int rInt;

    // Start is called before the first frame update
    void Start()
    {
        //init storyblock 
        scene_counter = scene_data.counter;

        if (this.GetComponent<TMP_InputField>() != null)
        {
            inputField = this.GetComponent<TMP_InputField>();
        }

        //on start
        scene_titlekeys = scene_data.getTitleKeys();

        //get wrong answers
        parseMessageOutputs();
        //Random r = new Random();
        //rInt = r.Next(0, story_indices.Count -1); //for ints

    }
    public void checkAnswer()
    {

        if (scene_counter < 0)
        {
            scene_counter = scene_data.counter;
        }

        if (scene_titlekeys == null || scene_titlekeys.Count <= 0)
        {
            scene_titlekeys = scene_data.getTitleKeys();
        }

        messageField.text = "";
        if (inputField.text == "next" && optionField.text.Contains("next"))
        {
            scene_counter = scene_data.forNext(scene_counter);
        }
        else if (inputField.text == "back")
        {
            scene_counter = scene_data.forBack(scene_counter);
        }
        else if (inputField.text == "settings")
        {
            //storyblock.resetTimer();
            settingsblock.resetTimer();
            //open settings
            //  settingsManager.openSettingsView();
        }
        else if (inputField.text == "close")
        {
            storyblock.resetTimer();
        }
        else if (scene_titlekeys.Contains(inputField.text))
        {
            goToTextBlock();
        }
        else if (inputField.text != "" && scene_counter > -1)
        {
            scene_answers = scene_data.getAnswer(scene_counter);
            string correct_answer = scene_data.getAnswerKey(scene_counter);
            if (inputField.text == correct_answer)
            {
                messageField.text = "correct!";
                scene_counter = scene_data.forNext(scene_counter);
            }
            else if (scene_counter == 7 && scene_answers[0] == ""){
                System.Random ran = new System.Random();
                
                rInt = ran.Next(0, story_indices.Count - 1); //for ints
                descriptionField.text = content[rInt];

                //set audio
                scene_data.setAudioEffect_public(audio_paths[0]);
            }
            else
            {
                messageField.text = "ERROR: invalid input";
            }
        }
        else
        {
            messageField.text = "ERROR: please enter correct commands";
        }
    }
    public void goToTextBlock()
    {
        if (scene_titlekeys.Contains(inputField.text))
        {
            scene_data.setTextBlock(inputField.text);
            scene_counter = scene_data.counter;
        }

		//uncomment to change bgm music-- test scenes

		if (scene_titlekeys[scene_counter] == "Did you hear the PA?!")
		{
			bgm_manager.changeBGM(1);
		}
	}

    private void parseMessageOutputs()
    {
        string file = LoadResourceTextfile(wronganswers_path);
        Messages sceneInJson = JsonUtility.FromJson<Messages>(file);

        content = new List<string>();
        // choices = new Dictionary<int, List<string>>();
        //title_keys = new List<string>();
        //scene_answerkeys = new List<string>();
        image_names = new List<string>();
        story_indices = new List<int>();
        audio_paths = new List<string>();

        foreach (WrongAnswers test_scene in sceneInJson.wrong_answers)
        {
            //title_keys.Add(test_scene.title_key);
            content.Add(test_scene.content);
            //scene_answerkeys.Add(test_scene.answer_key);
            story_indices.Add(test_scene.block_index);
           // image_names.Add(test_scene.image);
            audio_paths.Add(test_scene.audio_path);
        }

		//set init image

		//if (image_names[0] != "")
		//{
		//	images[0].SetActive(true);
		//}
	}
    public static string LoadResourceTextfile(string path)
    {
        TextAsset targetFile = Resources.Load<TextAsset>(path);
        return targetFile.text;
    }
}

[System.Serializable]
public class Messages
{
    //employees is case sensitive and must match the string "employees" in the JSON.
    public WrongAnswers[] wrong_answers;
}

[System.Serializable]
public class WrongAnswers
{
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public string title_key;
    public int block_index;
    public string content;
    public string image;
    public string audio_path;
    public string answer_key;
}
