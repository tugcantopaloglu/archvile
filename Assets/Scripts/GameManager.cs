using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //Referances
    public Player player;
    //public weapon weapon...

    //Logic
    public int gold;
    public int experience;

    /*
    INT preffered skin
    INT gold
    INT experience
    INT weaponLevel
    */

    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += gold.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin

        //
        gold = int.Parse(data[1]);
        experience = int.Parse(data[2]);

        Debug.Log("Load");
    }

}
