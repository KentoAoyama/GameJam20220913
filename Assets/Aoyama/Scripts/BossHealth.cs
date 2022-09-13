using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField, Tooltip("����Boss�̃v���n�u")] GameObject _bossPrefab;
    [SerializeField, Tooltip("���S���ɏo���v���n�u")] GameObject _deathPrefab;
    [SerializeField, Tooltip("Boss�̑̂̃p�[�c")] GameObject[] _bossBody;
    [SerializeField] bool _isLastBoss;
    [Tooltip("�{�X���o�Ă�����")] static int _bossCount;

    public int _enemyHealth = 10;
    int _destroyNum = 0;
    public static bool _isGameClear;

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


    void OnDestroy()
    {
        if (!_isLastBoss)
        {
            Instantiate(_deathPrefab, transform.position, transform.rotation);
            Instantiate(_bossPrefab, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(_deathPrefab, transform.position, transform.rotation);
            _isGameClear = true;
        }
    }


    /// <summary>Enemy�̗̑͂ɉ������s����������</summary>
    void EnemyMove()
    {
        if (_enemyHealth >= 7)
        {
            _animator.SetFloat("EnemyLevel", 4);
        }
        else if (_enemyHealth >= 4)
        {
            _animator.SetFloat("EnemyLevel", 2);
        }
        else if (_enemyHealth > 0)
        {
            _animator.SetFloat("EnemyLevel", 1);
        }
        else
        {
            Destroy(gameObject);
        }       
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            _enemyHealth--;
            Destroy(_bossBody[_destroyNum % 4]);
            _destroyNum++;
            _particle.Play();
        }
    }


    /// <summary>�G�̃��x����\���񋓌^</summary>
    public enum EnemyLevelState
    {
        Level1,
        Level2,
        Level3,
    }
}
