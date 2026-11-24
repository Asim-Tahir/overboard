using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkateboardSelectionManager : MonoBehaviour
{
    [SerializeField] private List<Skateboard> _skateboards;
    [SerializeField] private Transform _previewSpawnPoint;
    [SerializeField] private float _rotationSpeed = 25f;

    [SerializeField] private TextMeshProUGUI _nameText;

    [SerializeField] private Slider _speedSlider;
    [SerializeField] private Slider _handlingSlider;

    [SerializeField] private Button _prevButton;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _startButton;
    [SerializeField] private string _gameSceneName = "GameScene";
    [SerializeField] private InputActionReference _navigateAction;
    [SerializeField] private InputActionReference _submitAction;

    private int _currentIndex = 0;

    private GameObject _currentPreviewInstance;

    public static Skateboard SelectedSkateboard { get; private set; }

    private void OnEnable()
    {
        if (_nextButton != null)
        {
            _nextButton.onClick.AddListener(NextSkateboard);
        }

        if (_prevButton != null)
        {
            _prevButton.onClick.AddListener(PrevSkateboard);
        }

        if (_startButton != null)
        {
            _startButton.onClick.AddListener(StartGame);
        }

        if (_navigateAction != null)
        {
            _navigateAction.action.Enable();
            _navigateAction.action.performed += OnNavigatePerformed;
        }

        if (_submitAction != null)
        {
            _submitAction.action.Enable();
            _submitAction.action.performed += OnSubmitPerformed;
        }
    }


    private void OnDisable()
    {
        if (_nextButton != null)
        {
            _nextButton.onClick.RemoveListener(NextSkateboard);
        }

        if (_prevButton != null)
        {
            _prevButton.onClick.RemoveListener(PrevSkateboard);
        }

        if (_startButton != null)
        {
            _startButton.onClick.RemoveListener(StartGame);
        }

        if (_navigateAction != null)
        {
            _navigateAction.action.performed -= OnNavigatePerformed;
            _navigateAction.action.Disable();
        }

        if (_submitAction != null)
        {
            _submitAction.action.performed -= OnSubmitPerformed;
            _submitAction.action.Disable();
        }
    }


    private void Start()
    {
        if (_skateboards == null || _skateboards.Count == 0)
        {
            Debug.LogError("Kaykay listesi boş.");
            return;
        }

        _currentIndex = PlayerPrefs.GetInt("SelectedSkateboardIndex", 0);

        if (_currentIndex >= _skateboards.Count)
        {
            _currentIndex = 0;
        }

        UpdateSkateboardDisplay();
    }

    private void Update()
    {
        if (_currentPreviewInstance != null)
        {
            _currentPreviewInstance.transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
    }

    private void OnNavigatePerformed(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (input.x > 0.5f) NextSkateboard();
        else if (input.x < -0.5f) PrevSkateboard();
    }

    private void OnSubmitPerformed(InputAction.CallbackContext context)
    {
        StartGame();
    }

    public void NextSkateboard()
    {
        _currentIndex = (_currentIndex + 1) % _skateboards.Count;

        UpdateSkateboardDisplay();
    }

    public void PrevSkateboard()
    {
        _currentIndex--;

        if (_currentIndex < 0)
        {
            _currentIndex = _skateboards.Count - 1;
        }

        UpdateSkateboardDisplay();
    }

    private void UpdateSkateboardDisplay()
    {
        var currentSkateboard = _skateboards[_currentIndex];
        SelectedSkateboard = currentSkateboard;

        _nameText.text = currentSkateboard.Name;
        _speedSlider.value = currentSkateboard.Speed / 100f;
        _handlingSlider.value = currentSkateboard.Handling / 100f;

        if (_currentPreviewInstance != null)
        {
            Destroy(_currentPreviewInstance);
        }

        if (currentSkateboard.PreviewPrefab != null)
        {
            _currentPreviewInstance = Instantiate(
                currentSkateboard.PreviewPrefab,
                _previewSpawnPoint.position,
                _previewSpawnPoint.rotation
            );
            _currentPreviewInstance.transform.localScale = new Vector3(6, 6, 6);
        }
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedSkateboardIndex", _currentIndex);
        PlayerPrefs.Save();

        SceneManager.LoadScene(_gameSceneName);
    }
}
