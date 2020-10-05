using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Text _highScoreTextView = null;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
    }
    /*
    public void ResetData()
    {
        //"Highscore" equal to 0
        //
    }
    */
    public void Quit()
    {
        Application.Quit();
    }
}
