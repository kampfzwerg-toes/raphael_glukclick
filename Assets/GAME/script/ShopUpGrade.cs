using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpGrade : MonoBehaviour
{
    public string upgradeName = "nain";
   
    public int cost = 25;

    public float costmultiplier = 1.5f;

    public int bonusPerClick = 0;

    public float bonusPerSecond = 1f;

    public TextMeshProUGUI label; 

    int level = 0;

    Button button; 

    void Start()
    {

     button = GetComponent<Button>();
     UpdateLabel();
    }
    
    void UpdateLabel()
    {

        label.text = upgradeName + " (lvl " + level + ")\n" + cost + " cookies";
    }  

    void Update()
    {

        button.interactable = Gamemanager.Instance.GetCookies() >= cost; 
    }

    public void Buy()
    {

        if (!Gamemanager.Instance.SpendCookies(cost))
        {
            return;
        }
        
        Gamemanager.Instance.AddBonus(bonusPerClick, bonusPerSecond);

        level++;
        cost = Mathf .RoundToInt(cost * costmultiplier);
        UpdateLabel();
    
    
    }



}   




