using System.Reflection;
using UnityEngine.UIElements;

namespace ToasterTallerChat;

public static class TallerChat
{
    private static UIChat chat;

    static readonly FieldInfo _containerField = typeof(UIChat)
        .GetField("container", 
            BindingFlags.Instance | BindingFlags.NonPublic);
    
    static readonly FieldInfo _chatScrollViewField = typeof(UIChat)
        .GetField("chatScrollView", 
            BindingFlags.Instance | BindingFlags.NonPublic);
    
    public static void Start()
    {
        ScrollView chatScrollView = _chatScrollViewField.GetValue(UIChat.Instance) as ScrollView;
        VisualElement container = _containerField.GetValue(UIChat.Instance) as VisualElement;
        
        chatScrollView.style.minHeight = new StyleLength(Plugin.modSettings.ChatHeight);
        container.style.minHeight = new StyleLength(Plugin.modSettings.ChatHeight);
        container.style.left = 0;
        container.style.top = 0;
    }

    public static void Destroy()
    {
        Plugin.Log($"TallerChat cannot disable properly yet! Please restart your game after disabling.");
    }
}
