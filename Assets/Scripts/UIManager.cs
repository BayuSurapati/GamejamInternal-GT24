using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TMP_Text healthText;
    public TMP_Text staminaText;

    public GameObject uiLose;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
        UpdateStamina();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth()
    {
        healthText.text = " " + Mathf.RoundToInt(PlayerHealth.instance.currentHealth);
    }

    public void UpdateStamina()
    {
        staminaText.text = " " + Mathf.RoundToInt(PlayerMovement.instance.currentStamina);
    }

    public void UlangGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
