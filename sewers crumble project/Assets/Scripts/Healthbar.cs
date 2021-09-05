using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class Healthbar : MonoBehaviour
{
    public GameObject Ui;
    public GameObject GameOverPanel;

    public Image currentHealthbar;
    public Image currentShieldbar;

    public TextMeshProUGUI ratioText;
    public TextMeshProUGUI shieldText;

    private float hitpoint;
    private float shieldpoint;
    private float maxHitpoint = 150;

    public Sprite h1;
    public Sprite h2;
    public Sprite h3;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;

    public GameObject heartImages;
    public GameObject shieldImages;

    public TextMeshProUGUI saveStateInfo;
    public TextMeshProUGUI waterInfo;

    private void Start ()
    {
        hitpoint = (int) GameManager.Instance.hitPoints;
        shieldpoint = (int) GameManager.Instance.shieldPoints;
        UpdateHealthbar();
        UpdateShieldbar();
        UpdateCurrencyBar();
    }

    private void UpdateHealthbar ()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + "%";

        GameManager.Instance.hitPoints = (int) hitpoint;

        if (ratio*100 >= 66)
        {
            heartImages.GetComponent<Image>().sprite = h1;
        }
        else if (ratio*100 >= 33)
        {
            heartImages.GetComponent<Image>().sprite = h2;
        }
        else
        {
            heartImages.GetComponent<Image>().sprite = h3;
        }
        
    }

    private void UpdateShieldbar()
    {
        float ratio = shieldpoint / maxHitpoint;
        currentShieldbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        shieldText.text = (ratio * 100).ToString("0") + "%";

        GameManager.Instance.shieldPoints = (int) shieldpoint;

        if (ratio * 100 >= 66)
        {
            shieldImages.GetComponent<Image>().sprite = s1;
        }
        else if (ratio * 100 >= 33)
        {
            shieldImages.GetComponent<Image>().sprite = s2;
        }
        else
        {
            shieldImages.GetComponent<Image>().sprite = s3;
        }
    }

    private void TakeDamage(float damage)
    {
        
        hitpoint -= damage;
        
        if (hitpoint < 0)
        {
            hitpoint = 0;

            Ui.SetActive(false);
            GameOverPanel.SetActive(true);
            FindObjectOfType<GameManager>().EndGame();
        }

        UpdateHealthbar();
    }

    private void HealDamage (float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }

        UpdateHealthbar();
    }

    public void TakeShieldDamage(float damage)
    {
        if (shieldpoint > 0)
        {
            shieldpoint -= damage;
        }

        else if (shieldpoint <= 0)
        {
            hitpoint -= damage;
            TakeDamage(damage);
            shieldpoint = 0;
            
        }
        UpdateHealthbar();
        UpdateShieldbar();
    }

    private void HealShieldDamage(float heal)
    {
        shieldpoint += heal;
        if (shieldpoint > maxHitpoint)
        {
            shieldpoint = maxHitpoint;
        }

        UpdateShieldbar();
    }

    private void AddKey()
    {
        GameManager.Instance.currentSaveState++;
        UpdateCurrencyBar();
    }

    private void AddCoin()
    {
        GameManager.Instance.currency++;
        UpdateCurrencyBar();
    }

    private void UpdateCurrencyBar()
    {
        saveStateInfo.text = GameManager.Instance.currentSaveState.ToString();
        waterInfo.text = GameManager.Instance.currency.ToString();
    }

    void DoNothing()
    {
        return;
    }

}
