using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectMode : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycaster;
    GameObject placedPrefab;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        UIController.ShowUI("PlaceObject");
    }

    public void SetPlacedPrefab (GameObject prefab)
    {
        placedPrefab = prefab;
    }

    public void OnPlaceObject (InputValue value)
    {
        Vector2 touchPostion = value.Get<Vector2>();
        PlaceObject(touchPostion);
    }

    void PlaceObject(Vector2 touchPostion)
    {
        if(raycaster.Raycast(touchPostion, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            InteractionController.EnableMode("Main");
        }
    }
}
