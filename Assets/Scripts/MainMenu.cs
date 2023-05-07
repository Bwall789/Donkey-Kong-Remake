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

    public GameObject achievment1;
    public GameObject achievment2;
    public GameObject achievment3;
    public GameObject achievment4;
    public GameObject achievment5;

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

        if (profile.threeLevelsNoDamage == true){
            achievment1.SetActive(true);
        }else {
            achievment1.SetActive(false);
        }

        if (profile.tenDeaths == true){
            achievment2.SetActive(true);
        }else {
            achievment2.SetActive(false);
        }

        if (profile.onTheBoard == true){
            achievment3.SetActive(true);
        }else {
            achievment3.SetActive(false);
        }

        if (profile.levelScore2500 == true){
            achievment4.SetActive(true);
        }else {
            achievment4.SetActive(false);
        }

        if (profile.TwentyBarrels == true){
            achievment5.SetActive(true);
        }else {
            achievment5.SetActive(false);
        }
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
