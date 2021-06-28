using System;
using System.Collections;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;


/// <summary>
/// This class provides wrapper functionality for triggering animations and fades for the hand rig.
/// </summary>
public class HandInteractionHint : MonoBehaviour
{
    public GameObject VisualsRoot { get; set; }



    /// <

    [Tooltip("Time to wait between repeats in seconds.")]
    [SerializeField]
    private float repeatDelay = 1f;

    /// <summary>
    /// Time to wait between repeats in seconds.
    /// </summary>


    /// <summary>
    /// Custom function to determine visibility of visuals.
    /// Return true to hide visuals and reset min timer (max timer will still be in effect), return false when user is doing nothing and needs a hint.
    /// </summary>
    public Func<bool> CustomShouldHideVisuals = delegate { return false; };

    private Animator animator;

    private bool animatingOut = false;

    private bool loopRunning = false;

    /*void Update()
    {
        print("IsHandTracked()_real:" + IsHandTracked());
        if (IsHandTracked())
        {
            //SetActive(VisualsRoot, true);
            SetActive(VisualsRoot, true);
        }
        else
        {
            SetActive(VisualsRoot, false);
        }
    }*/

    private void Awake()
    {
        if (VisualsRoot == null)
        {
            if (transform.childCount > 0)
            {
                VisualsRoot = transform.GetChild(0).gameObject;
            }
            else
            {
                Debug.LogError("Incorrect hand rig setup. Disabling gameObject");
                gameObject.SetActive(false);
            }
        }

        // store the root's animator
        animator = VisualsRoot.GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Hand rig does not have an animator. Disabling gameObject");
            gameObject.SetActive(false);
        }

        // hide visuals by default
        if (VisualsRoot != null)
        {
            VisualsRoot.SetActive(false);
        }
    }



    /// <summary>
    /// Starts the hint loop logic.
    /// </summary>

    /// <summary>
    /// Fades out the hint and stops the hint loop logic
    /// </summary>

    /// <summary>
    /// Stops the hint with appropriate fade.
    /// </summary>


    /// <summary>
    /// The main timer logic coroutine. Pass the min/max delay to use and the function to evaluate the desired state.
    /// </summary>
    private IEnumerator HintLoopSequence(string stateToPlay)
    {
        // loop until the gameObject has been turned off
        while (VisualsRoot != null && loopRunning)
        {
            // First wait for the min timer, resetting it whenever ShouldHide is true.  Also
            // wait for the max timer, never resetting it.
            float maxTimer = 0;
            float timer = 0;
            /*while (timer < MinDelay && maxTimer < MaxDelay)
            {
                if (ShouldHideVisuals())
                {
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }

                if (UseMaxDelay)
                {
                    maxTimer += Time.deltaTime;
                }

                yield return null;
            }*/

            // show the root
            SetActive(VisualsRoot, true);
            print("IsHandTracked():" + IsHandTracked());
            if (!IsHandTracked())
            {
                SetActive(VisualsRoot, false);
            }

            if (animator != null)
            {
                animator.Play(stateToPlay);
            }

            float visibleTime = Time.time;
            int playCount = 0;

            // loop as long as visuals are active and we haven't repeated the number of times desired
            /*while (VisualsRoot.activeSelf && playCount < Repeats)
            {
                // hide if hand is present, but maxTimer was not hit
                bool shouldHide = ShouldHideVisuals();
                bool fadeOut = Time.time - visibleTime >= animationHideTime;
                if (shouldHide || fadeOut)
                {
                    // Yield while deactivate anim is playing (or instant deactivate if not animating)
                    yield return FadeOutHint();

                    // if fade out was caused by user interacting, we've reached the repeat limit, or we've stopped the loop, break out
                    if (shouldHide || playCount == Repeats - 1 || !loopRunning)
                    {
                        break;
                    }
                    // If we autohid, then reappear if hands are not tracked
                    else
                    {
                        yield return new WaitForSeconds(RepeatDelay);
                        SetActive(VisualsRoot, true);
                        if (animator != null)
                        {
                            animator.Play(stateToPlay);
                        }
                        visibleTime = Time.time;
                        playCount++;
                    }
                }
                yield return null;
            }*/
            yield return null;
        }

        //print("IsHandTracked():" + IsHandTracked());
        /*if (IsHandTracked())
        {
            SetActive(VisualsRoot, true);
        }
        else
        {
            SetActive(VisualsRoot, false);
        }*/
        //SetActive(VisualsRoot, true);
        /*while (VisualsRoot != null && loopRunning)
        {
            SetActive(VisualsRoot, true);
        }
        yield return null;*/
    }

    private void SetActive(GameObject root, bool show)
    {
        if (root != null)
        {
            root.SetActive(show);


        }
    }

    /// <summary>
    /// Gets the duration of the animation name passed in, or 0 if the state name is not found.
    /// </summary>


    /// <summary>
    /// Check if the user is making an attempt to proceed, according to the hint.
    /// Return true if the user is attempting to interact properly.  Visuals will hide until the max timer expires.
    /// Return false if the user is doing nothing.  Visuals will show according to the min timer.
    /// </summary>


    /// <summary>
    /// Return true if either of the user's hands are being tracked.
    /// Return false if neither of the user's hands are being tracked.
    /// </summary>
    private bool IsHandTracked()
    {
        print("Handedness.Right" + Handedness.Right);
        print(" HandJointUtils.FindHand(Handedness.Right)" + HandJointUtils.FindHand(Handedness.Right));
        print("Handedness.Right" + Handedness.Right);
        print(" HandJointUtils.FindHand(Handedness.Left)" + HandJointUtils.FindHand(Handedness.Left));
        return HandJointUtils.FindHand(Handedness.Right) != null;
    }
}

