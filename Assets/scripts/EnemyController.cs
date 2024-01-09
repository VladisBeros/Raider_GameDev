using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f; // �������� �������� ����������
    public Transform player; // ������ �� ������ ������
    private bool facingRight = false; // ���� ����������� ������

    void Update()
    {
        if (player != null)
        {
            // �������� ����������� � ������
            Vector3 direction = player.position - transform.position;
            direction.Normalize(); // ����������� ������, ����� ��������� ���������� ��������

            // ���������� ���������� � ����������� ������
            transform.Translate(direction * speed * Time.deltaTime);

            // ��������� ����������� � ������������ ����������
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
            // �������������� ������� �� ��� X ��� ��������� ����������
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

            // ��������� ���� �����������
            facingRight = !facingRight;
        }
    }
}