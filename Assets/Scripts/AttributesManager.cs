// Libraries and files
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character atributes
public class AttributesManager : MonoBehaviour
{
    // Veriables
    public int health;
    public int attack;

    // Take damage when hit by a projectile
    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    // Deal damage when shhot
    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if(atm != null)
        {
            atm.TakeDamage(attack);
        }
    }
}
