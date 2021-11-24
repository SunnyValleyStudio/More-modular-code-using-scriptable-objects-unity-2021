using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Version3
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private string animationAttackTrigger = "Attack";

        [SerializeField] private float attackInterval = 2;

        [SerializeField] private ThrowableWeapon weaponPrefab;

        [SerializeField] private Transform throwPoint;

        [SerializeField] private AudioSource throwAudioSource;

        private void Start()
        {
            StartCoroutine(PerformAttack());
        }

        private IEnumerator PerformAttack()
        {
            yield return new WaitForSeconds(attackInterval);
            animator.SetTrigger(animationAttackTrigger);
            ThrowWeapon();
        }

        private void ThrowWeapon()
        {
            ThrowableWeapon throwable = Instantiate(weaponPrefab.gameObject, throwPoint.position, Quaternion.identity)
                .GetComponent<ThrowableWeapon>();
            throwable.ThrowInDirection(transform.right * -1);
            throwAudioSource.Play();
            StartCoroutine(PerformAttack());
        }
    }
}