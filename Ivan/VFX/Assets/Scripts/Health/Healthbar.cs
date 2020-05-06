using UnityEngine.UI;
using UnityEngine;
using TMPro;

/// <summary>
/// Responsible for initializing and resizing the healthbar.
/// </summary>
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

    /// <summary>
    /// Function that will be subscribed to <see cref="Health.OnDamageTaken"/>.
    /// It scales the healthbar based on the current and mahimum health.
    /// </summary>
    /// <param name="health">The current health of the player</param>
    private void ScaleHealthbar(int health) {
        healthbarScaler.TargetScale = (float)health / Health.maxHealth;
    }
}
