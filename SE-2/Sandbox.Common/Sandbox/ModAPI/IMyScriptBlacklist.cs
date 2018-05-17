namespace Sandbox.ModAPI
{
    using VRage.Collections;

    public interface IMyScriptBlacklist
    {
        HashSetReader<string> GetBlacklistedIngameEntries();
        DictionaryReader<string, MyWhitelistTarget> GetWhitelist();
        IMyScriptBlacklistBatch OpenIngameBlacklistBatch();
    }
}

