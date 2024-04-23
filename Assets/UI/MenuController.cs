using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

namespace UI {
    public class MenuController : MonoBehaviour 
    {
        [Header("Mute Button")]
        [SerializeField]
        private Sprite _mutedSprite;
        [SerializeField]
        private Sprite _unmutedSprite;

        private bool _muted;

        [Header("Settings")]
        [SerializeField]
        private VisualTreeAsset _settingsButtonsTemplate;

        [Header("Play")]
        [SerializeField]
        private VisualTreeAsset _playButtonsTemplate;

        private VisualElement _playButtons;
        private VisualElement _settingsButtons;
        private VisualElement _buttonsWrapper;

        private UIDocument _doc;
        private Button _playButton;
        private Button _exitButton;
        private Button _settingsButton;
        private Button _muteButton;
        //private Button _level1Button;
        //private Button _level2Button;
        //private Button _level3Button;
        //private Button _level4Button;

        private void Awake() {
            _doc = GetComponent<UIDocument>();

            
            _playButton =
                _doc.rootVisualElement.Q<Button>("PlayButton");
            //_level1Button =
            //    _doc.rootVisualElement.Q<Button>("Level1Button");
            //_level2Button =
            //_doc.rootVisualElement.Q<Button>("Level2Button");
            //_level3Button =
            //    _doc.rootVisualElement.Q<Button>("Level3Button");
            //_level4Button =
            //    _doc.rootVisualElement.Q<Button>("Level4Button");
            _settingsButton =
                _doc.rootVisualElement.Q<Button>("SettingsButton");
            _exitButton =
                _doc.rootVisualElement.Q<Button>("ExitButton");
            _muteButton = 
                _doc.rootVisualElement.Q<Button>("MuteButton");
            _buttonsWrapper =
                _doc.rootVisualElement.Q<VisualElement>("Buttons");
            if (_buttonsWrapper == null)
            {
                Debug.LogError("ButtonsWrapper not found!");
                return;
            }

            _playButton.clicked += PlayButtonOnClicked;
            //_level1Button.clicked += () => LoadLevel(1);
            //_level2Button.clicked += () => LoadLevel(2);
            //_level3Button.clicked += () => LoadLevel(3);
            //_level4Button.clicked += () => LoadLevel(4);
            _settingsButton.clicked += SettingsButtonOnClicked;
            _exitButton.clicked += ExitButtonOnClicked;
            _muteButton.clicked += MuteButtonOnClicked;            

            _playButtons = _playButtonsTemplate.CloneTree();
            var backButton2 = 
                _playButtons.Q<Button>("BackButton");
            backButton2.clicked += BackButtonOnClicked;

            var level1Button = _playButtons.Q<Button>("Level1Button");
            var level2Button = _playButtons.Q<Button>("Level2Button");
            var level3Button = _playButtons.Q<Button>("Level3Button");
            var level4Button = _playButtons.Q<Button>("Level4Button");

            level1Button.clicked += () => LoadLevel(1);
            level2Button.clicked += () => LoadLevel(2);
            level3Button.clicked += () => LoadLevel(3);
            level4Button.clicked += () => LoadLevel(4);

            _settingsButtons = _settingsButtonsTemplate.CloneTree();
            var backButton = 
                _settingsButtons.Q<Button>("BackButton");
            backButton.clicked += BackButtonOnClicked;            

           
        }


        private void BackButtonOnClicked() {

            _buttonsWrapper.Clear();
            _buttonsWrapper.Add(_playButton);
            _buttonsWrapper.Add(_settingsButton);
            _buttonsWrapper.Add(_exitButton);
        }

        private void PlayButtonOnClicked() {

            //SceneManager.LoadScene("LevelSelector");
            _buttonsWrapper.Clear();
            _buttonsWrapper.Add(_playButtons);
        }

        private void ExitButtonOnClicked() {

            Application.Quit();
        }

        private void MuteButtonOnClicked() {

            _muted = !_muted;
            var bg =
                _muteButton.style.backgroundImage;
            bg.value = Background.FromSprite(
                _muted ? _mutedSprite : _unmutedSprite);
            _muteButton.style.backgroundImage = bg;
            AudioListener.volume = _muted ? 0 : 1;
        }

       

        private void SettingsButtonOnClicked() {

            _buttonsWrapper.Clear();
            _buttonsWrapper.Add(_settingsButtons);
        }

        private void LoadLevel(int level) {
            //string levelName = button.name.Replace("Level_", "");
            //SceneManager.LoadScene("Level_" + levelName);
            SceneManager.LoadScene("Level_" + level.ToString());
        }
    }
}