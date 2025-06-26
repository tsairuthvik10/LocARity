using UnityEngine;

public class HelpMenuController : MonoBehaviour
{
    public GameObject helpPanel;

    public void ToggleHelp()
    {
        helpPanel.SetActive(!helpPanel.activeSelf);
    }
}