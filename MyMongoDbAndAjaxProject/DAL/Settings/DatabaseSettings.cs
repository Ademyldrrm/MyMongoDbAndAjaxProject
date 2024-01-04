namespace MyMongoDbAndAjaxProject.DAL.Settings
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string ServiceCollectionName { get; set; }
        public string SkillCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string ContactInformationCollectionName { get; set; }
        public string ExperienceCollectionName { get; set; }
        public string EdicationCollectionName { get; set; }
        public string ProjectCollectionName { get; set; }
        public string RegisterCollectionName { get; set; }
        public string StatisticCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string MessageCategoryCollectionName { get; set; }
    }
}

