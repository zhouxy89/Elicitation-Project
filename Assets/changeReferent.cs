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

public class changeReferent : MonoBehaviour
{
    Animator m_Animator;
    int[] OrderOfReferent_P = Initialization.values_P;
    int[] OrderOfReferent_S = Initialization.values_S;
    int[] OrderOfReferent_GS = Initialization.values_GS;
    int[] OrderOfReferent_G = Initialization.values_G;
    //public Material oldMaterials;
    MeshRenderer cubeRenderer;
    //int[] OrderOfReferent = choseModalityOrder.experiementOrder;
    static public bool next = false;
    int line = 1;
    string secondTime = "";
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        cubeRenderer = gameObject.GetComponent<MeshRenderer>();
        //foreach (int value in referentOrder)
        //{
        //print("referentOrder:" + value);
        //}
    }

    void nextReferent()
    {
        Initialization.i++;

    }

    void nextPracticeReferent()
    {
        Initialization.j++;

    }
    // Update is called once per frame
    void Update()
    {


        //if (Input.GetKey(KeyCode.RightArrow))
        //{

        //m_Animator.SetTrigger("Xbox");
        //m_Animator.ResetTrigger("BackToIdle");
        //}
        if (Initialization.order < 4)
        { 
            if (Input.GetKey(KeyCode.RightArrow) && 0 < Initialization.i && Initialization.i < OrderOfReferent_S.Length + 1)
            {
                SaveReferent();
            }
            if (Input.GetKey(KeyCode.RightArrow) && Initialization.i < OrderOfReferent_S.Length && Initialization.j < OrderOfReferent_P.Length)
            {
                
                print("modality order:" + choseModalityOrder.experiementOrder[Initialization.order]);
                switch (choseModalityOrder.experiementOrder[Initialization.order])
                {
                    case 0:
                        //print("OrderOfReferent_P[Initialization.j]:" + OrderOfReferent_P[Initialization.j]);
                        switch (OrderOfReferent_P[Initialization.j])
                            {
                                
                                case 1:
                                    m_Animator.SetTrigger("ChangeColor");
                                    m_Animator.ResetTrigger("BackToIdle");
                                    break;
                                case 2:
                                    m_Animator.SetTrigger("BackToIdle");
                                    m_Animator.ResetTrigger("BackToIdle");
                                    break;
                                case 3:
                                    m_Animator.SetTrigger("ChangeColor");
                                    m_Animator.ResetTrigger("BackToIdle");
                                    break;
                                case 4:
                                    m_Animator.SetTrigger("BackToIdle");
                                    m_Animator.ResetTrigger("BackToIdle");
                                    break;
                                case 5:
                                    m_Animator.SetTrigger("ChangeColor");
                                    m_Animator.ResetTrigger("BackToIdle");
                                    break;
                                case 6:
                                    m_Animator.SetTrigger("BackToIdle");
                                    m_Animator.ResetTrigger("BackToIdle");
                                    break;
                            }
                        break;
                    case 1:
                            switch (OrderOfReferent_S[Initialization.i])
                            {
                                case 1:
                                    m_Animator.SetTrigger("MoveToRight");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 2:
                                    m_Animator.SetTrigger("MoveToLeft");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 3:
                                    m_Animator.SetTrigger("MoveUp");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 4:
                                    m_Animator.SetTrigger("MoveDown");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 5:
                                    m_Animator.SetTrigger("MoveTowards");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 6:
                                    m_Animator.SetTrigger("MoveAway");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 7:
                                    m_Animator.SetTrigger("RollClockwise");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 8:
                                    m_Animator.SetTrigger("RollCounterClockwise");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 9:
                                    m_Animator.SetTrigger("YawLeft");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 10:
                                    m_Animator.SetTrigger("YawRight");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 11:
                                    m_Animator.SetTrigger("PitchUp");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 12:
                                    m_Animator.SetTrigger("PitchDown");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 13:
                                    m_Animator.SetTrigger("Enlarge");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 14:
                                    m_Animator.SetTrigger("Shrink");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 15:
                                    m_Animator.SetTrigger("Create");
                                    gameObject.GetComponent<Renderer>().enabled = true;
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 16:
                                    m_Animator.SetTrigger("Destory");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 17:
                                    m_Animator.SetTrigger("Select");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 18:
                                    m_Animator.SetTrigger("SelectWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 19:
                                    m_Animator.SetTrigger("DestoryWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 20:
                                    m_Animator.SetTrigger("CreateWithSphere");
                                    gameObject.GetComponent<Renderer>().enabled = true;
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 21:
                                    m_Animator.SetTrigger("EnlargeWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 22:
                                    m_Animator.SetTrigger("ShrinkWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;

                            }
                        break;
                    case 2:
                            switch (OrderOfReferent_GS[Initialization.i])
                            {
                                case 1:
                                    m_Animator.SetTrigger("MoveToRight");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 2:
                                    m_Animator.SetTrigger("MoveToLeft");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 3:
                                    m_Animator.SetTrigger("MoveUp");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 4:
                                    m_Animator.SetTrigger("MoveDown");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 5:
                                    m_Animator.SetTrigger("MoveTowards");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 6:
                                    m_Animator.SetTrigger("MoveAway");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 7:
                                    m_Animator.SetTrigger("RollClockwise");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 8:
                                    m_Animator.SetTrigger("RollCounterClockwise");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 9:
                                    m_Animator.SetTrigger("YawLeft");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 10:
                                    m_Animator.SetTrigger("YawRight");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 11:
                                    m_Animator.SetTrigger("PitchUp");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 12:
                                    m_Animator.SetTrigger("PitchDown");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 13:
                                    m_Animator.SetTrigger("Enlarge");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 14:
                                    m_Animator.SetTrigger("Shrink");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 15:
                                    m_Animator.SetTrigger("Create");
                                    gameObject.GetComponent<Renderer>().enabled = true;
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 16:
                                    m_Animator.SetTrigger("Destory");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 17:
                                    m_Animator.SetTrigger("Select");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 18:
                                    m_Animator.SetTrigger("SelectWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 19:
                                    m_Animator.SetTrigger("DestoryWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 20:
                                    m_Animator.SetTrigger("CreateWithSphere");
                                    gameObject.GetComponent<Renderer>().enabled = true;
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 21:
                                    m_Animator.SetTrigger("EnlargeWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 22:
                                    m_Animator.SetTrigger("ShrinkWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;

                            }
                        break;
                    case 3:
                            switch (OrderOfReferent_G[Initialization.i])
                            {
                                case 1:
                                    m_Animator.SetTrigger("MoveToRight");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 2:
                                    m_Animator.SetTrigger("MoveToLeft");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 3:
                                    m_Animator.SetTrigger("MoveUp");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 4:
                                    m_Animator.SetTrigger("MoveDown");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 5:
                                    m_Animator.SetTrigger("MoveTowards");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 6:
                                    m_Animator.SetTrigger("MoveAway");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 7:
                                    m_Animator.SetTrigger("RollClockwise");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 8:
                                    m_Animator.SetTrigger("RollCounterClockwise");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 9:
                                    m_Animator.SetTrigger("YawLeft");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 10:
                                    m_Animator.SetTrigger("YawRight");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 11:
                                    m_Animator.SetTrigger("PitchUp");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 12:
                                    m_Animator.SetTrigger("PitchDown");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 13:
                                    m_Animator.SetTrigger("Enlarge");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 14:
                                    m_Animator.SetTrigger("Shrink");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 15:
                                    m_Animator.SetTrigger("Create");
                                    gameObject.GetComponent<Renderer>().enabled = true;
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 16:
                                    m_Animator.SetTrigger("Destory");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 17:
                                    m_Animator.SetTrigger("Select");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 18:
                                    m_Animator.SetTrigger("SelectWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 19:
                                    m_Animator.SetTrigger("DestoryWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 20:
                                    m_Animator.SetTrigger("CreateWithSphere");
                                    gameObject.GetComponent<Renderer>().enabled = true;
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 21:
                                    m_Animator.SetTrigger("EnlargeWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;
                                case 22:
                                    m_Animator.SetTrigger("ShrinkWithSphere");
                                    m_Animator.ResetTrigger("BackToIdle");

                                    break;

                            }
                        break;
                }


                if(choseModalityOrder.experiementOrder[Initialization.order] == 0)
                {
                    if (next == false)
                    {

                        next = true;
                        nextPracticeReferent();


                    }
                }
                else
                {
                    if (next == false)
                    {

                        next = true;
                        nextReferent();


                    }
                }
                
            }
        }
    }

    public void SaveReferent()
    {
        //var folder = Application.streamingAssetsPath;
        var folder = Application.persistentDataPath;

        var showText = new System.Text.StringBuilder();
        string currentTime = Time.time.ToString("f1");

        showText.Append("\n").Append(currentTime).Append(",").Append("show animation");

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        var filePath = Path.Combine(folder, "export_keyPress.csv");

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            if (currentTime != secondTime)
            {
                writer.Write(showText);
            }
            
        }

        line = line + 1;
        secondTime = currentTime;

    }
}
