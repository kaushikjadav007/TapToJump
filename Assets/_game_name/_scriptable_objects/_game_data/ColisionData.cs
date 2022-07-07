using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColisionData", menuName = "ScriptableObject/ColisionData", order = 100)]
public class ColisionData : ScriptableObject
{
    public GameEventNumber m_obstacle_event;
    public GameEventNumber m_game_event;
    public GameState m_game_state;
    public void _OnColisionHappen(string m_tag)
    {
        Debug.Log(m_tag);

        switch (m_tag)
        {
            case _Tags.m_point:
                m_game_event._Raise(_GameCode.m_point_scored);
                m_obstacle_event._Raise(_ObstacleCodes.m_genrate_new_obstacle);
                break;

            case _Tags.m_dead_point:
                m_game_state.m_currunt_state = _GameStates.m_game_over;
                m_game_event._Raise(_GameCode.m_game_ended);
                break;
        }
    }
}
