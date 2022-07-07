using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public ObstacleMovement m_obs;

    public void _OnColisionWithBird()
    {
        m_obs._DoPipeAnimation();

    }

    public void _EnableKey()
    {

    }
}
