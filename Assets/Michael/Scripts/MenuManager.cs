using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(1);
    
    
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
  

