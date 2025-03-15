using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Graphics;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;

namespace PhotoApplication;

[Activity(Theme = "@style/Maui.SplashTheme",
             MainLauncher = true,
             LaunchMode = LaunchMode.SingleTop,
             ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        MakeAppFullscreen();

        Microsoft.Maui.Handlers.SearchBarHandler.Mapper.AppendToMapping("CustomIconColor", (handler, view) =>
        {
            if (handler.PlatformView is AndroidX.AppCompat.Widget.SearchView searchView)
            {
                int searchIconId = searchView.Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
                if (searchIconId != 0)
                {
                    var searchIcon = searchView.FindViewById<Android.Widget.ImageView>(searchIconId);
                    searchIcon?.SetColorFilter(Android.Graphics.Color.Rgb(96, 96, 96));
                }
            }
        });
    }

    private void MakeAppFullscreen()
    {
        if (Window != null)
        {
            Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                SystemUiFlags.HideNavigation |
                SystemUiFlags.ImmersiveSticky |
                SystemUiFlags.Fullscreen);
        }
    }
}
