using Command.Actions;
using Command.Player;
using System;
using UnityEngine;

namespace Command.Sound
{
    public class SoundService
    {
        private SoundScriptableObject soundScriptableObject;
        private AudioSource audioEffects;
        private AudioSource backgroundMusic;

        public SoundService(SoundScriptableObject soundScriptableObject, AudioSource audioEffectSource, AudioSource bgMusicSource)
        {
            this.soundScriptableObject = soundScriptableObject;
            audioEffects = audioEffectSource;
            backgroundMusic = bgMusicSource;
            PlaybackgroundMusic(SoundType.BACKGROUND_MUSIC, true);
        }

        public void PlayAttackSFX(ActionType actionType, UnitType unitType)
        {
            switch (actionType)
            {
                case ActionType.Heal:
                    PlaySoundEffects(SoundType.HEAL);
                    break;
                case ActionType.AttackStance:
                    PlaySoundEffects(SoundType.ATTACK_STANCE);
                    break;
                case ActionType.Cleanse:
                    PlaySoundEffects(SoundType.CLEANSE);
                    break;
                case ActionType.Meditate:
                    PlaySoundEffects(SoundType.MEDITATE);
                    break;
                case ActionType.BerserkAttack:
                    PlaySoundEffects(SoundType.BERSERK_ATTACK);
                    break;
                case ActionType.ThirdEye:
                    PlaySoundEffects(SoundType.KNIFE_SLASH);
                    break;
                case ActionType.Attack:
                    if (unitType == UnitType.WIZARD)
                    {
                        PlaySoundEffects(SoundType.MAGIC_BALL);
                    }
                    else if (unitType == UnitType.SWORD_MASTER)
                    {
                        PlaySoundEffects(SoundType.SWORD_SLASH);
                    }
                    else if (unitType == UnitType.BERSERKER)
                    {
                        PlaySoundEffects(SoundType.KNIFE_SLASH);
                    }
                    else if (unitType == UnitType.MAGE)
                    {
                        PlaySoundEffects(SoundType.FIRE_ATTACK);
                    }
                    break;

            }
        }

        public void PlaySoundEffects(SoundType soundType, bool loopSound = false)
        {
            AudioClip clip = GetSoundClip(soundType);
            if (clip != null)
            {
                audioEffects.loop = loopSound;
                audioEffects.clip = clip;
                audioEffects.PlayOneShot(clip);
            }
            else
                Debug.LogError("No Audio Clip selected.");
        }

        private void PlaybackgroundMusic(SoundType soundType, bool loopSound = false)
        {
            AudioClip clip = GetSoundClip(soundType);
            if (clip != null)
            {
                backgroundMusic.loop = loopSound;
                backgroundMusic.clip = clip;
                backgroundMusic.Play();
                backgroundMusic.volume = 0.05f;
            }
            else
                Debug.LogError("No Audio Clip selected.");
        }

        private AudioClip GetSoundClip(SoundType soundType)
        {
            Sounds sound = Array.Find(soundScriptableObject.audioList, item => item.soundType == soundType);
            if (sound.audio != null)
                return sound.audio;
            return null;
        }
    }
}