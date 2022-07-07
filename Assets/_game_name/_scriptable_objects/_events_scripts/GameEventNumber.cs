using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameEventNumber",menuName = "ScriptableObject/GameEventNumber",order =100)]
public class GameEventNumber : ScriptableObject
{
    public List<GameEventListenerNumber> m_listerners = new List<GameEventListenerNumber>();

    public void _Raise(int m_number)
    {
        foreach (GameEventListenerNumber item in m_listerners)
        {
            item._InvokeEvent(m_number);
        }
    }

    public void _RegisterEvent(GameEventListenerNumber m_game_event)
    {
        if (!m_listerners.Contains(m_game_event))
        {
            m_listerners.Add(m_game_event);
        }
    }


    public void _DeRegisterEvent(GameEventListenerNumber m_game_event)
    {
        if (m_listerners.Contains(m_game_event))
        {
            m_listerners.Remove(m_game_event);
        }
    }
}
[System.Serializable]
public class MyNumberEvent : UnityEvent<int>
{

}
