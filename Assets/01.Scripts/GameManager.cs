using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-2000)]
public class GameManager : MonoBehaviour
{
    private int a = 30;
    public static GameManager instance = null;

    [SerializeField]
    public SaveData saveData;

    [SerializeField]
    private string saveDatastring = "fandora";

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationFocus(bool focusStatus)

    {
        if (focusStatus)

        {
            DisableSystemUI.DisableNavUI();
        }
    }

    private void Start()
    {
        try
        {
            saveData = ES3.Load<SaveData>(saveDatastring);
        }
        catch
        {
            saveData = new SaveData();
        }
    }

    private void OnApplicationQuit()
    {
        ES3.Save<SaveData>(saveDatastring, saveData);
    }

    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}