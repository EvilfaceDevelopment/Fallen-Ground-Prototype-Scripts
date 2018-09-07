using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.PlayerScripts.Stats.GUI
{
    public class PlayerStatsGUI : MonoBehaviour
    {
//======================================================
// VARIABLES
//======================================================
// Private variables
//======================================================

        [SerializeField] private Text _healthText;
        [SerializeField] private Text _hungerText;
        [SerializeField] private Text _thirstText;
//======================================================
// UNITY FUNCTIONS
//======================================================
        
        public void Start()
        {
            GameManager.Instance.StatsController.OnHealthChange += HealthGuiUpdate;
            GameManager.Instance.StatsController.OnHungerChange += HungerGuiUpdate;
            GameManager.Instance.StatsController.OnThirstChange += ThirstGuiUpdate;


        }

   

        [ExecuteInEditMode]
        public void OnDisable()
        {
            GameManager.Instance.StatsController.OnHealthChange -= HealthGuiUpdate;
            GameManager.Instance.StatsController.OnHungerChange -= HungerGuiUpdate;
            GameManager.Instance.StatsController.OnThirstChange -= ThirstGuiUpdate;
        }
//===================================================
// CUSTOM FUNCTIONS
//===================================================

        public void HealthGuiUpdate(float amount)
        {
            _healthText.text = "Health: " + amount;
        }
        public void HungerGuiUpdate(float amount)
        {
            _hungerText.text = "Hunger: " + amount;
        }
        public void ThirstGuiUpdate(float amount)
        {
            _thirstText.text = "Thirst: " + amount;
        }
    }
}
