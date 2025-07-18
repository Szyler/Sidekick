namespace Sidekick.Common.Settings;

public static class SettingKeys
{
    public const string Version = nameof(Version);

    public const string BearerToken = nameof(BearerToken);
    public const string BearerExpiration = nameof(BearerExpiration);

    public const string OpenHomeOnLaunch = nameof(OpenHomeOnLaunch);
    public const string SilentStart = nameof(SilentStart);
    public const string Zoom = nameof(Zoom);

    // Cloudflare settings
    public const string CloudflareUserAgent = nameof(CloudflareUserAgent);

    public const string LanguageParser = nameof(LanguageParser);
    public const string LanguageUi = nameof(LanguageUi);
    public const string LeagueId = nameof(LeagueId);
    public const string LeaguesHash = nameof(LeaguesHash);

    /// <summary>
    /// Serves the purpose of having the game localized, but wanting to trade in english when there is no trade site in the game language.
    /// </summary>
    public const string UseInvariantTradeResults = nameof(UseInvariantTradeResults);

    public const string KeyClose = nameof(KeyClose);
    public const string KeyFindItems = nameof(KeyFindItems);
    public const string KeyOpenMapCheck = nameof(KeyOpenMapCheck);
    public const string KeyOpenPriceCheck = nameof(KeyOpenPriceCheck);
    public const string KeyOpenWealth = nameof(KeyOpenWealth);
    public const string KeyOpenWiki = nameof(KeyOpenWiki);
    public const string KeyOpenInCraftOfExile = nameof(KeyOpenInCraftOfExile);

    public const string MouseWheelNavigateStash = nameof(MouseWheelNavigateStash);
    public const string MouseWheelNavigateStashReverse = nameof(MouseWheelNavigateStashReverse);

    public const string EscapeClosesOverlays = nameof(EscapeClosesOverlays);
    public const string RetainClipboard = nameof(RetainClipboard);
    public const string ChatCommands = nameof(ChatCommands);
    public const string PreferredWiki = nameof(PreferredWiki);
    public const string PoeNinjaLastClear = nameof(PoeNinjaLastClear);
    public const string Poe2ScoutLastClear = nameof(Poe2ScoutLastClear);
    public const string RegexHotkeys = nameof(RegexHotkeys);

    public const string MapCheckDangerousRegex = nameof(MapCheckDangerousRegex);

    public const string OverlayCloseWithMouse = nameof(OverlayCloseWithMouse);

    public const string PriceCheckPredictionEnabled = nameof(PriceCheckPredictionEnabled);
    public const string PriceCheckMarketEnabled = nameof(PriceCheckMarketEnabled);
    public const string PriceCheckItemListedAge = nameof(PriceCheckItemListedAge);
    public const string PriceCheckCurrency = nameof(PriceCheckCurrency);
    public const string PriceCheckCurrencyPoE2 = nameof(PriceCheckCurrencyPoE2);
    public const string PriceCheckItemCurrencyMin = nameof(PriceCheckItemCurrencyMin);
    public const string PriceCheckItemCurrencyMinPoE2 = nameof(PriceCheckItemCurrencyMinPoE2);
    public const string PriceCheckItemCurrencyMax = nameof(PriceCheckItemCurrencyMax);
    public const string PriceCheckItemCurrencyMaxPoE2 = nameof(PriceCheckItemCurrencyMaxPoE2);
    public const string PriceCheckBulkMinimumStock = nameof(PriceCheckBulkMinimumStock);
    public const string PriceCheckCurrencyMode = nameof(PriceCheckCurrencyMode);
    public const string PriceCheckNormalizeValue = nameof(PriceCheckNormalizeValue);
    public const string PriceCheckCompactMode = nameof(PriceCheckCompactMode);
    public const string PriceCheckSidebarWidth = nameof(PriceCheckSidebarWidth);
    public const string PriceCheckStatus = nameof(PriceCheckStatus);
    public const string PriceCheckItemClassFilter = nameof(PriceCheckItemClassFilter);
    public const string PriceCheckAutomaticallySearch = nameof(PriceCheckAutomaticallySearch);
    public const string PriceCheckAutomaticallySearchCurrency = nameof(PriceCheckAutomaticallySearchCurrency);
    public const string PriceCheckEnableAllFilters = nameof(PriceCheckEnableAllFilters);
    public const string PriceCheckEnableFiltersByRegex = nameof(PriceCheckEnableFiltersByRegex);
    public const string PriceCheckDefaultFilterType = nameof(PriceCheckDefaultFilterType);
    public const string PriceCheckAutomaticallyLoadMoreData = nameof(PriceCheckAutomaticallyLoadMoreData);

    public const string SaveWindowPositions = nameof(SaveWindowPositions);

    public const string WealthEnabled = nameof(WealthEnabled);
    public const string WealthTrackedTabs = nameof(WealthTrackedTabs);
    public const string WealthItemTotalMinimum = nameof(WealthItemTotalMinimum);
}
