using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawTriangle : MonoBehaviour
{
    public static Transform[] children { get; private set; }
    private Vector3[] childpos;
    private LineRenderer line;
    private static void Init()
    {
        children = null;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (mode == LoadSceneMode.Single) children = null;
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        children = GetComponentsInChildren<Transform>()
            .Where(t => t != transform)
            .ToArray();

        line = GetComponent<LineRenderer>();
        line.positionCount = children.Length;
        childpos = new Vector3[children.Length];

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < children.Length; i++)
        {
            childpos[i] = children[i].position;
            Debug.Log($"DrawTriangle.children[{i}] = {children[i].name} at {children[i].position}");
        }
        line.SetPositions(childpos);
    }
}
