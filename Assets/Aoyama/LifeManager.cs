using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    [SerializeField] Text _countDownText;
    [SerializeField] string _resultSceneName;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    IEnumerator GameOver()
    {
        _countDownText.text = "GameOver";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(_resultSceneName);
    }
}
