using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f; // Скорость движения противника
    public Transform player; // Ссылка на объект игрока
    private bool facingRight = false; // Флаг направления вправо

    void Update()
    {
        if (player != null)
        {
            // Получаем направление к игроку
            Vector3 direction = player.position - transform.position;
            direction.Normalize(); // Нормализуем вектор, чтобы сохранить постоянную скорость

            // Перемещаем противника в направлении игрока
            transform.Translate(direction * speed * Time.deltaTime);

            // Проверяем направление и поворачиваем противника
            if (direction.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (direction.x < 0 && facingRight)
            {
                Flip();
            }
        }

        void Flip()
        {
            // Переворачиваем масштаб по оси X для изменения ориентации
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

            // Обновляем флаг направления
            facingRight = !facingRight;
        }
    }
}