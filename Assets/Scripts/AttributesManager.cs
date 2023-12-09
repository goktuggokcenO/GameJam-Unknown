using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    public int health;
    public int attack;
    public HealthBar healthBar;

    public void Start()
    {
        HealthBar healthBar= GetComponentInChildren<HealthBar>();
        if (healthBar != null)
        {
            UpdateHealthBar();
        }
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (healthBar != null)
        {
            UpdateHealthBar();
        }
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            atm.TakeDamage(attack);
        }
    }

    private void UpdateHealthBar()
    {
        // Gerekirse maxHealth ve currentHealth parametreleri hesaplanýr
        float maxHealth = 100f; // Örnek bir deðer, gerçek deðeri projenize göre ayarlayýn
        float currentHealth = Mathf.Clamp01((float)health / maxHealth); // 0-1 aralýðýnda bir deðere dönüþtür

        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }
}
