using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirsPanel : MonoBehaviour
{
    public GameObject firstPanel;
    public GameObject secondPanel;
    public GameObject UIManager;
    private UIControl uiControl;
    // Start is called before the first frame update
    private void OnEnable()
    {
        uiControl = UIManager.GetComponent<UIControl>();
        StartCoroutine(FirstPanelDelay());
    }

    IEnumerator FirstPanelDelay()
    {
        yield return new WaitForSeconds(2);
        firstPanel.SetActive(false);
        uiControl.NowPanel = secondPanel;
        secondPanel.SetActive(true);
    }
}
