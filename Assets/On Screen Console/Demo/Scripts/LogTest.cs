using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chindianese.OnScreenConsole.Demo
{
    /// <author>Tay Hao Cheng</author>
    /// <summary>
    /// Test script to send logs. 
    /// </summary>
    public class LogTest : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField]
        private bool log; // used as button

        [SerializeField]
        private bool error; // used as button

        [SerializeField]
        private bool warning; // used as button

        [SerializeField]
        private bool exception; // used as button
        private void OnValidate()
        {
            if (log)
            {
                log = false;
                Debug.Log("Log Test");
            }
            if (error)
            {
                error = false;
                Debug.LogError("Error Test");
            }
            if (warning)
            {
                warning = false;
                Debug.LogWarning("Warning Test");
            }
            if (exception)
            {
                exception = false;
                GameObject nullObject = null;
                string nullString = nullObject.name;
            }
        }
        private void Start()
        {
            {
                log = false;
                Debug.Log("Log Test");
            }
            {
                error = false;
                Debug.LogError("Error Test");
            }
            {
                warning = false;
                Debug.LogWarning("Warning Test");
            }
            {
                exception = false;
                GameObject nullObject = null;
                string nullString = nullObject.name;
            }
        }
    }
}