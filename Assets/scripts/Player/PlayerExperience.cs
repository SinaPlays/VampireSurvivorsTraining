using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    float CurrentXP = 0;
    float XPToNextLevel = 10;
    [SerializeField] int PlayerLevel = 1;
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
            Debug.Log("Level Up! New Level: " + PlayerLevel);
    }

}
