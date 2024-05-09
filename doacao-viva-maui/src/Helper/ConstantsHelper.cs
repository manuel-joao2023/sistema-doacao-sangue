namespace SalveVidaDoandoApp.Helper;

public class ConstantsHelper
{
    public static string BaseAddress => (DeviceInfo.Platform == DevicePlatform.Android)
        ? "https://10.0.2.2:7098/api" : "https://localhost:7098/api";

}
