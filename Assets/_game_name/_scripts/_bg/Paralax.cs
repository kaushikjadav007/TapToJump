using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float m_speed;

    [Space]
    public GameState m_state;

    private Material m_my_mat;
    private float m_i;

    private void Start()
    {
        m_my_mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_state.m_currunt_state == _GameStates.m_in_game)
        {
            m_i += Time.deltaTime * m_speed;
            m_my_mat.SetTextureOffset("_MainTex", Vector2.right * m_i);
        }
    }
}
