using UnityEngine;
using UnityEngine.UI;

namespace UnityMainMenuStatePattern
{
    // Context class managing state transitions and delegating behavior to current state.
    public class MenuContext : MonoBehaviour
    {
        private MenuState _currentState;

        [Header("UI Panels")]
        public GameObject mainMenuPanel;
        public GameObject settingsPanel;
        public GameObject playPanel;

        private void Start()
        {
            // Initialize with Main Menu state.
            TransitionTo(new MainMenuState());
        }

        public void TransitionTo(MenuState state)
        {
            _currentState = state;
            _currentState.SetContext(this);
            _currentState.EnterState();
        }

        public void OnPlayButtonClicked()
        {
            _currentState.HandlePlay();
        }

        public void OnSettingsButtonClicked()
        {
            _currentState.HandleSettings();
        }

        public void OnBackButtonClicked()
        {
            _currentState.HandleBack();
        }
    }

    // Abstract base state class.
    public abstract class MenuState
    {
        protected MenuContext _context;

        public void SetContext(MenuContext context)
        {
            _context = context;
        }

        public abstract void EnterState();
        public abstract void HandlePlay();
        public abstract void HandleSettings();
        public abstract void HandleBack();
    }

    // Concrete state: Main Menu.
    public class MainMenuState : MenuState
    {
        public override void EnterState()
        {
            Debug.Log("Entering Main Menu State");
            _context.mainMenuPanel.SetActive(true);
            _context.settingsPanel.SetActive(false);
            _context.playPanel.SetActive(false);
        }

        public override void HandlePlay()
        {
            Debug.Log("Main Menu: Play button clicked.");
            _context.TransitionTo(new PlayState());
        }

        public override void HandleSettings()
        {
            Debug.Log("Main Menu: Settings button clicked.");
            _context.TransitionTo(new SettingsState());
        }

        public override void HandleBack()
        {
            Debug.Log("Main Menu: Back button clicked (no action).");
        }
    }

    // Concrete state: Settings.
    public class SettingsState : MenuState
    {
        public override void EnterState()
        {
            Debug.Log("Entering Settings State");
            _context.mainMenuPanel.SetActive(false);
            _context.settingsPanel.SetActive(true);
            _context.playPanel.SetActive(false);
        }

        public override void HandlePlay()
        {
            Debug.Log("Settings: Play button clicked (no action).");
        }

        public override void HandleSettings()
        {
            Debug.Log("Settings: Settings button clicked (no action).");
        }

        public override void HandleBack()
        {
            Debug.Log("Settings: Back button clicked.");
            _context.TransitionTo(new MainMenuState());
        }
    }

    // Concrete state: Play.
    public class PlayState : MenuState
    {
        public override void EnterState()
        {
            Debug.Log("Entering Play State");
            _context.mainMenuPanel.SetActive(false);
            _context.settingsPanel.SetActive(false);
            _context.playPanel.SetActive(true);
        }

        public override void HandlePlay()
        {
            Debug.Log("Play: Play button clicked (no action).");
        }

        public override void HandleSettings()
        {
            Debug.Log("Play: Settings button clicked (no action).");
        }

        public override void HandleBack()
        {
            Debug.Log("Play: Back button clicked.");
            _context.TransitionTo(new MainMenuState());
        }
    }
}
