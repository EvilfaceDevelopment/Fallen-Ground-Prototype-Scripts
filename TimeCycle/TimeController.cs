using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    public TimeController instance;
    public delegate void OnDayChanged();
    public static event OnDayChanged change;


    [SerializeField]
    private Light m_sun;
    [SerializeField]
    private float m_sunIntensity;
    [SerializeField]
    private float m_currentDay = 0;
    [SerializeField]
    private float m_secondsInaDay = 120f;
   [SerializeField] [Range(0f,1f)]
    private float m_currentTime = 0f;

    private float m_multiplier = 1f;
    // Use this for initialization
    void Start ()
    {
        m_sunIntensity = m_sun.intensity;
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		UpdateSun();

	    m_currentTime += ((Time.deltaTime / m_secondsInaDay) * m_multiplier);
	    if (m_currentTime >= 1f)
        {
            change?.Invoke();
            m_currentDay += 1;
	        m_currentTime = 0f;
	    }
	}

    public void UpdateSun()
    {
        m_sun.transform.localRotation = Quaternion.Euler((m_currentTime * 360f) - 90, 170, 0);

        float m_sunIntensityMultiplier = 1;
        if (m_currentTime <= 0.23f || m_currentTime >= 0.75f)
        {
            m_sunIntensityMultiplier = 0;
        }
        else if (m_currentTime <= 0.25f)
        {
            m_sunIntensityMultiplier = Mathf.Clamp01((m_currentTime - 0.23f) * (1 / 0.02f));
        }
        else if (m_currentTime >= 0.73f)
        {
            m_sunIntensityMultiplier = Mathf.Clamp01(1 - ((m_currentTime - 0.73f) * (1 / 0.02f)));
        }

        m_sun.intensity = m_sunIntensity * m_sunIntensityMultiplier;
    }





}
