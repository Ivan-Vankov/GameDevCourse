using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JuiceUIManager : MonoBehaviour {

    public static bool SoundOn { get; private set; } = false;
    public static bool ScreenShakeOn { get; private set; } = false;
    public static bool ParticlesOn { get; private set; } = false;
    public static bool RecoilOn { get; private set; } = false;
    public static bool PermananceOn { get; private set; } = false;
    public static bool MuzzleFlashOn { get; private set; } = false;
    public static bool RewardOn { get; private set; } = false;
    public static bool TweeningOn { get; private set; } = false;

    public static Action<bool> OnSoundStateChanged;

    public void SetSoundState() {
        SoundOn = !SoundOn;
        OnSoundStateChanged?.Invoke(SoundOn);
    }

    public void SetScreenShakeState() {
        ScreenShakeOn = !ScreenShakeOn;
    }

    public void SetParticlesState() {
        ParticlesOn = !ParticlesOn;
    }

    public void SetRecoilState() {
        RecoilOn = !RecoilOn;
    }
}
