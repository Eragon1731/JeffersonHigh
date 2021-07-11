using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using TMPro;
using System;

/* Class ParseJson reads .json and stores information. Information is used as
   assets are triggered */
public class ParseJson : MonoBehaviour
{
    //Public Containers
    public TextMeshPro story_block;
    public string filepath;
    public TextMeshPro options_list;
    public Transform image_grp; 
    public GameObject[] images;
    public AudioSource sfx_source;

    //temp
    public AudioClip[] audio_sources;

    //Protected and Private Containers
    public List<int> story_indices;
    protected List<string> title_keys;
    protected List<string> image_names;
    protected List<string> content;
    protected Dictionary<int, List<string>> choices;
    private List<string> scene_answers;
    private List<string> scene_answerkeys;
    private List<string> audio_paths;

    public int counter = -1;

    // Read file and set init structs
    void Start()
    {
        ReadStoreJsonValues(filepath);
    }

    /* Read and store json values */
    public void ReadStoreJsonValues(string filepath) {
        string file = LoadResourceTextfile(filepath);
        Scene sceneInJson = JsonUtility.FromJson<Scene>(file);

        //init info structs for scene/act 
        content = new List<string>();
        choices = new Dictionary<int, List<string>>();
        title_keys = new List<string>();
        scene_answerkeys = new List<string>();
        image_names = new List<string>();
        story_indices = new List<int>();
        audio_paths = new List<string>();

        foreach (Dialogue test_scene in sceneInJson.dialogue)
        {
            title_keys.Add(test_scene.title_key);
            content.Add(test_scene.content);
            scene_answerkeys.Add(test_scene.answer_key);
            story_indices.Add(test_scene.block_index);
            image_names.Add(test_scene.image);
            audio_paths.Add(test_scene.audio_path);

            var key = 0;
            var temp_answers = new List<string>();
            foreach (Answer curr_answer in test_scene.answers)
            {
                key = Int32.Parse(curr_answer.key);
                temp_answers.Add(curr_answer.A1);
                temp_answers.Add(curr_answer.A2);
                temp_answers.Add(curr_answer.A3);
            }
            choices.Add(key, temp_answers);
        }

        print("init titles" + title_keys);
        //set init counter
        //counter = story_indices[0];

        //set init image
        if (image_names[0] != "")
        {
            images[0].SetActive(true);
        }

        print("content size" + content.Count);
        counter = forNext(counter);
        print("init counter" + counter);
    }


    /* set Story block text */
    public void setTextBlock(string title_key)
    {
        if (title_keys.Contains(title_key))
        {
            int index = title_keys.IndexOf(title_key);
            story_block.text = content[index];
            counter = story_indices[index];
            showOptions(index);

            //check which image should show
            toggleImage(counter);
            //check if there is a sfx and play it
            print("index" + index);
            print("counter" + counter);
            setAudioEffect(counter);
        }
        else
        {
            print(title_key + "doesn't exist");
        }
    }

    /* set Story input options */
    private void showOptions(int index = 0)
    {
        if (index < 0)
        {
            print("ERROR: invalid input");
        }
        else
        {
            counter = story_indices[index];
            options_list.text = "";
            string temp = "";
            if (counter > -1)
            {
                scene_answers = getAnswer(counter);
                if (scene_answers != null)
                {
                    foreach (string answer in scene_answers)
                    {
                        temp += answer + "\n";
                    }
                    options_list.text = temp.Substring(0, temp.Length - 2);
                }
            }
        }
    }

    /* Set up audio effects if there is one - public */
    public void setAudioEffect_public(string name) {
        //print("audio paths" + audio_paths.Count);
        if (name != "")
        {

            int temp_id = 0;
            temp_id = Array.FindIndex(audio_sources, x => x.name == name);
            print("temp id" + temp_id);

            sfx_source.clip = audio_sources[temp_id];
            sfx_source.Play();
        }
        else
        {
            print("ERROR: NO audio");
        }
    }

    /* Set up audio effects if there is one */
    private void setAudioEffect(int curr_index)
    {
        print("audio paths" + audio_paths.Count);
        if (audio_paths[curr_index] != "")
        {

            int temp_id = curr_index;
            //print("temp id" + temp_id);
            //if (curr_index > audio_sources.Length)
            //{
                temp_id = Array.FindIndex(audio_sources, x => x.name == audio_paths[curr_index]);
                print("temp id" + temp_id); 
            //}

            sfx_source.clip = audio_sources[temp_id];
            sfx_source.Play();
        }
        else
        {
            print("ERROR: NO audio");
        }
    }

    public int forBack(int curr_index)
    {
        if (curr_index > 0)
        {
            counter = story_indices[--curr_index];
            story_block.text = content[counter];
        }
        else
        {
            counter = 0;
        }
        showOptions(counter);

        //check which image should show
        toggleImage(counter);

        //check if there is a sfx and play it
        setAudioEffect(counter);
        return counter;
    }

    public int forNext(int curr_index)
    {
        if (curr_index <= content.Count - 1)
        {
            // print(counter);
            //print(curr_index);
            // print(story_indices.Count);
            // print(content.Count);
            counter = story_indices[++curr_index];
            story_block.text = content[counter];
        }
        else
        {
            counter = content.Count - 1;
        }
        showOptions(counter);

        //check which image should show
        toggleImage(counter);

        //check if there is a sfx and play it
        setAudioEffect(counter);
        //print("new counter" + counter); 
        return counter;
    }

    void toggleImage(int index)
    {
        //bad performance, fix later
        foreach (GameObject image in images)
        {
            if (image.name == image_names[index])
            {
                print("image name:" + image.name);
                image.SetActive(true);
                //image.GetComponent<Text_RevealLine>().resetTimer();
            }
            else
            {
                image.SetActive(false);
            }
        }
    }

    public static string LoadResourceTextfile(string path)
    {
        TextAsset targetFile = Resources.Load<TextAsset>(path);
        return targetFile.text;
    }


    /* Get Methods */

    public List<string> getTitleKeys()
    {
        print("these are title_keys" + title_keys);
        return title_keys;
    }

    public List<string> getAnswer(int number)
    {
        if (choices.ContainsKey(number))
        {
            //print("c: " + choices[number][0]); 
            return choices[number];
        }
        else
        {
            print("ERROR: No answers");
        }
        return null;
    }
    public string getAnswerKey(int index)
    {
        if (scene_answerkeys[index] != "")
        {
            return scene_answerkeys[index];
        }
        else
        {
            print("ERROR: doesnt exist");
            return null;
        }
    }
}

/* JSON Structs */

[System.Serializable]
public class Scene
{
    //employees is case sensitive and must match the string "employees" in the JSON.
    public Dialogue[] dialogue;
}

[System.Serializable]
public class Dialogue
{
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public string title_key;
    public int block_index;
    public string content;
    public string image;
    public string audio_path;
    public string answer_key;
    public Answer[] answers;
    //public string hidden_message;
}

[System.Serializable]
public class Answer
{
    public string key;
    public string A1;
    public string A2;
    public string A3;
}
