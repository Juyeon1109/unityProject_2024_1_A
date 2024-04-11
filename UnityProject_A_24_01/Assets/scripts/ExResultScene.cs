using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExResultScene : MonoBehaviour
{
    public Text TextUI;

    public void Start()
    {
        TextUI.text = PlayerPrefs.GetInt("Point").ToString();
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene_Gun");
    }
}
