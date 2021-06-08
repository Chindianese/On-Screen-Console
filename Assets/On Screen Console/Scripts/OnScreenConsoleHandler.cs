using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chindianese.OnScreenConsole
{
    /// <author>Tay Hao Cheng</author>
    /// <summary>
    /// https://answers.unity.com/questions/1020051/print-debuglog-to-screen-c.html
    /// </summary>
    [ExecuteInEditMode]
    public class OnScreenConsoleHandler : MonoBehaviour
    {
        string myLog;
        Queue myLogQueue = new Queue();

        void OnEnable()
        {
            Debug.Log("Enabled On Screen Console Handler");
            Application.logMessageReceived += HandleLog;
        }

        void OnDisable()
        {
            Debug.Log("Disabled On Screen Console Handler");
            Application.logMessageReceived -= HandleLog;
        }

        void HandleLog(string logString, string stackTrace, LogType type)
        {
            myLog = logString;
            string formattedLog = "\n [" + type + "] : " + myLog;
            if (type == LogType.Exception) // add stack trace
                formattedLog = "\n" + stackTrace;
            // handle color formatting
            switch (type)
            {
                case LogType.Log:
                    break;
                case LogType.Warning:
                    formattedLog = WrapInColor(formattedLog, Color.yellow);
                    break;
                case LogType.Exception:
                    formattedLog = WrapInColor(formattedLog, Color.red);
                    break;
                case LogType.Error:
                    formattedLog = WrapInColor(formattedLog, Color.red);
                    break;
                case LogType.Assert:
                    break;
            }
            
            myLogQueue.Enqueue(formattedLog); // Add to queue
            myLog = string.Empty;
            foreach (string mylog in myLogQueue)
            {
                myLog += mylog;
            }
        }

        void OnGUI()
        {
           //  GUI.Box(new Rect(0, 0, Screen.width, myLogQueue.Count * 20), "Console Background");
            GUILayout.Label(myLog);
        }

        private string WrapInColor(string s, Color col)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(col)}>{s}</color>";
        }
    }
}