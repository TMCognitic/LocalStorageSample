using LocalStorageSample.Infrastructure;
using LocalStorageSample.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace LocalStorageSample.Pages
{
    public partial class Home
    {
        private LoginForm? LoginForm { get; set; }

        [Inject]
        private LocalStorageManager LocalStorageManager { get; set; } = default!;

        protected override void OnInitialized()
        {
            LoginForm = new LoginForm();
        }

        private async void OnClick(EditContext context)
        {
            await LocalStorageManager.Set("User", new User(LoginForm.Nom!, LoginForm.Email!));
        }
    }
}
