using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    string profileFile;
    string profileName;
    ProfileData profile = new ProfileData(0,"",0,0);

    public ProfileData profileSelect(string userName)
    {
        profileName = userName;
        profileFile = Application.persistentDataPath + "/" + profileName + ".json";
        readProfileFile();
        Debug.Log(profileFile);
        return profile;
    }

    public void readProfileFile()
    {
        if (File.Exists(profileFile))
        {
            string fileContents = File.ReadAllText(profileFile);
            profile = JsonUtility.FromJson<ProfileData>(fileContents);
            Debug.Log("profile loads");
        } else{
            ProfileData newProfile = new ProfileData(0,profileName,0,0);
            string jsonString = JsonUtility.ToJson(newProfile);
            File.WriteAllText(profileFile, jsonString);
            Debug.Log("profile new");

        }
    }

    public void writeProfileFile()
    {
        string jsonString = JsonUtility.ToJson(profile);
        File.WriteAllText(profileFile, jsonString);
    }
}