using PackageTest.Dtos;
using System.Collections.Generic;
using VersionManagement.BusinessLogics;
using VersionManagement.Models;

namespace PackageTest.BusinessLogics
{
    public class VersionLogicHandler
    {
        private IVManager vManager;

        public VersionLogicHandler(IVManager theManager)
        {
            vManager = theManager;
        }

        public VersionInfo CreateNewVersion(VersionInfoDto newVersion)
        {
            if (newVersion != null)
            {
                return vManager.CreateNewVersion(new VersionInfo
                {
                    Creator = newVersion.Creator,
                    VersionNumber = newVersion.VersionNumber,
                    VersionTitle = newVersion.VersionTitle,
                    ReleaseDate = newVersion.ReleaseDate,
                    ReleaseNote = newVersion.ReleaseNote,
                    Status = VersionStatus.unaudited,
                });
            }

            return null;
        }

        public VersionDetail CreateNewDetail(VersionDetialDto newDetail)
        {
            if (newDetail != null)
            {
                return vManager.CreateNewDetail(new VersionDetail
                {
                    Applicant = newDetail.Applicant,
                    CommitIds = newDetail.CommitIds,
                    DetailNote = newDetail.DetailNote,
                    Iteration = newDetail.Iteration,
                    TaskTitle = newDetail.TaskTitle,
                    Type = newDetail.TaskType,
                    Version = new VersionInfo { Id = newDetail.VersionId }
                });
            }

            return null;
        }

        public void Submit(int id, string releaseNote)
        {
            if (id != 0)
            {
                vManager.Submit(id, releaseNote);
            }
        }

        public void DeleteVersion(int id)
        {
            if (id != 0)
            {
                vManager.DeleteVersion(id);
            }
        }

        public void UpdateDetail(VersionDetialDto updated)
        {
            if (updated != null)
            {
                vManager.UpdateDetail(new VersionDetail
                {
                    Id = updated.Id,
                    Applicant = updated.Applicant,
                    CommitIds = updated.CommitIds,
                    DetailNote = updated.DetailNote,
                    Iteration = updated.Iteration,
                    TaskTitle = updated.TaskTitle,
                    Type = updated.TaskType,
                    Version = new VersionInfo { Id = updated.VersionId },
                });
            }
        }

        public ICollection<VersionDetail> GetVersionDetails(int versionId)
        {
            if (versionId != 0)
            {
                return vManager.GetVersionDetails(versionId);
            }

            return null;
        }

        public void DeleteDetail(int id)
        {
            if (id != 0)
            {
                vManager.DeleteDetail(id);
            }
        }
    }
}
