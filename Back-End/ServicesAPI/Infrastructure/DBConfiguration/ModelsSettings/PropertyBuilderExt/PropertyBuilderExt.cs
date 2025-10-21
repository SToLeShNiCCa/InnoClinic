using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DBConfiguration.ModelsSettings.PropertyBuilderExt
{
    public static class PropertyBuilderExt
    {
        public static PropertyBuilder<TProp> HasEnumComment<TProp>(this PropertyBuilder<TProp> self)
            where TProp : struct, Enum
        {
            var items = Enum.GetValues<TProp>().Select(e => ((int)(object)e) + " = " + e.ToString());
            return self.HasComment(string.Join(" , ", items));
        }
    }
}
