using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField, Tooltip("死亡時に出すプレハブ")] GameObject _deathPrefab;
    [SerializeField, Tooltip("Bossの体のパーツ")] GameObject[] _bossBody;

    public int _enemyHealth = 5;
    int _destroyNum = 0;

    Animator _animator;
    ParticleSystem _particle;

    EnemyLevelState _els;
    public EnemyLevelState ELS => _els;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _particle = GetComponent<ParticleSystem>();
    }


    void FixedUpdate()
    {
        if (TimeManager._isGame)
        {
            EnemyMove();
        }
    }


    void OnDisable()
    {
        if (_deathPrefab)
        {
            Instantiate(_deathPrefab, transform.position, transform.rotation);
        }
    }

    /// <summary>Enemyの体力に応じた行動をさせる</summary>
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
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            _enemyHealth--;
            Destroy(_bossBody[_destroyNum]);
            _destroyNum++;
            _particle.Play();
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
