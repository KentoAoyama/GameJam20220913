using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField, Tooltip("死亡時に出すプレハブ")] GameObject _deathPrefab;

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
        else if (_enemyHealth > 0)
        {
            _animator.SetFloat("EnemyLevel", 1);
        }
        else
        {
            Instantiate(_deathPrefab, transform.position, transform.rotation);
        }
    }


    /// <summary>敵のレベルを表す列挙型</summary>
    public enum EnemyLevelState
    {
        Level1,
        Level2,
        Level3,
    }
}
