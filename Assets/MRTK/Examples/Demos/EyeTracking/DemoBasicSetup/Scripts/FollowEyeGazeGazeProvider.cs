// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.Serialization;
using UnityEditor;
using System.IO;
using System;
using System.Globalization;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos.EyeTracking
{
    /// <summary>
    /// Sample for allowing the game object that this script is attached to follow the user's eye gaze
    /// at a given distance of "DefaultDistanceInMeters". 
    /// </summary>
    [AddComponentMenu("Scripts/MRTK/Examples/FollowEyeGazeGazeProvider")]
    public class FollowEyeGazeGazeProvider : MonoBehaviour
    {
        [Tooltip("Display the game object along the eye gaze ray at a default distance (in meters).")]
        [SerializeField]
        private float defaultDistanceInMeters = 2f;
        Vector3 originVector;
        Vector3 dircVector;
        Vector3 eyeDirect_normalized;
        Vector3 oldVector;
        int line = 1;
        string secondTime = "";
        Vector3 HeadOffset = new Vector3(0, 0, 1f);
        Vector3 headOrigin;
        Vector3 headDirection;
        Vector3 headDirection_normalized;
        /*private Vector3 _counter;
        public Vector3 Counter
        {
            get => _counter;
            set
            {
                _counter = value;
                SecondKeyFrames.Add(new SecondKeyFrame(value, Time.time));
            }
        }

        void Start()
        {
            Counter = new Vector3(0.0f, 1.0f, 0.0f);
        }*/

        private void Update()
        {
            var gazeProvider = CoreServices.InputSystem?.GazeProvider;
            if (gazeProvider != null)
            {
                gameObject.transform.position = gazeProvider.GazeOrigin + gazeProvider.GazeDirection.normalized * defaultDistanceInMeters;
                dircVector = CoreServices.InputSystem.GazeProvider.GazeDirection;
                originVector = CoreServices.InputSystem.GazeProvider.GazeOrigin;
                eyeDirect_normalized = CoreServices.InputSystem.EyeGazeProvider.GazeDirection.normalized;

                headOrigin = Camera.main.transform.position + HeadOffset;
                headDirection = Camera.main.transform.forward;
                headDirection_normalized = Camera.main.transform.forward.normalized;

                //print("GazeDirection:" + CoreServices.InputSystem.GazeProvider.GazeDirection);
                //print("GazeOrigin:" + CoreServices.InputSystem.GazeProvider.GazeOrigin);
                //print("HitPosition" + CoreServices.InputSystem.GazeProvider.HitPosition);

                
                if (oldVector != dircVector)
                {
                    //print("true/false" + (oldVector != dircVector));
                    //print("oldVector:" + oldVector);
                    //print("dircVector:" + dircVector);
                    
                    save();
                }
              
            }


        }

        /*[SerializeField]
        public class SecondKeyFrame
        {
            public Vector3 Value;

            public float Time;

            public SecondKeyFrame() { }

            public SecondKeyFrame(Vector3 dircVector, float time)
            {
                Value = dircVector;
                Time = time;
            }
        }

        private List<SecondKeyFrame> SecondKeyFrames = new List<SecondKeyFrame>(10000);

        public string ToCSV()
        {
            //var sb = new System.Text.StringBuilder("Time,dirc_X,dirc_Y,dirc_Z");
            var sb = new System.Text.StringBuilder("");
            string v1 = "(";
            string v2 = ")";
            string final = "";
            foreach (var frame in SecondKeyFrames)
            {
                final = frame.Value.ToString().Replace(v1, "");
                final = final.Replace(v2, "");
                sb.Append("\n").Append(frame.Time.ToString()).Append(",").Append(final);
            }

            return sb.ToString();
        }*/

        public void save()
        {
            string v1 = "(";
            string v2 = ")";
            string final_direct = "";
            string final_origin = "";
            string final_headOrigin = "";
            string final_headDirection = "";
            string final_eyeDirect_normalized = "";
            string final_headDirection_normalized = "";

            //var folder = Application.streamingAssetsPath;
            var folder = Application.persistentDataPath;

            var showText = new System.Text.StringBuilder();
            final_direct = dircVector.ToString().Replace(v1, "");
            final_direct = final_direct.Replace(v2, "");

            final_origin = originVector.ToString().Replace(v1, "");
            final_origin = final_origin.Replace(v2, "");

            final_headOrigin = headOrigin.ToString().Replace(v1, "");
            final_headOrigin = final_headOrigin.Replace(v2, "");

            final_headDirection = headDirection.ToString().Replace(v1, "");
            final_headDirection = final_headDirection.Replace(v2, "");

            final_eyeDirect_normalized = eyeDirect_normalized.ToString().Replace(v1, "");
            final_eyeDirect_normalized = final_eyeDirect_normalized.Replace(v2, "");

            final_headDirection_normalized = headDirection_normalized.ToString().Replace(v1, "");
            final_headDirection_normalized = final_headDirection_normalized.Replace(v2, "");

            string currentTime = Time.time.ToString("f1");
            
            if (line == 1)
            {
                showText = new System.Text.StringBuilder("Time,headOrigin_X,headOrigin_Y,headOrigin_Z,headDirection_X,headDirection_Y,headDirection_Z,eyeOrigin_X,eyeOrigin_Y,eyeOrigin_Z,eyeDirection_X,eyeDirection_Y,eyeDirection_Z");
            }
            showText.Append("\n").Append(currentTime).Append(",").Append(final_headOrigin).Append(",").Append(final_headDirection).Append(",").Append(final_origin).Append(",").Append(final_direct);
            //var content = ToCSV();

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var filePath = Path.Combine(folder, "export_gazeDirction.csv");

            using (StreamWriter writer = new StreamWriter(filePath,true))
            {
                if (currentTime != secondTime)
                {
                    writer.Write(showText);
                }
            }
            
            oldVector = dircVector;
            line = line + 1;
            secondTime = currentTime;
        }
    }
} 