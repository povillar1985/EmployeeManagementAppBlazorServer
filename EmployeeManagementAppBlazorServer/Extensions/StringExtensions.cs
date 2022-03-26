namespace EmployeeManagementAppBlazorServer.Extensions
{
    public static class StringExtensions
    {
        public static string ToCurrencyFormat(this double val) => val.ToString("C2");
    }
}
