using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class DetectColourOnScreen : MonoBehaviour
{
    [SerializeField] ARSessionOrigin sessionOrigin;
    ARPlaneManager planeManager;
    ARPointCloudManager pointCloudManager;

    [SerializeField] private Camera cam;
    [SerializeField] private GameObject avgColourPreview;
    [SerializeField] private GameObject avgColourReference;
    [SerializeField] private int colourDetectionsPerSecond = 1;
    [SerializeField] private int totalDetectionsForAverage = 10;

    [SerializeField] private GameObject homeButton;

    private Image avgColour;
    private Colours refColours;

    private Color colour;

    private int i = 0; //fixed update tracker
    private int n = 0; //number of colour grabs

    private int getColourInterval;
    private int screenWidth;
    private int screenHeight;

    //variables used during "running average"
    private float avgRed = 0;
    private float avgGreen = 0;
    private float avgBlue = 0;


    // Start is called before the first frame update
    void Start()
    {
        avgColour = avgColourPreview.GetComponent<Image>();

        if (colourDetectionsPerSecond < 1) colourDetectionsPerSecond = 1;
        getColourInterval = 50 / colourDetectionsPerSecond;

        screenWidth = Screen.width;
        screenHeight = Screen.height;

        refColours = avgColourReference.GetComponent<Colours>();
    }

    //Awake called when script is loaded
    private void Awake()
    {
        planeManager = sessionOrigin.GetComponent<ARPlaneManager>();
        pointCloudManager = sessionOrigin.GetComponent<ARPointCloudManager>();
    }

    //Enable/disable plane detection
    void ShowTrackables(bool show)
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

    //When script is enabled from the UIController (in the UI Canvas object)
    void OnEnable()
    {
        UIController.ShowUI("GetAverageColour");

        homeButton.SetActive(false);

        ShowTrackables(false);

        //Reset counters
        i = 0;
        n = 0;
    }

    //When script is disabled (cancel button)
    private void OnDisable()
    {
        homeButton.SetActive(true);
        ShowTrackables(true);
    }

    // FixedUpdate is called 50x per second
    void FixedUpdate()
    {
        i++;

        if (i % getColourInterval == 0)
        {
            var screenCenterTexture = new Texture2D(screenWidth, screenHeight);
            screenCenterTexture.ReadPixels(cam.pixelRect, 0, 0, false);
            screenCenterTexture.Apply();

            colour = screenCenterTexture.GetPixel(screenWidth / 2, screenHeight / 2);

            UpdateAvgColor(colour);

            Destroy(screenCenterTexture);
        }
    }

    //Get the running average Color
    void UpdateAvgColor(Color c)
    {
        n++;

        if (n <= totalDetectionsForAverage)
        {
            if (n == 1)
            {
                avgRed = c.r;
                avgGreen = c.g;
                avgBlue = c.b;
            }
            else
            {
                avgRed = avgRed + ((c.r - avgRed) / n);
                avgGreen = avgGreen + ((c.g - avgGreen) / n);
                avgBlue = avgBlue + ((c.b - avgBlue) / n);
            }
            avgColour.color = new Color(avgRed, avgGreen, avgBlue);
        }
        else
        {
            //Assign average colour to reference
            refColours.SetColour(avgColour.color);

            //End colour average session
            InteractionController.EnableMode("ColourRecommendation");
        }
    }
}