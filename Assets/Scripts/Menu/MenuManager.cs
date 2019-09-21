using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    
    [SerializeField]
    private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = startButton.GetComponent<Button>();
        btn1.onClick.AddListener(startGame);
        
        Button btn2 = quitButton.GetComponent<Button>();
        btn2.onClick.AddListener(quitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void startGame(){
        SceneManager.LoadScene("Level1");
    }

    void quitGame()
    {
        Application.Quit();
    }
    
}
