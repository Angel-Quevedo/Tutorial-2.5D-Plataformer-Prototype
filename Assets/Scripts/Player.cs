using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 1f;
    [SerializeField] float _gravity = 1f;
    [SerializeField] float _jumpHeight = 15f;
    [SerializeField] int _lives = 3;

    UIManager _uiManager;
    CharacterController _characterController;
    int _coins;
    float _yVelocity;
    bool _canDobleJump;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _uiManager = FindObjectOfType<UIManager>();

        _uiManager.UpdateCoinText(_coins);
        _uiManager.UpdateLivesText(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        //Application.targetFrameRate = 240;

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _movementSpeed;

        if (_characterController.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _canDobleJump = true;
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            if (_canDobleJump && Input.GetKeyDown(KeyCode.Space))
            {
                _canDobleJump = false;
                _yVelocity += _jumpHeight;
            }

            _yVelocity -= _gravity * Time.deltaTime;
        }

        velocity.y = _yVelocity;

        _characterController.Move(velocity * Time.deltaTime);

    }

    public void AddCoins(int amount)
    {
        _coins += amount;
        _uiManager.UpdateCoinText(_coins);
    }

    public void LoseLives(int amount)
    {
        _lives -= amount;
        if (_lives <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        _uiManager.UpdateLivesText(_lives);
    }
}
