using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShit : MonoBehaviour
{
    public Material m_UiColor;


    public void ChangeUIColor()
    {
#if UNITY_ANDROID 
        Debug.Log("Button clicked on Android !");
#endif
#if UNITY_IOS
        Debug.Log("Button clicked on IOS !");
#endif
#if UNITY_EDITOR
        Debug.Log("Button clicked on Editor !");
#endif
        if (m_UiColor != null)
        {
            if (m_UiColor.color == Color.red)
            {
                m_UiColor.color = Color.blue;
            }
            else
            {
                m_UiColor.color = Color.red;
            }
        }
        
    }
}
