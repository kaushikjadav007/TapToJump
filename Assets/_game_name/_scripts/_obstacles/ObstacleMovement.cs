using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{
    [Space]
    public Transform m_hoop;
    [Space]
    public Transform m_upper_pipe;
    public Transform m_bottom_pipe;
    [Header("Scriptable Object")]
    public GameState m_game_satate;
    public GameEventNumber m_obstacle_event;

    private Vector3 m_upper_pos;
    private Vector3 m_bottom_pos;

    public Hoop m_hoop_script;
    [Space]
    public List<Sprite> m_sprites;
    [Space]
    public List<SpriteRenderer> m_all_pipes;

    private float m_move_speed=3.5f;
    // Update is called once per frame

    private float m_max_scren_point;
    private Vector2 m_hoop_pos;
    private void Start()
    {
        m_max_scren_point= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y;

        m_max_scren_point -= 5;
        Debug.Log(m_max_scren_point);
        _ResetHoopPosition();
    }

    private void OnEnable()
    {
        m_upper_pos = m_upper_pipe.localPosition;
        m_bottom_pos = m_bottom_pipe.localPosition;
    }

    void Update()
    {
        if (m_game_satate.m_currunt_state != _GameStates.m_in_game) return;
        transform.position += (Vector3.left * m_move_speed * Time.deltaTime);    
    }

    public void _ResetHoopPosition()
    {
       // Debug.Log("Resets Me");
        m_hoop.GetComponent<Collider2D>().enabled=true;

        m_upper_pipe.localPosition = m_upper_pos;
        m_bottom_pipe.localPosition = m_bottom_pos;

        m_hoop_pos = m_hoop.position;
        m_hoop_pos.y = Random.Range(-2, 5);

        m_hoop.position = m_hoop_pos;
        _ResetArt();
    }

    void _ResetArt()
    {

        Sprite s = m_sprites[Random.Range(0, m_sprites.Count)];

        foreach (var item in m_all_pipes)
        {
            item.sprite = s;
        }
    }

    public void _DoPipeAnimation()
    {
        m_upper_pipe.DOMoveY(50f,2f);
        m_bottom_pipe.DOMoveY(-50f,2f);
    }

}
