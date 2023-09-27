using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slider : MonoBehaviour
{
    private RectTransform rectTransform;
    [Header("Slider")]
    [SerializeField] Vector2 slideLimits = new Vector2(0,3240);
    [SerializeField] ScrollRect scrollRect;
    [Space]
    [Header("Switch Car")]
    [SerializeField] Vector2 yCoordinatsOfSwithCars = new Vector2(300, 700);

    [SerializeField] Image car0;
    [SerializeField] Image car1;
    [SerializeField] Image car2;
    [Space]
    [Header("Hood Cover")]

    [SerializeField] Vector2 yCoordinatsOfOpenHood = new Vector2(740, 1200);
    [SerializeField] RectTransform hoodCover;
    private Vector2 angleOfOpen = new Vector2(42.2f, 0);
    [Space]
    [Header("Magnifying Glass")]
    [SerializeField] Vector2 yCoordinatsOfOpenMagnifyingGlass = new Vector2(740, 1200);
    [SerializeField] RectTransform magnifyingGlass;
    private Vector2 scaleOfOpenMagnifyingGlass = new Vector2(0,30f);
    [Space]
    [Header("Buttons")]
    [SerializeField] Button upBotton;
    [SerializeField] Button downButton;
    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        ChangeCarState(true, false, false);

        hoodCover.transform.eulerAngles = new Vector3(0, 0, angleOfOpen.x);
        magnifyingGlass.localScale = Vector2.zero;


        upBotton.onClick.AddListener(GoToSideOfPage);
    }

    // Update is called once per frame
    void Update()
    {
        //controll of top and botton slide
        if (rectTransform.localPosition.y < slideLimits.x) 
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x,slideLimits.x);
        if (rectTransform.localPosition.y > slideLimits.y) 
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x,slideLimits.y);

        //car switcher
        if (rectTransform.localPosition.y < yCoordinatsOfSwithCars.x
            && car0.gameObject.activeSelf == false) {
            ChangeCarState(true, false, false);

        }
        else if (rectTransform.localPosition.y > yCoordinatsOfSwithCars.x 
            && rectTransform.localPosition.y < yCoordinatsOfSwithCars.y 
            && car1.gameObject.activeSelf == false)
        {
            ChangeCarState(false, true, false);
        }
        else if(rectTransform.localPosition.y > yCoordinatsOfSwithCars.y
            && car2.gameObject.activeSelf == false) {
            ChangeCarState(false, false, true);
        }
        
        //hood cover
        if(rectTransform.localPosition.y > yCoordinatsOfOpenHood.x &&
            rectTransform.localPosition.y < yCoordinatsOfOpenHood.y) {
            float hight = rectTransform.localPosition.y - yCoordinatsOfOpenHood.x;
            float currAngle = -(angleOfOpen.x - angleOfOpen.y)*hight/(yCoordinatsOfOpenHood.y- yCoordinatsOfOpenHood.x)+angleOfOpen.x;
            hoodCover.transform.eulerAngles = new Vector3(0, 0, currAngle);
        }

        //magnifying glass

        if (rectTransform.localPosition.y > yCoordinatsOfOpenMagnifyingGlass.x &&
             rectTransform.localPosition.y < yCoordinatsOfOpenMagnifyingGlass.y) {
            float hight = rectTransform.localPosition.y - yCoordinatsOfOpenMagnifyingGlass.x;
            float currScale = (scaleOfOpenMagnifyingGlass.y - scaleOfOpenMagnifyingGlass.x) * hight 
                / (yCoordinatsOfOpenMagnifyingGlass.y - yCoordinatsOfOpenMagnifyingGlass.x);
            magnifyingGlass.localScale = new Vector2(currScale, currScale);
        }

    }

    private void ChangeCarState(bool car0Value, bool car1Value,  bool car2Value) {
        car0.gameObject.SetActive(car0Value);
        car1.gameObject.SetActive(car1Value);
        car2.gameObject.SetActive(car2Value);
    }

    private void GoToSideOfPage() {
        /*
        float wereAreWeGo;
        if (rectTransform.localPosition.y > 500) wereAreWeGo = 0;
        else wereAreWeGo = 3240;
        int sign;
        if (wereAreWeGo > rectTransform.localPosition.y) sign = -1;
        else sign = 1;

        while(rectTransform.localPosition.y <= wereAreWeGo) {
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x,
                rectTransform.localPosition.y + 0.1f * sign); 
        }
        */
        Debug.Log("rectTransform.localPosition.y == " + rectTransform.localPosition.y);
        
        /*
        while (rectTransform.localPosition.y >= 0) {
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x,
                rectTransform.localPosition.y);
        }
        */
    }
}
