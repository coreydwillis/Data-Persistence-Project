using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    private string input;
    public TMP_Text BestScoreText;
    public TMP_InputField NameInput;

    private void Start()
    {
        if (SceneChanger.Instance.BestScore > 1)
        {
            BestScoreText.text = "Best Score : " + SceneChanger.Instance.BestPlayerName + " : " + SceneChanger.Instance.BestScore;
        }
        else
        {
            BestScoreText.text = "No best score yet";
        }

        if (NameInput.text != "Enter name...")
        {
            NameInput.text = SceneChanger.Instance.PlayerName;
        }
        //SetName();
        //ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        //ColorPicker.onColorChanged += NewColorSelected;
        //ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneChanger.Instance.SaveVars();
    //MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
            Application.Quit(); // original code to quit Unity player
    #endif
    }
    public void SetName(string s)
    {
        input = s;
        SceneChanger.Instance.PlayerName = input;
    }
}
