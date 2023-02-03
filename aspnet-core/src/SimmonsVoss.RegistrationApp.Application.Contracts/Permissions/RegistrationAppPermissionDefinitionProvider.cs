using SimmonsVoss.RegistrationApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SimmonsVoss.RegistrationApp.Permissions;

public class RegistrationAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(RegistrationAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(RegistrationAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RegistrationAppResource>(name);
    }
}
