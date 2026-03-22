using System.Reflection;
using UnityEngine.UIElements;

namespace ToasterTallerChat;

public static class TallerChat
{
    static readonly FieldInfo _chatField = typeof(UIChat)
        .GetField("chat",
            BindingFlags.Instance | BindingFlags.NonPublic);

    static readonly FieldInfo _scrollViewField = typeof(UIChat)
        .GetField("scrollView",
            BindingFlags.Instance | BindingFlags.NonPublic);

    public static void Start()
    {
        UIChat uiChat = MonoBehaviourSingleton<UIManager>.Instance.Chat;

        VisualElement chat = _chatField.GetValue(uiChat) as VisualElement;
        ScrollView scrollView = _scrollViewField.GetValue(uiChat) as ScrollView;

        scrollView.style.minHeight = new StyleLength(Plugin.modSettings.ChatHeight);
        chat.style.minHeight = new StyleLength(Plugin.modSettings.ChatHeight);
        chat.style.left = 0;
        chat.style.top = 0;
    }

    public static void Destroy()
    {
        Plugin.Log($"TallerChat cannot disable properly yet! Please restart your game after disabling.");
    }
}
