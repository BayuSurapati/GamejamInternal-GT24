using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TMP_Text staminaText;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateStamina();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStamina()
    {
        staminaText.text = " " + Mathf.RoundToInt(PlayerMovement.instance.currentStamina);
    }
}
