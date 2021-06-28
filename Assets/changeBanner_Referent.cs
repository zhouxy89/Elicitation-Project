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
using UnityEngine.UI;

public class changeBanner_Referent : MonoBehaviour
{
    Text referent;
    int[] OrderOfReferent_P = Initialization.values_P;
    int[] OrderOfReferent_S = Initialization.values_S;
    int[] OrderOfReferent_GS = Initialization.values_GS;
    int[] OrderOfReferent_G = Initialization.values_G;
    //int[] OrderOfReferent = choseModalityOrder.experiementOrder;
    int line = 1;
    string secondTime = "";
    Text record_modality;
    // Start is called before the first frame update
    void Start()
    {
        referent = GameObject.Find("Referent").GetComponent<Text>();
        //print("OrderOfReferent"+ OrderOfReferent);

        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Initialization.order == 3) {
        //gameObject.GetComponent<Text>().enabled = false;
        //} 
        //if (Initialization.order < OrderOfReferent.Length)
        if (Input.GetKey(KeyCode.UpArrow) && Initialization.i < OrderOfReferent_S.Length && Initialization.j < OrderOfReferent_P.Length)
        {
            
            changeReferent.next = false;
            Panel1Script.next = false;
            switch (choseModalityOrder.experiementOrder[Initialization.order])
            {
                case 0:
                        switch (OrderOfReferent_P[Initialization.j])
                        {
                            case 1:
                                referent.text = "Change yellow cube color to purple";
                                break;
                            case 2:
                                referent.text = "Reverse the color";
                                break;
                            case 3:
                                referent.text = "Change yellow cube color to purple";
                                break;
                            case 4:
                                referent.text = "Reverse the color";
                                break;
                            case 5:
                                referent.text = "Change yellow cube color to purple";
                                break;
                            case 6:
                                referent.text = "Reverse the color";
                                break;
                        }
                    break;
                case 1:
                        switch (OrderOfReferent_S[Initialization.i])
                        {
                            case 1:
                                referent.text = "Move yellow cube to the right side of purple capsule";
                                break;
                            case 2:
                                referent.text = "Move yellow cube to the left side of blue cylinder";
                                break;
                            case 3:
                                referent.text = "Move yellow cube up";
                                break;
                            case 4:
                                referent.text = "Move yellow cube down";
                                break;
                            case 5:
                                referent.text = "Move yellow cube towards yourself";
                                break;
                            case 6:
                                referent.text = "Move yellow cube away from yourself";
                                break;
                            case 7:
                                referent.text = "Roll yellow cube clockwise";
                                break;
                            case 8:
                                referent.text = "Roll yellow cube counter clockwise";
                                break;
                            case 9:
                                referent.text = "Yaw yellow cube to left";
                                break;
                            case 10:
                                referent.text = "Yaw yellow cube to right";
                                break;
                            case 11:
                                referent.text = "Pitch yellow cube up";
                                break;
                            case 12:
                                referent.text = "Pitch yellow cube down";
                                break;
                            case 13:
                                referent.text = "Enlarge yellow cube";
                                break;
                            case 14:
                                referent.text = "Shrink yellow cube";
                                break;
                            case 15:
                                referent.text = "Create object";
                                break;
                            case 16:
                                referent.text = "Destroy yellow cube";
                                break;
                            case 17:
                                referent.text = "Select yellow cube";
                                break;
                            case 18:
                                referent.text = "Select both yellow cube and green sphere";
                                break;
                            case 19:
                                referent.text = "Destroy both yellow cube and green sphere";
                                break;
                            case 20:
                                referent.text = "Create two objects at the same time";
                                break;
                            case 21:
                                referent.text = "Enlarge both yellow cube and green sphere";
                                break;
                            case 22:
                                referent.text = "Shrink both yellow cube and green sphere";
                                break;

                        }

                    break;
                case 2:
                        switch (OrderOfReferent_GS[Initialization.i])
                        {
                            case 1:
                                referent.text = "Move yellow cube to the right side of purple capsule";
                                break;
                            case 2:
                                referent.text = "Move yellow cube to the left side of blue cylinder";
                                break;
                            case 3:
                                referent.text = "Move yellow cube up";
                                break;
                            case 4:
                                referent.text = "Move yellow cube down";
                                break;
                            case 5:
                                referent.text = "Move yellow cube towards yourself";
                                break;
                            case 6:
                                referent.text = "Move yellow cube away from yourself";
                                break;
                            case 7:
                                referent.text = "Roll yellow cube clockwise";
                                break;
                            case 8:
                                referent.text = "Roll yellow cube counter clockwise";
                                break;
                            case 9:
                                referent.text = "Yaw yellow cube to left";
                                break;
                            case 10:
                                referent.text = "Yaw yellow cube to right";
                                break;
                            case 11:
                                referent.text = "Pitch yellow cube up";
                                break;
                            case 12:
                                referent.text = "Pitch yellow cube down";
                                break;
                            case 13:
                                referent.text = "Enlarge yellow cube";
                                break;
                            case 14:
                                referent.text = "Shrink yellow cube";
                                break;
                            case 15:
                                referent.text = "Create object";
                                break;
                            case 16:
                                referent.text = "Destroy yellow cube";
                                break;
                            case 17:
                                referent.text = "Select yellow cube";
                                break;
                            case 18:
                                referent.text = "Select both yellow cube and green sphere";
                                break;
                            case 19:
                                referent.text = "Destroy both yellow cube and green sphere";
                                break;
                            case 20:
                                referent.text = "Create two objects at the same time";
                                break;
                            case 21:
                                referent.text = "Enlarge both yellow cube and green sphere";
                                break;
                            case 22:
                                referent.text = "Shrink both yellow cube and green sphere";
                                break;

                        }
                    break;
                case 3:
                        switch (OrderOfReferent_G[Initialization.i])
                        {
                            case 1:
                                referent.text = "Move yellow cube to the right side of purple capsule";
                                break;
                            case 2:
                                referent.text = "Move yellow cube to the left side of blue cylinder";
                                break;
                            case 3:
                                referent.text = "Move yellow cube up";
                                break;
                            case 4:
                                referent.text = "Move yellow cube down";
                                break;
                            case 5:
                                referent.text = "Move yellow cube towards yourself";
                                break;
                            case 6:
                                referent.text = "Move yellow cube away from yourself";
                                break;
                            case 7:
                                referent.text = "Roll yellow cube clockwise";
                                break;
                            case 8:
                                referent.text = "Roll yellow cube counter clockwise";
                                break;
                            case 9:
                                referent.text = "Yaw yellow cube to left";
                                break;
                            case 10:
                                referent.text = "Yaw yellow cube to right";
                                break;
                            case 11:
                                referent.text = "Pitch yellow cube up";
                                break;
                            case 12:
                                referent.text = "Pitch yellow cube down";
                                break;
                            case 13:
                                referent.text = "Enlarge yellow cube";
                                break;
                            case 14:
                                referent.text = "Shrink yellow cube";
                                break;
                            case 15:
                                referent.text = "Create object";
                                break;
                            case 16:
                                referent.text = "Destroy yellow cube";
                                break;
                            case 17:
                                referent.text = "Select yellow cube";
                                break;
                            case 18:
                                referent.text = "Select both yellow cube and green sphere";
                                break;
                            case 19:
                                referent.text = "Destroy both yellow cube and green sphere";
                                break;
                            case 20:
                                referent.text = "Create two objects at the same time";
                                break;
                            case 21:
                                referent.text = "Enlarge both yellow cube and green sphere";
                                break;
                            case 22:
                                referent.text = "Shrink both yellow cube and green sphere";
                                break;

                        }
                    break;
            }
            record_modality = changeModality.modality;
            //line = EyeTrackingTarget.line_gaze;
            SaveBanner();
        }
            
                 
       
    }

    public void SaveBanner()
    {
        //var folder = Application.streamingAssetsPath;
        var folder = Application.persistentDataPath;

        var showText = new System.Text.StringBuilder();
        string currentTime = Time.time.ToString("f1");

        /*if (line == 1)
        {

            showText = new System.Text.StringBuilder("\n Time,key,Modality,Referent,hit_target");
        }*/
        
        showText.Append("\n").Append(currentTime).Append(",").Append("change referentBanner").Append(",").Append(record_modality.text).Append(",").Append(referent.text);

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
