using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public static int _enemyHealth = 5;

    Animator _animator;

    EnemyLevelState _els;
    public EnemyLevelState ELS => _els;
    

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
  

    void FixedUpdate()
    {
        if (TimeManager._isGame)
        {
            EnemyMove();
        }
    }


    void EnemyMove()
    {
        if (_enemyHealth >= 4)
        {
            _animator.SetFloat("EnemyLevel", 4); 
        }
        else if (_enemyHealth >= 2)
        {
            _animator.SetFloat("EnemyLevel", 2);
        }
        else
        {
            _animator.SetFloat("EnemyLevel", 1);
        }
    }


    /// <summary>“G‚ÌƒŒƒxƒ‹‚ð•\‚·—ñ‹“Œ^</summary>
    public enum EnemyLevelState
    {
        Level1,
        Level2,
        Level3,
        Death
    }
}
