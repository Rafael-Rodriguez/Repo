namespace Chapter24.CustomerMaintenance.Database
{
    public class SaveChangesResult
    {
        public enum Result
        {
            Ok,
            Retry,
            Abort
        };

        public Result Value { get; set; }
    }
}
