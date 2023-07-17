using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class MainMode : MonoBehaviour { 

     public GameObject target;
    string btnName;

    Camera camera;
    void Start()
    {
    camera = Camera.main;

    }

    public void OnSelectObject(InputValue value)
    {
        Vector2 touchPosition = value.Get<Vector2>();
        Ray ray = camera.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            target = hit.transform.gameObject;
        }


    }
    
    public void destroyTarget()
    {
        Destroy(target);
        InteractionController.EnableMode("Main");
    }

    void OnEnable()
    {
        UIController.ShowUI("Main");
    }
}
