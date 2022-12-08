using System.Threading.Tasks;
using Bryan.BookStore.Localization;
using Bryan.BookStore.MultiTenancy;
using Bryan.BookStore.Permissions;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace Bryan.BookStore.Blazor.Menus;

public class BookStoreMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<BookStoreResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                BookStoreMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.AddItem(
                new ApplicationMenuItem(
                    "BooksStore",
                    l["Menu:BookStore"],
                    icon: "fa fa-book",
                    order: 1
                    ).AddItem(
                        new ApplicationMenuItem(
                            "BooksStore.Books",
                            l["Menu:Books"],
                            url: "/books"
                            )
                        )
                   );

 
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Palindrome",
                l["Menu:Palindrome"],
                icon: "fa fa-stream",
                url: "/palindrome",
                order: 2
                ));

        if (await context.IsGrantedAsync(BookStorePermissions.Authors.Default))
        {
            context.Menu.Items
                .Find(x => x.Name == "BooksStore")
                .AddItem(new ApplicationMenuItem(
                "BooksStore.Authors",
                l["Menu:Authors"],
                url: "/authors"
            ));
        }

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        //return Task.CompletedTask;
    }
}
