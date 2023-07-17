using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class RecommendAsset : MonoBehaviour
{
    [SerializeField] private ARSessionOrigin sessionOrigin;
    private ARPlaneManager planeManager;
    private ARPointCloudManager pointCloudManager;

    [SerializeField] private GameObject refColourObject;
    [SerializeField] private GameObject furnitureList;
    [SerializeField] private GameObject placeObjectMode;

    [SerializeField] private GameObject fullButtonList;

    private Color refAverageColour;
    private Color assetColour;
    private float deltaRed;
    private float deltaGreen;
    private float deltaBlue;
    //private float bestDelta;

    [SerializeField] private List<GameObject> assetsList;
    private List<MatchingObject> matchingAssetsList = new List<MatchingObject>();
    //private GameObject currentBestFit = null;

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
        if (assetsList != null && assetsList.Count > 0)
        {
            UIController.ShowUI("ColourRecommendation");

            //Empty previous matching assets
            matchingAssetsList.Clear();
            matchingAssetsList.TrimExcess();

            //bestDelta = 999; //reset delta
            refAverageColour = refColourObject.GetComponent<Colours>().GetColor();

            ShowTrackables(false);
            FindBestMatch();
        }
    }

    //When script is disabled (cancel button)
    private void OnDisable()
    {
        ShowTrackables(true);
    }

    //Iterate through resources folder for best matching asset
    void FindBestMatch()
    {
        foreach (GameObject asset in assetsList)
        {
            try
            {
                assetColour = asset.GetComponent<Colours>().GetColor();
                if (assetColour != null)
                {
                    //compare colours
                    deltaRed = Math.Abs(refAverageColour.r - assetColour.r);
                    deltaGreen = Math.Abs(refAverageColour.g - assetColour.g);
                    deltaBlue = Math.Abs(refAverageColour.b - assetColour.b);

                    float matchNum = Math.Abs(deltaRed + deltaGreen + deltaBlue);

                    CompareListItems(matchNum, asset);

                    /*
                    if (currentBestFit == null)
                    {
                        bestDelta = Math.Abs(deltaRed + deltaGreen + deltaBlue);
                        currentBestFit = asset;
                    }
                    else if (bestDelta > Math.Abs(deltaRed + deltaGreen + deltaBlue))
                    { //if the current asset is a closer match than the current bestFit
                        bestDelta = Math.Abs(deltaRed + deltaGreen + deltaBlue);
                        currentBestFit = asset;
                    }
                    */
                }
            }
            catch
            {
                //do nothing
            }
        }

        CleanAssetButtonsList();

        if (matchingAssetsList.Count > 0)
        {
            AddAssetsToList();
        }

        /*
        if (currentBestFit != null)
        {
            AddAssetsToList();
        }
        */

    }

    //Compare the current target to each item in the list
    void CompareListItems(float f, GameObject o)
    {
        int listLength = matchingAssetsList.Count;

        //if list is empty, add first item
        if (listLength < 1)
        {
            matchingAssetsList.Add(new MatchingObject(f, o));
        }
        else
        {
            for (int i = 0; i < listLength; i++)
            {
                //if new item more "matchy" than item[i], take its place and bump it down.
                if (matchingAssetsList[i].matchNumber > f)
                {
                    matchingAssetsList.Insert(i, new MatchingObject(f, o));
                    break;
                }
                else if (i == listLength - 1)
                {
                    matchingAssetsList.Insert(i + 1, new MatchingObject(f, o));
                    break;
                }

                //break after end of list or top 3
                if (i >= 2) break;
            }
        }
    }

    //Clear list of items from pervious search
    void CleanAssetButtonsList()
    {
        for (int i = 0; i < furnitureList.transform.childCount; i++)
        {
            Destroy(furnitureList.transform.GetChild(i).gameObject);
        }

        /*
        int c = furnitureList.transform.childCount;

        if (c > 0)
        {
            for (int i = 0; i < c; i++)
            {
                Destroy(furnitureList.transform.GetChild(i).gameObject);
            }
        }
        */
    }

    //Add asset to list of matches
    void AddAssetsToList()
    {
        //Add asset button to list ui
        for (int i = 0; i < matchingAssetsList.Count; i++)
        {
            GameObject obj = Instantiate(matchingAssetsList[i].asset, furnitureList.transform);

            string matchPercent = ((1 - (matchingAssetsList[i].matchNumber / 3)) * 100).ToString("n2");

            obj.transform.Find("Text (TMP) (1)").GetComponent<TextMeshProUGUI>().text = "%" + matchPercent;

            if (i >= 2) break; //stop at 3 
        }

        //Instantiate(currentBestFit, furnitureList.transform);
    }
}

//Object representation of Key : Value for best fit
public class MatchingObject
{
    public float matchNumber;
    public GameObject asset;

    public MatchingObject(float f, GameObject g)
    {
        matchNumber = f;
        asset = g;
    }
}