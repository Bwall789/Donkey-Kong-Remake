using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    string profileFile;
    string profileName;
    ProfileData profile = new ProfileData(0,"",0,0);

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public ProfileData profileSelect(string userName)
    {
        profileName = userName;
        profileFile = Application.persistentDataPath + "/" + profileName + ".json";
        readProfileFile();
        return profile;
    }

    public void readProfileFile()
    {
        if (File.Exists(profileFile))
        {
            string fileContents = File.ReadAllText(profileFile);
            profile = JsonUtility.FromJson<ProfileData>(fileContents);
        } else{
            ProfileData newProfile = new ProfileData(0,profileName,0,0);
            string jsonString = JsonUtility.ToJson(newProfile);
            File.WriteAllText(profileFile, jsonString);

        }
    }

    public void writeProfileFile(string usersName, int highestscore, int numOfDeaths, int levelsComplete)
    {
        profileName = usersName;
        profileFile = Application.persistentDataPath + "/" + profileName + ".json";
        ProfileData profile2 = new ProfileData(0,"",0,0);

        profile2.name = usersName;
        profile2.highscore = highestscore;
        profile2.numberOfDeaths = numOfDeaths;
        profile2.levelsCompleted = levelsComplete;

        string jsonString = JsonUtility.ToJson(profile2);
        File.WriteAllText(profileFile, jsonString);
    }
}