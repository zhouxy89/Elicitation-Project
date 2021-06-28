using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.Serialization;
using UnityEditor;
using System.IO;

public class gazeTracking : MonoBehaviour
{
    
    Vector3 gazeVector = EyeTrackingTarget.gazeVector;
    

    private Vector3 _counter;
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
        Counter = new Vector3(0.0f, 1.0f, 0.0f); ;
    }

    // Update is called once per frame
    void Update()
    {
        //SaveToFile();
        
    }

    [SerializeField]
    public class KeyFrame
    {
        public Vector3 Value;

        public float Time;

        public KeyFrame() { }

        public KeyFrame(Vector3 gazeVector, float time)
        {
            Value = gazeVector;
            Time = time;
        }
    }
    private List<KeyFrame> keyFrames = new List<KeyFrame>(10000);


    public string ToCSV()
    {
        var sb = new System.Text.StringBuilder("Time,gaze_X,gaze_Y,gaze_Z");
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
    }


    public void SaveToFile()
    {
        print("gaze:" + gazeVector);
        // Use the CSV generation from before
        var content = ToCSV();

        // The target file path e.g.

        var folder = Application.streamingAssetsPath;

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        var filePath = Path.Combine(folder, "export_gaze.csv");

        using (var writer = new StreamWriter(filePath, false))
        {
            writer.Write(content);
        }


        //Debug.Log($"CSV file written to /"{filePath}/"");

        //AssetDatabase.Refresh();
    }
}