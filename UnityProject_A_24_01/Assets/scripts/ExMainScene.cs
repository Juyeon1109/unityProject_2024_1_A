using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExMainScene : MonoBehaviour
{
    public void GoToShootGame()
    {
        SceneManager.LoadScene("GameScene_Gun");
    }

    public void GoToJumpGame()
    {
        SceneManager.LoadScene("GameScene_Jump");
    }

    public void GoExit()
    {
        Application.Quit();
    }
}
