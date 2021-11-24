using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Version1
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 10;
        [SerializeField] private int currentHealth = 0;

        [SerializeField] private GameObject bloodParticle;

        [SerializeField] private Renderer renderer;
        [SerializeField] private float flashTime = 0.2f;
        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
                UpdateUI(currentHealth, maxHealth);
            }
        }

        [SerializeField] private UISlider uiSlider;

        private void Start()
        {
            CurrentHealth = maxHealth;
        }

        private void UpdateUI(int currentValue, int maxValue)
        {
            uiSlider.SetValue((float)currentValue / maxValue);
        }

        public void Reduce(int damage)
        {
            CurrentHealth -= damage;
            CreateHitFeedback();
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void CreateHitFeedback()
        {
            Instantiate(bloodParticle, transform.position, Quaternion.identity);
            StartCoroutine(FlashFeedback());
        }

        private IEnumerator FlashFeedback()
        {
            renderer.material.SetInt("_Flash", 1);
            yield return new WaitForSeconds(flashTime);
            renderer.material.SetInt("_Flash", 0);
        }

        private void Die()
        {
            Debug.Log("Died");
            CurrentHealth = maxHealth;
        }
    }
}