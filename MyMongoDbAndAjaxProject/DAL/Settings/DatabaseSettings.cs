namespace MyMongoDbAndAjaxProject.DAL.Settings
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TestimonialCollectionName { get; set; }
    }
}

