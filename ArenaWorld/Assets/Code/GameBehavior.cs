using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public string labelText = "Pass through the maze to escape!";
    public int maxAmmo = 10;
    public bool showWinScreen = false;
    private int _ammoCollected = 0;
    public int Ammo {
        get {return _ammoCollected;}
        set {
            _ammoCollected = value;
            if(_ammoCollected >= maxAmmo) {
                labelText = "You've found all the ammo!";
                showWinScreen = true;

                Time.timeScale = 0f;
            } else {
                labelText = "Ammo found, only " + (maxAmmo - _ammoCollected) + " more left!";
            }
            Debug.LogFormat("Items: {0}", _ammoCollected);
        }
    }

    private int _playerHP = 10;
    public int HP {
        get {return _playerHP;}
        set {
            _playerHP = value;
            Debug.LogFormat("Health: {0}", _playerHP);
        }
    }

    void OnGUI() {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Ammo:" + _ammoCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 30), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 -100, Screen.height / 2 - 50, 200, 100), "You've collected all the Ammo!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
