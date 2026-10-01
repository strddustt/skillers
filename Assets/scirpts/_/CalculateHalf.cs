using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CalculateHalf : MonoBehaviour
{
    private Transform[] children2;
    // Start is called before the first frame update
    void Start()
    {
        children2 = GetComponentsInChildren<Transform>()
            .Where(t => t != transform)
            .ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < children2.Length; i++)
        {
            switch(i)
            {

                case (0):
                    Vector2 half1 = (DrawTriangle.children[0].position + DrawTriangle.children[1].position) / 2;
                    children2[i].position = half1;
                    break;
                case (1):
                    Vector2 half2 = (DrawTriangle.children[1].position + DrawTriangle.children[2].position) / 2;
                    children2[i].position = half2;
                    break;
                case (2):
                    Vector2 half3 = (DrawTriangle.children[2].position + DrawTriangle.children[0].position) / 2;
                    children2[i].position = half3;
                    break;
            }
        }
    }
}
