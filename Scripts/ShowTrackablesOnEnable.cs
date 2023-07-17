using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ShowTrackablesOnEnable : MonoBehaviour
{
    [SerializeField] ARSessionOrigin sessionOrigin;
    ARPlaneManager planeManager;
    ARPointCloudManager pointCloudManager;
    bool isStarted;

    private void Awake()
    {
        planeManager = sessionOrigin.GetComponent<ARPlaneManager>();
        pointCloudManager = sessionOrigin.GetComponent<ARPointCloudManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        ShowTrackables(true);
    }

    void OnDisable()
    {
        if (isStarted)
        {
            ShowTrackables(false);
        }
    }

    void ShowTrackables (bool show)
    {
        if (pointCloudManager)
        {
            pointCloudManager.SetTrackablesActive(show);
            pointCloudManager.enabled = show;
        }
        if (planeManager)
        {
            planeManager.SetTrackablesActive(show);
            planeManager.enabled = show;
        }
    }
}
