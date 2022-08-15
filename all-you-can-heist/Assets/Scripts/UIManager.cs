using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    Image m_OverlayPanel;
    [SerializeField]
    Text m_GoldText;

    [SerializeField]
    Text m_keysText;

    [SerializeField]
    Text m_TimeText;
    [SerializeField]
    Text m_LoseTitle;
    [SerializeField]
    Text m_WinTitle;
    [SerializeField]
    Text m_ScoreTitle;
    [SerializeField]
    Text m_Score;

    [SerializeField]
    GameObject m_ContextInfo;

    [SerializeField]
    PlayerData playerData;

    [SerializeField]
    Transform CollectData;


    private void Awake()
    {
        Instance = this;
    }

    public void Gold(int gold)
    {
        ModifyText(m_GoldText, playerData.Gold.ToString());
        PopUpMessage("Encontrado " +  gold +  " oro!");
    }

    public void UseKey()
    {
        ModifyText(m_keysText, playerData.Keys.ToString());
        PopUpMessage("Has USADO una LLAVE!");
    }

    public void GrabKey()
    {
        ModifyText(m_keysText, playerData.Keys.ToString());
        PopUpMessage("Has ENCONTRADO una LLAVE!");
    }

    public void RequireKey()
    {
        PopUpMessage("Necesitas una llave!");
    }

    public void WinGame()
    {
        ActiveEndGame(true);
    }

    public void LoseGame()
    {
        ActiveEndGame(false);
    }

    private void ActiveEndGame(bool win)
    {
        Time.timeScale = 0;
        m_OverlayPanel.gameObject.SetActive(true);
        m_LoseTitle.gameObject.SetActive(!win);
        m_WinTitle.gameObject.SetActive(win);
        m_ScoreTitle.gameObject.SetActive(win);
        m_Score.gameObject.SetActive(win);
        ModifyText(m_Score, playerData.Gold.ToString());

    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    private void ModifyText(Text text, string info)
    {
        text.text = info;
    }

    private void PopUpMessage(string message)
    {
        
        GameObject info = Instantiate(m_ContextInfo);
        info.GetComponent<ContextInfo>().SetText(message);
        info.gameObject.SetActive(true);
        info.gameObject.transform.SetParent(CollectData);
    }
}
