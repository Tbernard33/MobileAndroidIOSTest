using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShit : MonoBehaviour
{
    public Material m_UiColor;


    public void ChangeUIColor()
    {
        Debug.Log("Button clicked !");
        if(m_UiColor != null)
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
