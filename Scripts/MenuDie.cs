using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDie : MonoBehaviour
{
    public void RePlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);


    }
    public void QuitGame()
    {


        Debug.Log("You quit, Why?");
        Application.Quit();
    }



}
