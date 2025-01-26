using System;
using System.Linq;
using Il2CppTMPro;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace BlackScreenFix
{
    public class Main : MelonMod
    {
        public static Main Instance { get; private set; }
        public bool ToolsAreInstalled { get; private set; }
        public string WarningText => Application.systemLanguage == SystemLanguage.Russian
            ? $"Для работы BlackScreenFix необходимо установить мод {nameof(ClimeronToolsForPvZ)}!\nТребуемую версию можно найти в релизах."
            : $"To use BlackScreenFix, you need to install the mod {nameof(ClimeronToolsForPvZ)}!\nThe required version can be found in the releases.";
        public string URLButtonText => Application.systemLanguage == SystemLanguage.Russian
            ? "Открыть страницу с релизами"
            : "Open the releases page";

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
            Instance = this;
            CheckForInstalledTools();
        }
        private void CheckForInstalledTools() =>
            ToolsAreInstalled = RegisteredMelons.Any(mod => mod.Info.Name == nameof(ClimeronToolsForPvZ));
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (!ToolsAreInstalled)
            {
                CreateWarningMessage();
                CreateURLButton();
            }
        }
        private void CreateWarningMessage()
        {
            Canvas messageCanvas = new GameObject("WarningMessage").AddComponent<Canvas>();
            RectTransform messageRectTransform = messageCanvas.GetComponent<RectTransform>();
            messageRectTransform.localScale = new(0.01f, 0.01f, 1);
            messageRectTransform.anchoredPosition = new(0, 1);
            TextMeshProUGUI textComponent = messageRectTransform.gameObject.AddComponent<TextMeshProUGUI>();
            textComponent.color = Color.red;
            textComponent.text = WarningText;
            textComponent.enableWordWrapping = false;
            textComponent.alignment = TextAlignmentOptions.Center;
        }
        private void CreateURLButton()
        {
            Canvas canvas = new GameObject("URLButton").AddComponent<Canvas>();
            canvas.worldCamera = Camera.main;
            canvas.gameObject.AddComponent<GraphicRaycaster>();
            Button button = canvas.gameObject.AddComponent<Button>();
            Image image = button.gameObject.AddComponent<Image>();
            image.color = Color.gray;
            RectTransform buttonRectTransform = button.GetComponent<RectTransform>();
            buttonRectTransform.localScale = new(0.01f, 0.01f, 1);
            buttonRectTransform.sizeDelta = new(700, 100);
            buttonRectTransform.anchoredPosition = new(0, -1);
            button.onClick.AddListener(OpenURL());
            TextMeshProUGUI textComponent = new GameObject("URLButtonText").AddComponent<TextMeshProUGUI>();
            textComponent.transform.SetParent(buttonRectTransform);
            textComponent.enableWordWrapping = false;
            textComponent.text = URLButtonText;
            textComponent.alignment = TextAlignmentOptions.Center;
            RectTransform textRectTransform = textComponent.GetComponent<RectTransform>();
            textRectTransform.localScale = Vector3.one;
            textRectTransform.anchorMin = Vector2.zero;
            textRectTransform.anchorMax = Vector2.one;
            textRectTransform.anchoredPosition = Vector2.zero;
        }
        private Action OpenURL() => delegate { Application.OpenURL("https://github.com/Climeron/PvZ-Fusion-BlackScreenFix/releases"); };
    }
}
