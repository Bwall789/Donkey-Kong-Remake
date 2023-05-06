using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject manager;
    public GameObject quitOptions;
    public GameObject optionsMenu;
    public GameObject statsMenu;

    [SerializeField] private TMP_Dropdown dropdown;
    public string profileName;
    public ProfileData profile;

    public void profileSelect(){

        profileName = dropdown.options[dropdown.value].text;        
        profile = GameObject.Find("GameDataManager").GetComponent<GameDataManager>().profileSelect(profileName);
        GameObject.Find("GameManager").GetComponent<GameManager>().loadProfile(profileName, profile);
        GameObject.Find("GameManager").GetComponent<GameManager>().statsUpdate();
    }
    
    public void StartGame(){
        GameObject.Find("GameManager").GetComponent<GameManager>().NewGame();
    }

    public void OpenStats(){
        statsMenu.SetActive(true);
    }


    public void CloseStats(){
        statsMenu.SetActive(false);
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
