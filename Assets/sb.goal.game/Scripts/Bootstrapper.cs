using UnityEngine;

public static class Bootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Execute()
    {
        UIManager.OpenWindow(Window.Loading);
    }
}
