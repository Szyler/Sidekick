using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Microsoft.Extensions.Logging;
using Microsoft.Web.WebView2.Core;
using Sidekick.Apis.Poe.Clients;
using Sidekick.Apis.Poe.CloudFlare;
using Sidekick.Wpf.Helpers;
using Application=System.Windows.Application;

namespace Sidekick.Wpf;

public partial class CloudflareWindow
{
    private readonly ILogger logger;
    private readonly ICloudflareService cloudflareService;
    private readonly Uri uri;
    private bool challengeCompleted;

    public CloudflareWindow(ILogger logger, ICloudflareService cloudflareService, Uri uri)
    {
        this.logger = logger;
        this.cloudflareService = cloudflareService;
        this.uri = uri;
        InitializeComponent();
        Ready();
    }

    public void Ready()
    {
        _ = Application.Current.Dispatcher.Invoke(async () =>
        {
            Topmost = true;
            ShowInTaskbar = true;
            ResizeMode = ResizeMode.NoResize;

            await WebView.EnsureCoreWebView2Async();
            WebView.CoreWebView2.Settings.UserAgent = PoeTradeHandler.UserAgent;

            // Handle cookie changes by checking cookies after navigation
            WebView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;

            WebView.Source = uri;

            // This avoids the white flicker which is caused by the page content not being loaded initially. We show the webview control only when the content is ready.
            WebView.Visibility = Visibility.Visible;

            // The window background is transparent to avoid any flickering when opening a window. When the webview content is ready we need to set a background color. Otherwise, mouse clicks will go through the window.
            Background = (Brush?)new BrushConverter().ConvertFrom("#000000");
            Opacity = 0.01;

            CenterHelper.Center(this);
            Activate();
        });
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        if (!challengeCompleted)
        {
            logger.LogInformation("[CloudflareWindow] Closing the window without completing the challenge, marking as failed");
            _ = cloudflareService.CaptchaChallengeFailed();
        }

        base.OnClosing(e);
    }

    private async void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
    {
        var cookies = await GetCookies();
        if (cookies == null)
        {
            return;
        }

        logger.LogInformation("[CloudflareWindow] Cookie check completed, challenge likely completed");
        // Store the Cloudflare cookie
        _ = cloudflareService.CaptchaChallengeCompleted(cookies);
        challengeCompleted = true;

        Dispatcher.Invoke(Close);
    }

    private async Task<Dictionary<string, string>?> GetCookies()
    {
        try
        {
            var cookies = await WebView.CoreWebView2.CookieManager.GetCookiesAsync(uri.GetLeftPart(UriPartial.Authority));
            var cfCookie = cookies.FirstOrDefault(c => c.Name == "cf_clearance");
            if (cfCookie != null)
            {
                return cookies.ToDictionary(c => c.Name, c => c.Value);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "[CloudflareWindow] Error handling cookie check");
        }

        return null;
    }

    private async Task<string?> GetContents()
    {
        try
        {
            // Inject and execute JavaScript to get the raw content of the page
            var script = @"
            (function() {
                return document.documentElement.innerText; // Returns the raw content of the page
            })();";

            // Execute the script and get the response as a string
            var rawContent = await WebView.CoreWebView2.ExecuteScriptAsync(script);

            if (!string.IsNullOrEmpty(rawContent))
            {
                // Clean up the response (escaping and unescaping)
                rawContent = rawContent.Trim('"').Replace("\\n", "\n").Replace("\\\"", "\"").Replace("\\t", "\t");

                // Log or process the content (assuming it's JSON or text-based)
                logger.LogInformation("[CloudflareWindow] Retrieved API response: {rawContent}", rawContent.Substring(0, 10000));

                // If it's JSON you can parse it
                // var jsonObject = JsonSerializer.Deserialize<YourType>(rawContent);
            }
            else
            {
                logger.LogWarning("[CloudflareWindow] No content available from the WebView.");
            }

            // Handle content or move to the next step
            // Example: signal success or close window
            challengeCompleted = true;
            Dispatcher.Invoke(Close);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "[CloudflareWindow] Error while retrieving content of the WebView.");
        }

        return null;
    }
}
