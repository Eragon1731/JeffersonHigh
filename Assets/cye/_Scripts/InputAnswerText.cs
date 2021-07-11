using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class InputAnswerText : MonoBehaviour
{
    protected TMP_InputField inputField;
    public Text_RevealWordwithSound storyblock; 
    public TMP_Text messageField;
    public TMP_Text optionField;
    public TMP_Text messageField_tag;

    public ParseJson scene_data;
    public BGMManager bgm_manager;
    public Text_RevealWordwithSound settingsblock; 
    private int scene_counter =-1; 
    private List<string> scene_answers;
    private List<string> scene_titlekeys;
    // Start is called before the first frame update
    void Start()
    {
        //init storyblock 
        scene_counter = scene_data.counter;

        if (this.GetComponent<TMP_InputField>() != null) {
            inputField = this.GetComponent<TMP_InputField>(); 
        }

        //on start
        scene_titlekeys = scene_data.getTitleKeys();
    }
    public void checkAnswer() {

        if (scene_counter < 0) {
            scene_counter = scene_data.counter;
        }

        if (scene_titlekeys == null || scene_titlekeys.Count <=0 ) {
            scene_titlekeys = scene_data.getTitleKeys();
        }

        messageField.text = "";
        if (inputField.text == "next" && optionField.text.Contains("next"))
        {
            //print("input counter" + scene_counter); 
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
        else if (inputField.text.Contains("bgm") || inputField.text.Contains("sfx"))
        {
            var info = inputField.text.Split(' ');
            //print("info" + info.Length);
            //settingsManager.adjustVolume(info[0], float.Parse(info[1]));
        }
        else if (inputField.text == "close")
        {
            storyblock.resetTimer();
        }
        //exceptions: loading part2 of act3
        else if (inputField.text == "Go under")
        {
            scene_data.ReadStoreJsonValues("Act3_part2");
            scene_counter = scene_data.counter = 0;
            scene_titlekeys = scene_data.getTitleKeys();
            goToTextBlock();
        }
        else if (inputField.text == "Turn back" && !scene_titlekeys.Contains("Turn back")) {
            scene_data.ReadStoreJsonValues("Act3_part2");
            scene_data.counter = scene_counter = 1;
            scene_titlekeys = scene_data.getTitleKeys();
            goToTextBlock();
        }
        else if (scene_titlekeys.Contains(inputField.text))
        {
            goToTextBlock();
        }
        else if (inputField.text != "" && scene_counter > -1)
        {
            //print("Debug: contains Go to Ms. Grables Class " + scene_titlekeys.Contains("Go to Ms. Grables Class"));
            scene_answers = scene_data.getAnswer(scene_counter);
            string correct_answer = scene_data.getAnswerKey(scene_counter);
            if (inputField.text == correct_answer)
            {
                messageField.text = "correct!";
                scene_counter = scene_data.forNext(scene_counter);
                // this.updateCounter();
            }
            else if (inputField.text.Equals("start") ||
                inputField.text.Equals("I hope I fit") ||
                inputField.text.Equals("Get to broad window") ||
                inputField.text.Equals("Crap")) {
                messageField.text = "Entering next Act";
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
    public void goToTextBlock() {
        if (scene_titlekeys.Contains(inputField.text)) {
            scene_data.setTextBlock(inputField.text);
            scene_counter = scene_data.counter;
        }

        //uncomment to change bgm music -- test scenes
        if (scene_titlekeys[scene_counter] == "Open Ms. Grables' computer")
        {
            bgm_manager.changeBGM(1);
        }
        else if (scene_titlekeys[scene_counter] == "Get to broad window" ||
            scene_titlekeys[scene_counter] == "I hope I fit" ||
            scene_titlekeys[scene_counter] == "Crap")
        {
            bgm_manager.changeBGM(0);
        }
        else if (scene_titlekeys[scene_counter] == "Oh no...")
        {
            //print("CAN FIND BGM");
            bgm_manager.changeBGM(2);
        }
        else if (scene_titlekeys[scene_counter] == "Tell me NOW") {
            bgm_manager.changeBGM(2);
        }
    }
}
