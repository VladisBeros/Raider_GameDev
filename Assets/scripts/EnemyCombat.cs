using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public int attackDamage = 1;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            // Проверяем наличие игрока в зоне атаки
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

            if (hitPlayers.Length > 0)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");

        // Атакуем всех игроков в зоне атаки
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<Health>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
