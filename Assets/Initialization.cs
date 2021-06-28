using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
	static public int[] values_P = { 1, 2, 3, 4, 5, 6 };
	static public int[] values_S = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
	static public int i = 0;
	static public int[] values_GS = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
	
	static public int[] values_G = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
	
	static public int order = 0;
	static public int j = 0;

	// Start is called before the first frame update
	void Start()
    {
        Shuffle(values_S);
		Shuffle(values_GS);
		Shuffle(values_G);
		foreach (int value_S in values_S)
		{
			print("value_S:" + value_S);
		}
		foreach (int value_GS in values_GS)
		{
			print("value_GS:" + value_GS);
		}
		foreach (int value_G in values_G)
		{
			print("value_G:" + value_G);
		}

		
	}

    // Update is called once per frame
    void Update()
    {
        
	}

	void Shuffle(int[] a)
	{
		// Loops through array
		for (int i = a.Length - 1; i > 0; i--)
		{
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = Random.Range(0, i);

			// Save the value of the current i, otherwise it'll overright when we swap the values
			int temp = a[i];

			// Swap the new and old values
			a[i] = a[rnd];
			a[rnd] = temp;
		}

		// Print
		//for (int i = 0; i < a.Length; i++)
		//{
			//Debug.Log(a[i]);
		//}
	}
}
