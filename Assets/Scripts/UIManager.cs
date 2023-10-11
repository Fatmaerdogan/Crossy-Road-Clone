using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject Panel;
    void Start()=> Events.GameFinish += PanelActive;
    private void OnDisable()=>Events.GameFinish -= PanelActive;
    public void PanelActive()=>Panel.SetActive(true);
    public void RestartButtonClick()=>SceneManager.LoadScene(0);


}
