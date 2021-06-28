using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backToIdleSphere : MonoBehaviour
{
    Animator m_Animator;
    int[] OrderOfReferent_S = Initialization.values_S;
    int[] OrderOfReferent_GS = Initialization.values_GS;
    int[] OrderOfReferent_G = Initialization.values_G;
    //int[] OrderOfReferent = choseModalityOrder.experiementOrder;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Initialization.i < OrderOfReferent_S.Length+1)
        {
            m_Animator.SetTrigger("BackSphereIdle");

            switch (choseModalityOrder.experiementOrder[Initialization.order])
            {
                case 1:
                        if (OrderOfReferent_S[Initialization.i] == 20)
                        {
                            gameObject.GetComponent<Renderer>().enabled = false;
                        }
                    break;
                case 2:
                        if (OrderOfReferent_GS[Initialization.i] == 20)
                        {
                            gameObject.GetComponent<Renderer>().enabled = false;
                        }
                    break;
                case 3:
                        if (OrderOfReferent_G[Initialization.i] == 20)
                        {
                            gameObject.GetComponent<Renderer>().enabled = false;
                        }
                    break;
            }


            

            


        }
    }
}
