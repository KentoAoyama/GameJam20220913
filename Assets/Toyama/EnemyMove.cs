using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 左右に波を描きながら下にオブジェクトを移動させる
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [SerializeField] float m_amplitude = 0f;
    [SerializeField] float m_speedX = 3f;
    [SerializeField] float m_speedY = 1f;
    Vector2 m_initialPosition;
    float m_timer;

    void Start()
    {
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        m_timer += Time.deltaTime;
        float posX = Mathf.Sin(m_timer * m_speedX) * m_amplitude;
        float posY = (-1) * m_timer * m_speedY;

        Vector2 pos = m_initialPosition + new Vector2(posX, posY);
        transform.position = pos;
    }
}