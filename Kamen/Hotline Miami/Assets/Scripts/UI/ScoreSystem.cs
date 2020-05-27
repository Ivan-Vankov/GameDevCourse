using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreSystem : MonoBehaviour {

    private Animator animator;
    private TextMeshProUGUI scoreText = null;
    private int score = 0;

    private void Start() {
        animator = GetComponent<Animator>();
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }

    private void OnEnable() {
        EnemyHealth.OnEnemyDeath += UpdateScoreUI;
        JuiceUIManager.OnRewardStateChanged += SetScoreEnabledState;
    }

    private void OnDisable() {
        EnemyHealth.OnEnemyDeath -= UpdateScoreUI;
        JuiceUIManager.OnRewardStateChanged -= SetScoreEnabledState;
    }

    private void SetScoreEnabledState(bool isEnabled) {
        scoreText.enabled = isEnabled;
    }

    private void UpdateScoreUI(Vector3 position) {
        score += 10;
        scoreText.text = score.ToString();
        animator.SetTrigger("HasScored");
    }
}
