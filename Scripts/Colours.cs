using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colours : MonoBehaviour
{
    [SerializeField] private Color colour;

    // Start is called before the first frame update
    void Start()
    {
        //Simple failsafe
        if (colour == null)
        {
            colour = new Color(1, 1, 1); //white
        }
    }

    //Set colour value to new value
    public void SetColour(Color colour)
    {
        this.colour = colour;
    }

    public Color GetColor()
    {
        return colour;
    }

}
