using Microsoft.JSInterop;
using System.Text.Json;

namespace LocalStorageSample.Infrastructure
{
    public class LocalStorageManager
    {
        public event Func<string, Task>? OnLocalStorageChanged;

        private readonly IJSRuntime _runtime;

        public LocalStorageManager(IJSRuntime runtime)

        {
            _runtime = runtime;            
        }

        public async ValueTask<T?> Get<T>(string key)
            where T : class
        {            
            try
            {
                string json = await _runtime.InvokeAsync<string>("localStorage.getItem", key);
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Set<T>(string key, T? value)
            where T : class
        {
            await _runtime.InvokeAsync<T>("localStorage.setItem", key, JsonSerializer.Serialize(value));
            Func<string, Task>? onLocalStorageChanged = OnLocalStorageChanged;
            onLocalStorageChanged?.Invoke(key);
        }
    }
}
