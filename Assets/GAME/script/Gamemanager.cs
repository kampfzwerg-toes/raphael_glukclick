using TMPro;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager Instance;

    public TextMeshProUGUI scoreText; 

    public TextMeshProUGUI perSecondText;
    public int cookiesPerClick = 1;

    public float cookiesPerSecond = 0f;
    float cookies = 0f;

    void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        cookies += cookiesPerSecond * Time.deltaTime;
        UpdateUI();
    }

    public void AddCookies ()
    {
        cookies += cookiesPerClick;

        Debug.Log("Nombre Cookies :" + cookies);
    }

    private void UpdateUI()
    {
        scoreText.text = "cookies " + Mathf.FloorToInt(cookies);
    
    }

    public float GetCookies()
    {

        return cookies;
    }

    public bool SpendCookies(int amount)
    {

        if (cookies < amount)
        {  
            return false; 
        
        }
        
        cookies -= amount;
        return true;
    
    }

    public void AddBonus(int bonusPerClick, float bonusPerSecond)
    {
        cookiesPerClick += bonusPerClick;
        cookiesPerSecond += bonusPerSecond;
    }







}

