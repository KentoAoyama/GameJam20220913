using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Text _countDownText;
    [SerializeField] GameObject _panel;

    float _countDown = 3.5f;

    /// <summary>�J�E���g�_�E�����I�����A�Q�[�����J�n���Ă��邩�\���ϐ�</summary>
    public static bool _isGame;


    void Awake()
    {
        _panel.SetActive(true);
    }


    void FixedUpdate()
    {
        TextChange();
        GameStateChange();
    }


    void TextChange()
    {
        if (!_isGame)
        {
            _countDown -= Time.deltaTime;

            _countDownText.text = Mathf.Floor(_countDown).ToString();
        }
    }


    void GameStateChange()
    {
        if (_countDown < 1)
        {
            _panel.SetActive(false);
            _countDownText.text = "";
            _isGame = true;
        }
    }
}
