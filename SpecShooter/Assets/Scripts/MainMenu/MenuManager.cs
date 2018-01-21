using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void PlayButtonPressed(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
    public void Restart(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
