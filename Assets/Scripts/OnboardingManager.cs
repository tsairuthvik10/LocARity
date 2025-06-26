using UnityEngine;
using UnityEngine.UI;

public class OnboardingManager : MonoBehaviour
{
    public GameObject[] tooltipPanels;
    public GameObject progressDotsParent;
    public Button nextButton, skipButton;
    private int currentStep = 0;

    void Start()
    {
        ShowStep(0);
        nextButton.onClick.AddListener(NextStep);
        skipButton.onClick.AddListener(SkipTutorial);
    }

    void ShowStep(int step)
    {
        for (int i = 0; i < tooltipPanels.Length; i++)
            tooltipPanels[i].SetActive(i == step);

        for (int i = 0; i < progressDotsParent.transform.childCount; i++)
        {
            progressDotsParent.transform.GetChild(i).GetComponent<Image>().color =
                (i == step) ? Color.white : Color.gray;
        }
    }

    void NextStep()
    {
        currentStep++;
        if (currentStep >= tooltipPanels.Length)
            EndTutorial();
        else
            ShowStep(currentStep);
    }

    void SkipTutorial()
    {
        PlayerPrefs.SetInt("TutorialSkipped", 1);
        EndTutorial();
    }

    void EndTutorial()
    {
        foreach (var panel in tooltipPanels)
            panel.SetActive(false);
        gameObject.SetActive(false);
    }
}