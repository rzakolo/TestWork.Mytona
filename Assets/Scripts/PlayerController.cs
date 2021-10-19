using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask rayLayer;
    [SerializeField] private Canvas canvas;
    private Camera mainCamera;
    private List<PlayerWarrior> selectedWarriors;
    private List<PlayerWarrior> visibleWarriors;
    private float lastClickTime;
    void Start()
    {
        selectedWarriors = new List<PlayerWarrior>();
        visibleWarriors = new List<PlayerWarrior>();
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            float timeBetweenClick = Time.time - lastClickTime;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 50))
            {
                if (hit.collider && hit.collider.CompareTag("PlayerBase"))
                {
                    hit.collider.gameObject.GetComponent<PlayerBase>().enabled = true;
                    canvas.gameObject.SetActive(true);
                }
                if (hit.collider && hit.collider.CompareTag("Player"))
                {
                    PlayerWarrior playerWarrior = hit.collider.gameObject.GetComponent<PlayerWarrior>();
                    selectedWarriors.Add(playerWarrior);
                    playerWarrior.Select();
                }
                else if (selectedWarriors != null && timeBetweenClick >= 0.4f)
                {
                    for (int i = 0; i < selectedWarriors.Count; i++)
                    {
                        if (!selectedWarriors[i])
                        {
                            selectedWarriors.Remove(selectedWarriors[i]);
                            continue;
                        }
                        Vector3 mousePosition = hit.point;
                        mousePosition.y = 1;
                        selectedWarriors[i].MoveTo(mousePosition);
                    }
                }
                else if (timeBetweenClick <= 0.3f)
                {
                    SelectVisibleWarriors();
                }
            }
            lastClickTime = Time.time;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            for (int i = 0; i < selectedWarriors.Count - 1; i++)
            {
                selectedWarriors[i].UnSelect();
            }
            selectedWarriors = new List<PlayerWarrior>();
        }
    }

    private void SelectVisibleWarriors()
    {
        for (int i = 0; i < visibleWarriors.Count; i++)
        {
            visibleWarriors[i].Select();
            selectedWarriors.Add(visibleWarriors[i]);
        }
    }
    public void AddVisibleWarrior(PlayerWarrior playerWarrior)
    {
        visibleWarriors.Add(playerWarrior);
    }

    public void RemoveInvisibleWarrior(PlayerWarrior playerWarrior)
    {
        visibleWarriors.Remove(playerWarrior);
    }
}
