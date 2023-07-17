using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using DG.Tweening;

[System.Serializable]
public class UIPanelDictionary : SerializableDictionaryBase<string, CanvasGroup> { }

public class UIController : Singleton<UIController>
{
    [SerializeField] UIPanelDictionary uiPanels;
    CanvasGroup currentPanel;
    // Start is called before the first frame update
    string btnName;
    void Start()
    {

    }

    override protected void Awake()
    {
        base.Awake();
        ResetAllUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hits;
            if (Physics.Raycast(ray, out Hits))
            {
                btnName = Hits.transform.tag;
                switch (btnName)
                {
                    case "DresserShopButton":
                        Application.OpenURL("https://sydneyar.myshopify.com/products/dresser");
                        break;
                    case "ChairShopButton":
                        Application.OpenURL("https://sydneyar.myshopify.com/products/stone-chair");
                        break;
                    case "VaseShopButton":
                        Application.OpenURL("https://sydneyar.myshopify.com/products/vase");
                        break;
                    case "RoundTableShtopButton":
                        Application.OpenURL("https://sydneyar.myshopify.com/products/round-wooden-table");
                        break;
                    case "VanityShopButton":
                        Application.OpenURL("https://sydneyar.myshopify.com/products/vanity");
                        break;
                    case "ChesterfieldShopButton":
                        Application.OpenURL("https://sydneyar.myshopify.com/products/chesterfield-couch");
                        break;
                    case "PictureFrameShopButton":
                        Application.OpenURL("https://sydneyar.myshopify.com/products/picture-frame");
                        break;
                    case "ShelfShopButton":
                        Application.OpenURL("https://www.ikea.com/ca/en/p/kallax-shelf-unit-white-stained-oak-effect-00324518/#content");
                        break;
                    case "SideTableShopButton":
                        Application.OpenURL("https://www.ikea.com/ca/en/p/kallax-shelf-unit-white-stained-oak-effect-00324518/#content");
                        break;
                    case "BranchShopButton":
                        Application.OpenURL("https://www.amazon.ca/FeiLix-Artificial-Branches-Decorative-Decorations/dp/B08G1RGVR9/ref=asc_df_B08G1RGVR9/?tag=googleshopc0c-20&linkCode=df0&hvadid=492375563181&hvpos=&hvnetw=g&hvrand=14359119988785286678&hvpone=&hvptwo=&hvqmt=&hvdev=c&hvdvcmdl=&hvlocint=&hvlocphy=9000834&hvtargid=pla-951402972629&psc=1");
                        break;
                    case "TallVaseShopButton":
                        Application.OpenURL("https://www.google.com/shopping/product/1?hl=en&q=wood+vase&prds=epd:8321228543518806953,eto:8321228543518806953_0,pid:8321228543518806953&sa=X&ved=0ahUKEwir35LHv-n7AhVTF1kFHe0SBtIQ9pwGCA0");
                        break;
                    case "FatVaseShopButton":
                        Application.OpenURL("https://annieandflora.com/product/set-of-wood-vases/");
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void ResetAllUI()
    {
        foreach (CanvasGroup panel in uiPanels.Values)
        {
            panel.gameObject.SetActive(false);
        }
    }

    public static void ShowUI(string name)
    {
        Instance?._ShowUI(name);
    }

    void _ShowUI(string name)
    {
        CanvasGroup panel;
        if (uiPanels.TryGetValue(name, out panel))
        {
            ChangeUI(uiPanels[name]);
        }
        else
        {
            Debug.LogError("Undefined ui panel " + name);

        }
    }

    void ChangeUI(CanvasGroup panel)
    {
        if (panel == currentPanel)
            return;
        if (currentPanel)
            FadeOut(currentPanel);
            //currentPanel.gameObject.SetActive(false);
        currentPanel = panel;
        if (panel)
            FadeIn(panel);
            //panel.gameObject.SetActive(true);
    }

    void FadeIn(CanvasGroup panel)
    {
        panel.gameObject.SetActive(true);
        panel.DOFade(1f, 0.5f);
    }

    void FadeOut(CanvasGroup panel)
    {
        panel.DOFade(0f, 0.5f).OnComplete(() => panel.gameObject.SetActive(false));
    }
}
