using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] _enemy;
    [SerializeField] Transform _spawnPoint = null;
    [SerializeField] float _spawnTime = 2f;
    [SerializeField] int _enemyCount = 0;

    private int _index;
    private bool _flag = false;
    private int _spawnCounter = 0;
    private float _enemyTimer = 5f;
    private bool _bossSpawne = false;

    public static bool _isBossActive;


    void Update()
    {
        if(TimeManager._isGame == true)
        {
            _flag = true;
        }

        if (!_flag) return;

        if (_bossSpawne)
        {
            return;
        }

        // ウェーブ内で敵の生成間隔を待つ
        _enemyTimer += Time.deltaTime;
        if (_enemyTimer > _spawnTime)
        {
            // m_enemyPrefabs 配列の全ての要素に対してウェーブが終わったら
            if (_index > _enemy.Length - 1)
            {
                // ボス
                _isBossActive = true;
                return;
            }

            // まだウェーブを生成し、タイマーをリセットして m_spawnCounter をカウントアップする
            _enemyTimer = 0;
            _spawnCounter++;

            // 敵を生成する
            GameObject go = Instantiate(_enemy[_index]);
            go.transform.position = _spawnPoint.position;

            // ウェーブが終わったら、次のウェーブに映る
            if (_spawnCounter > _enemyCount - 1)
            {
                _spawnCounter = 0;
                _index++;
            }
        }
    }
}

