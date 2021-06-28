using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeReferentsSphere : MonoBehaviour
{
    Animator m_Animator;
    int[] OrderOfReferent_S = Initialization.values_S;
    int[] OrderOfReferent_GS = Initialization.values_GS;
    int[] OrderOfReferent_G = Initialization.values_G;
    //int[] OrderOfReferent = choseModalityOrder.experiementOrder;
    // Start is called before the first frame update
    static public bool c1_SphereSelect = false;
    static public bool c1_SphereDestory = false;
    static public bool c1_SphereCreate = false;
    static public bool c1_SphereEnlarge = false;
    static public bool c1_SphereShrink = false;
    static public bool c2_SphereSelect = false;
    static public bool c2_SphereDestory = false;
    static public bool c2_SphereCreate = false;
    static public bool c2_SphereEnlarge = false;
    static public bool c2_SphereShrink = false;
    static public bool c3_SphereSelect = false;
    static public bool c3_SphereDestory = false;
    static public bool c3_SphereCreate = false;
    static public bool c3_SphereEnlarge = false;
    static public bool c3_SphereShrink = false;


    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) && 0 < Initialization.i && Initialization.i < OrderOfReferent_S.Length + 1)
        {
            //print("get in update");
            //print("referentOrder[Initialization.i]:" + referentOrder[Initialization.i]);

            switch (choseModalityOrder.experiementOrder[Initialization.order])
            {
                case 1:
                    if (c1_SphereSelect == false || c1_SphereDestory == false || c1_SphereCreate == false || c1_SphereEnlarge == false || c1_SphereShrink == false)
                    {
                        switch (OrderOfReferent_S[Initialization.i - 1])
                        {
                            case 18:
                                m_Animator.SetTrigger("SphereSelect");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c1_SphereSelect = true;
                                break;
                            case 19:
                                m_Animator.SetTrigger("SphereDestory");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c1_SphereDestory = true;
                                break;
                            case 20:
                                m_Animator.SetTrigger("SphereCreate");
                                gameObject.GetComponent<Renderer>().enabled = true;
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c1_SphereCreate = true;
                                break;
                            case 21:
                                m_Animator.SetTrigger("SphereEnlarge");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c1_SphereEnlarge = true;
                                break;
                            case 22:
                                m_Animator.SetTrigger("SphereShrink");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c1_SphereShrink = true;
                                break;

                        }

                    }
                    break;
                case 2:
                    if (c2_SphereSelect == false || c2_SphereDestory == false || c2_SphereCreate == false || c2_SphereEnlarge == false || c2_SphereShrink == false)
                    {
                        switch (OrderOfReferent_GS[Initialization.i - 1])
                        {
                            case 18:
                                m_Animator.SetTrigger("SphereSelect");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c2_SphereSelect = true;
                                break;
                            case 19:
                                m_Animator.SetTrigger("SphereDestory");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c2_SphereDestory = true;
                                break;
                            case 20:
                                m_Animator.SetTrigger("SphereCreate");
                                gameObject.GetComponent<Renderer>().enabled = true;
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c2_SphereCreate = true;
                                break;
                            case 21:
                                m_Animator.SetTrigger("SphereEnlarge");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c2_SphereEnlarge = true;
                                break;
                            case 22:
                                m_Animator.SetTrigger("SphereShrink");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c2_SphereShrink = true;
                                break;

                        }
                    }
                    break;
                case 3:
                    if (c3_SphereSelect == false || c3_SphereDestory == false || c3_SphereCreate == false || c3_SphereEnlarge == false || c3_SphereShrink == false)
                    {
                        switch (OrderOfReferent_G[Initialization.i - 1])
                        {
                            case 18:
                                m_Animator.SetTrigger("SphereSelect");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c3_SphereSelect = true;
                                break;
                            case 19:
                                m_Animator.SetTrigger("SphereDestory");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c3_SphereDestory = true;
                                break;
                            case 20:
                                m_Animator.SetTrigger("SphereCreate");
                                gameObject.GetComponent<Renderer>().enabled = true;
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c3_SphereCreate = true;
                                break;
                            case 21:
                                m_Animator.SetTrigger("SphereEnlarge");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c3_SphereEnlarge = true;
                                break;
                            case 22:
                                m_Animator.SetTrigger("SphereShrink");
                                m_Animator.ResetTrigger("BackSphereIdle");
                                //Initialization.i++;
                                c3_SphereShrink = true;
                                break;

                        }
                    }
                     break;

            }
            
        }
    }
}
