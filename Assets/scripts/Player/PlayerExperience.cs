using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    float CurrentXP = 0;
    float XPToNextLevel = 10;
    [SerializeField] int PlayerLevel = 1;

    [Header("UI")]
    [SerializeField] Image XPBar;
    [SerializeField] TextMeshProUGUI XPText;


    private void Update()
    {
        XPText.text = CurrentXP.ToString() + " / " + XPToNextLevel.ToString();
        XPBar.fillAmount = CurrentXP / XPToNextLevel;
    }
    public void GainXP(float SomeAmount)
    {
        CurrentXP += SomeAmount;
        if (CurrentXP >= XPToNextLevel)
        {
            LevelUp();
        }

    }
    void LevelUp()
    {
        PlayerLevel++;
        CurrentXP = 0;
        XPToNextLevel *= 1.1f;
        AudioManager.instance.PlaySFX(ESoundFX.PlayerLevelUp);
        GameManager.instance.ChangeState(GameManager.GameState.UpgradeMenu);
    }

}
