using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraClass
{

}

[System.Serializable]
public enum _GameStates
{
    m_menu_state,
    m_tap_to_play,
    m_in_game,
    m_game_over
}

public struct _GameCode
{
    public const int m_game_started = 0;
    public const int m_game_ended = 1;
    public const int m_point_scored = 2;
    public const int m_replay = 3;
}

public struct _ObstacleCodes
{
    public const int m_genrate_new_obstacle=0;
    public const int m_rest_on_replay = 1;
}

public struct _SavedString
{
    public const string m_score = "Score";
}

public struct _Tags
{
    public const string m_bird = "Bird";
    public const string m_dead_point = "DeadPoint";
    public const string m_point = "Point";
}

