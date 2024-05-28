
using LocalStorageSample.Infrastructure;
using LocalStorageSample.Models;
using Microsoft.AspNetCore.Components;

namespace LocalStorageSample.Layout
{
    public partial class MainLayout
    {
        private User? _user;

        public User? User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
                StateHasChanged();
            }
        }

        [Inject]
        private LocalStorageManager LocalStorageManager { get; set; } = default!;        

        protected override async Task OnInitializedAsync()
        {
            LocalStorageManager.OnLocalStorageChanged += OnLocalStorageChanged;
            User = await LocalStorageManager.Get<User>("User");
        }

        private async Task OnLocalStorageChanged(string key)
        {
            if(key is "User")
            {
                User = await LocalStorageManager.Get<User>("User");
            }
        }

        private async Task Disconnect()
        {
            await LocalStorageManager.Set("User", (User?)null);
        }
    }
}
