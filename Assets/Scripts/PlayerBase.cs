using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Button invokeButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Text invokeTimer;
    [SerializeField] private PlayerWarrior warrior;
    private float timer = 10.0f;
    private bool canInvoke;

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        slider = canvas.GetComponentInChildren<Slider>();
        invokeButton = canvas.GetComponentInChildren<Button>();
        closeButton = canvas.GetComponentInChildren<Button>();
        invokeTimer = canvas.GetComponentInChildren<Text>();
        invokeButton.onClick.AddListener(() => canInvoke = true);
        slider.onValueChanged.AddListener((OnValueChanged));
    }

    private void OnValueChanged(float arg0)
    {
        if (arg0 > 0)
            invokeButton.interactable = true;
        else
            invokeButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInvoke)
        {
            if (timer <= 0 && slider.value > 0)
            {
                Spawn();
                slider.value -= 1;
                timer = 10.0f;
            }
            else
            {
                invokeTimer.text = timer.ToString("F1");
                timer -= Time.deltaTime;
            }

            if (slider.value == 0)
                canInvoke = false;
        }
    }



    private void Spawn()
    {
        warrior.transform.position = transform.position;
        Instantiate(warrior);
    }
}
