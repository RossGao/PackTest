using Microsoft.AspNetCore.Mvc;
using PackageTest.BusinessLogics;
using PackageTest.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace PackageTest.Controllers
{
    [Route("version")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private VersionLogicHandler logicHandler;

        public VersionController(VersionLogicHandler theHanlder)
        {
            logicHandler = theHanlder;
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateNewVersion(VersionInfoDto newVersion)
        {
            if (newVersion != null)
            {
                var created = logicHandler.CreateNewVersion(newVersion);
                return Ok(created);
            }

            return BadRequest();
        }

        [Route("detail")]
        [HttpPost]
        public IActionResult CreateNewDetail(VersionDetialDto newDetail)
        {
            if (newDetail != null)
            {
                var created = logicHandler.CreateNewDetail(newDetail);
                return Ok(new VersionDetialDto   // 应该写在DtoTransfer.cs中
                {
                    Applicant = created.Applicant,
                    CommitIds = created.CommitIds,
                    DetailNote = created.DetailNote,
                    Id = created.Id,
                    Iteration = created.Iteration,
                    TaskTitle = created.TaskTitle,
                    TaskType = created.Type,
                    VersionId = created.Version.Id
                });
            }

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("submit")]
        public IActionResult Submit(int id, string releaseNote)
        {
            if (id != 0)
            {
                logicHandler.Submit(id, releaseNote);
                return Ok();
            }

            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                logicHandler.DeleteVersion(id);
                return Ok();
            }

            return BadRequest();
        }

        [Route("detail")]
        [HttpPut]
        public IActionResult UpdateDetail(VersionDetialDto updated)
        {
            if (updated != null)
            {
                logicHandler.UpdateDetail(updated);
                return Ok();
            }

            return BadRequest();
        }

        [Route("detail")]
        [HttpGet]
        public IActionResult GetDetails(int versionId)
        {
            if (versionId != 0)
            {
                var details = logicHandler.GetVersionDetails(versionId);

                if (details != null && details.Count > 0)
                {
                    var detailsDto = new List<VersionDetialDto>(); // 应该写在DtoTransfer.cs中

                    details.ToList().ForEach(d =>
                    {
                        detailsDto.Add(new VersionDetialDto
                        {
                            Applicant = d.Applicant,
                            CommitIds = d.CommitIds,
                            Id = d.Id,
                            DetailNote = d.DetailNote,
                            Iteration = d.Iteration,
                            TaskTitle = d.TaskTitle,
                            TaskType = d.Type,
                            VersionId = d.Version.Id,
                        });
                    });

                    return Ok(detailsDto);
                }

                return NotFound();
            }

            return BadRequest();
        }

        [Route("detail")]
        [HttpDelete]
        public IActionResult DeleteDetails(int id)
        {
            if (id != 0)
            {
                logicHandler.DeleteDetail(id);
                return Ok();
            }

            return BadRequest();
        }
    }
}
