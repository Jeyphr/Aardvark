using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class ps_UIHandler : MonoBehaviour
{
    //Vars
    private float _visMaxHealth     = 100f;
    private float _visHealth        = 100f;

    private int _visMaxAmmo = 0;
    private int _visAmmo = 0;

    private int _visPoints = 0;
    private int _visRound = 0;

    [Space]
    [Header("Object References")]
    [SerializeField] Image bar_Health, bar_Ammo;
    [SerializeField] TMPro.TMP_Text hText, aText, rText, pText;
    [SerializeField] Material mat_normal;
    [SerializeField] Material mat_critical;

    

    public void Awake()
    {
        {
            updateUI();
        }
    }
    public void updateUI()
    {
        updateHealth();
        updateAmmo();
        updateRounds();
        updatePointss();
        updatePerks();
    }

    #region UPDATING STATEMENTS
    private void updateHealth()
    {
        setHealth(bar_Health, _visHealth);
        if (_visHealth < (_visMaxHealth / 3))
        {
            bar_Health.material = mat_critical;
            hText.color = mat_critical.color;
            hText.fontSize = 20;
            hText.alpha = 1f;
        }
        else
        {
            bar_Health.material = mat_normal;
            hText.color = mat_normal.color;
            hText.fontSize = 10;
            hText.alpha = 0.5f;
        }
    }
    private void updateAmmo()
    {
        setAmmo(bar_Ammo, _visAmmo);
    }
    private void updateRounds()
    {
        setRound(_visRound);
    }
    private void updatePointss()
    {
        setPoints(_visPoints);
    }
    private void updatePerks()
    {
        Debug.Log("Updating Perks!");
    }
    #endregion
    #region STAT SETTERS
    private void setHealth(Image bar, float val)
    {
        _visHealth = val;
        bar.fillAmount = _visHealth / 100;
        hText.text = _visHealth.ToString();
    }
    private void setAmmo(Image bar, int val)
    {
        _visAmmo = val;
        bar.fillAmount = _visAmmo / 100;
        aText.text = _visAmmo.ToString();
    }
    private void setRound(int val)
    {
        _visRound = val;
        rText.text = "Round: " + _visRound.ToString();
    }
    private void setPoints(int val)
    {
        _visPoints = val;
        pText.text = "$" + _visPoints.ToString();
    }
    #endregion
    #region SETTERS AND GETTERS
    public float VisMaxHealth { get => _visMaxHealth; set => _visMaxHealth = value; }
    public float VisHealth { get => _visHealth; set => _visHealth = value; }
    public int VisMaxAmmo { get => _visMaxAmmo; set => _visMaxAmmo = value; }
    public int VisAmmo { get => _visAmmo; set => _visAmmo = value; }
    public int VisPoints { get => _visPoints; set => _visPoints = value; }
    public int VisRound { get => _visRound; set => _visRound = value; }

    #endregion
}
