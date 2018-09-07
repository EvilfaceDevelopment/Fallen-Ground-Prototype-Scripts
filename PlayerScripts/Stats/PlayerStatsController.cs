using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    /* This class contains all of the data needed for player the player stats
     * e.g health, thirst, hunger
     *
     * This class is also the controller for those stats so it also contains logic for modifying
     * each stat.
     *
     */

    //=================================================
    // DELEGATES & EVENTS
    //=================================================
    //health change
    public delegate void OnHealthChangeDelegate(float newValue);
    public event OnHealthChangeDelegate OnHealthChange;
    //hunger change
    public delegate void OnHungerChangeDelegate(float newValue);
    public event OnHungerChangeDelegate OnHungerChange;
    //thirst
    public delegate void OnThirstChangeDelegate(float newValue);
    public event OnThirstChangeDelegate OnThirstChange;


    

    //=================================================
    // VARIABLES
    //=================================================
    //Private variables
    //=================================================
    //Health vars
    //
    private float _currentHealth;
    private float _maxHealth;
    private float _minHealth;
    //=================================================
    // Hunger vars
    private float _currentHunger;
    private float _maxHunger;
    private float _minHunger;
    // Thirst vars
    private float _currentThirst;
    private float _maxThirst;
    private float _minThirst;




    //=================================================
    // PUBLIC VARIABLES
    //=================================================
    public float CurrentHealth 
    {
        get { return _currentHealth; }
        set
        {
            if (value > _maxHealth) return;
            if (value < _minHealth) return;
            _currentHealth = value;
            OnHealthChange?.Invoke(_currentHealth); //null propogation on event.
        }
    }

    public float CurrentHunger
    {
        get { return _currentHunger; }
        set
        {
            if (value > _maxHunger) return;
            if (value < _minHunger) return;
            _currentHunger = value;
            OnHungerChange?.Invoke(_currentHunger); //null propogation on event.
        }
    }

    public float CurrentThirst
    {
        get { return _currentThirst; }
        set
        {
            if (value > _maxThirst) return;
            if (value < _minThirst) return;
            _currentThirst = value;
            OnThirstChange?.Invoke(_currentThirst); //null propogation on event.
        }
    }

    public void Start()
    {
        //set health vars
        _maxHealth = 100;
        CurrentHealth = _maxHealth;
        _minHealth = 0;
        //set hunger vars
        _maxHunger = 100;
        CurrentHunger = _maxHunger;
        _minHunger = 0;
        //set thirst vars
        _minThirst = 0;
        _maxThirst = 100;
        CurrentThirst = _maxThirst;

    }

    public void OnEnable()
    {
        TimeController.change += HalveHealthAndThirst;
    }

    public void OnDisable()
    {
        TimeController.change -= HalveHealthAndThirst;
    }

    public void CheckIfDead()
    {
        if (CurrentHealth <= _minHealth)
        {
            Debug.Log("player is dead!!!!!!");
        }
    }

    /// <summary>
    /// Adds an an amount to the players current health
    /// </summary>
    /// 
    /// <example>
    /// PlayerStatsController.ModifyHealth(-5f);
    /// </example>
    /// 
    /// <param name="amount"> the amount to be added to the players current health.
    /// Can be a minus value as demonstrated in example.s
    /// </param>

    public void HalveHealthAndThirst()
    {
        ModifyHunger(-(_currentHunger /2));
        ModifyThirst(-(_currentThirst / 2));
    }

    public void ModifyHealth(float amount)
    {
        CurrentHealth += amount;
        CheckIfDead();
    }

    public void ModifyHunger(float amount)
    {
        CurrentHunger += amount;
        CheckIfDead();
    }

    public void ModifyThirst(float amount)
    {
        CurrentThirst += amount;
        CheckIfDead();
    }

    public void TestChangeAll()
    {
        ModifyHealth(-5f);
        ModifyThirst(-5f);
        ModifyHunger(-5f);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            TestChangeAll();
        }
    }
}

