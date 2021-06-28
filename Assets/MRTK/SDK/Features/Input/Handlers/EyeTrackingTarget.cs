// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.Serialization;
using UnityEditor;
using System.IO;
using System.Globalization;


namespace Microsoft.MixedReality.Toolkit.Input
{
    
    /// <summary>
    /// A game object with the "EyeTrackingTarget" script attached reacts to being looked at independent of other available inputs.
    /// </summary>
    [AddComponentMenu("Scripts/MRTK/SDK/EyeTrackingTarget")]
    public class EyeTrackingTarget : InputSystemGlobalHandlerListener, IMixedRealityPointerHandler, IMixedRealitySpeechHandler
    {
        static public Vector3 hitVector;
        static public Vector3 gazeVector;
        string secondTime = "";

        [Tooltip("Select action that are specific to when the target is looked at.")]
        [SerializeField]
        private MixedRealityInputAction selectAction = MixedRealityInputAction.None;

        [Tooltip("List of voice commands to trigger selecting this target only if it is looked at.")]
        [SerializeField]
        [FormerlySerializedAs("voice_select")]
        private MixedRealityInputAction[] voiceSelect = null;

        [Tooltip("Duration in seconds that the user needs to keep looking at the target to select it via dwell activation.")]
        [Range(0, 10)]
        [SerializeField]
        private float dwellTimeInSec = 0.8f;

        [SerializeField]
        [Tooltip("Event is triggered when the user starts to look at the target.")]
        [FormerlySerializedAs("OnLookAtStart")]
        private UnityEvent onLookAtStart = null;

        /// <summary>
        /// Event is triggered when the user starts to look at the target.
        /// </summary>
        public UnityEvent OnLookAtStart
        {
            get { return onLookAtStart; }
            set { onLookAtStart = value; }
        }

        [SerializeField]
        [Tooltip("Event is triggered when the user continues to look at the target.")]
        [FormerlySerializedAs("WhileLookingAtTarget")]
        private UnityEvent whileLookingAtTarget = null;

        /// <summary>
        /// Event is triggered when the user continues to look at the target.
        /// </summary>
        public UnityEvent WhileLookingAtTarget
        {
            get { return whileLookingAtTarget; }
            set { whileLookingAtTarget = value; }
        }

        [SerializeField]
        [Tooltip("Event to be triggered when the user is looking away from the target.")]
        [FormerlySerializedAs("OnLookAway")]
        private UnityEvent onLookAway = null;

        /// <summary>
        /// Event to be triggered when the user is looking away from the target.
        /// </summary>
        public UnityEvent OnLookAway
        {
            get { return onLookAway; }
            set { onLookAway = value; }
        }

        [SerializeField]
        [Tooltip("Event is triggered when the target has been looked at for a given predefined duration (dwellTimeInSec).")]
        [FormerlySerializedAs("OnDwell")]
        private UnityEvent onDwell = null;

        /// <summary>
        /// Event is triggered when the target has been looked at for a given predefined duration (dwellTimeInSec).
        /// </summary>
        public UnityEvent OnDwell
        {
            get { return onDwell; }
            set { onDwell = value; }
        }

        [SerializeField]
        [Tooltip("Event is triggered when the looked at target is selected.")]
        [FormerlySerializedAs("OnSelected")]
        private UnityEvent onSelected = null;

        /// <summary>
        /// Event is triggered when the looked at target is selected.
        /// </summary>
        public UnityEvent OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        
        [SerializeField]
        [Tooltip("If true, the eye cursor (if enabled) will snap to the center of this object.")]
        private bool eyeCursorSnapToTargetCenter = false;

        /// <summary>
        /// If true, the eye cursor (if enabled) will snap to the center of this object.
        /// </summary>
        public bool EyeCursorSnapToTargetCenter
        {
            get { return eyeCursorSnapToTargetCenter; }
            set { eyeCursorSnapToTargetCenter = value; }
        }

        /// <summary>
        /// Returns true if the user looks at the target or more specifically when the eye gaze ray intersects 
        /// with the target's bounding box.
        /// </summary>
        public bool IsLookedAt { get; private set; }

        /// <summary>
        /// Returns true if the user has been looking at the target for a certain amount of time specified by dwellTimeInSec.
        /// </summary>
        public bool IsDwelledOn { get; private set; } = false;
        
        private DateTime lookAtStartTime;

        /// <summary>
        /// Duration in milliseconds to indicate that if more time than this passes without new eye tracking data, then timeout. 
        /// </summary>
        private float EyeTrackingTimeoutInMilliseconds = 200;

        /// <summary>
        /// The time stamp received from the eye tracker to indicate when the eye tracking signal was last updated.
        /// </summary>
        private static DateTime lastEyeSignalUpdateTimeFromET = DateTime.MinValue;

        /// <summary>
        /// The time stamp from the eye tracker has its own time frame, which makes it difficult to compare to local times. 
        /// </summary>
        private static DateTime lastEyeSignalUpdateTimeLocal = DateTime.MinValue; 

        public static GameObject LookedAtTarget { get;  private set; }
        public static EyeTrackingTarget LookedAtEyeTarget { get; private set; }
        public static Vector3 LookedAtPoint { get; private set; }
        int line_gaze = 1;
        #region Focus handling
        protected override void Start()
        {
            base.Start();
            IsLookedAt = false;
            LookedAtTarget = null;
            LookedAtEyeTarget = null;
        }

        private void Update()
        {
            var eyeGazeProvider = CoreServices.InputSystem?.EyeGazeProvider;
            // Try to manually poll the eye tracking data
            //print("eyeGazeProvider" + eyeGazeProvider);
            if (eyeGazeProvider != null 
                && eyeGazeProvider.IsEyeTrackingEnabledAndValid)
            {
                //gazeVector = CoreServices.InputSystem.GazeProvider.GazeDirection;
                //print("gazeVector" + gazeVector);
                UpdateHitTarget();
                

                bool isLookedAtNow = (LookedAtTarget == this.gameObject);
                                
                if (IsLookedAt && (!isLookedAtNow))
                {
                    // Stopped looking at the target
                    OnEyeFocusStop();
                }
                else if ((!IsLookedAt) && (isLookedAtNow))
                {
                    // Started looking at the target
                    OnEyeFocusStart();
                }
                else if (IsLookedAt && (isLookedAtNow))
                {
                    // Keep looking at the target
                    OnEyeFocusStay();
                }
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            OnEyeFocusStop();
        }

        /// <inheritdoc />
        protected override void RegisterHandlers()
        {
            CoreServices.InputSystem?.RegisterHandler<IMixedRealityPointerHandler>(this);
            CoreServices.InputSystem?.RegisterHandler<IMixedRealitySpeechHandler>(this);
        }

        /// <inheritdoc />
        protected override void UnregisterHandlers()
        {
            CoreServices.InputSystem?.UnregisterHandler<IMixedRealityPointerHandler>(this);
            CoreServices.InputSystem?.UnregisterHandler<IMixedRealitySpeechHandler>(this);
        }

        private void UpdateHitTarget()
        {
            var eyeGazeProvider = CoreServices.InputSystem?.EyeGazeProvider;
            if (eyeGazeProvider != null)
            {
                if (lastEyeSignalUpdateTimeFromET != eyeGazeProvider.Timestamp)
                {
                    lastEyeSignalUpdateTimeFromET = eyeGazeProvider.Timestamp;
                    lastEyeSignalUpdateTimeLocal = DateTime.UtcNow;

                    // ToDo: Handle raycasting layers
                    RaycastHit hitInfo = default(RaycastHit);
                    Ray lookRay = new Ray(eyeGazeProvider.GazeOrigin, eyeGazeProvider.GazeDirection.normalized);
                    bool isHit = UnityEngine.Physics.Raycast(lookRay, out hitInfo);

                    if (isHit)
                    {
                        LookedAtTarget = hitInfo.collider.gameObject;
                        LookedAtEyeTarget = LookedAtTarget.GetComponent<EyeTrackingTarget>();
                        LookedAtPoint = hitInfo.point;
                        //line_gaze = changeBanner_Referent.line;
                        SaveHit();
                        print("LookedAtTarget:" + LookedAtTarget);
                        //print("LookedAtEyeTarget:" + LookedAtEyeTarget);
                        //print("LookedAtPoint:" + LookedAtPoint);

                        //print("HitPosition" + CoreServices.InputSystem.EyeGazeProvider.HitPosition);
                        hitVector = CoreServices.InputSystem.EyeGazeProvider.HitPosition;
                    }
                    else
                    {
                        LookedAtTarget = null;
                        LookedAtEyeTarget = null;
                    }
                }
                else if ((DateTime.UtcNow - lastEyeSignalUpdateTimeLocal).TotalMilliseconds > EyeTrackingTimeoutInMilliseconds)
                {
                    LookedAtTarget = null;
                    LookedAtEyeTarget = null;
                }
                //print("LookedAtTarget:" + LookedAtTarget);
                
            }
        }

        public void SaveHit()
        {
            //var folder = Application.streamingAssetsPath;
            var folder = Application.persistentDataPath;

            var showText = new System.Text.StringBuilder();
            string currentTime = Time.time.ToString("f1");

            if (line_gaze == 1)
            {

                //showText = new System.Text.StringBuilder("Time,hit_target");
                showText = new System.Text.StringBuilder("\n Time,key,Modality,Referent,hit_target");
            }
            
            showText.Append("\n").Append(currentTime).Append(",").Append(" ").Append(",").Append(" ").Append(",").Append(" ").Append(",").Append(LookedAtTarget.ToString());

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //var filePath = Path.Combine(folder, "export_gazeHit.csv");
            var filePath = Path.Combine(folder, "export_keyPress.csv");

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if (currentTime != secondTime)
                {
                    writer.Write(showText);
                }
            }

            line_gaze = line_gaze + 1;
            secondTime = currentTime;

        }

        protected void OnEyeFocusStart()
        {
            lookAtStartTime = DateTime.UtcNow;
            IsLookedAt = true;
            OnLookAtStart.Invoke();
            

        }

        protected void OnEyeFocusStay()
        {
            WhileLookingAtTarget.Invoke();

            if ((!IsDwelledOn) && (DateTime.UtcNow - lookAtStartTime).TotalSeconds > dwellTimeInSec)
            {
                OnEyeFocusDwell();
            }
        }

        protected void OnEyeFocusDwell()
        {
            IsDwelledOn = true;
            OnDwell.Invoke();
        }

        protected void OnEyeFocusStop()
        {
            IsDwelledOn = false;
            IsLookedAt = false;
            OnLookAway.Invoke();            
        }

        #endregion 

        #region IMixedRealityPointerHandler
        void IMixedRealityPointerHandler.OnPointerUp(MixedRealityPointerEventData eventData) { }

        void IMixedRealityPointerHandler.OnPointerDown(MixedRealityPointerEventData eventData) { }

        void IMixedRealityPointerHandler.OnPointerDragged(MixedRealityPointerEventData eventData) { }

        void IMixedRealityPointerHandler.OnPointerClicked(MixedRealityPointerEventData eventData)
        {
            if ((eventData.MixedRealityInputAction == selectAction) && IsLookedAt)
            {
                OnSelected.Invoke();
            }
        }
        
        void IMixedRealitySpeechHandler.OnSpeechKeywordRecognized(SpeechEventData eventData)
        {
            if ((IsLookedAt) && (this.gameObject == LookedAtTarget))
            {
                if (voiceSelect != null)
                {
                    for (int i = 0; i < voiceSelect.Length; i++)
                    {
                        if (eventData.MixedRealityInputAction == voiceSelect[i])
                        {
                            OnSelected.Invoke();
                        }
                    }
                }
            }
        }
        #endregion
    }
}