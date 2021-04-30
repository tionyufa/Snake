using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(SnakeColor))]
[RequireComponent(typeof(SnakeViewScore))]
public class SnakeHead : MonoBehaviour
{
    [SerializeField] private MenuLosing _menuLosing;
    [SerializeField] private Image _cdFeverImage;
    private Rigidbody _rigidbody;
    private int _totalScore;
    private int _сoin;
    private bool _feverMode;
    
    public UnityAction <int> UpdateScore;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
       
    }

    public void Move(Vector3 movePostion)
    {
        if (!_feverMode)
        {
            _rigidbody.MovePosition(movePostion);
        }
        else
        {
            _rigidbody.MovePosition (Vector3.Lerp(transform.position,
                new Vector3(0, movePostion.y, movePostion.z),Time.fixedTime * 0.5f));
        }
    }

    public void Rotate(float direction)
    {
        if (!_feverMode) //Не смог додуматься как сделать чтобы змея не расплюшивалась об стену
        {
            _rigidbody.MoveRotation(Quaternion.Euler(0f, direction, 0f));
        }
        else
        {
            _rigidbody.MoveRotation(Quaternion.Euler(0f, 0f, 0f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_feverMode)
        {
            if (other.TryGetComponent(out Human human)) //
            {
                if (human.IsEat())
                {
                    _totalScore++;
                    _сoin = 0;
                    UpdateScore?.Invoke(_totalScore);
                    Destroy(human.gameObject);
                }
                else
                {
                    Time.timeScale = 0;
                    if (_totalScore > PlayerPrefs.GetInt("Score"))
                    {
                        PlayerPrefs.SetInt("Score", _totalScore);
                    }

                    _menuLosing.OnLossMenu(_totalScore);

                }
            }

            if (other.gameObject.CompareTag("Trap"))
            {
                Time.timeScale = 0;
                if (_totalScore > PlayerPrefs.GetInt("Score"))
                {
                    PlayerPrefs.SetInt("Score", _totalScore);
                }

                _menuLosing.OnLossMenu(_totalScore);

            }

            if (other.gameObject.CompareTag("Coin"))
            {
                _сoin++;
                _totalScore++;
                UpdateScore?.Invoke(_totalScore);
                Destroy(other.gameObject);

                if (_сoin > 3)
                {
                    StartCoroutine(OnFeverMode());
                }
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Coin") || other.gameObject.CompareTag("Trap") ||
                other.gameObject.CompareTag("Human"))
            {
                _totalScore++;
                UpdateScore?.Invoke(_totalScore);
                Destroy(other.gameObject);
            }
        }

    }

    IEnumerator OnFeverMode()
    {
        _feverMode = true;
        float wait = 5f;
        while (wait > 0)
        {
            wait -= 0.025f;
            _cdFeverImage.fillAmount = wait / 5f;
            yield return new WaitForSeconds(0.025f);
        }
        _feverMode = false;
        _сoin = 0;
    }
}
