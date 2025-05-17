using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public InventoryPanel inventoryPanel;

    public void OpenInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.OnOpen();
        Cursor.visible =true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void CloseInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(false);
        Cursor.visible =false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public float timeCounter = 30f;
    public ItemData targetItem;
    public int targetAmount = 5;
    
    public TMP_Text timeCounterText;
    public Image targetItemIcon;
    public TMP_Text targetCurrentAmountText;
    
    // for Win and lose Text
    public TMP_Text winText;
    public TMP_Text loseText;

    private void Win()
    {
        winText.text = "You Win";
    }
    
    private void Lose()
    {
        loseText.text = "You Lose";
    }

    public bool isPlayerWin = false;
    private void Start()
    {
        targetItemIcon.sprite = targetItem.itemIcon;
    }

    private void Update()
    {
        if (isPlayerWin)
        {
            Win();
            return;
        }
        
        if (timeCounter > 0f)
        {
            timeCounter -= Time.deltaTime;
            timeCounterText.text = timeCounter.ToString();
            targetCurrentAmountText.text = "x " + (targetAmount - InventoryManager.instance.GetItemAmount(targetItem)).ToString();

            if (InventoryManager.instance.GetItemAmount(targetItem) >= targetAmount) //player win
            {
                Debug.Log("Player Win");
                isPlayerWin = true;
            }
        }
        else // player lose
        {   
            Lose();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
