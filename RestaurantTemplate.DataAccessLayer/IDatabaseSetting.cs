namespace RestaurantTemplate.DataAccessLayer
{
    public interface IDatabaseSetting
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
