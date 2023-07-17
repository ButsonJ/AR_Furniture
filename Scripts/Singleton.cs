using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton behaviour class, used for components that should only have one instance
/// </summary>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    public static bool isInitialized
    {
        get { return Instance != null; }
    }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"Trying to instantiate a second instance of singleton class {GetType().Name}");
        }
        else
        {
            Instance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
