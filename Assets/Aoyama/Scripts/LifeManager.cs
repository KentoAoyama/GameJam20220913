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
    GameObject _boss;

    BossHealth _bossHealth;
    PlayerHealth _playerHealth;

    void Start()
    {
        _endPanel.SetActive(false);

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
        //BossÇÃHPÇ™É[ÉçÇ…Ç»Ç¡ÇΩéûÇÃèàóù
        if (_bossHealth._enemyHealth <= 0)
        {
            StartCoroutine(GameClear());
        }

        //PlayerÇÃHPÇ™É[ÉçÇ…Ç»Ç¡ÇΩç€Ç…Ç‚ÇÈèàóù
        if (_playerHealth._playerHealth <= 0)
        {
            StartCoroutine(GameOver());
        }
    }


    IEnumerator GameClear()
    {
        Destroy(_boss);
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
