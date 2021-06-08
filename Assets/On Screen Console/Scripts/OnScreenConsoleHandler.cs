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
        [Header("Settings")]
        [SerializeField]
        private bool consoleVisible = true;
        [SerializeField]
        private bool backgroundVisible = false;
        [SerializeField]
        private int fontSize = 15;
        [SerializeField]
        [Tooltip("GUI button to toggle console")]
        private bool consoleButtonVisible = true;
        //
        string myLog;
        Queue myLogQueue = new Queue();


        public void ToggleConsole()
        {
            consoleVisible = !consoleVisible;
        }
        public void ToggleBackground()
        {
            backgroundVisible = !backgroundVisible;
        }

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
        Vector2 scrollPosition;
        void OnGUI()
        {
            if(consoleButtonVisible)
            {
                GUI.color = consoleVisible ? Color.red : Color.green;
                if (GUI.Button(new Rect(Screen.width-50, 0, 50, 20), "Toggle"))
                    ToggleConsole();
                GUI.color = Color.white;
            }
            if (!consoleVisible) return;
            if (myLog == null || myLog.Length <= 0) return;
            float logYOffset = 20;
            GUIContent mgc = new GUIContent(myLog);
            float myHeight = (myLog.Length > 0) ? (new GUIStyle(GUI.skin.label)).CalcHeight(mgc, Screen.width) : 0;
            if (backgroundVisible)            
                GUI.Box(new Rect(0, logYOffset, Screen.width, Mathf.Min(myHeight, Screen.height)), "");            
            GUI.color = Color.white;
            if (GUI.Button(new Rect(0, 0, 50, 20), "Clear"))            
                ClearConsole();

            Rect viewport = new Rect(0, logYOffset, Screen.width - 30, myHeight);
            scrollPosition = GUI.BeginScrollView(new Rect(0, logYOffset, Screen.width, Screen.height), scrollPosition, viewport);
            GUI.color = Color.white;
            GUI.skin.label.fontSize = fontSize;
            GUILayout.Label(myLog);
            // End the scroll view that we began above.
            GUI.EndScrollView();

        }

        private string WrapInColor(string s, Color col)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(col)}>{s}</color>";
        }
        public void ClearConsole()
        {
            myLog = "";
            myLogQueue.Clear();
        }
    }
}