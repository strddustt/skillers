using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RenderLine : MonoBehaviour
{
    private LineRenderer line;
    public Vector3 supportVector;
    public Vector3 directionVector;
    private Vector3 a;
    private Vector3 b;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponentInChildren<LineRenderer>();
        a = transform.position;
        b = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        line.startColor = Color.black;
        line.endColor = Color.black;
        line.SetPosition(0, a);
        line.SetPosition(1, b);
    }
    public void SetAB(Vector3 pointA, Vector3 pointB)
    {
        a = pointA;
        b = pointB;
        directionVector = b - a;
    }


}
