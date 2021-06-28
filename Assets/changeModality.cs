using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeModality : MonoBehaviour
{
    static public Text modality;
    int[] OrderOfReferent_P = Initialization.values_P;
    int[] OrderOfReferent_S = Initialization.values_S;
    int[] OrderOfReferent_GS = Initialization.values_GS;
    int[] OrderOfReferent_G = Initialization.values_G;
    //int[] OrderOfReferent = choseModalityOrder.experiementOrder;
    
    // Start is called before the first frame update
    void Start()
    {
        modality = GameObject.Find("Modality").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Initialization.order == 3)
            {
            modality.text = "Thank you for your participation!";
        }*/

        if (Input.GetKey(KeyCode.UpArrow) && Initialization.i < OrderOfReferent_S.Length && Initialization.j < OrderOfReferent_P.Length)
        {
            

            switch (choseModalityOrder.experiementOrder[Initialization.order])
            {
                case 0:
                        switch (OrderOfReferent_P[Initialization.j])
                        {
                            case 1:
                                modality.text = "Speech Only";
                                break;
                            case 2:
                                modality.text = "Speech Only";
                                break;
                            case 3:
                                modality.text = "Gesture Only";
                                break;
                            case 4:
                                modality.text = "Gesture Only";
                                break;
                            case 5:
                                modality.text = "Speech and Gesture";
                                break;
                            case 6:
                                modality.text = "Speech and Gesture";
                                break;
                        }
                    break;
                case 1:
                    switch (OrderOfReferent_S[Initialization.i])
                    {
                        case 1:
                            modality.text = "Speech Only";
                            break;
                        case 2:
                            modality.text = "Speech Only";
                            break;
                        case 3:
                            modality.text = "Speech Only";
                            break;
                        case 4:
                            modality.text = "Speech Only";
                            break;
                        case 5:
                            modality.text = "Speech Only";
                            break;
                        case 6:
                            modality.text = "Speech Only";
                            break;
                        case 7:
                            modality.text = "Speech Only";
                            break;
                        case 8:
                            modality.text = "Speech Only";
                            break;
                        case 9:
                            modality.text = "Speech Only";
                            break;
                        case 10:
                            modality.text = "Speech Only";
                            break;
                        case 11:
                            modality.text = "Speech Only";
                            break;
                        case 12:
                            modality.text = "Speech Only";
                            break;
                        case 13:
                            modality.text = "Speech Only";
                            break;
                        case 14:
                            modality.text = "Speech Only";
                            break;
                        case 15:
                            modality.text = "Speech Only";
                            break;
                        case 16:
                            modality.text = "Speech Only";
                            break;
                        case 17:
                            modality.text = "Speech Only";
                            break;
                        case 18:
                            modality.text = "Speech Only";
                            break;
                        case 19:
                            modality.text = "Speech Only";
                            break;
                        case 20:
                            modality.text = "Speech Only";
                            break;
                        case 21:
                            modality.text = "Speech Only";
                            break;
                        case 22:
                            modality.text = "Speech Only";
                            break;

                    }

                    break;
                case 2:
                    switch (OrderOfReferent_GS[Initialization.i])
                    {
                        case 1:
                            modality.text = "Speech and Gesture";
                            break;
                        case 2:
                            modality.text = "Speech and Gesture";
                            break;
                        case 3:
                            modality.text = "Speech and Gesture";
                            break;
                        case 4:
                            modality.text = "Speech and Gesture";
                            break;
                        case 5:
                            modality.text = "Speech and Gesture";
                            break;
                        case 6:
                            modality.text = "Speech and Gesture";
                            break;
                        case 7:
                            modality.text = "Speech and Gesture";
                            break;
                        case 8:
                            modality.text = "Speech and Gesture";
                            break;
                        case 9:
                            modality.text = "Speech and Gesture";
                            break;
                        case 10:
                            modality.text = "Speech and Gesture";
                            break;
                        case 11:
                            modality.text = "Speech and Gesture";
                            break;
                        case 12:
                            modality.text = "Speech and Gesture";
                            break;
                        case 13:
                            modality.text = "Speech and Gesture";
                            break;
                        case 14:
                            modality.text = "Speech and Gesture";
                            break;
                        case 15:
                            modality.text = "Speech and Gesture";
                            break;
                        case 16:
                            modality.text = "Speech and Gesture";
                            break;
                        case 17:
                            modality.text = "Speech and Gesture";
                            break;
                        case 18:
                            modality.text = "Speech and Gesture";
                            break;
                        case 19:
                            modality.text = "Speech and Gesture";
                            break;
                        case 20:
                            modality.text = "Speech and Gesture";
                            break;
                        case 21:
                            modality.text = "Speech and Gesture";
                            break;
                        case 22:
                            modality.text = "Speech and Gesture";
                            break;
                        

                    }
                    break;
                case 3:
                    switch (OrderOfReferent_G[Initialization.i])
                    {
                        case 1:
                            modality.text = "Gesture Only";
                            break;
                        case 2:
                            modality.text = "Gesture Only";
                            break;
                        case 3:
                            modality.text = "Gesture Only";
                            break;
                        case 4:
                            modality.text = "Gesture Only";
                            break;
                        case 5:
                            modality.text = "Gesture Only";
                            break;
                        case 6:
                            modality.text = "Gesture Only";
                            break;
                        case 7:
                            modality.text = "Gesture Only";
                            break;
                        case 8:
                            modality.text = "Gesture Only";
                            break;
                        case 9:
                            modality.text = "Gesture Only";
                            break;
                        case 10:
                            modality.text = "Gesture Only";
                            break;
                        case 11:
                            modality.text = "Gesture Only";
                            break;
                        case 12:
                            modality.text = "Gesture Only";
                            break;
                        case 13:
                            modality.text = "Gesture Only";
                            break;
                        case 14:
                            modality.text = "Gesture Only";
                            break;
                        case 15:
                            modality.text = "Gesture Only";
                            break;
                        case 16:
                            modality.text = "Gesture Only";
                            break;
                        case 17:
                            modality.text = "Gesture Only";
                            break;
                        case 18:
                            modality.text = "Gesture Only";
                            break;
                        case 19:
                            modality.text = "Gesture Only";
                            break;
                        case 20:
                            modality.text = "Gesture Only";
                            break;
                        case 21:
                            modality.text = "Gesture Only";
                            break;
                        case 22:
                            modality.text = "Gesture Only";
                            break;

                    }
                    break;
            }
            
        }

        
    }
}
