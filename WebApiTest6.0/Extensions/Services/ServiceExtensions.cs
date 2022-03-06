namespace WebApiTest6._0.Extensions.Services
{
    public static class ServiceExtensions
    {
        public static void AddThisLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

            services.ConfigureCore("_myAllowSpecificOrigins");
            services.AddSwaggerGen(c => c.CustomSchemaIds(x => x.FullName[(x.FullName.LastIndexOf('.') + 1)..].Replace('+', '.')));
        }
        private static void ConfigureCore(this IServiceCollection services, string policy)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins",
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AnyPolicy", builder => builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            });
        }
    }
}
