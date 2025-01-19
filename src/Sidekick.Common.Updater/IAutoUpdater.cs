namespace Sidekick.Common.Updater;

/// <summary>
/// Provides functionality to check for, download, and apply updates.
/// </summary>
public interface IAutoUpdater
{
    /// <summary>
    /// Enables the automatic update functionality, allowing the application to automatically check for, download, and apply updates.
    /// </summary>
    void EnableAutoUpdates();

    /// <summary>
    /// Checks for available updates, downloads the updates if available, and applies them.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task CheckForUpdates();
}
