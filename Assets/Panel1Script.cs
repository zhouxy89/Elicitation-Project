using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel1Script : MonoBehaviour
{
    public GameObject popupPanel;
    public Text reminder;
    static public bool next = false;
    // Start is called before the first frame update
    void Start()
    {
        popupPanel.GetComponent<Text>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)){

            //print("Initialization.j_panel" + Initialization.j);
            //print("Initialization.order_outside" + Initialization.order);
            if (Initialization.j == 6)
            {
                if (Initialization.order == 0)
                {
                    reminder.text = "The practice part of experiement is finished.";
                }
                popupPanel.GetComponent<Text>().enabled = true;
            }

            if (Initialization.i == 22)
            {
                //print("at 22");
                //print("Initialization.order" + Initialization.order);
                if (Initialization.order == 1)
                {
                    reminder.text = "The first part of experiement is finished.";
                }
                else if (Initialization.order == 2)
                {
                    reminder.text = "The second part of experiement is finished.";
                }
                else if (Initialization.order == 3)
                {
                    reminder.text = "The experiement is finished. Thank you for your participation!";
                }


                popupPanel.GetComponent<Text>().enabled = true;
            }

            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {


            if (Initialization.i == 22 || Initialization.j == 6)
            {
                popupPanel.GetComponent<Text>().enabled = false;
            }
            //print("next1:" + next);
            //print("Initialization.order1:" + Initialization.order);
            if (next == false)
            {
                if ((Initialization.i == 22 || Initialization.j == 6 )&& Initialization.order < 4)
                {
                    next = true;
                    //print("next2:" + next);
                    Initialization.i = 0;
                    Initialization.j = 0;
                    Initialization.order++;
                    //print("Initialization.order2:" + Initialization.order);
                }
            }
        }

        //print("i:" + Initialization.i);
        //print("order:" + Initialization.order);
    }
}
