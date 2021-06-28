using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class setupOrders : MonoBehaviour
{
    static public int order = 0;
    InputField txt_Input;
    // Start is called before the first frame update
    void Start()
    {
         txt_Input = GameObject.Find("Orders").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        order = Int32.Parse(txt_Input.text);
    }
}
