using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; 
using UnityEngine.SceneManagement;

public class TheUI : MonoBehaviour
{
    private TheBall theBall;
    private void Start() {
        
        theBall = GameObject.Find("/TheBall").GetComponent<TheBall>();
    }
    private void Update()
    {
            GetComponentInChildren<TMP_Text>().text = theBall.playerPoint.ToString();
    }
    public void RestartGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
