using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Player
{
    public class UnitView : MonoBehaviour
    {
        public UnitController Controller;

        [SerializeField] private SpriteRenderer unitIndicator;
        [SerializeField] private GameObject healthBar;
        private Animator unitAnimator;

        private void Awake()
        {
            unitAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            PlayAnimation(UnitAnimations.IDLE);
        }

        public void PlayAnimation(UnitAnimations animationToPlay) => unitAnimator.Play(animationToPlay.ToString(), 0);

        public void SetUnitIndicator(bool setActive) => unitIndicator.gameObject.SetActive(setActive);

        public void UpdateHealthBar(float currentHealthRatio) => healthBar.transform.localScale = new Vector3(currentHealthRatio, 0.2f, 1);

        public void OnActionAnimationComplete() => Controller.OnActionExecuted();
    }

    public enum UnitAnimations
    {
        IDLE,
        ACTION1,
        ACTION2,
        DEATH
    }

}
