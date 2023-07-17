using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ScanMode : MonoBehaviour
{

    [SerializeField] ARPlaneManager planeManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (planeManager.trackables.count > 0)
        {
            InteractionController.EnableMode("Main");
        }
    }

    void OnEnable()
    {
        UIController.ShowUI("Scan");
    }
}
