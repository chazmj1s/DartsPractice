using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace DartsPractice;

public class App : Application
{
    public App()
    {
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new MainPage());
    }
}
