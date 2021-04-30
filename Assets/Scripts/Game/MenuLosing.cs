using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuLosing : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _leaveButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(Restart);
        _leaveButton.onClick.AddListener(Leave);
    }

    public void OnLossMenu(int score)
    {
        _panel.SetActive(true);
        _text.text = String.Format("Вы проиграли! \nВаш счет - {0} \nВаш лучший счет - {1}" +
                                   "\nХотите попробовать снова",score,PlayerPrefs.GetInt("Score"));
       
    }

    private void Restart()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
    }

    private void Leave()
    {
        Application.Quit();
    }
}
