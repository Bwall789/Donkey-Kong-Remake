using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject manager;
    
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

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit pressed");
    }


}
