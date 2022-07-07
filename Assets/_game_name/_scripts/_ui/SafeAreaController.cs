using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaController : MonoBehaviour
{

    public _SafeAreaSide m_sides;

    void Start()
    {
        var rectTransform = GetComponent<RectTransform>();

        var safeArea = Screen.safeArea;
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;


        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        switch (m_sides)
        {
            case _SafeAreaSide.m_top:
                rectTransform.anchorMax = anchorMax;
                break;
            case _SafeAreaSide.m_bottom:
                rectTransform.anchorMin = anchorMin;
                break;
            case _SafeAreaSide.m_both:
                rectTransform.anchorMin = anchorMin;
                rectTransform.anchorMax = anchorMax;
                break;
        }


    }
}
[System.Serializable]
public enum _SafeAreaSide
{
    m_top,
    m_bottom,
    m_both
}




