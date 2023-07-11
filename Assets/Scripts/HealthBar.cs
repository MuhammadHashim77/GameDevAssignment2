using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    [SerializeField] private float damageTaken = 5f;
    [SerializeField] private float duration = 3f;

    private float fullHealthBarWidth;

    private void Start()
    {
        currentHealth = maxHealth;
        fullHealthBarWidth = healthBar.sizeDelta.x;  // Store the initial width of the health bar
        StartCoroutine(DamageSequence());
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void TakeDamage()
    {
        currentHealth -= damageTaken;
        float healthPercentage = currentHealth / maxHealth;
        healthBar.sizeDelta = new Vector2(healthPercentage * fullHealthBarWidth, 26);  // Use the actual width of the full health bar
    }

    IEnumerator DamageSequence()
    {
        yield return new WaitForSeconds(duration);

        while (currentHealth > 0)
        {
            TakeDamage();
            yield return new WaitForSeconds(duration);
        }
    }
}
