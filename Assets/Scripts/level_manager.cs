using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_manager : MonoBehaviour {

    public static bool bulleth = false;
	public void NormalClicked()
    {
        bulleth = false;
        SceneManager.LoadScene("game");
    }
    public void BulletClicked()
    {
        bulleth = true;
        SceneManager.LoadScene("game");
    }
    public void QuitClicked()
    {
        Application.Quit();
    }
}
