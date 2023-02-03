using Volo.Abp.Settings;

namespace SimmonsVoss.RegistrationApp.Settings;

public class RegistrationAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(RegistrationAppSettings.MySetting1));
    }
}
