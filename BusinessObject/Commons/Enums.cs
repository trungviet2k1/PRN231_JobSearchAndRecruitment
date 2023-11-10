namespace BusinessObject.Commons
{
    public class Enums
    {
        public static readonly string SESSION_KEY_JOB_SEEKER = "_JobSeeker";
    }

    public enum JobApplicationStatus
    {
        Submitted,
        UnderReview,
        Accepted,
        Rejected
    }

    public enum TimeType
    {
        FullTime,
        PartTime,
        Contract,
        Internship,
        Temporary,
        Remote
    }
}
