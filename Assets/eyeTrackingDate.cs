using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.Serialization;
using UnityEditor;
using System.IO;
using System;
using System.Globalization;

public class eyeTrackingDate : MonoBehaviour
{
    Vector3 hitVector = EyeTrackingTarget.hitVector;
    GameObject target = EyeTrackingTarget.LookedAtTarget;
    int line = 1;

    /*private Vector3 _counter;
    public Vector3 Counter
    {
        get => _counter;
        set
        {
            _counter = value;
            keyFrames.Add(new KeyFrame(value, Time.time));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Counter = new Vector3(0.0f, 1.0f, 0.0f);
    }*/

    // Update is called once per frame
    void Update()
    {
        SaveToFile();
    }

    /*[SerializeField]
    public class KeyFrame
    {
        public Vector3 Value;
        
        public float Time;

        public KeyFrame() { }

        public KeyFrame(Vector3 hitVector, float time)
        {
            Value = hitVector;
            Time = time;
        }
    }

    private List<KeyFrame> keyFrames = new List<KeyFrame>(10000);



    public string ToCSV()
    {
        var sb = new System.Text.StringBuilder("Time,hit_X,hit_Y,hit_Z");
        string v1 = "(";
        string v2 = ")";
        string final = "";
        foreach (var frame in keyFrames)
        {
            final = frame.Value.ToString().Replace(v1, "");
            final = final.Replace(v2, "");
            sb.Append("\n").Append(frame.Time.ToString()).Append(",").Append(final);
        }
        
        return sb.ToString();
    }*/


    public void SaveToFile()
    {
        // Use the CSV generation from before
        //var content = ToCSV();

        string v1 = "(";
        string v2 = ")";
        string final = "";
        var folder = Application.streamingAssetsPath;
        //var folder = Application.persistentDataPath;

        var showText = new System.Text.StringBuilder();
        final = hitVector.ToString().Replace(v1, "");
        final = final.Replace(v2, "");
        if (line == 1)
        {
            //showText = new System.Text.StringBuilder("Time,hit_X,hit_Y,hit_Z");
            showText = new System.Text.StringBuilder("Time,hit_target");
        }
        //showText.Append("\n").Append(DateTime.Now).Append(",").Append(final);
        showText.Append("\n").Append(DateTime.Now).Append(",").Append(target.ToString()); 

        if (!Directory.Exists(folder)){
            Directory.CreateDirectory(folder);
        } 

        var filePath = Path.Combine(folder, "export.csv");

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.Write(showText);
        }

        line = line + 1;


    }
}
