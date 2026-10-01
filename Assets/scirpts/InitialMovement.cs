using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InitialMovement : MonoBehaviour
{
#if UNITY_EDITOR //shoutout monoscript!!
    public MonoScript[] targetScripts;
#endif
    private MonoBehaviour[] scripts;
    [SerializeField] private List<string> targetTypeName;
    private List<MonoBehaviour> disabledScripts;
    private void OnValidate()
    {
        if (targetTypeName == null)
        {
            Debug.Log("ts probably gotta recompile. if it happens during runtime, you should uhhhh... be scared or smth");
        }
        targetTypeName = new List<string>();
#if UNITY_EDITOR
        foreach (var script in targetScripts)
        {
            targetTypeName.Add(script.GetClass()?.AssemblyQualifiedName);
        }
#endif
    }
    // Start is called before the first frame update
    void Start()
    {
        disabledScripts = new List<MonoBehaviour>();
        scripts = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        foreach (string currentType in targetTypeName)
        {
            System.Type type = System.Type.GetType(currentType);
            foreach (var script in scripts)
            {
                if (type.IsInstanceOfType(script))
                {
                    script.enabled = false;
                    disabledScripts.Add(script);
                }
            }
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
