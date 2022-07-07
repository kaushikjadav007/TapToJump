using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenrator : MonoBehaviour
{
    public ObstacleMovement m_prefab;

    [Space]
    public List<ObstacleMovement> m_obstacle_pooler;

    public float m_x_pos;

    private float m_diffren_between_two_obstacles = 10f;

    private Vector3 m_next_pos;
    private ObstacleMovement m_temp_obj;

    IEnumerator  Start()
    {

        yield return new WaitForEndOfFrame();
        _GenrateNewObstacle(15);
    }


    public void _OnObstacleEvent(int m_no)
    {
        switch (m_no)
        {
            case _ObstacleCodes.m_genrate_new_obstacle:
                _GenrateNewObstacle(m_x_pos);
                break;
            case _ObstacleCodes.m_rest_on_replay:
                _Reset();
                break;
        }
    }

    void _Reset()
    {
        foreach (var m_item in m_obstacle_pooler)
        {
            m_item.transform.position = new Vector3(-50f, 0f, 0f);
        }
        _GenrateNewObstacle(15);
    }


    void _GenrateNewObstacle(float m_x)
    {
        m_next_pos = Vector3.zero;
        m_next_pos.x = m_x;


        m_temp_obj = _GetPooledObject();

        if (m_temp_obj == null)
        {
            m_temp_obj = Instantiate(m_prefab, m_next_pos, Quaternion.identity);
        }

        m_temp_obj._ResetHoopPosition();
        m_temp_obj.transform.position = m_next_pos;

        m_obstacle_pooler.Add(m_temp_obj);
    }

    /// <summary>
    /// Mini Object Pool
    /// </summary>
    /// <returns></returns>
    ObstacleMovement _GetPooledObject()
    {
        foreach (ObstacleMovement m_items in m_obstacle_pooler)
        {
            if (m_items.transform.position.x < -15f)
            {
                return m_items;
            }
        }

        return null;
    }

}
