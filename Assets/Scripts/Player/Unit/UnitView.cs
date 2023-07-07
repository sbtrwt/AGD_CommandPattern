using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Player
{
    public class UnitView : MonoBehaviour
    {
        public UnitController Controller;

        [SerializeField] private SpriteRenderer unitIndicator;
        private Animator unitAnimator;

        private void Awake()
        {
            unitAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            PlayAnimation(UnitAnimations.IDLE);
        }

        private void PlayAnimation(UnitAnimations animationToPlay) => unitAnimator.Play(animationToPlay.ToString(), 0);

        public void SetUnitIndicator(bool setActive) => unitIndicator.gameObject.SetActive(setActive);
    }

    public enum UnitAnimations
    {
        IDLE,
        ACTION1,
        ACTION2,
        DEATH
    }

}
