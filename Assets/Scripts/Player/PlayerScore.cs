using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class PlayerScore : MonoBehaviour
{
    // Public
    public TextMeshProUGUI scoreText;
    public Image rankEmpty;
    public Image rankFull;

    // Private
    int buildingScore = 0;
    int kickScore = 0;
    bool enemyHit = false;
    PlayerMovementController movementController;
    PlayerCombatController combatController;
    PlayerSettings playerSettings;
    int maxScore;
    private RankDefinition currentRank;

    int score = 0;
    private int Score
    {
        get { return score; }
        set
        {
            int oldScore = score;
            int newScore = Mathf.Clamp(value, 0, maxScore);
            int delta = newScore - oldScore;
            score = newScore;

            if (delta != 0) { OnScoreChanged(delta); }
        }
    }

    private void Awake()
    {
        movementController = GetComponent<PlayerMovementController>();
        combatController = GetComponent<PlayerCombatController>();
        playerSettings = Resources.Load<PlayerSettings>("ScriptableObjects/PlayerSettings");
        maxScore = playerSettings.playerRanks[playerSettings.playerRanks.Length - 1].exitScore;
    }

    public void CheckBuildingScore()
    {
        // Add the built up scores to total
        if (buildingScore > 0 || kickScore > 0)
        {
            // Check that animation is not being done
            if (!combatController.DoingKickAnimation())
            {
                if (enemyHit) { kickScore += (kickScore / playerSettings.trickValues[Trick.EnemyHit]); }
                Score += buildingScore + kickScore;
                Debug.Log("Score added: " + (buildingScore + kickScore));
            }
            else
            {
                Debug.Log("Lost score: " + (buildingScore + kickScore));
            }

            buildingScore = 0;
            kickScore = 0;
            enemyHit = false;
        }
    }

    public void AddTrick(Trick _trick)
    {
        if (_trick == Trick.EnemyHit) { enemyHit = true; }
        // If score is a kick, add to kick score. Otherwise add to building score
        else if (_trick >= Trick.Kick1 && _trick <= Trick.Kick3) { kickScore += playerSettings.trickValues[_trick]; }
        else { buildingScore += playerSettings.trickValues[_trick]; }

        Debug.Log("Added trick: " + _trick);
    }

    private void OnScoreChanged(int delta)
    {
        if (scoreText) scoreText.text = "Score: " + score;
        UpdateRankSprite();
        movementController.boostingState.Boost += delta * playerSettings.scoreToBoostRatio;
    }

    private void UpdateRankSprite()
    {
        RankDefinition[] ranks = playerSettings.playerRanks;
        for (int i = 0; i < ranks.Length; i++)
        {
            RankDefinition thisRank = ranks[i];
            if (score > thisRank.enterScore && score <= thisRank.exitScore)
            {
                if (thisRank != currentRank)
                {
                    currentRank = thisRank;
                    OnRankChanged();
                }

                int scoreRange = thisRank.exitScore - thisRank.enterScore;
                float fill = (score - thisRank.enterScore) / (float)scoreRange;

                rankFull.fillAmount = fill;
            }
        }
    }

    private void OnRankChanged()
    {
        rankEmpty.sprite = currentRank.emptySprite;
        rankFull.sprite = currentRank.fullSprite;

        movementController.maxSpeed = currentRank.maxSpeed;
        movementController.boostingMaxSpeed = currentRank.boostingMaxSpeed;
    }
}