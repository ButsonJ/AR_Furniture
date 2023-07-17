using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChairFilter : MonoBehaviour
{
    private GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.gameObject.SetActive(false);
        //CanvasObject.gameObject.SetActive(false);


    }

    public void ToggleCanvas()
    {
        gameObject.transform.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
