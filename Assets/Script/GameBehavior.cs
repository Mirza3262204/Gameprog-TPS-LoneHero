using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    private int _itemsCollected = 0;
    private int _playerHP = 10;
    public int MaxItems = 4;

    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;
    public Button WinButton;
    public Button LossButton;

    void Start()
    {
        ItemText.text = "Items: " + _itemsCollected;
        HealthText.text = "Health: " + _playerHP;

        if (WinButton != null)
            WinButton.gameObject.SetActive(false);

        if (LossButton != null) LossButton.gameObject.SetActive(false);
    }

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            ItemText.text = "Items: " + _itemsCollected;

            if (_itemsCollected >= MaxItems)
            {
                ProgressText.text = "You've found all the items!";
                if (WinButton != null)
                    WinButton.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                int remaining = MaxItems - _itemsCollected;
                ProgressText.text = "Item found, only " + remaining + " more to go!";
            }
        }
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Health: "  + _playerHP;
            Debug.LogFormat("Lives: {0}", _playerHP);

            if (_playerHP <= 0)
            {
                UpdateScene("You want another life with that?");
                if (LossButton != null) LossButton.gameObject.SetActive(true);
            }
            else
            {
                ProgressText.text = "Ouch... that's got hurt";
            }
        }
    }

    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0f;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}