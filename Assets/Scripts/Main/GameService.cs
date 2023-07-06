using UnityEngine;
using Command.Utilities;
using Command.Sound;
using System.Collections.Generic;
using Command.Input;
using Command.Player;
using Command.UI;
using Command.Commands;

namespace Command.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        // Services:
        public SoundService SoundService { get; private set; }
        public CommandInvoker CommandInvoker { get; private set; }
        public InputService InputService { get; private set; }
        public PlayerService PlayerService { get; private set; }
        [SerializeField] public UIService UIService { get; private set; }

        // Scriptable Objects:
        [SerializeField] private SoundScriptableObject soundScriptableObject;
        [SerializeField] private List<BattleScriptableObject> battleScriptableObjects;

        // Scene References:
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioSource bgMusicSource;

        private void Start()
        {
            SoundService = new SoundService(soundScriptableObject, sfxSource, bgMusicSource);
            CommandInvoker = new CommandInvoker();
            InputService = new InputService();
            PlayerService = new PlayerService(battleScriptableObjects);
        }

        private void Update() => InputService.UpdateInputService();

        public void ProcessUnitCommand(IUnitCommand commandToProcess) => PlayerService.ProcessUnitCommand(commandToProcess);
    }
}