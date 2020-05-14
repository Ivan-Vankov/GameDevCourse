using UnityEngine;
using static JuiceUIManager;

public class AudioManager : MonoBehaviour {

    [SerializeField] private AudioSource hitSound = null;
    [SerializeField] private AudioSource gunFireSound = null;
    [SerializeField] private AudioSource music = null;
    [SerializeField] private AudioSource dashSound = null;
    [SerializeField] private AudioSource deathSound = null;

    private static AudioManager instance;

    private void Start() {
        instance = this;
    }

    private void OnEnable() {
        JuiceUIManager.OnSoundStateChanged += SwitchMusicOnOrOff;
    }

    private void OnDisable() {
        JuiceUIManager.OnSoundStateChanged -= SwitchMusicOnOrOff;
    }

    public static void PlayHitSound() {
        if (SoundOn) { instance.hitSound.Play(); }
    }

    public static void PlayGunfireSound() {
        if (SoundOn) { instance.gunFireSound.Play(); }
    }

    public static void SwitchMusicOnOrOff(bool IsOn) {
        if (IsOn) {
            instance.music.Play();
        } else {
            instance.music.Stop();
        }
    }

    public static void PlayDashSound() {
        if (SoundOn) { instance.dashSound.Play(); }
    }

    public static void PlayDeathSound() {
        if (SoundOn) { instance.deathSound.Play(); }
    }
}
