using Microsoft.JSInterop;
using System.Text.Json;

namespace EventEase.Services;

public class SessionStorageService
{
    private readonly IJSRuntime _jsRuntime;

    public SessionStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task SaveItemAsync<T>(string key, T item)
    {
        var json = JsonSerializer.Serialize(item);
        await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", key, json);
    }

    public async Task<T?> GetItemAsync<T>(string key)
    {
        var json = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", key);
        return json == null ? default : JsonSerializer.Deserialize<T>(json);
    }

    public async Task RemoveItemAsync(string key)
    {
        await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", key);

    }
}