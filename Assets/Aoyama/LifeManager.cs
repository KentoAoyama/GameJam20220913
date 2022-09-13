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


    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        GameEnd();
    }


    void GameEnd()
    {
        if (BossHealth._enemyHealth <= 0)
        {
            StartCoroutine(GameClear());
        }

        //Player‚ÌHP‚ªƒ[ƒ‚É‚È‚Á‚½Û‚É‚â‚éˆ—
        //if ()
        //{

        //}        
    }


    IEnumerator GameClear()
    {
        _panel.SetActive(true);
        yield return new WaitForSeconds(2);
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
