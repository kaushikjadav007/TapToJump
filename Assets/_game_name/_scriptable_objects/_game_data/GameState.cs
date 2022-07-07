using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObject/GameState",order =100)]
public class GameState : ScriptableObject
{
    public _GameStates m_currunt_state;
}
