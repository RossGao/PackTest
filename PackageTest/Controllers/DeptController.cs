using Microsoft.AspNetCore.Mvc;
using PackageTest.BusinessLogics;
using PackageTest.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilsPack.Models;

namespace PackageTest.Controllers
{
    [Route("dept")]
    [ApiController]
    public class DeptController : ControllerBase
    {
        private DeptLogicHandler _deptLogic;

        public DeptController(DeptLogicHandler theLogicHandler)
        {
            _deptLogic = theLogicHandler;
        }

        [HttpPost]
        public IActionResult AddNewDepartment(DeptDto newDept)
        {
            if (newDept != null && newDept.Id == 0)
            {
                var added = _deptLogic.UpdateDept(newDept, OperationTypeEnum.Add);
                return Ok(DtoTransfer.ConvertDeptToDto(added));
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateDepartment(DeptDto updated)
        {
            if (updated != null && updated.Id != 0)
            {
                var result = _deptLogic.UpdateDept(updated);
                return Ok(DtoTransfer.ConvertDeptToDto(result));
            }

            return BadRequest();
        }

        [Route("change/confirmation")]
        [HttpPut]
        public IActionResult ConfirmChange(int changeId)
        {
            if (changeId != 0)
            {
                var changed = _deptLogic.ConfirmChange(changeId);

                if (changed != null)
                {
                    return Ok(changed);
                }

                return NotFound();
            }

            return BadRequest();
        }

        [Route("filter")]
        [HttpPost]
        public IActionResult GetDept(DeptDto filter, int pageIndex = 1, int pageSize = 20)
        {
            var depts = _deptLogic.GetDepts(filter, pageIndex, pageSize);

            if (depts != null && depts.Count > 0)
            {
                return Ok(depts);
            }

            return NotFound();
        }

        [Route("activity")]
        [HttpPut]
        public IActionResult ActivateDepartment(int deptId)
        {
            if (deptId != 0)
            {
                var dept = _deptLogic.ActivateDept(deptId);

                if (dept != null)
                {
                    return Ok(DtoTransfer.ConvertDeptToDto(dept));
                }

                return NotFound();
            }

            return BadRequest();
        }

        [Route("activity")]
        [HttpDelete]
        public IActionResult DeactivateDepartment(int deptId)
        {
            if (deptId != 0)
            {
                var dept = _deptLogic.DeactivateDept(deptId);

                if (dept != null)
                {
                    return Ok(DtoTransfer.ConvertDeptToDto(dept));
                }

                return NotFound();
            }

            return BadRequest();
        }

        [Route("employee")]
        [HttpDelete]
        public async Task<IActionResult> RemoveEmployeesAsync(int deptId, ICollection<string> empIds)
        {
            if (empIds != null && empIds.Count > 0)
            {
                var dept = await _deptLogic.RemoveEmployeesAsync(deptId, empIds);

                if (dept != null)
                {
                    return Ok(DtoTransfer.ConvertDeptToDto(dept));
                }

                return NotFound();
            }

            return BadRequest();
        }

        [Route("employee")]
        [HttpPut]
        public async Task<IActionResult> AddEmployeesAsync(int deptId, ICollection<string> empIds)
        {
            if (deptId != 0 && empIds != null && empIds.Count > 0)
            {
                var dept = await _deptLogic.AddEmployeesAsync(deptId, empIds);

                if (dept != null)
                {
                    return Ok(DtoTransfer.ConvertDeptToDto(dept));
                }

                return NotFound();
            }

            return BadRequest();
        }

        [Route("change")]
        [HttpDelete]
        public IActionResult DeleteChange(int changeId)
        {
            if (changeId != 0)
            {
                var change = _deptLogic.DeleteChagne(changeId);

                if (change != null)
                {
                    return Ok(DtoTransfer.ConvertChangeToDto(change));
                }

                return NotFound();
            }

            return BadRequest();
        }

        [Route("change/search")]
        [HttpPost]
        public IActionResult GetChanges(ChangeDto filter)
        {
            if (filter != null)
            {
                var changes = _deptLogic.GetChanges(filter);
                var changeDtos = new List<ChangeDto>();

                if (changes != null && changes.Count > 0)
                {
                    changes.ToList().ForEach(c =>
                    {
                        changeDtos.Add(DtoTransfer.ConvertChangeToDto(c));
                    });

                    return Ok(changes);
                }

                return NotFound();
            }

            return BadRequest();
        }
    }
}
