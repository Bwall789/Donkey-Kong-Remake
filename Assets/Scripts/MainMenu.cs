using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject manager;
    public GameObject quitOptions;
    
    public void StartGame(){
        manager.SetActive(true);
    }

    public void OpenAwards(){

    }


    public void CloseAwards(){

    }

    public void OpenOptions(){

    }


    public void CloseOptions(){

    }

    public void QuitMenu(){
        quitOptions.SetActive(true);
    }

    public void QuitYes(){
        Application.Quit();
        Debug.Log("Quit pressed");
    }

    public void QuitNo(){
        quitOptions.SetActive(false);
    }
}
