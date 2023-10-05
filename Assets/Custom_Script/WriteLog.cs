using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class WriteLog : MonoBehaviour
{
    GameManager gameManager;

    private static FileStream FileWriter;

    private static UTF8Encoding encoding;

    private static WriteLog consoleLog;

    public static WriteLog ConsoleLog // one instane mode
    {
        get
        {
            if (consoleLog == null)
                consoleLog = new WriteLog();
            return consoleLog;
        }
    }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void LogStart() // loggging start
    {
        Debug.Log("logging start");
        Directory.CreateDirectory(Application.persistentDataPath + "/Log");
        string NowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(" ", "_").Replace("/", "_").Replace(":", "_");
        FileInfo fileInfo = new FileInfo(Application.persistentDataPath + "/Log/" + NowTime + "_Log.txt");
        // set up the log.txt file location
        FileWriter = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
        encoding = new UTF8Encoding();
        Application.logMessageReceived += LogCallback;
    }
    /// <summary>
    /// Log return
    /// </summary>
    /// <param name="condition">output content</param>
    /// <param name="stackTrace">stackTrace</param>
    /// <param name="type">Log type</param>
    private void LogCallback(string condition, string stackTrace, LogType type) // write into the console
    {
        //輸出的日誌型態可以自定義
        string content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + "【" + type + "】" + "【" + stackTrace + "】" + ":" + condition + Environment.NewLine + Environment.NewLine;
        FileWriter.Write(encoding.GetBytes(content), 0, encoding.GetByteCount(content));
        FileWriter.Flush();
    }

    public void OnDestroy() // close logging
    {
        if (gameManager.ControlLog) // control to keep logging
        {
            if ((FileWriter != null))
            {
                Debug.Log("logging end");
                FileWriter.Close();
                Application.logMessageReceived -= LogCallback;
            }
        } else
        {
            Debug.Log("keep logging");
        }
    }
}
