using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Command.UI
{
    public class GameplayUIView : MonoBehaviour, IUIView
    {
        [SerializeField] private Image backgroundImage;

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);

        public void SetBeckground(Sprite spriteToSet) => backgroundImage.sprite = spriteToSet;
    }
}