using System;
using System.Collections;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    public GameObject VisualsRoot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetActive(VisualsRoot, true);
        print("IsHandTracked():" + IsHandTracked());
        if (!IsHandTracked())
        {
            SetActive(VisualsRoot, false);
        }
    }

    private void SetActive(GameObject root, bool show)
    {
        if (root != null)
        {
            root.SetActive(show);


        }
    }

    private bool IsHandTracked()
    {
        print("Handedness.Right" + Handedness.Right);
        print(" HandJointUtils.FindHand(Handedness.Right)" + HandJointUtils.FindHand(Handedness.Right));
        print("Handedness.Right" + Handedness.Right);
        print(" HandJointUtils.FindHand(Handedness.Left)" + HandJointUtils.FindHand(Handedness.Left));
        return HandJointUtils.FindHand(Handedness.Left) != null;
    }
}
