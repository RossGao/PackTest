using System;
using VersionManagement.Models;

namespace PackageTest.Dtos
{
    public class VersionInfoDto
    {
        public int Id { get; set; }

        public string VersionNumber { get; set; }

        public string VersionTitle { get; set; }

        public string Creator { get; set; }

        public DateTime ReleaseDate { get; set; }

        public VersionStatus Status { get; set; }

        public string ReleaseNote { get; set; }
    }
}
