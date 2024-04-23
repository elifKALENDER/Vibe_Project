using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class LevelSelector : MonoBehaviour {

    private UIDocument _doc;
    private Button _level1Button;
    private Button _level2Button;
    private Button _level3Button;
    private Button _level4Button;

    private void Awake() {
        // Butonlara týklama olaylarýný ata
        AssignButtonClickEvents();
    }

    private void AssignButtonClickEvents() {
        _doc = GetComponent<UIDocument>();

        _level1Button =
            _doc.rootVisualElement.Q<Button>("Level1Button");
        _level1Button.clicked += () => LoadLevel(1);

        _level2Button =
            _doc.rootVisualElement.Q<Button>("Level2Button");
        _level2Button.clicked += () => LoadLevel(2);

        _level3Button =
            _doc.rootVisualElement.Q<Button>("Level3Button");
        _level3Button.clicked += () => LoadLevel(3);

        _level4Button =
            _doc.rootVisualElement.Q<Button>("Level4Button");
        _level4Button.clicked += () => LoadLevel(4);        
        
    }

    //private void AssignButtonClickEvents() {
    //    for (int i = 1; i <= 4; i++)
    //    {
    //        string buttonName = "Level" + i + "Button";
    //        Button levelButton = GameObject.Find(buttonName).GetComponent<Button>();
    //        levelButton.onClick.AddListener(() => LoadLevel(i));
    //    }
    //}

    private void LoadLevel(int level) {
        SceneManager.LoadScene("Level_" + level.ToString());
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using UnityEngine.UIElements;
//using Button = UnityEngine.UIElements.Button;

//public class LevelSelector : MonoBehaviour
//{
//    public int level;
//    //public Text levelText;
//    // Start is called before the first frame update
//    void Start()
//    {
//       // levelText.text=level.ToString();
//    }

//    public void OpenScene(EventBase evt) {

//        Button clickedButton= evt.target as Button;

//        if (clickedButton != null )
//        {
//            string buttonText=clickedButton.text;

//            if(buttonText== "1") {
//                LoadLevel(1); 
//            }

//            else if (buttonText == "2")
//            {
//                LoadLevel(2);
//            }
//            else if (buttonText == "3")
//            {
//                LoadLevel(3);
//            }
//            else if  (buttonText == "4")
//            {
//                LoadLevel(4);
//            }

//        }

//        //SceneManager.LoadScene("Level_" + level.ToString());
//    }

//    private void LoadLevel(int level) {
//        SceneManager.LoadScene("Level_"+level);
//    }
//}
