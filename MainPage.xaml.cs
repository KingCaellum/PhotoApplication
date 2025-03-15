using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Devices;

namespace PhotoApplication
{
    public partial class MainPage : Microsoft.Maui.Controls.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>()
                .SetToolbarPlacement(ToolbarPlacement.Bottom);

            this.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>()
                .SetIsSwipePagingEnabled(false);

            CurrentPageChanged += OnTabChanged;
        }

        private void OnTabChanged(object sender, EventArgs e)
        {
            try
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(50));
            }
            catch (FeatureNotSupportedException)
            {
                Console.WriteLine("Vibration not supported on this device.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error triggering vibration: {ex.Message}");
            }
        }
    }

}
