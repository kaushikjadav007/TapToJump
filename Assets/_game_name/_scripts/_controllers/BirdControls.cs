using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControls : MonoBehaviour
{

    public GameState m_game_state;
    public ColisionData m_colidion_data;
    [Space]
    public GameObject m_flying;
    public GameObject m_hit;

    private Rigidbody2D m_rb;
    [Space]
    public float m_jump_force;
    public float m_fall_speed;
    public float m_jump_speed;

    private Touch m_touch;

    private SpriteRenderer m_idele;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.bodyType = RigidbodyType2D.Static;
        m_idele = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {

        switch (m_game_state.m_currunt_state)
        {
            case _GameStates.m_tap_to_play:
                _FirstTapToStartGamme();
                break;

            case _GameStates.m_in_game:
#if UNITY_EDITOR
                _EditorInput();
#endif
                _TouchInput();

                // _Move();
                _SmoothJump();
                break;
        }


    }


    void _FirstTapToStartGamme()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_game_state.m_currunt_state = _GameStates.m_in_game;
            m_rb.bodyType = RigidbodyType2D.Dynamic;
            _Jump();
            m_idele.enabled = false;
            m_flying.SetActive(true);
        }

        if (Input.touchCount > 0)
        {
            m_game_state.m_currunt_state = _GameStates.m_in_game;
            m_rb.bodyType = RigidbodyType2D.Dynamic;
            _Jump();
            m_idele.enabled = false;
            m_flying.SetActive(true);
        }
    }

    void _EditorInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _Jump();
        }
    }

    void _TouchInput()
    {
        if (Input.touchCount == 0) return;

        m_touch = Input.GetTouch(0);

        switch (m_touch.phase)
        {
            case TouchPhase.Began:
                _Jump();
                break;
        }


    }


    //void _Move()
    //{
    //    transform.position += Vector3.right * m_move_speed * Time.deltaTime;
    //}

    void _Jump()
    {
        m_rb.velocity = Vector2.zero;
        m_rb.velocity = Vector2.up * m_jump_force;
    }

    void _SmoothJump()
    {
        if (m_rb.velocity.y < 0)
        {
            m_rb.velocity += Vector2.up * Physics2D.gravity.y * (m_fall_speed - 1) * Time.deltaTime;  // KSK EDIT
        }
        else if (m_rb.velocity.y > 0)
        {
            m_rb.velocity += Vector2.up * Physics2D.gravity.y * (m_jump_speed - 1) * Time.deltaTime;
        }
    }


    public void _GameEvent(int m_code)
    {
        switch (m_code)
        {
            case _GameCode.m_replay:
                _ResetOnReplay();
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D m_col)
    {
        switch (m_col.collider.tag)
        {
            case _Tags.m_dead_point:
                m_flying.SetActive(false);
                m_hit.SetActive(true);
                m_colidion_data._OnColisionHappen(m_col.collider.tag);
                break;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D m_col)
    {
        switch (m_col.tag)
        {
            case _Tags.m_point:
                m_col.enabled = false;
                m_colidion_data._OnColisionHappen(m_col.tag);
                m_col.GetComponent<Hoop>()._OnColisionWithBird();
                break;
        }
    }

    void _ResetOnReplay()
    {
        transform.position = Vector3.zero;
        m_rb.bodyType = RigidbodyType2D.Static;
        m_idele.enabled = true;
        m_flying.SetActive(false);
        m_hit.SetActive(false);
    }
}
