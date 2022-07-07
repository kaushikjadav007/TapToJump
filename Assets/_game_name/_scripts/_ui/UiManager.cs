using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class UiManager : MonoBehaviour
{
    [Header("UI PANELS")]
    public GameObject m_menu_panel;
    public GameObject m_in_game_panel;
    public GameObject m_game_over_panel;
    [Header("Buttons")]
    public Button m_play_button;
    public Button m_replay_button;

    [Header("Texts")]
    public TextMeshProUGUI m_score;
    public TextMeshProUGUI m_game_over_scrore;
    [Header("Events")]
    public GameState m_game_state;
    public GameEventNumber m_game_event;
    public GameEventNumber m_obstacle_event;

    private int m_score_count;


    private void Start()
    {
        m_menu_panel.SetActive(true);
        m_score_count = PlayerPrefs.GetInt(_SavedString.m_score);
        m_score.text = m_score_count.ToString();
        m_game_state.m_currunt_state = _GameStates.m_menu_state;
    }

    private void OnEnable()
    {
        m_play_button.onClick.AddListener(_OnPlayButtonClick);
        m_replay_button.onClick.AddListener(_OnReplay);
    }

    private void OnDisable()
    {
        m_play_button.onClick.RemoveListener(_OnPlayButtonClick);
        m_replay_button.onClick.RemoveListener(_OnReplay);
        
    }

    private async void _OnPlayButtonClick()
    {
        StartCoroutine(_StartGame());
    }

    public async void _OnReplay()
    {
        m_obstacle_event._Raise(_ObstacleCodes.m_rest_on_replay);
        m_game_event._Raise(_GameCode.m_replay);



        m_in_game_panel.SetActive(true);
        m_game_over_panel.SetActive(false);
        StartCoroutine(_StartGame());
    }

    IEnumerator _StartGame()
    {
        m_game_event._Raise(_GameCode.m_game_started);
        m_menu_panel.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        m_in_game_panel.SetActive(true);
        m_game_state.m_currunt_state = _GameStates.m_tap_to_play;
    }

    public void _OnGameEvent(int m_no)
    {
        switch (m_no)
        {
            case _GameCode.m_game_ended:
                m_in_game_panel.SetActive(false);
                m_game_over_panel.SetActive(true);
                m_game_over_scrore.text = m_score_count.ToString();
                PlayerPrefs.SetInt(_SavedString.m_score, m_score_count);
                break;

            case _GameCode.m_point_scored:
                m_score_count++;
                m_score.text = m_score_count.ToString();
                break;
        }
    }


}
