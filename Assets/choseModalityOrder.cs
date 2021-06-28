using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class choseModalityOrder : MonoBehaviour
{
    
    static public int order = 0;
    int key;
    //int menuIndex = 0;
    //List<Dropdown.OptionData> menuOptions;


    // Start is called before the first frame update
    /*void Start()
    {
        menuIndex = dropdownMenu.GetComponent<Dropdown>().value;
        menuOptions = dropdownMenu.GetComponent<Dropdown>().options;
    }

    // Update is called once per frame
    void Update()
    {
        order = Int32.Parse(menuOptions[menuIndex].text);
        print("order:"+ order);


    }*/
    //public RectTransform dropdownMenu;
    public TextMeshProUGUI label;
    public TextMeshProUGUI itemLabel;
    static public int[] experiementOrder;
    public Renderer meshRenderer;

    void Start()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Renderer>().enabled = true;
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            key = 0;
            HandleInputData(key);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            key = 1;
            HandleInputData(key);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            key = 2;
            HandleInputData(key);
        }
    }

    public void HandleInputData(int val)
    {
        
        if (val == 0)
        {
            order = 0;
            experiementOrder = new int[] { 0, 1, 2, 3 };
            //gameObject.SetActive(false);
        }
        if (val == 1)
        {
            order = 1;
            experiementOrder = new int[] { 0, 3, 1, 2 };
            //gameObject.SetActive(false);
        }
    
        if (val == 2)
        {
            order = 2;
            experiementOrder = new int[] { 0, 2, 3, 1 };
            //gameObject.SetActive(false);
        }

        //print("order:" + order);
        foreach (int value in experiementOrder)
        {
            //print("real order:" + value);
        }
        //GameObject.Find("Dropdown").GetComponent<Dropdown>().enabled = false;
        gameObject.SetActive(false);
        gameObject.GetComponent<Renderer>().enabled = false;
        meshRenderer.enabled = false;
        label.enabled = false;
        itemLabel.enabled = false;
        //dropdownMenu.SetActive(false);
    }
}
