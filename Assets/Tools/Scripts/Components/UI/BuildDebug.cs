using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildDebug : MonoBehaviour
{
    private static BuildDebug Instance;

    [SerializeField]
    private TextMeshProUGUI debugTextObject;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void LogMessage(string message) => debugTextObject.text += (message + '\n');

    public void ClearText() => debugTextObject.text = "";

    public void Close() => gameObject.SetActive(false);

    public void Open() => gameObject.SetActive(true);

    public static void Log(string message)
    {
        if(Instance == null)
        {
            Instance = (Instantiate(Resources.Load("BuildDebugCanvas")) as GameObject).transform.GetChild(1).GetComponent<BuildDebug>();
        }

        Instance.LogMessage(message);
    }

    public static void Log(object obj) => Log(obj.ToString());

    public static void Clear()
    {
        Instance?.ClearText();
    }
}
