using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; 
using UnityEngine.SceneManagement;

public class TheUI : MonoBehaviour
{
    private TheBall theBall;
    private TMP_Text scoreBoard;

    private void Start() {
        
        theBall = GameObject.Find("/TheBall").GetComponent<TheBall>();
        scoreBoard = GetComponentInChildren<TMP_Text>();
    }
    private void Update()
    {
            scoreBoard.text = theBall.playerPoint.ToString();
    }
    public void RestartGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
