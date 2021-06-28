using System;
using System.Collections;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class showHand : MonoBehaviour
{
    public GameObject VisualsRoot;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = VisualsRoot.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHandTracked())
        {
            //SetActive(VisualsRoot, true);
            VisualsRoot.SetActive(true);
        }
        else
        {
            VisualsRoot.SetActive(false);
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
        return HandJointUtils.FindHand(Handedness.Right) != null && HandJointUtils.FindHand(Handedness.Left) != null;
    }
}
