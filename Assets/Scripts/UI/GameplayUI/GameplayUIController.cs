using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.UI
{
    public class GameplayUIController : IUIController
    {
        private GameplayUIView gameplayView;

        public GameplayUIController(GameplayUIView gameplayView) => this.gameplayView = gameplayView;

        public void Show() => gameplayView.EnableView();

        public void SetBackgroundImage(Sprite spriteToSet) => gameplayView.SetBeckground(spriteToSet);
    }
}