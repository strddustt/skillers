using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Les5 : MonoBehaviour
{
    private Transform[] points;
    [SerializeField] private RenderLine line1;
    [SerializeField] private RenderLine line2;
    [SerializeField] private GameObject interceptPoint;
    Vector2 a;
    Vector2 b;
    Vector2 c;
    Vector2 d;
    Vector2 point;

    // Start is called before the first frame update
    void Start()
    {
        points = GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();

    }

    // Update is called once per frame
    void Update()
    {
        updatePoints();
        line1.SetAB(a, b);
        line2.SetAB(c, d);

    }
    private void updatePoints()
    {
        a = points[0].position;
        b = points[1].position;
        c = points[2].position;
        d = points[3].position;
        CalculateIntercept();
    }
    private void CalculateIntercept()
    {
        if (LineIntersection(out point))
        {
            interceptPoint.SetActive(true);
            interceptPoint.transform.position = point;
        }
        else
        {
            interceptPoint.SetActive(false); 
        }

    }
    float Cross(Vector2 v, Vector2 w) => v.x * w.y - v.y * w.x;

    bool LineIntersection(out Vector2 point)
    {
        Vector2 r = b - a;
        Vector2 s = d - c;
        float denom = Cross(r, s);

        point = default;
        if (Mathf.Abs(denom) < 1e-6f) return false; // parallel or collinear

        float t = Cross(c - a, s) / denom;
        float u = Cross(c - a, r) / denom;

        if (t < 0f || t > 1f || u < 0f || u > 1f) return false; // crossing is outside a segment

        point = a + t * r;
        return true;
    }

}
