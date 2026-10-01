using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
// 1 unit of distance is 50 million km
public class gravity : MonoBehaviour
{
    private List<gravity> otherObject;
    [SerializeField] private double mass;
    private Vector2 finalvector;
    private Vector2 currentvector;
    // Start is called before the first frame update
    void Start()
    {
        otherObject = new List<gravity>();
        otherObject.AddRange
        (
            FindObjectsByType<gravity>(FindObjectsSortMode.None)
        );
        currentvector = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentvector += (Vector2)transform.position;
        transform.position = Vector2.MoveTowards(transform.position, finalvector, Time.deltaTime); 
    }
    private void Grav(Vector2 direction)
    {
        foreach (var obj in otherObject)
        {
            
            Vector2 currentposition = transform.position;
            Vector2 otherTransform = obj.transform.position;
            double distance = Vector2.Distance(currentposition, otherTransform);
            double force = (6.6743f * math.exp(0.00000000001)) * ((mass * obj.mass) / distance);
            Vector2 addVector = new Vector2(otherTransform.x - currentposition.x, otherTransform.y - currentposition.y);
            addVector.Normalize();
            addVector *= (float)force;
            finalvector += addVector;
        }
    }
    
}
