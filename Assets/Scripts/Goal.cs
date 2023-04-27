using MoreMountains.Feedbacks;
using QFSW.QC;
using Sirenix.OdinInspector;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public MMFeedbacks goalFeedback;

    [SerializeField, Required] private float scoreForThisLevel = 5f;
    private PlayerScore playerScore;

    void Start()
    {
        goalFeedback.Initialization();
        playerScore = GameObject.Find("GameManager").GetComponent<PlayerScore>();
    }

    [Button(buttonSize: 2), Command("Goal")]
    private void ActivateGoal()
    {
        // Todo: Change level

        goalFeedback?.PlayFeedbacks();
        playerScore.UpdateScore(scoreForThisLevel);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) &&
    collision.name == "Player")
        {
            ActivateGoal();
        }
        else
        {
            // Do nothing
        }
    }
}
