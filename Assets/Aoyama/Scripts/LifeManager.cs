using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    [SerializeField] string _resultSceneName;
    [SerializeField] GameObject _endPanel;


    GameObject _player;

    PlayerHealth _playerHealth;

    void Start()
    {
        _endPanel.SetActive(false);

        _player = GameObject.FindWithTag("Player");

        _playerHealth = _player.GetComponent<PlayerHealth>();
    }

    
    void FixedUpdate()
    {
        GameEnd();
    }


    void GameEnd()
    {
        //BossのHPがゼロになった時の処理
        if (BossHealth._isGameClear)
        {
            StartCoroutine(GameClear());
        }

        //PlayerのHPがゼロになった際にやる処理
        if (_playerHealth._playerHealth <= 0)
        {
            StartCoroutine(GameOver());
        }
    }


    IEnumerator GameClear()
    {
        _endPanel.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(_resultSceneName);
    }


    IEnumerator GameOver()
    {
        Destroy(_player);
        _endPanel.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(_resultSceneName);
    }
}
