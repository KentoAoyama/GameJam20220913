using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    [SerializeField] Text _countDownText;
    [SerializeField] string _resultSceneName;
    [SerializeField] GameObject _panel;

    BossHealth _bossHealth;


    void Start()
    {
        _bossHealth = FindObjectOfType<BossHealth>().GetComponent<BossHealth>();
    }

    
    void FixedUpdate()
    {
        GameEnd();
    }


    void GameEnd()
    {
        if (_bossHealth._enemyHealth <= 0)
        {
            StartCoroutine(GameClear());
        }

        //Player‚ÌHP‚ªƒ[ƒ‚É‚È‚Á‚½Û‚É‚â‚éˆ—
        //if ()
        //{
              //StartCoroutine(GameOver());
        //}        
    }


    IEnumerator GameClear()
    {
        _panel.SetActive(true);
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(_resultSceneName);
    }


    IEnumerator GameOver()
    {
        _panel.SetActive(false);
        _countDownText.text = "GameOver";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(_resultSceneName);
    }
}
