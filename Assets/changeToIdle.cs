using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class changeToIdle : MonoBehaviour
{
    // Start is called before the first frame update
    Animator m_Animator;
    MeshRenderer cubeRenderer;
    int[] OrderOfReferent_P = Initialization.values_P;
    int[] OrderOfReferent_S = Initialization.values_S;
    int[] OrderOfReferent_GS = Initialization.values_GS;
    int[] OrderOfReferent_G = Initialization.values_G;
    //public Material newMaterials;
    //int[] OrderOfReferent = choseModalityOrder.experiementOrder;
    //bool noCube = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        cubeRenderer = gameObject.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

      
            if (Input.GetKey(KeyCode.DownArrow)&& Initialization.i < OrderOfReferent_S.Length+1)
            {
            //print("Initialization.i" + Initialization.i);
            //if (refOrder[Initialization.i] == 15)
            //{
            //if (noCube)
            //{
            //noCube = false;
            //m_Animator.SetTrigger("BackToIdle");
            //}

            //m_Animator.SetTrigger("NoCubeShow");
            //m_Animator.SetActive(false);
            //}
            //else
            //{
                if (choseModalityOrder.experiementOrder[Initialization.order] == 0)
                {
                    //print("Initialization.j_idle" + Initialization.j);
                    if (Initialization.j == 6)
                    {
                        m_Animator.SetTrigger("BackToIdle");
                    }
                    if (OrderOfReferent_P[Initialization.j] == 2 || OrderOfReferent_P[Initialization.j] == 4 || OrderOfReferent_P[Initialization.j] == 6)
                    {
                        //m_Animator.SetTrigger("BackToIdle");
                        //cubeRenderer.material = newMaterials;
                    }
                    else
                    {
                        m_Animator.SetTrigger("BackToIdle");
                    }
                }
                else
                {
                    m_Animator.SetTrigger("BackToIdle");
                }
                    

            //}
                switch (choseModalityOrder.experiementOrder[Initialization.order])
                {
                    
                    case 1:
                            if (OrderOfReferent_S[Initialization.i] == 15 || OrderOfReferent_S[Initialization.i] == 20)
                            {
                                gameObject.GetComponent<Renderer>().enabled = false;
                            }
                        break;
                    case 2:
                            if (OrderOfReferent_GS[Initialization.i] == 15 || OrderOfReferent_GS[Initialization.i] == 20)
                            {
                                gameObject.GetComponent<Renderer>().enabled = false;
                            }
                        break;
                    case 3:
                            if (OrderOfReferent_G[Initialization.i] == 15 || OrderOfReferent_G[Initialization.i] == 20)
                            {
                                gameObject.GetComponent<Renderer>().enabled = false;
                            }
                        break;
                }
            
            

            }
            
        //if (Input.GetKey(KeyCode.DownArrow))
        //{

        //m_Animator.ResetTrigger("BackToIdle");

        //}
    }
}
