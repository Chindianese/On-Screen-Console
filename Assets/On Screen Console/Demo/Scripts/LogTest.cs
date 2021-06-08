using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chindianese.OnScreenConsole.Demo
{
    /// <author>Tay Hao Cheng</author>
    /// <summary>
    /// Test script to send logs
    /// </summary>
    public class LogTest : MonoBehaviour
    {
        [SerializeField]
        private bool log;

        [SerializeField]
        private bool error;

        [SerializeField]
        private bool warning;
        private void OnValidate()
        {
            if (log)
            {
                Debug.Log("Log Test");
                log = false;
            }
            if (error)
            {
                Debug.LogError("Log Test");
                error = false;
            }
            if (warning)
            {
                Debug.LogWarning("Log Test");
                warning = false;
            }
        }
    }
}