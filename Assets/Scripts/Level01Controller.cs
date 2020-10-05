using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView = null;
    [SerializeField] GameObject _PopupMenu = null;
    [SerializeField] GameObject _RetryMenu = null;

    int _currentScore;
    
    void Start()
    {
        _PopupMenu.SetActive(false);
        _RetryMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = (false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PopupMenu();
        }
 
    }
    public void IncreaseScore(int scoreIncrease)
    {
        _currentScore += scoreIncrease;

        _currentScoreTextView.text =
            "Score: " + _currentScore.ToString();
    }
    public void PopupMenu()
    {
        bool currentIsActive = _PopupMenu.activeSelf;
        _PopupMenu.SetActive(!currentIsActive);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = (true);
    }
    public void RetryMenu()
    {
        _RetryMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = (true);
    }
    public void ExitLevel()
    {
        int highScore = PlayerPrefs.GetInt("Highscore");
        if (_currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }
        SceneManager.LoadScene("MainMenu");
    }
}
