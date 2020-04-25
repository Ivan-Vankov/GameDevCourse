using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Healthbar : MonoBehaviour {

    [SerializeField] private Sprite avatar = null;
    [SerializeField] private Image avatarRenderer = null;
    [SerializeField] private string heroName = "HeroName";
    [SerializeField] private TextMeshProUGUI heroNameRenderer = null;
    [SerializeField] private Health heroHealth = null;
    [SerializeField] private HealthbarScaler healthbarScaler = null;

    void Start() {
        avatarRenderer.sprite = avatar;
        heroNameRenderer.text = heroName;
    }

    private void OnEnable() {
        heroHealth.OnDamageTaken += ScaleHealthbar;
    }

    private void OnDisable() {
        heroHealth.OnDamageTaken -= ScaleHealthbar;
    }

    private void ScaleHealthbar(int health) {
        healthbarScaler.TargetScale = (float)health / Health.maxHealth;
    }
}
