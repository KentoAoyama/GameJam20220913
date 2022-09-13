using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    [SerializeField] string _resultSceneName;
    [SerializeField] GameObject _panel;

    GameObject _player;
    GameObject _boss;

    BossHealth _bossHealth;
    PlayerHealth _playerHealth;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _boss = GameObject.FindWithTag("Boss");

        _bossHealth = FindObjectOfType<BossHealth>().GetComponent<BossHealth>();
        _playerHealth = FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
    }

    
    void FixedUpdate()
    {
        GameEnd();
    }


    void GameEnd()
    {
        //Boss‚ÌHP‚ªƒ[ƒ‚É‚È‚Á‚½‚Ìˆ—
        if (_bossHealth._enemyHealth <= 0)
        {
            StartCoroutine(GameClear());
        }

        //Player‚ÌHP‚ªƒ[ƒ‚É‚È‚Á‚½Û‚É‚â‚éˆ—
        if (_playerHealth._playerHealth <= 0)
        {
            StartCoroutine(GameOver());
        }
    }


    IEnumerator GameClear()
    {
        Destroy(_boss);
        yield return new WaitForSeconds(5);
        _panel.SetActive(true);
        SceneManager.LoadScene(_resultSceneName);
    }


    IEnumerator GameOver()
    {
        Destroy(_player);
        yield return new WaitForSeconds(5);
        _panel.SetActive(true);
        SceneManager.LoadScene(_resultSceneName);
    }
}
