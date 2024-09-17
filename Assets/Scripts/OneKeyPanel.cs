using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneKeyPanel : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject thisPanel;
    public GameObject UIManager;
    private UIControl uiControl;
    private void OnEnable()
    {
        uiControl = UIManager.GetComponent<UIControl>();
        StartCoroutine(PanelDelay());
    }

    IEnumerator PanelDelay()
    {
        yield return new WaitForSeconds(5);
        thisPanel.SetActive(false);
        uiControl.NowPanel = thisPanel;
        mainPanel.SetActive(true);
    }
}
