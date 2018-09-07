using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Health : ObjectProperty
{
    public float MinHealth = 0f;
    public float MaxHealth = 100f;
    public float CurrentHealth;

    public void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public override void Run(float amount)
    {
        CurrentHealth -= amount;
    }
    [UsedImplicitly]
    public void Update()
    {
        if (CurrentHealth <= MinHealth)
        {
            transform.GetComponent<ObjectDeathHandler>().Execute();
        }
    }

}
