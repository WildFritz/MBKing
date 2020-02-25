using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//***** Menu manger for all buttons
public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Title()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void Instructions()
    {
        SceneManager.LoadScene(1);
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
    }
    public void Level2()
    {
        SceneManager.LoadScene(3);
    }
    public void Level3()
    {
        SceneManager.LoadScene(4);
    }

    public void Win()
    {
        SceneManager.LoadScene(5);
    }
    public void Lose()
    {
        SceneManager.LoadScene(6);
    }
    public void Credits()
    {
        SceneManager.LoadScene(7);
    }
}
