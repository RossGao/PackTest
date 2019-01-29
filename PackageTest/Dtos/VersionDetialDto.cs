using VersionManagement.Models;

namespace PackageTest.Dtos
{
    public class VersionDetialDto
    {
        public int Id { get; set; }

        public string TaskTitle { get; set; }

        public TaskType TaskType { get; set; }

        public string Iteration { get; set; }

        public string CommitIds { get; set; }

        public string DetailNote { get; set; }

        public string Applicant { get; set; }

        public int VersionId { get; set; }
    }
}
