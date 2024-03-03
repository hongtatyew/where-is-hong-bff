using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;

namespace WhereIsHong.WishClient;

public class JournalRepository(HttpClient _httpClient, IMemoryCache _memoryCache) : IJournalRepository
{
    public async Task<List<JournalEntry>> GetEntriesAsync(Guid journalId, CancellationToken cancellationToken = default)
    {
        var getJournalBriefEntriesResponse = await _httpClient
            .GetFromJsonAsync<List<GetJournalEntriesResponse>>($"journals/{journalId:N}/entries", cancellationToken)
            .ConfigureAwait(false) ?? [];

        var journalEntries = new List<JournalEntry>();
        foreach (var briefEntry in getJournalBriefEntriesResponse)
        {
            if (_memoryCache.TryGetValue<JournalEntry>(briefEntry.Id, out var cachedEntry))
            {
                if (cachedEntry is not null) journalEntries.Add(cachedEntry);
                continue;
            }

            var detailEntry = await _httpClient
                .GetFromJsonAsync<JournalEntry>($"journals/{journalId:N}/entries/{briefEntry.Id}", cancellationToken)
                .ConfigureAwait(false);

            if (detailEntry is not null)
            {
                if (detailEntry.Created < DateTime.Now.AddDays(-2))
                {
                    var memoryCacheOptions = new MemoryCacheEntryOptions();
                    memoryCacheOptions.SetPriority(CacheItemPriority.NeverRemove);
                    _memoryCache.Set(briefEntry.Id, detailEntry, memoryCacheOptions);
                }

                journalEntries.Add(detailEntry);
            }
        }

        return [.. journalEntries.OrderByDescending(x => x.Created)];
    }
}
