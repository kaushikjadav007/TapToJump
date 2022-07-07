using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventListenerNumber : MonoBehaviour
{
    public GameEventNumber m_game_event;

    [Tooltip("THIS IS EVENT ")]
    [Space]
    public MyNumberEvent m_unity_event;

    private void OnEnable()
    {
        m_game_event._RegisterEvent(this);
    }

    private void OnDisable()
    {
        m_game_event._DeRegisterEvent(this);
    }

    public void _InvokeEvent(int m_number)
    {
        if (m_unity_event != null)
        {
            // Debug.Log("EVENT INVOKED");
            m_unity_event.Invoke(m_number);
        }
    }
}
