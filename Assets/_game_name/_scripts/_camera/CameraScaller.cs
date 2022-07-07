using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaller : MonoBehaviour
{
    public SpriteRenderer m_sprite;


    public Transform m_top;
    public Transform m_bottom;
  //  public Transform m_bg;

    private void OnEnable()
    {
        if (m_sprite != null)
        {
            _DoCameraSize(m_sprite);
        }

        Vector3 m_pos=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
       // Debug.Log(m_pos);

        m_top.position = new Vector3(0f, m_pos.y,0f);
        m_bottom.position = new Vector3(0f, -m_pos.y,0f);
      //  m_bg.position = m_bottom.position;

    }

    public void _DoCameraSize(SpriteRenderer m_r)
    {

        Debug.Log("Doing Camera Size");

        m_sprite = m_r;

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = m_sprite.bounds.size.x / m_sprite.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            // Debug.Log("This Worked");
            Camera.main.orthographicSize = m_sprite.bounds.size.y / 2f;
        }
        else
        {
            //  Debug.Log("This Worked");
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = m_sprite.bounds.size.y / 2f * differenceInSize;
        }
    }
}
