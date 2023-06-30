using Domain.Interfaces;

namespace ConsoleClient.Domain.Builder
{
    public class ProductDirector
    {
        public static void MakeProductToSave(IBuilder builder)
        {
            builder.SetRepository();
            builder.SetApiService();
        }

        public static void MakeProductToGetDateNow(IBuilder builder)
        {
            builder.SetDateTimeProvider();
        }
    }
}
