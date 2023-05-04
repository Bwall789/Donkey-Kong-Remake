using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject manager;
    public GameObject quitOptions;
    public GameObject optionsMenu;
    public GameObject awardMenu;
    
    public void StartGame(){
        manager.SetActive(true);
    }

    public void OpenAwards(){
        awardMenu.SetActive(true);
    }


    public void CloseAwards(){
        awardMenu.SetActive(false);
    }

    public void OpenOptions(){
        optionsMenu.SetActive(true);

    }


    public void CloseOptions(){
        optionsMenu.SetActive(false);
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
