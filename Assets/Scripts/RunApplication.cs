using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class RunApplication : MonoBehaviour
{
    public static RunApplication Instance;

    private Process CurrentProcess;
    private string NameOfRunningProcess;

    [SerializeField]
    private GameObject BlockInput;

    [SerializeField]
    private ApplicationInfoPanel Info;


    // Start is called before the first frame update

    private void Awake()
    {
        Application.runInBackground = false;
        Application.targetFrameRate = 100;
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentProcess != null && !CurrentProcess.HasExited)
        {
            ShowRunningApp(true);
        }
        else
        {
            ShowRunningApp(false);
        }
    }

    public void LaunchApp(string path, string name)
    {

        NameOfRunningProcess = name;
        CurrentProcess = Process.Start(Application.dataPath + path);        
    }

    public void LaunchWeb (string path, string name)
    {

        NameOfRunningProcess = name;
        CurrentProcess = Process.Start("chrome", "--new-window --start-maximized --start-fullscreen --app=" + Application.dataPath + path);
    }

    public void LaunchInfo(string path, string name)
    {

        NameOfRunningProcess = name;
        Info.gameObject.SetActive(true);
    }

    public void CloseProcess()
    {
        CurrentProcess.Kill();
    }

    public string GetRunningProcessName()
    {
        return NameOfRunningProcess;
    }

    void ShowRunningApp(bool show)
    {
        BlockInput.SetActive(show);
    }
}

