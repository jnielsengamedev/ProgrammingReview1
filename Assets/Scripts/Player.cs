using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int lives;
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI playerLivesDisplay;
    [SerializeField] private TextMeshProUGUI playerScoreDisplay;

    private float _verticalInput;
    private float _horizontalInput;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        playerLivesDisplay.text = $"Lives: {lives}";
        playerScoreDisplay.text = $"Score: {score}";

        transform.Translate(Vector3.up * (moveSpeed * _verticalInput * Time.deltaTime));
        transform.Translate(Vector3.right * (moveSpeed * _horizontalInput * Time.deltaTime));
    }
}
