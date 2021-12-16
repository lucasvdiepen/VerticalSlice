using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : Menu
{   
    public override void ExecuteButton()
    {
        switch (selectedButton)
        {
            case 0:
                SceneManager.LoadScene("GameScene");
                break;
            case 2:
                Application.Quit();
                break;
        }
    }
}
