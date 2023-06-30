using Domain.Interfaces;

namespace Domain.Builders
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
